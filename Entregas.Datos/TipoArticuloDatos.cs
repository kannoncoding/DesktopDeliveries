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
        // Arreglo estático para almacenar hasta 10 tipos de artículo
        private static TipoArticulo[] tipos = new TipoArticulo[10];
        private static int tipoCount = 0;

        // Agrega un nuevo TipoArticulo, validando duplicados y límite
        public static void AddTipoArticulo(TipoArticulo tipo)
        {
            if (tipoCount >= 10)
                throw new InvalidOperationException("No se pueden ingresar más registros"); // Límite alcanzado

            // Validar Id único
            for (int i = 0; i < tipoCount; i++)
            {
                if (tipos[i] != null && tipos[i].Id == tipo.Id)
                    throw new InvalidOperationException("El Id de Tipo de Artículo ya existe, ingrese uno diferente.");
            }

            tipos[tipoCount] = tipo;
            tipoCount++;
        }

        // Devuelve todos los tipos actualmente almacenados
        public static TipoArticulo[] GetAllTipos()
        {
            TipoArticulo[] resultado = new TipoArticulo[tipoCount];
            Array.Copy(tipos, resultado, tipoCount);
            return resultado;
        }

        // Opcional: Buscar por Id (útil para lógica de UI/relaciones)
        public static TipoArticulo GetTipoById(int id)
        {
            for (int i = 0; i < tipoCount; i++)
            {
                if (tipos[i] != null && tipos[i].Id == id)
                    return tipos[i];
            }
            return null;
        }
    }
}
