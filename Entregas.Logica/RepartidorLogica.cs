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
        // Registra un nuevo repartidor, validando datos y traduciendo excepciones en mensajes amigables.
        public static string RegistrarRepartidor(int id, string nombre, string ap1, string ap2, DateTime fechaNac, DateTime fechaContrat, bool activo)
        {
            // Validar que los campos de nombre y apellidos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ap1) || string.IsNullOrWhiteSpace(ap2))
                return "Todos los campos de nombre y apellidos son requeridos.";

            // Validar que el ID sea positivo
            if (id <= 0)
                return "El Id debe ser un número positivo.";

            // Validar que el repartidor sea mayor de edad (18+)
            int edad = CalcularEdad(fechaNac, DateTime.Today);
            if (edad < 18)
                return "El repartidor debe ser mayor de edad (18+ años).";

            // Validar que la fecha de contratación no sea futura
            if (fechaContrat.Date > DateTime.Today)
                return "La fecha de contratación no puede ser posterior a hoy.";

            // Validar que la fecha de nacimiento no sea futura
            if (fechaNac.Date > DateTime.Today)
                return "La fecha de nacimiento no puede ser posterior a hoy.";

            // Intentar agregar el repartidor a la capa de datos
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
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("límite"))
                    return "No se pueden ingresar más registros, límite de repartidores alcanzado.";
                else if (ex.Message.Contains("ya existe"))
                    return "El Id de Repartidor ya existe.";
                else
                    return "Ocurrió un error al registrar el repartidor.";
            }
            catch (Exception)
            {
                return "Ocurrió un error inesperado al registrar el repartidor.";
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

        // Devuelve todos los repartidores registrados actualmente.
        public static Repartidor[] ObtenerTodos()
        {
            return RepartidorDatos.ObtenerTodos();
        }
    }
}
