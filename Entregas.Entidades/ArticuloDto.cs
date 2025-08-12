using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class ArticuloDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string TipoNombre { get; set; } = string.Empty;
        public double Valor { get; set; }
        public int Inventario { get; set; }
        public bool Activo { get; set; }

        // ---------- Validaciones básicas ----------

        public void ValidarBasico()
        {
            if (Id <= 0) throw new ArgumentException("El Id del artículo debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(Nombre)) throw new ArgumentException("El nombre del artículo es obligatorio.");
            if (Valor < 0) throw new ArgumentException("El valor del artículo no puede ser negativo.");
            if (Inventario < 0) throw new ArgumentException("El inventario no puede ser negativo.");
        }

        // ¿Está disponible para la cantidad solicitada?
        public bool EstaDisponible(int cantidadSolicitada)
            => Activo && cantidadSolicitada > 0 && Inventario >= cantidadSolicitada;

        // Calcula el monto con recargo de envío (por defecto 12%).
        public double CalcularMontoConEnvio(int cantidad, double porcentajeEnvio = 0.12)
        {
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (porcentajeEnvio < 0) throw new ArgumentException("El porcentaje de envío no puede ser negativo.");

            var subtotal = Valor * cantidad;
            return subtotal * (1.0 + porcentajeEnvio);
        }

        // Representación amigable (usa CRC como prefijo de moneda).
        public override string ToString()
            => $"{Id} - {Nombre} ({TipoNombre}) | CRC {Valor:N2} | Inv: {Inventario} | {(Activo ? "Sí" : "No")}";

        // ---------- Fábricas desde entidades de dominio ----------

        // Convierte una entidad Articulo a DTO (evita exponer todo el objeto por la red).
        public static ArticuloDto FromEntidad(Articulo a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));

            return new ArticuloDto
            {
                Id = a.Id,
                Nombre = a.Nombre ?? string.Empty,
                TipoNombre = a.TipoArticulo?.Nombre ?? string.Empty,
                Valor = a.Valor,
                Inventario = a.Inventario,
                Activo = a.Activo
            };
        }

        // Versión segura que no lanza excepciones y devuelve false si falla.
        public static bool TryFromEntidad(Articulo? a, out ArticuloDto? dto)
        {
            dto = null;
            if (a == null) return false;

            try
            {
                dto = FromEntidad(a);
                return true;
            }
            catch
            {
                dto = null;
                return false;
            }
        }

        // Convierte múltiples entidades a una lista de DTOs (filtra nulos).
        public static List<ArticuloDto> FromEntidades(IEnumerable<Articulo?> articulos)
        {
            if (articulos == null) throw new ArgumentNullException(nameof(articulos));
            return articulos
                .Where(x => x != null)
                .Select(x => FromEntidad(x!))
                .ToList();
        }
    }
}