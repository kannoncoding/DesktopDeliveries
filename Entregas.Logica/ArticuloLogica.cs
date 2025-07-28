// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Lógica de negocio para Artículos. Valida y gestiona operaciones sobre artículos para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;
using Entregas.Datos;

namespace Entregas.Logica
{
    public static class ArticuloLogica
    {
        // Registra un nuevo artículo, validando datos y reglas de negocio.
        public static string RegistrarArticulo(int id, string nombre, TipoArticulo tipo, string valorStr, string inventarioStr, bool activo)
        {
            // Validar campos obligatorios
            if (id <= 0)
                return "El Id debe ser un número positivo.";

            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del artículo es requerido.";

            if (tipo == null)
                return "Debe seleccionar un Tipo de Artículo.";

            // Validar y convertir valor
            if (!double.TryParse(valorStr, out double valor) || valor < 0)
                return "El valor del artículo debe ser numérico y positivo.";

            // Validar y convertir inventario
            if (!int.TryParse(inventarioStr, out int inventario) || inventario < 0)
                return "El inventario debe ser un número entero positivo o cero.";

            // Validar unicidad de ID
            var existente = ArticuloDatos.ObtenerPorId(id);
            if (existente != null)
                return "Ya existe un Artículo con ese Id.";

            // Validar existencia del tipo de artículo en BD
            var tipoEnBD = TipoArticuloDatos.ObtenerPorId(tipo.Id);
            if (tipoEnBD == null)
                return "El Tipo de Artículo seleccionado no existe en la base de datos.";

            // Construir y registrar el artículo
            try
            {
                Articulo nuevoArticulo = new Articulo
                {
                    Id = id,
                    Nombre = nombre.Trim(),
                    TipoArticulo = tipoEnBD,
                    Valor = valor,
                    Inventario = inventario,
                    Activo = activo
                };

                ArticuloDatos.AgregarArticulo(nuevoArticulo);

                return "El registro se ha ingresado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al registrar el artículo: {ex.Message}";
            }
        }

        // Devuelve todos los artículos registrados
        public static List<Articulo> ObtenerTodos()
        {
            try
            {
                return ArticuloDatos.ObtenerTodos();
            }
            catch
            {
                return new List<Articulo>();
            }
        }

        // Devuelve un artículo específico por ID
        public static Articulo ObtenerPorId(int id)
        {
            try
            {
                return ArticuloDatos.ObtenerPorId(id);
            }
            catch
            {
                return null;
            }
        }

        //COMMENTED OUT TEMPOR
        /* 
        // Actualizar un artículo existente
        public static string ActualizarArticulo(Articulo articulo)
        {
            // Validaciones similares a registrar...
            // (Puedes agregar según tu diseño)
            return ArticuloDatos.ActualizarArticulo(articulo);
        }

        // Eliminar un artículo por ID (opcional según requisitos)
        public static string EliminarArticulo(int id)
        {
            try
            {
                ArticuloDatos.EliminarArticulo(id);
                return "El artículo fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        } */
        //END COMMENTED OUT
    }
}
