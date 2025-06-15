// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Representa una persona cliente registrada en ENTREGAS S.A. Incluye identificación, nombres, apellidos, fecha de nacimiento y estado de actividad.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class Cliente
    {
        // Identificador único del cliente
        public required int Identificacion { get; set; }

        // Nombre del cliente
        public required string Nombre { get; set; }

        // Primer apellido del cliente
        public required string PrimerApellido { get; set; }

        // Segundo apellido del cliente
        public required string SegundoApellido { get; set; }

        // Fecha de nacimiento del cliente
        public required DateTime FechaNacimiento { get; set; }

        // Estado del cliente: activo (true) o inactivo (false)
        public required bool Activo { get; set; }

        // Constructor vacío
        public Cliente() { }

        // Constructor
        public Cliente(int identificacion, string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, bool activo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Activo = activo;
        }
    }
}
