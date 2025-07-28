// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Lógica de negocio para Tipos de Artículo. Valida y gestiona operaciones sobre tipos de artículo para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;
using Entregas.Datos;

namespace Entregas.Logica
{
    public static class TipoArticuloLogica
    {
        // Registra un nuevo tipo de artículo, validando datos y reglas de negocio.
        public static string RegistrarTipoArticulo(int id, string nombre, string descripcion)
        {
            if (id <= 0)
                return "El Id debe ser un número positivo.";

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
                return "Todos los campos son requeridos.";

            // Validar unicidad de ID
            var existente = TipoArticuloDatos.ObtenerPorId(id);
            if (existente != null)
                return "Ya existe un Tipo de Artículo con ese Id.";

            // Registrar en la base de datos
            try
            {
                TipoArticulo nuevoTipo = new TipoArticulo
                {
                    Id = id,
                    Nombre = nombre.Trim(),
                    Descripcion = descripcion.Trim()
                };
                TipoArticuloDatos.AgregarTipoArticulo(nuevoTipo);

                return "El registro se ha ingresado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al registrar el tipo de artículo: {ex.Message}";
            }
        }

        // Devuelve todos los tipos de artículo registrados
        public static List<TipoArticulo> ObtenerTodos()
        {
            try
            {
                return TipoArticuloDatos.ObtenerTodos();
            }
            catch
            {
                return new List<TipoArticulo>();
            }
        }

        // Devuelve un tipo de artículo por su ID
        public static TipoArticulo ObtenerPorId(int id)
        {
            try
            {
                return TipoArticuloDatos.ObtenerPorId(id);
            }
            catch
            {
                return null;
            }
        }

        // COMMENT OUT FOR FUTURE TEST
        /*
        // Actualizar un tipo de artículo existente (opcional)
        public static string ActualizarTipoArticulo(TipoArticulo tipo)
        {
            try
            {
                TipoArticuloDatos.ActualizarTipoArticulo(tipo);
                return "El tipo de artículo fue actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        // Eliminar un tipo de artículo por ID (opcional)
        public static string EliminarTipoArticulo(int id)
        {
            try
            {
                TipoArticuloDatos.EliminarTipoArticulo(id);
                return "El tipo de artículo fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        } */
        //COMMENT OUT END
    }
}
