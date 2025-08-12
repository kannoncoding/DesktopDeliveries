// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Entregas.Entidades;
using Entregas.Datos;
using Entregas.Logica;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Entregas.Presentacion
{
    public partial class FormMenuPrincipal : Form
    {

        private TcpListener? listener;
        private int clientesConectados = 0;
        private const int puerto = 14100;
        private const int maxClientes = 5;
        private volatile bool escuchando = false;

        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        // Registrar
        private void registrarTipoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarTipoArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarCliente())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarRepartidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarRepartidor())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarPedido())
            {
                frm.ShowDialog(this);
            }
        }

        // Consultar
        private void consultarTipoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarTipoArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarCliente())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarRepartidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarRepartidor())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarPedido())
            {
                frm.ShowDialog(this);
            }
        }

        private void IniciarServidorTCP()
        {
            try
            {
                listener = new TcpListener(IPAddress.Loopback, puerto);
                listener.Start();
                escuchando = true;

                var hiloListener = new Thread(() =>
                {
                    EscribirBitacora("Servidor escuchando en 127.0.0.1:" + puerto);

                    while (escuchando)
                    {
                        try
                        {
                            if (listener != null && listener.Pending())
                            {
                                var cliente = listener.AcceptTcpClient();

                                if (Interlocked.CompareExchange(ref clientesConectados, 0, 0) < maxClientes)
                                {
                                    Interlocked.Increment(ref clientesConectados);
                                    ActualizarContador();

                                    // espera object?  -> método recibe object?
                                    ThreadPool.QueueUserWorkItem(ManejarCliente, cliente);
                                }
                                else
                                {
                                    // Rechazar la conexión
                                    using var s = cliente.GetStream();
                                    using var w = new StreamWriter(s, new UTF8Encoding(false)) { AutoFlush = true };
                                    var res = JsonMensajeria.Fail("Servidor ocupado, intente nuevamente.");
                                    w.Write(JsonMensajeria.SerializarRespuestaLinea(res));
                                    cliente.Close();
                                    EscribirBitacora("Conexión rechazada (máximo de clientes).");
                                }
                            }

                            Thread.Sleep(50);
                        }
                        catch (Exception exLoop)
                        {
                            EscribirBitacora("Error en loop del listener: " + exLoop.Message);
                        }
                    }
                });

                hiloListener.IsBackground = true;
                hiloListener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el servidor TCP: " + ex.Message);
            }
        }


        private async void ManejarCliente(object? obj)
        {
            var cliente = (TcpClient?)obj;
            if (cliente == null) return;

            string clienteIP = cliente.Client.RemoteEndPoint?.ToString() ?? "Cliente desconocido";
            EscribirBitacora($"Cliente conectado: {clienteIP}");



            try
            {
                using var stream = cliente.GetStream();
                using var reader = new StreamReader(stream, new UTF8Encoding(false), detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);
                using var writer = new StreamWriter(stream, new UTF8Encoding(false), bufferSize: 1024, leaveOpen: true) { AutoFlush = true };

                string? linea;
                while ((linea = await reader.ReadLineAsync()) != null)   // mensajes terminados en \n
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    MensajeSolicitud req;
                    try
                    {
                        req = JsonMensajeria.DeserializarSolicitud(linea);
                    }
                    catch (Exception exJson)
                    {
                        EscribirBitacora($"JSON inválido: {exJson.Message}");
                        var err = MensajeRespuesta.Fail("JSON inválido");
                        await writer.WriteAsync(JsonMensajeria.SerializarRespuestaLinea(err));
                        continue;
                    }

                    EscribirBitacora($"Comando recibido: {req.Comando}");

                    MensajeRespuesta res;

                    try
                    {
                        res = MensajeRespuesta.Fail("Comando no soportado", req.CorrelationId);


                        switch (req.Comando?.ToLowerInvariant())
                        {
                            case "ping":
                                res = MensajeRespuesta.Ok(new { message = "pong" }, req.CorrelationId);
                                break;

                            // ----------------------------------------------
                            // VALIDAR CLIENTE (cliente se loguea en el cliente)
                            // req.Datos: { "id": 123 }
                            // res.Datos: ClienteDto
                            // ----------------------------------------------
                            case "validar_cliente":
                                {
                                    if (!req.TryGetDato<int>("id", out var id))
                                        throw new InvalidOperationException("Faltan datos: { id }");

                                    var cliEnt = ClienteDatos.ObtenerPorId(id);
                                    if (cliEnt == null || !cliEnt.Activo)
                                    {
                                        res = MensajeRespuesta.Fail("Cliente no existe o está inactivo.", req.CorrelationId);
                                        break;
                                    }

                                    res = MensajeRespuesta.Ok(ClienteDto.FromEntidad(cliEnt), req.CorrelationId);
                                    EscribirBitacora($"[Validación] Cliente OK: {cliEnt.Identificacion} - {cliEnt.Nombre} {cliEnt.PrimerApellido}");
                                    break;
                                }


                            // ----------------------------------------------
                            // LISTAR ARTÍCULOS ACTIVOS (ya lo tenías; dejo versión DTO)
                            // res.Datos: List<ArticuloDto>
                            // ----------------------------------------------
                            case "listar_articulos_activos":
                                {
                                    var lista = ArticuloDatos.ObtenerTodos()
                                        .Where(a => a != null && a.Activo)
                                        .Select(a => ArticuloDto.FromEntidad(a!))
                                        .ToList();

                                    res = MensajeRespuesta.Ok(lista, req.CorrelationId);
                                    EscribirBitacora($"[Consulta] listar_articulos_activos -> {lista.Count} ítems");
                                    break;
                                }

                            // ----------------------------------------------
                            // OBTENER ARTÍCULO POR ID (ya lo tenías; dejo versión DTO)
                            // req.Datos: { "id": 200 }
                            // res.Datos: ArticuloDto
                            // ----------------------------------------------
                            case "obtener_articulo_por_id":
                                {
                                    if (!req.TryGetDato<int>("id", out var id))
                                        throw new InvalidOperationException("Faltan datos: { id }");

                                    var art = ArticuloDatos.ObtenerPorId(id);
                                    if (art == null)
                                    {
                                        res = MensajeRespuesta.Fail("No existe el artículo", req.CorrelationId);
                                        break;
                                    }

                                    res = MensajeRespuesta.Ok(ArticuloDto.FromEntidad(art), req.CorrelationId);
                                    EscribirBitacora($"[Consulta] obtener_articulo_por_id -> {id}");
                                    break;
                                }

                            // ----------------------------------------------
                            // REGISTRAR PEDIDO (encabezado + detalles)
                            // req.Datos: PedidoSolicitudDto (con NumeroPedido, FechaPedido,
                            //            ClienteId, RepartidorId, Direccion, Items[])
                            // res.Datos: PedidoCompletoDto
                            // ----------------------------------------------
                            case "registrar_pedido":
                                {
                                    var sol = req.GetDatos<PedidoSolicitudDto>();
                                    sol.ValidarTodo(); // <<-- este es el correcto

                                    // Entidades base
                                    var cliEnt = ClienteDatos.ObtenerPorId(sol.ClienteId)
                                               ?? throw new InvalidOperationException("Cliente no existe.");
                                    var repEnt = RepartidorDatos.ObtenerPorId(sol.RepartidorId)
                                               ?? throw new InvalidOperationException("Repartidor no existe.");

                                    // 1) Encabezado
                                    var msgEnc = PedidoLogica.RegistrarPedido(
                                        sol.NumeroPedido,
                                        sol.FechaPedido,
                                        cliEnt,
                                        repEnt,
                                        sol.Direccion ?? string.Empty
                                    );

                                    if (!msgEnc.Contains("correctamente", StringComparison.OrdinalIgnoreCase))
                                    {
                                        res = MensajeRespuesta.Fail(msgEnc, req.CorrelationId);
                                        break;
                                    }

                                    // 2) Detalles
                                    foreach (var it in sol.Items)
                                    {
                                        it.Validar();

                                        var art = ArticuloDatos.ObtenerPorId(it.ArticuloId);
                                        if (art == null)
                                        {
                                            res = MensajeRespuesta.Fail($"Artículo {it.ArticuloId} no existe.", req.CorrelationId);
                                            break;
                                        }

                                        var msgDet = PedidoLogica.AgregarDetalleAPedido(sol.NumeroPedido, art, it.Cantidad);
                                        if (!msgDet.Contains("correctamente", StringComparison.OrdinalIgnoreCase))
                                        {
                                            res = MensajeRespuesta.Fail(msgDet, req.CorrelationId);
                                            break;
                                        }
                                    }
                                    if (!res.Exito) break; // si falló algún detalle

                                    // 3) Construir DTO de salida
                                    var dets = PedidoLogica.ObtenerDetallesPorPedido(sol.NumeroPedido);
                                    var detsDto = dets.Select(PedidoDetalleDto.FromEntidad).ToList();
                                    var total = detsDto.Sum(d => d.Monto);

                                    var encDto = new PedidoEncabezadoDto
                                    {
                                        PedidoId = sol.NumeroPedido,
                                        FechaPedido = sol.FechaPedido,
                                        Direccion = sol.Direccion ?? string.Empty,
                                        ClienteId = cliEnt.Identificacion,
                                        ClienteNombre = $"{cliEnt.Nombre} {cliEnt.PrimerApellido} {cliEnt.SegundoApellido}".Trim(),
                                        RepartidorId = repEnt.Identificacion,
                                        RepartidorNombre = $"{repEnt.Nombre} {repEnt.PrimerApellido} {repEnt.SegundoApellido}".Trim(),
                                        Total = total
                                    };

                                    var salida = new PedidoCompletoDto { Encabezado = encDto, Detalles = detsDto };

                                    res = MensajeRespuesta.Ok(salida, req.CorrelationId);
                                    EscribirBitacora($"[Registro] Pedido #{sol.NumeroPedido} de cliente {cliEnt.Identificacion} con {detsDto.Count} detalle(s).");
                                    break;
                                }

                            // ----------------------------------------------
                            // CONSULTAR PEDIDOS DE UN CLIENTE
                            // req.Datos: { "clienteId": 123 }
                            // res.Datos: List<PedidoCompletoDto>
                            // ----------------------------------------------
                            case "consultar_pedidos_cliente":
                                {
                                    if (!req.TryGetDato<int>("clienteId", out var clienteId))
                                        throw new InvalidOperationException("Faltan datos: { clienteId }");

                                    var pedidos = PedidoLogica.ObtenerTodosLosPedidos()
                                        .Where(p => p != null && p.Cliente?.Identificacion == clienteId)
                                        .ToList();

                                    var listaEnc = new List<PedidoEncabezadoDto>();
                                    foreach (var p in pedidos!)
                                    {
                                        var dets = PedidoLogica.ObtenerDetallesPorPedido(p.NumeroPedido);
                                        listaEnc.Add(PedidoEncabezadoDto.FromEntidad(p, dets));
                                    }

                                    res = MensajeRespuesta.Ok(listaEnc, req.CorrelationId);
                                    EscribirBitacora($"[Consulta] pedidos de cliente {clienteId} -> {listaEnc.Count}");
                                    break;
                                }

                            // ----------------------------------------------
                            // CONSULTAR UN PEDIDO ESPECÍFICO POR NÚMERO
                            // req.Datos: { "numero": 5001 }
                            // res.Datos: PedidoCompletoDto
                            // ----------------------------------------------
                            case "consultar_pedido_por_numero":
                                {
                                    if (!req.TryGetDato<int>("numero", out var numero))
                                        throw new InvalidOperationException("Faltan datos: { numero }");

                                    var ped = PedidoLogica.ObtenerTodosLosPedidos()
                                              .FirstOrDefault(p => p != null && p.NumeroPedido == numero);

                                    if (ped == null)
                                    {
                                        res = MensajeRespuesta.Fail("No existe el pedido.", req.CorrelationId);
                                        break;
                                    }

                                    var dets = PedidoLogica.ObtenerDetallesPorPedido(numero);
                                    var dto = PedidoCompletoDto.FromEntidades(ped, dets);

                                    res = MensajeRespuesta.Ok(dto, req.CorrelationId);
                                    EscribirBitacora($"[Consulta] pedido #{numero} -> {dto.Detalles.Count} detalle(s)");
                                    break;
                                }



                            default:
                                res = MensajeRespuesta.Fail("Comando no soportado", req.CorrelationId);
                                break;
                        }
                    }
                    catch (Exception exCmd)
                    {
                        res = MensajeRespuesta.Fail(exCmd.Message, req.CorrelationId);
                    }

                    await writer.WriteAsync(JsonMensajeria.SerializarRespuestaLinea(res));
                }
            }
            catch (Exception ex)
            {
                EscribirBitacora($"Error con cliente: {ex.Message}");
            }
            finally
            {
                cliente.Close();
                Interlocked.Decrement(ref clientesConectados);
                ActualizarContador();
                EscribirBitacora($"Cliente desconectado: {clienteIP}");
            }
        }


        private void EscribirBitacora(string mensaje)
        {
            if (txtBitacora.InvokeRequired)
            {
                txtBitacora.Invoke(new Action(() => EscribirBitacora(mensaje)));
            }
            else
            {
                txtBitacora.AppendText($"[{DateTime.Now:HH:mm:ss}] {mensaje}\r\n");
            }
        }

        private void ActualizarContador()
        {
            if (lblClientesConectados.InvokeRequired)
            {
                lblClientesConectados.Invoke(new Action(ActualizarContador));
            }
            else
            {
                lblClientesConectados.Text = $"Clientes conectados: {clientesConectados}";
            }
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            IniciarServidorTCP();
        }
    }
}
