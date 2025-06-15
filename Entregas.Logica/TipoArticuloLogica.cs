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
        // Registra un nuevo tipo de artículo, validando datos y traduciendo excepciones en mensajes amigables.
        public static string RegistrarTipoArticulo(int id, string nombre, string descripcion)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            {
                return "Todos los campos son requeridos.";
            }

            if (id <= 0)
            {
                return "El Id debe ser un número positivo.";
            }

            // Intentar agregar el tipo a la capa de datos
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
            catch (InvalidOperationException ex)
            {
                // Mensajes claros para los errores conocidos
                if (ex.Message.Contains("límite"))
                {
                    return "No se pueden ingresar más registros (límite alcanzado).";
                }
                else if (ex.Message.Contains("ya existe"))
                {
                    return "El Id de Tipo de Artículo ya existe, ingrese uno diferente.";
                }
                else
                {
                    // Cualquier otro error técnico, se da un mensaje genérico
                    return "Ocurrió un error al registrar el tipo de artículo.";
                }
            }
            catch (Exception)
            {
                // Fallback genérico para otros errores no previstos
                return "Ocurrió un error inesperado al registrar el tipo de artículo.";
            }
        }

        // Devuelve todos los tipos de artículo registrados.
        public static TipoArticulo[] ObtenerTodos()
        {
            return TipoArticuloDatos.ObtenerTodos();
        }
    }
}
