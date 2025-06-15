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
        // Registra un nuevo artículo, validando datos y traduciendo excepciones en mensajes amigables.
        public static string RegistrarArticulo(int id, string nombre, TipoArticulo tipo, string valorStr, string inventarioStr, bool activo)
        {
            // Validar campos obligatorios
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

            if (id <= 0)
                return "El Id debe ser un número positivo.";

            // Intentar agregar el artículo a la capa de datos
            try
            {
                Articulo nuevoArticulo = new Articulo
                {
                    Id = id,
                    Nombre = nombre.Trim(),
                    TipoArticulo = tipo,
                    Valor = valor,
                    Inventario = inventario,
                    Activo = activo
                };

                ArticuloDatos.AgregarArticulo(nuevoArticulo);

                return "El registro se ha ingresado correctamente.";
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("límite"))
                    return "No se pueden ingresar más registros, límite de artículos alcanzado.";
                else if (ex.Message.Contains("ya existe"))
                    return "El Id de Artículo ya existe.";
                else
                    return "Ocurrió un error al registrar el artículo.";
            }
            catch (Exception)
            {
                return "Ocurrió un error inesperado al registrar el artículo.";
            }
        }

        // Devuelve todos los artículos registrados.
        public static Articulo[] ObtenerTodos()
        {
            return ArticuloDatos.ObtenerTodos();
        }
    }
}
