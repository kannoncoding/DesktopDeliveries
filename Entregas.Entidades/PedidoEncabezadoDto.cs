using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class PedidoEncabezadoDto
    {
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Direccion { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;

        public int RepartidorId { get; set; }
        public string RepartidorNombre { get; set; } = string.Empty;

        public double Total { get; set; }

        // ---------- Validaciones ----------

        public void ValidarBasico()
        {
            if (PedidoId <= 0) throw new ArgumentException("El número de pedido debe ser mayor a cero.");
            if (FechaPedido.Date < DateTime.MinValue.Date) throw new ArgumentException("Fecha de pedido inválida.");
            if (string.IsNullOrWhiteSpace(Direccion)) throw new ArgumentException("La dirección es obligatoria.");
            if (ClienteId <= 0) throw new ArgumentException("El Id del cliente debe ser mayor a cero.");
            if (RepartidorId <= 0) throw new ArgumentException("El Id del repartidor debe ser mayor a cero.");
            if (Total < 0) throw new ArgumentException("El total no puede ser negativo.");
        }

        public override string ToString()
            => $"#{PedidoId} {FechaPedido:yyyy-MM-dd} | Cliente: {ClienteNombre} ({ClienteId}) | Rep: {RepartidorNombre} ({RepartidorId}) | {Direccion} | Total CRC {Total:N2}";

        // ---------- Fábricas / Conversión desde entidades ----------

        public static PedidoEncabezadoDto FromEntidad(Pedido p, double total = 0.0)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            var dto = new PedidoEncabezadoDto
            {
                PedidoId = p.NumeroPedido,
                FechaPedido = p.FechaPedido,
                Direccion = p.Direccion ?? string.Empty,
                ClienteId = p.Cliente?.Identificacion ?? 0,
                ClienteNombre = ClienteNombreDe(p.Cliente),
                RepartidorId = p.Repartidor?.Identificacion ?? 0,
                RepartidorNombre = RepartidorNombreDe(p.Repartidor),
                Total = total
            };

            return dto;
        }

        // Calcula el total a partir de una colección de DetallePedido (si se suministra).
        public static PedidoEncabezadoDto FromEntidad(Pedido p, IEnumerable<DetallePedido?> detalles)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (detalles == null) throw new ArgumentNullException(nameof(detalles));

            double total = detalles.Where(d => d != null).Sum(d => d!.Monto);
            return FromEntidad(p, total);
        }

        public static bool TryFromEntidad(Pedido? p, IEnumerable<DetallePedido?>? detalles, out PedidoEncabezadoDto? dto)
        {
            dto = null;
            if (p == null) return false;

            try
            {
                dto = detalles == null ? FromEntidad(p) : FromEntidad(p, detalles);
                return true;
            }
            catch
            {
                dto = null;
                return false;
            }
        }

        // ---------- Helpers de nombres ----------

        private static string ClienteNombreDe(Cliente? c)
        {
            if (c == null) return string.Empty;
            var partes = new[] { c.Nombre, c.PrimerApellido, c.SegundoApellido }
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s!.Trim());
            return string.Join(" ", partes);
        }

        private static string RepartidorNombreDe(Repartidor? r)
        {
            if (r == null) return string.Empty;
            var partes = new[] { r.Nombre, r.PrimerApellido, r.SegundoApellido }
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s!.Trim());
            return string.Join(" ", partes);
        }
    }
}
