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
        // Registra un nuevo cliente, validando datos y reglas de negocio.
        public static string RegistrarCliente(int id, string nombre, string ap1, string ap2, DateTime fechaNac, bool activo)
        {
            // Validar campos obligatorios
            if (id <= 0)
                return "El Id debe ser un número positivo.";

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ap1) || string.IsNullOrWhiteSpace(ap2))
                return "Todos los campos de nombre y apellidos son requeridos.";

            if (fechaNac.Date > DateTime.Today)
                return "La fecha de nacimiento no puede ser posterior a hoy.";

            // Validar unicidad de ID
            var existente = ClienteDatos.ObtenerPorId(id);
            if (existente != null)
                return "Ya existe un Cliente con ese Id.";

            // Construir y registrar el cliente
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
            catch (Exception ex)
            {
                return $"Ocurrió un error al registrar el cliente: {ex.Message}";
            }
        }

        // Devuelve todos los clientes registrados
        public static List<Cliente> ObtenerTodos()
        {
            try
            {
                return ClienteDatos.ObtenerTodos();
            }
            catch
            {
                return new List<Cliente>();
            }
        }

        // Devuelve un cliente específico por ID
        public static Cliente ObtenerPorId(int id)
        {
            try
            {
                return ClienteDatos.ObtenerPorId(id);
            }
            catch
            {
                return null;
            }
        }


        /* COMMENT OUT FOR FUTURE TEST
        // Actualizar un cliente existente
        public static string ActualizarCliente(Cliente cliente)
        {
            try
            {
                ClienteDatos.ActualizarCliente(cliente);
                return "El cliente fue actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        // Eliminar un cliente por ID
        public static string EliminarCliente(int id)
        {
            try
            {
                ClienteDatos.EliminarCliente(id);
                return "El cliente fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        } */
        // END COMMENT OUT
    }

}
