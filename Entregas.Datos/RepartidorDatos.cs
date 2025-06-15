// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo de repartidores para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class RepartidorDatos
    {
        // Arreglo estático para almacenar hasta 20 repartidores
        private static Repartidor[] repartidores = new Repartidor[20];
        private static int repartidorCount = 0;

        // Agrega un nuevo repartidor al arreglo, validando capacidad y unicidad de identificación.
        public static void AgregarRepartidor(Repartidor repartidor)
        {
            if (repartidorCount >= repartidores.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            for (int i = 0; i < repartidorCount; i++)
            {
                if (repartidores[i] != null && repartidores[i].Identificacion == repartidor.Identificacion)
                    throw new InvalidOperationException("Identificación de repartidor ya existe");
            }

            repartidores[repartidorCount] = repartidor;
            repartidorCount++;
        }

        // Devuelve todos los repartidores actualmente almacenados.

        public static Repartidor[] ObtenerTodos()
        {
            Repartidor[] copia = new Repartidor[repartidorCount];
            Array.Copy(repartidores, copia, repartidorCount);
            return copia;
        }

        // Busca un repartidor por identificación.
        public static Repartidor ObtenerRepartidorPorId(int identificacion)
        {
            for (int i = 0; i < repartidorCount; i++)
            {
                if (repartidores[i] != null && repartidores[i].Identificacion == identificacion)
                    return repartidores[i];
            }
            return null;
        }

        // Devuelve la cantidad actual de repartidores almacenados.

        public static int ObtenerCantidad()
        {
            return repartidorCount;
        }
    }
}
