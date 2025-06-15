// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Representa a una persona repartidora registrada en ENTREGAS S.A. Incluye identificación, nombres, apellidos, fecha de nacimiento, fecha de contratación y estado de actividad.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class Repartidor
    {
        // Identificador único del repartidor
        public required int Identificacion { get; set; }

        // Nombre del repartidor
        public required string Nombre { get; set; }

        // Primer apellido del repartidor
        public required string PrimerApellido { get; set; }

        // Segundo apellido del repartidor
        public required string SegundoApellido { get; set; }

        // Fecha de nacimiento del repartidor
        public required DateTime FechaNacimiento { get; set; }

        // Fecha de contratación del repartidor
        public required DateTime FechaContratacion { get; set; }

        // Estado del repartidor: activo (true) o inactivo (false)
        public required bool Activo { get; set; }

        // Constructor vacío
        public Repartidor() { }

        // Constructor
        public Repartidor(int identificacion, string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, DateTime fechaContratacion, bool activo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            FechaContratacion = fechaContratacion;
            Activo = activo;
        }
    }
}
