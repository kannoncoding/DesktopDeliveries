// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Provee almacenamiento y manejo de Tipos de Artículo para ENTREGAS S.A. 

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


        // Agrega un nuevo tipo de artículo al arreglo, validando capacidad y unicidad de ID.

        public static void AgregarTipoArticulo(TipoArticulo tipo)
        {
            if (tipo == null)
                throw new ArgumentNullException(nameof(tipo), "El tipo de artículo no puede ser null.");

            if (tipoCount >= tipos.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            for (int i = 0; i < tipoCount; i++)
            {
                if (tipos[i] != null && tipos[i].Id == tipo.Id)
                    throw new InvalidOperationException("ID ya existe");
            }

            tipos[tipoCount] = tipo;
            tipoCount++;
        }


        // Devuelve todos los tipos de artículo actualmente almacenados.

        public static TipoArticulo[] ObtenerTodos()
        {
            TipoArticulo[] copia = new TipoArticulo[tipoCount];
            Array.Copy(tipos, copia, tipoCount);
            return copia;
        }


        // Devuelve la cantidad actual de tipos almacenados.

        public static int ObtenerCantidad()
        {
            return tipoCount;
        }
    }
}
