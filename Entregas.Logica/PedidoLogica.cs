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
        // Crea un nuevo pedido (encabezado) validando los datos necesarios
        public static string CrearPedido(int numero, DateTime fecha, Cliente cliente, Repartidor repartidor, string direccion)
        {
            // Validar que el número de pedido sea positivo
            if (numero <= 0)
                return "El número de pedido debe ser un número positivo.";

            // Validar que la fecha no sea nula y no sea anterior a hoy
            if (fecha.Date < DateTime.Today)
                return "La fecha del pedido no puede ser anterior a hoy.";

            // Validar cliente y repartidor seleccionados
            if (cliente == null || repartidor == null)
                return "Seleccione un cliente y un repartidor para el pedido.";

            // Validar dirección no vacía
            if (string.IsNullOrWhiteSpace(direccion))
                return "La dirección de entrega es requerida.";

            // Intentar registrar el pedido
            try
            {
                Pedido nuevoPedido = new Pedido
                {
                    NumeroPedido = numero,
                    FechaPedido = fecha,
                    Cliente = cliente,
                    Repartidor = repartidor,
                    Direccion = direccion.Trim()
                };

                PedidoDatos.AgregarPedido(nuevoPedido);

                return "El encabezado del pedido se ha registrado correctamente.";
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("límite"))
                    return "No se pueden ingresar más registros, límite de pedidos alcanzado.";
                else if (ex.Message.Contains("ya existe"))
                    return "El número de pedido ya existe.";
                else
                    return "Ocurrió un error al registrar el pedido.";
            }
            catch (Exception)
            {
                return "Ocurrió un error inesperado al registrar el pedido.";
            }
        }

        // Agrega un detalle a un pedido, validando todas las reglas de negocio
        public static string AgregarDetalleAPedido(int pedidoNum, Articulo articulo, int cantidad)
        {
            // Validar que el artículo no sea nulo
            if (articulo == null)
                return "Debe seleccionar un artículo válido.";

            // Validar cantidad mayor a cero
            if (cantidad <= 0)
                return "La cantidad debe ser mayor que cero.";

            // Validar que el pedido exista
            Pedido pedido = PedidoDatos.ObtenerPedidoPorNumero(pedidoNum);
            if (pedido == null)
                return "El pedido no existe.";

            // Verificar si el artículo ya fue agregado a este pedido
            DetallePedido[] detallesExistentes = DetallePedidoDatos.ObtenerDetallesPorPedido(pedidoNum);
            foreach (var det in detallesExistentes)
            {
                if (det != null && det.Articulo != null && det.Articulo.Id == articulo.Id)
                    return "Ese artículo ya está agregado en el pedido. No se puede duplicar.";
            }

            // Verificar inventario disponible
            if (cantidad > articulo.Inventario)
                return $"Cantidad excede el inventario disponible (máx {articulo.Inventario})";

            // Calcular el monto (incluye 12% de envío)
            double monto = articulo.Valor * cantidad * 1.12;

            // Intentar agregar el detalle
            try
            {
                DetallePedido detalle = new DetallePedido
                {
                    NumeroPedido = pedidoNum,
                    Articulo = articulo,
                    Cantidad = cantidad,
                    Monto = monto
                };

                DetallePedidoDatos.AgregarDetalle(detalle);

                // Actualizar inventario del artículo
                articulo.Inventario -= cantidad;
                if (articulo.Inventario == 0)
                {
                    articulo.Activo = false;
                    // (Opcional) Retornar un warning si quieres informar a la UI
                }

                return "El detalle del pedido se ha agregado correctamente.";
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("límite"))
                    return "No se pueden ingresar más detalles, límite alcanzado.";
                else
                    return "Ocurrió un error al agregar el detalle al pedido.";
            }
            catch (Exception)
            {
                return "Ocurrió un error inesperado al agregar el detalle al pedido.";
            }
        }

        // Obtiene todos los pedidos registrados
        public static Pedido[] ObtenerTodosLosPedidos()
        {
            return PedidoDatos.ObtenerTodosLosPedidos();
        }

        // Obtiene los detalles asociados a un pedido específico
        public static DetallePedido[] ObtenerDetallesPorPedido(int pedidoNum)
        {
            return DetallePedidoDatos.ObtenerDetallesPorPedido(pedidoNum);
        }
    }
}
