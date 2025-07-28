// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Descripción del archivo: Representa el detalle (línea) de un pedido registrado en ENTREGAS S.A. Incluye el número de pedido, el artículo solicitado, la cantidad y el monto total de la línea.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{

    public class DetallePedido
    {
        // Número de pedido al que pertenece este detalle (llave foránea)
        public required int NumeroPedido { get; set; }

        public int ArticuloId { get; set; } // Id de relación para BD

        // Referencia al artículo solicitado (debe ser seleccionado del arreglo de artículos)
        public required Articulo Articulo { get; set; }

        // Cantidad de unidades solicitadas de ese artículo
        public required int Cantidad { get; set; }

        // Monto total de esta línea: Valor * Cantidad * 1.12 (el cálculo es responsabilidad de la lógica)
        public required double Monto { get; set; }

        // Constructor vacío
        public DetallePedido() { }

        // Constructor
        public DetallePedido(int numeroPedido, Articulo articulo, int cantidad, double monto)
        {
            NumeroPedido = numeroPedido;
            Articulo = articulo;
            Cantidad = cantidad;
            Monto = monto;
        }
    }
}
