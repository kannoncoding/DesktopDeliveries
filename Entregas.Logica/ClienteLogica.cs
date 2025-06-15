// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Lógica de negocio para Clientes. Valida y gestiona operaciones sobre clientes para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;
using Entregas.Datos;

namespace Entregas.Logica
{
    public static class ClienteLogica
    {
        // Registra un nuevo cliente, validando datos y traduciendo excepciones en mensajes amigables.
        public static string RegistrarCliente(int id, string nombre, string ap1, string ap2, DateTime fechaNac, bool activo)
        {
            // Validar que los campos de nombre y apellidos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ap1) || string.IsNullOrWhiteSpace(ap2))
                return "Todos los campos de nombre y apellidos son requeridos.";

            // Validar que la fecha de nacimiento no sea futura
            if (fechaNac.Date > DateTime.Today)
                return "La fecha de nacimiento no puede ser posterior a hoy.";

            // Validar que el ID sea positivo
            if (id <= 0)
                return "El Id debe ser un número positivo.";

            // Intentar agregar el cliente a la capa de datos
            try
            {
                Cliente nuevoCliente = new Cliente
                {
                    Identificacion = id,
                    Nombre = nombre.Trim(),
                    PrimerApellido = ap1.Trim(),
                    SegundoApellido = ap2.Trim(),
                    FechaNacimiento = fechaNac,
                    Activo = activo
                };

                ClienteDatos.AgregarCliente(nuevoCliente);

                return "El registro se ha ingresado correctamente.";
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("límite"))
                    return "No se pueden ingresar más registros, límite de clientes alcanzado.";
                else if (ex.Message.Contains("ya existe"))
                    return "El Id de Cliente ya existe.";
                else
                    return "Ocurrió un error al registrar el cliente.";
            }
            catch (Exception)
            {
                return "Ocurrió un error inesperado al registrar el cliente.";
            }
        }

        // Devuelve todos los clientes registrados actualmente.
        public static Cliente[] ObtenerTodos()
        {
            return ClienteDatos.ObtenerTodos();
        }
    }
}
