using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class PedidoDetalleDto
    {
        public int ArticuloId { get; set; }
        public string ArticuloNombre { get; set; } = string.Empty;
        public string TipoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public double Monto { get; set; }   // Total de la línea (incluye recargo de envío según tu lógica)

        // ---------- Validaciones ----------

        public void ValidarBasico()
        {
            if (ArticuloId <= 0) throw new ArgumentException("El Id del artículo debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(ArticuloNombre)) throw new ArgumentException("El nombre del artículo es obligatorio.");
            if (Cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (Monto < 0) throw new ArgumentException("El monto no puede ser negativo.");
        }

        // ---------- Cálculos ----------

        public static double CalcularMonto(double valorUnitario, int cantidad, double porcentajeEnvio = 0.12)
        {
            if (valorUnitario < 0) throw new ArgumentException("El valor unitario no puede ser negativo.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (porcentajeEnvio < 0) throw new ArgumentException("El porcentaje de envío no puede ser negativo.");

            var subtotal = valorUnitario * cantidad;
            return subtotal * (1.0 + porcentajeEnvio);
        }

        // ---------- Fábricas desde entidades ----------

        public static PedidoDetalleDto FromEntidad(DetallePedido d)
        {
            if (d == null) throw new ArgumentNullException(nameof(d));

            var art = d.Articulo; // ¡No crear uno nuevo! Evitamos 'required' sin inicializar.

            return new PedidoDetalleDto
            {
                ArticuloId = art?.Id ?? 0,
                ArticuloNombre = art?.Nombre ?? string.Empty,
                TipoNombre = art?.TipoArticulo?.Nombre ?? string.Empty,
                Cantidad = d.Cantidad,
                Monto = d.Monto
            };
        }

        public static bool TryFromEntidad(DetallePedido? d, out PedidoDetalleDto? dto)
        {
            dto = null;
            if (d == null) return false;

            try
            {
                dto = FromEntidad(d);
                return true;
            }
            catch
            {
                dto = null;
                return false;
            }
        }

        public static List<PedidoDetalleDto> FromEntidades(IEnumerable<DetallePedido?> detalles)
        {
            if (detalles == null) throw new ArgumentNullException(nameof(detalles));

            return detalles
                .Where(x => x != null)
                .Select(x => FromEntidad(x!))
                .ToList();
        }

        // ---------- Representación ----------

        public override string ToString()
            => $"{ArticuloId} - {ArticuloNombre} ({TipoNombre}) x{Cantidad} | CRC {Monto:N2}";
    }
}