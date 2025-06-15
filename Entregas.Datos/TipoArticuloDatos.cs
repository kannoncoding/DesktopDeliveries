// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Descripción del archivo: Provee almacenamiento y manejo de Tipos de Artículo para ENTREGAS S.A. 
// Incluye las operaciones para agregar y consultar tipos de artículo (10 máximo).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class TipoArticuloDatos
    {
        // Arreglo estático de 10 posiciones para almacenar tipos de artículo
        private static TipoArticulo[] tipos = new TipoArticulo[10];
        private static int tipoCount = 0;

        /// <summary>
        /// Agrega un nuevo tipo de artículo al arreglo, validando capacidad y unicidad de ID.
        /// </summary>
        /// <param name="tipo">Objeto TipoArticulo a agregar</param>
        /// <exception cref="InvalidOperationException">Si el arreglo está lleno o el ID ya existe</exception>
        public static void AddTipoArticulo(TipoArticulo tipo)
        {
            // Validar si el arreglo ya está lleno
            if (tipoCount >= tipos.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            // Validar unicidad de ID
            for (int i = 0; i < tipoCount; i++)
            {
                if (tipos[i] != null && tipos[i].Id == tipo.Id)
                    throw new InvalidOperationException("ID ya existe");
            }

            // Insertar el nuevo tipo y aumentar el contador
            tipos[tipoCount] = tipo;
            tipoCount++;
        }

        /// <summary>
        /// Devuelve todos los tipos de artículo actualmente almacenados.
        /// </summary>
        public static TipoArticulo[] GetAll()
        {
            TipoArticulo[] copia = new TipoArticulo[tipoCount];
            Array.Copy(tipos, copia, tipoCount);
            return copia;
        }

        /// <summary>
        /// Devuelve la cantidad actual de tipos almacenados.
        /// </summary>
        public static int GetCount()
        {
            return tipoCount;
        }
    }
}
