// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo de artículos para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class ArticuloDatos
    {
        // Arreglo estático para almacenar hasta 20 artículos
        private static Articulo[] articulos = new Articulo[20];
        private static int articuloCount = 0;


        // Agrega un nuevo artículo al arreglo, validando capacidad y unicidad de ID.

        public static void AgregarArticulo(Articulo articulo)
        {
            if (articuloCount >= articulos.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            for (int i = 0; i < articuloCount; i++)
            {
                if (articulos[i] != null && articulos[i].Id == articulo.Id)
                    throw new InvalidOperationException("ID de Artículo ya existe");
            }

            articulos[articuloCount] = articulo;
            articuloCount++;
        }


        // Obtiene un artículo por su ID.

        public static Articulo? ObtenerArticuloPorId(int id)
        {
            for (int i = 0; i < articuloCount; i++)
            {
                if (articulos[i] != null && articulos[i].Id == id)
                    return articulos[i];
            }
            return null;
        }


        // Devuelve todos los artículos actualmente almacenados.

        public static Articulo[] ObtenerTodos()
        {
            Articulo[] copia = new Articulo[articuloCount];
            Array.Copy(articulos, copia, articuloCount);
            return copia;
        }


        // Devuelve la cantidad actual de artículos almacenados.

        public static int ObtenerCantidad()
        {
            return articuloCount;
        }
    }
}
