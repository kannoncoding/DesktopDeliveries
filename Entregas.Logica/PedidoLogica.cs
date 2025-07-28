// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Lógica de negocio para Pedidos y sus detalles en ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;
using Entregas.Datos;

namespace Entregas.Logica
{
    public static class PedidoLogica
    {
        // Registrar un nuevo pedido (encabezado)
        public static string RegistrarPedido(int numero, DateTime fecha, Cliente cliente, Repartidor repartidor, string direccion)
        {
            if (numero <= 0)
                return "El número de pedido debe ser un número positivo.";

            if (fecha.Date < DateTime.Today)
                return "La fecha del pedido no puede ser anterior a hoy.";

            if (cliente == null)
                return "Debe seleccionar un cliente.";

            if (repartidor == null)
                return "Debe seleccionar un repartidor.";

            if (string.IsNullOrWhiteSpace(direccion))
                return "La dirección de entrega es requerida.";

            // Validar unicidad del número de pedido
            var existente = PedidoDatos.ObtenerPedidoPorNumero(numero);
            if (existente != null)
                return "Ya existe un pedido con ese número.";

            // Validar existencia de cliente y repartidor en BD
            var clienteBD = ClienteDatos.ObtenerPorId(cliente.Identificacion);
            if (clienteBD == null)
                return "El cliente seleccionado no existe en la base de datos.";

            var repartidorBD = RepartidorDatos.ObtenerPorId(repartidor.Identificacion);
            if (repartidorBD == null)
                return "El repartidor seleccionado no existe en la base de datos.";

            // Registrar pedido
            try
            {
                Pedido nuevoPedido = new Pedido
                {
                    NumeroPedido = numero,
                    FechaPedido = fecha,
                    Cliente = clienteBD,
                    Repartidor = repartidorBD,
                    Direccion = direccion.Trim()
                };

                PedidoDatos.AgregarPedido(nuevoPedido);

                return "El encabezado del pedido se ha registrado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al registrar el pedido: {ex.Message}";
            }
        }

        // Agrega un detalle a un pedido, validando todas las reglas de negocio
        public static string AgregarDetalleAPedido(int pedidoNum, Articulo articulo, int cantidad)
        {
            if (articulo == null)
                return "Debe seleccionar un artículo válido.";

            if (cantidad <= 0)
                return "La cantidad debe ser mayor que cero.";

            // Validar que el pedido exista en BD
            var pedido = PedidoDatos.ObtenerPedidoPorNumero(pedidoNum);
            if (pedido == null)
                return "El pedido no existe.";

            // Verificar si el artículo ya fue agregado a este pedido
            var detallesExistentes = DetallePedidoDatos.ObtenerDetallesPorPedido(pedidoNum);
            foreach (var det in detallesExistentes)
            {
                if (det != null && det.Articulo != null && det.Articulo.Id == articulo.Id)
                    return "Ese artículo ya está agregado en el pedido. No se puede duplicar.";
            }

            // Verificar inventario disponible en BD
            var articuloBD = ArticuloDatos.ObtenerPorId(articulo.Id);
            if (articuloBD == null)
                return "El artículo seleccionado no existe en la base de datos.";

            if (cantidad > articuloBD.Inventario)
                return $"Cantidad excede el inventario disponible (máx {articuloBD.Inventario})";

            // Calcular el monto (incluye 12% de envío)
            double monto = articuloBD.Valor * cantidad * 1.12;

            try
            {
                DetallePedido detalle = new DetallePedido
                {
                    NumeroPedido = pedidoNum,
                    Articulo = articuloBD,
                    Cantidad = cantidad,
                    Monto = monto
                };

                DetallePedidoDatos.AgregarDetalle(detalle);

                // Actualizar inventario y estado del artículo en la BD
                articuloBD.Inventario -= cantidad;
                if (articuloBD.Inventario < 0) articuloBD.Inventario = 0;
                if (articuloBD.Inventario == 0)
                    articuloBD.Activo = false;

                ArticuloDatos.ActualizarInventarioYEstado(articuloBD.Id, articuloBD.Inventario, articuloBD.Activo);

                return "El detalle del pedido se ha agregado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al agregar el detalle al pedido: {ex.Message}";
            }
        }

        // Obtener todos los pedidos registrados
        public static List<Pedido> ObtenerTodosLosPedidos()
        {
            try
            {
                return PedidoDatos.ObtenerTodosLosPedidos();
            }
            catch
            {
                return new List<Pedido>();
            }
        }

        // Obtener los detalles asociados a un pedido específico
        public static List<DetallePedido> ObtenerDetallesPorPedido(int pedidoNum)
        {
            try
            {
                return DetallePedidoDatos.ObtenerDetallesPorPedido(pedidoNum);
            }
            catch
            {
                return new List<DetallePedido>();
            }
        }
    }
}
