// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo de pedidos (órdenes) para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class PedidoDatos
    {
        // Arreglo estático para almacenar hasta 40 pedidos
        private static Pedido[] pedidos = new Pedido[40];
        private static int pedidoCount = 0;

        // Agrega un nuevo pedido al arreglo, validando capacidad y unicidad de número de pedido.
        public static void AgregarPedido(Pedido pedido)
        {
            if (pedidoCount >= pedidos.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            for (int i = 0; i < pedidoCount; i++)
            {
                if (pedidos[i] != null && pedidos[i].NumeroPedido == pedido.NumeroPedido)
                    throw new InvalidOperationException("El número de pedido ya existe");
            }

            pedidos[pedidoCount] = pedido;
            pedidoCount++;
        }

        // Devuelve todos los pedidos actualmente almacenados.
        public static Pedido[] ObtenerTodosLosPedidos()
        {
            Pedido[] copia = new Pedido[pedidoCount];
            Array.Copy(pedidos, copia, pedidoCount);
            return copia;
        }

        // Busca un pedido por su número de pedido.
        public static Pedido? ObtenerPedidoPorNumero(int numeroPedido)
        {
            for (int i = 0; i < pedidoCount; i++)
            {
                if (pedidos[i] != null && pedidos[i].NumeroPedido == numeroPedido)
                    return pedidos[i];
            }
            return null;
        }

        // Devuelve la cantidad actual de pedidos almacenados.
        public static int ObtenerCantidad()
        {
            return pedidoCount;
        }
    }
}
