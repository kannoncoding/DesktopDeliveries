using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public bool Activo { get; set; }

        // ---------- Validaciones básicas ----------

        public void ValidarBasico()
        {
            if (Id <= 0) throw new ArgumentException("El Id del cliente debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(NombreCompleto)) throw new ArgumentException("El nombre del cliente es obligatorio.");
        }

        // Representación amigable.
        public override string ToString() =>
            $"{Id} - {NombreCompleto} | {(Activo ? "Activo" : "Inactivo")}";

        // ---------- Utilidades de nombre ----------

        public static string ConstruirNombreCompleto(string? nombre, string? primerApellido, string? segundoApellido)
        {
            var partes = new[] { nombre, primerApellido, segundoApellido }
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => p!.Trim());
            return string.Join(" ", partes);
        }

        // ---------- Fábricas desde entidades de dominio ----------

        public static ClienteDto FromEntidad(Cliente c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));

            return new ClienteDto
            {
                Id = c.Identificacion,
                NombreCompleto = ConstruirNombreCompleto(c.Nombre, c.PrimerApellido, c.SegundoApellido),
                Activo = c.Activo
            };
        }

        // Versión segura que no lanza excepciones y devuelve false si falla.
        public static bool TryFromEntidad(Cliente? c, out ClienteDto? dto)
        {
            dto = null;
            if (c == null) return false;

            try
            {
                dto = FromEntidad(c);
                return true;
            }
            catch
            {
                dto = null;
                return false;
            }
        }

        // Convierte múltiples entidades a una lista de DTOs (filtra nulos).
        public static List<ClienteDto> FromEntidades(IEnumerable<Cliente?> clientes)
        {
            if (clientes == null) throw new ArgumentNullException(nameof(clientes));

            return clientes
                .Where(x => x != null)
                .Select(x => FromEntidad(x!))
                .ToList();
        }
    }
}
