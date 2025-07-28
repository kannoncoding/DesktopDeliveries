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
using Microsoft.Data.SqlClient;
using System.Data;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class ClienteDatos
    {
        // Inserta un nuevo cliente en la base de datos
        public static void AgregarCliente(Cliente cliente)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"INSERT INTO Cliente 
                    (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo)
                    VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Activo)";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                    comando.Parameters.AddWithValue("@SegundoApellido", cliente.SegundoApellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento.Date);
                    comando.Parameters.AddWithValue("@Activo", cliente.Activo);
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Devuelve todos los clientes almacenados
        public static List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo 
                                    FROM Cliente";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Identificacion = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                PrimerApellido = reader.GetString(2),
                                SegundoApellido = reader.GetString(3),
                                FechaNacimiento = reader.GetDateTime(4),
                                Activo = reader.GetBoolean(5)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Busca un cliente por su identificación
        public static Cliente? ObtenerPorId(int identificacion)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo 
                                    FROM Cliente 
                                    WHERE Identificacion = @Identificacion";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@Identificacion", identificacion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Identificacion = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                PrimerApellido = reader.GetString(2),
                                SegundoApellido = reader.GetString(3),
                                FechaNacimiento = reader.GetDateTime(4),
                                Activo = reader.GetBoolean(5)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
