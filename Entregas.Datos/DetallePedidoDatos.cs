// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo para los detalles de pedido (líneas de pedido) en ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class DetallePedidoDatos
    {
        // Arreglo estático para almacenar hasta 500 detalles de pedido
        private static DetallePedido[] detalles = new DetallePedido[500];
        private static int detalleCount = 0;

        // Agrega un nuevo detalle de pedido al arreglo, validando capacidad.

        public static void AgregarDetalle(DetallePedido detalle)
        {
            if (detalleCount >= detalles.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            detalles[detalleCount] = detalle;
            detalleCount++;
        }

        // Devuelve todos los detalles para un pedido específico.
        public static DetallePedido[] ObtenerDetallesPorPedido(int numeroPedido)
        {
            // Primero contar cuántos detalles existen para el pedido
            int cantidad = 0;
            for (int i = 0; i < detalleCount; i++)
            {
                if (detalles[i] != null && detalles[i].NumeroPedido == numeroPedido)
                    cantidad++;
            }

            // Crear el arreglo de retorno
            DetallePedido[] resultado = new DetallePedido[cantidad];
            int idx = 0;
            for (int i = 0; i < detalleCount; i++)
            {
                if (detalles[i] != null && detalles[i].NumeroPedido == numeroPedido)
                {
                    resultado[idx] = detalles[i];
                    idx++;
                }
            }

            return resultado;
        }

        // Devuelve la cantidad actual de detalles almacenados.
        public static int ObtenerCantidad()
        {
            return detalleCount;
        }

    }
}
