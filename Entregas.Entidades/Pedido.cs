// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Representa el encabezado de un pedido registrado en ENTREGAS S.A. Incluye número de pedido, fecha, cliente asociado, repartidor asignado y dirección de entrega.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class Pedido
    {
        // Número único de pedido
        public required int NumeroPedido { get; set; }

        // Fecha del pedido (debe ser igual o posterior a la fecha actual; validación en lógica)
        public required DateTime FechaPedido { get; set; }

        public int ClienteId { get; set; } // Id de relación para BD
        public int RepartidorId { get; set; } // Id de relación para BD

        // Referencia al cliente que realiza el pedido
        public required Cliente Cliente { get; set; }

        // Referencia al repartidor asignado para el pedido
        public required Repartidor Repartidor { get; set; }

        // Dirección de entrega del pedido
        public required string Direccion { get; set; }

        // Constructor vacío
        public Pedido() { }

        // Constructor
        public Pedido(int numeroPedido, DateTime fechaPedido, Cliente cliente, Repartidor repartidor, string direccion)
        {
            NumeroPedido = numeroPedido;
            FechaPedido = fechaPedido;
            Cliente = cliente;
            Repartidor = repartidor;
            Direccion = direccion;
        }
    }
}
