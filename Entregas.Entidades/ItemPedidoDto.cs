using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entregas.Entidades
{
    public class ItemPedidoDto
    {
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }

        // Validaciones
        public void Validar()
        {
            if (ArticuloId <= 0) throw new ArgumentException("El Id del artículo debe ser mayor a cero.");
            if (Cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
        }

        public bool TryValidar(out string? mensaje)
        {
            mensaje = null;
            if (ArticuloId <= 0) { mensaje = "El Id del artículo debe ser mayor a cero."; return false; }
            if (Cantidad <= 0) { mensaje = "La cantidad debe ser mayor a cero."; return false; }
            return true;
        }

        // Helpers
        public static ItemPedidoDto Crear(int articuloId, int cantidad)
        {
            var it = new ItemPedidoDto { ArticuloId = articuloId, Cantidad = cantidad };
            it.Validar();
            return it;
        }

        public void AcumularCantidad(int delta)
        {
            if (delta <= 0) throw new ArgumentException("El incremento debe ser mayor a cero.");
            Cantidad += delta;
        }

        public void AjustarCantidad(int nuevaCantidad)
        {
            if (nuevaCantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
            Cantidad = nuevaCantidad;
        }

        public bool EsMismaLlave(ItemPedidoDto? otro) => otro != null && ArticuloId == otro.ArticuloId;

        public ItemPedidoDto Clonar() => new ItemPedidoDto { ArticuloId = ArticuloId, Cantidad = Cantidad };

        public override string ToString() => $"{ArticuloId}x{Cantidad}";
        public override bool Equals(object? obj) => obj is ItemPedidoDto o && ArticuloId == o.ArticuloId && Cantidad == o.Cantidad;
        public override int GetHashCode() => HashCode.Combine(ArticuloId, Cantidad);
    }
}
