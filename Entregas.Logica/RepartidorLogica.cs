// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Lógica de negocio para Repartidores. Valida y gestiona operaciones sobre repartidores para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;
using Entregas.Datos;

namespace Entregas.Logica
{
    public static class RepartidorLogica
    {
        // Registra un nuevo repartidor, validando datos y reglas de negocio
        public static string RegistrarRepartidor(int id, string nombre, string ap1, string ap2, DateTime fechaNac, DateTime fechaContrat, bool activo)
        {
            if (id <= 0)
                return "El Id debe ser un número positivo.";

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ap1) || string.IsNullOrWhiteSpace(ap2))
                return "Todos los campos de nombre y apellidos son requeridos.";

            if (fechaNac.Date > DateTime.Today)
                return "La fecha de nacimiento no puede ser posterior a hoy.";

            // Validar que el repartidor sea mayor de edad (18+)
            int edad = CalcularEdad(fechaNac, DateTime.Today);
            if (edad < 18)
                return "El repartidor debe ser mayor de edad (18+ años).";

            if (fechaContrat.Date > DateTime.Today)
                return "La fecha de contratación no puede ser posterior a hoy.";

            // Validar unicidad de ID
            var existente = RepartidorDatos.ObtenerPorId(id);
            if (existente != null)
                return "Ya existe un Repartidor con ese Id.";

            // Registrar repartidor en la BD
            try
            {
                Repartidor nuevoRepartidor = new Repartidor
                {
                    Identificacion = id,
                    Nombre = nombre.Trim(),
                    PrimerApellido = ap1.Trim(),
                    SegundoApellido = ap2.Trim(),
                    FechaNacimiento = fechaNac,
                    FechaContratacion = fechaContrat,
                    Activo = activo
                };

                RepartidorDatos.AgregarRepartidor(nuevoRepartidor);

                return "El registro se ha ingresado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al registrar el repartidor: {ex.Message}";
            }
        }

        // Calcula la edad a partir de la fecha de nacimiento y la fecha actual
        private static int CalcularEdad(DateTime fechaNacimiento, DateTime fechaActual)
        {
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-edad))
                edad--;
            return edad;
        }

        // Devuelve todos los repartidores registrados
        public static List<Repartidor> ObtenerTodos()
        {
            try
            {
                return RepartidorDatos.ObtenerTodos();
            }
            catch
            {
                return new List<Repartidor>();
            }
        }

        // Devuelve un repartidor específico por ID
        public static Repartidor ObtenerPorId(int id)
        {
            try
            {
                return RepartidorDatos.ObtenerPorId(id);
            }
            catch
            {
                return null;
            }
        }

        // COMMENT OUT FOR FUTURE TEST
        /*
        // Actualizar un repartidor existente
        public static string ActualizarRepartidor(Repartidor repartidor)
        {
            try
            {
                RepartidorDatos.ActualizarRepartidor(repartidor);
                return "El repartidor fue actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        // Eliminar un repartidor por ID (opcional según requisitos)
        public static string EliminarRepartidor(int id)
        {
            try
            {
                RepartidorDatos.EliminarRepartidor(id);
                return "El repartidor fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        } */
        // COMMENT OUT END
    }
}
