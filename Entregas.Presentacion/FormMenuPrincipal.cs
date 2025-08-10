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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entregas.Presentacion
{
    public partial class FormMenuPrincipal : Form
    {

        private TcpListener listener;
        private int clientesConectados = 0;
        private const int puerto = 14100;
        private const int maxClientes = 5;
        private bool escuchando = false;

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

                Thread hiloListener = new Thread(() =>
                {
                    EscribirBitacora("Servidor escuchando en 127.0.0.1:" + puerto);
                    while (escuchando)
                    {
                        if (listener.Pending())
                        {
                            if (clientesConectados < maxClientes)
                            {
                                TcpClient cliente = listener.AcceptTcpClient();
                                Interlocked.Increment(ref clientesConectados);
                                ActualizarContador();

                                ThreadPool.QueueUserWorkItem(ManejarCliente, cliente);
                            }
                        }
                        Thread.Sleep(100); // evitar consumo excesivo de CPU
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

        private void ManejarCliente(object obj)
        {
            TcpClient cliente = (TcpClient)obj;
            string clienteIP = cliente.Client.RemoteEndPoint?.ToString() ?? "Cliente desconocido";
            EscribirBitacora($"Cliente conectado: {clienteIP}");

            try
            {
                NetworkStream stream = cliente.GetStream();
                byte[] buffer = new byte[1024];
                int bytesLeidos;

                while ((bytesLeidos = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    EscribirBitacora($"Mensaje recibido: {mensaje}");

                    // (Aquí luego llamarás a lógica según el mensaje recibido)
                    string respuesta = "Recibido";
                    byte[] respuestaBytes = Encoding.UTF8.GetBytes(respuesta);
                    stream.Write(respuestaBytes, 0, respuestaBytes.Length);
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
