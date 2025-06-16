// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo de clientes para ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class ClienteDatos
    {
        // Arreglo estático para almacenar hasta 20 clientes
        private static Cliente[] clientes = new Cliente[20];
        private static int clienteCount = 0;

        // Agrega un nuevo cliente al arreglo, validando capacidad y unicidad de identificación.

        public static void AgregarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser null.");

            if (clienteCount >= clientes.Length)
                throw new InvalidOperationException("No se pueden ingresar más registros");

            for (int i = 0; i < clienteCount; i++)
            {
                if (clientes[i] != null && clientes[i].Identificacion == cliente.Identificacion)
                    throw new InvalidOperationException("Identificación de cliente ya existe");
            }

            clientes[clienteCount] = cliente;
            clienteCount++;
        }


        // Devuelve todos los clientes actualmente almacenados.

        public static Cliente[] ObtenerTodos()
        {
            Cliente[] copia = new Cliente[clienteCount];
            Array.Copy(clientes, copia, clienteCount);
            return copia;
        }


        // Busca un cliente por identificación.
        public static Cliente? ObtenerClientePorId(int identificacion)
        {
            for (int i = 0; i < clienteCount; i++)
            {
                if (clientes[i] != null && clientes[i].Identificacion == identificacion)
                    return clientes[i];
            }
            return null;
        }


        // Devuelve la cantidad actual de clientes almacenados.

        public static int ObtenerCantidad()
        {
            return clienteCount;
        }
    }
}
