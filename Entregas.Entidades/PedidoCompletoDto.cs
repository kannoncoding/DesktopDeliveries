using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class PedidoCompletoDto
    {
        public PedidoEncabezadoDto Encabezado { get; set; } = new();
        public List<PedidoDetalleDto> Detalles { get; set; } = new();

        // ---------- Cálculos ----------

        public double CalcularTotal()
            => Detalles?.Sum(d => d?.Monto ?? 0.0) ?? 0.0;

        public void ActualizarTotalEnEncabezado()
            => Encabezado.Total = CalcularTotal();

        // ---------- Validaciones ----------

        public void Validar()
        {
            if (Encabezado == null) throw new ArgumentException("El encabezado del pedido es obligatorio.");
            Encabezado.ValidarBasico();

            if (Detalles == null || Detalles.Count == 0)
                throw new ArgumentException("El pedido debe contener al menos un detalle.");

            foreach (var d in Detalles)
            {
                if (d == null) throw new ArgumentException("El detalle no puede ser nulo.");
                d.ValidarBasico();
            }
        }

        // ---------- Helpers de manipulación ----------

        public void AgregarDetalle(PedidoDetalleDto detalle, bool actualizarTotal = true)
        {
            if (detalle == null) throw new ArgumentNullException(nameof(detalle));
            detalle.ValidarBasico();
            Detalles.Add(detalle);

            if (actualizarTotal) ActualizarTotalEnEncabezado();
        }

        public bool QuitarDetallePorArticulo(int articuloId, bool actualizarTotal = true)
        {
            var idx = Detalles.FindIndex(d => d != null && d.ArticuloId == articuloId);
            if (idx < 0) return false;

            Detalles.RemoveAt(idx);
            if (actualizarTotal) ActualizarTotalEnEncabezado();
            return true;
        }

        public void LimpiarDetalles(bool actualizarTotal = true)
        {
            Detalles.Clear();
            if (actualizarTotal) ActualizarTotalEnEncabezado();
        }

        // ---------- Fábricas desde entidades ----------

        public static PedidoCompletoDto FromEntidades(Pedido p, IEnumerable<DetallePedido?> detalles)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (detalles == null) throw new ArgumentNullException(nameof(detalles));

            var listaDet = PedidoDetalleDto.FromEntidades(detalles);
            var enc = PedidoEncabezadoDto.FromEntidad(p, listaDet.Select(d => new DetallePedido
            {
                // Nota: solo usamos Monto y Cantidad para total; los demás campos no son necesarios aquí.
                Cantidad = d.Cantidad,
                Monto = d.Monto,
                Articulo = new Articulo { Id = d.ArticuloId, Nombre = d.ArticuloNombre, TipoArticulo = new TipoArticulo { Nombre = d.TipoNombre } }
            }));

            return new PedidoCompletoDto
            {
                Encabezado = enc,
                Detalles = listaDet
            };
        }

        public static bool TryFromEntidades(Pedido? p, IEnumerable<DetallePedido?>? detalles, out PedidoCompletoDto? dto)
        {
            dto = null;
            if (p == null || detalles == null) return false;

            try
            {
                dto = FromEntidades(p, detalles);
                return true;
            }
            catch
            {
                dto = null;
                return false;
            }
        }

        // ---------- Representación ----------

        public override string ToString()
            => $"Pedido #{Encabezado?.PedidoId} | {Detalles?.Count ?? 0} items | Total CRC {CalcularTotal():N2}";
    }
}
