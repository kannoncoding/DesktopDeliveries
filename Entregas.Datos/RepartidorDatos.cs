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
using System.Data;
using Microsoft.Data.SqlClient;

using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class RepartidorDatos
    {
        // Agrega un nuevo repartidor en la base de datos
        public static void AgregarRepartidor(Repartidor repartidor)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"INSERT INTO Repartidor
                    (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, FechaContratacion, Activo)
                    VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @FechaContratacion, @Activo)";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@Identificacion", repartidor.Identificacion);
                    comando.Parameters.AddWithValue("@Nombre", repartidor.Nombre);
                    comando.Parameters.AddWithValue("@PrimerApellido", repartidor.PrimerApellido);
                    comando.Parameters.AddWithValue("@SegundoApellido", repartidor.SegundoApellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", repartidor.FechaNacimiento.Date);
                    comando.Parameters.AddWithValue("@FechaContratacion", repartidor.FechaContratacion.Date);
                    comando.Parameters.AddWithValue("@Activo", repartidor.Activo);
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Devuelve todos los repartidores almacenados
        public static List<Repartidor> ObtenerTodos()
        {
            var lista = new List<Repartidor>();
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, FechaContratacion, Activo 
                                    FROM Repartidor";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Repartidor
                            {
                                Identificacion = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                PrimerApellido = reader.GetString(2),
                                SegundoApellido = reader.GetString(3),
                                FechaNacimiento = reader.GetDateTime(4),
                                FechaContratacion = reader.GetDateTime(5),
                                Activo = reader.GetBoolean(6)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Busca un repartidor por identificación
        public static Repartidor? ObtenerRepartidorPorId(int identificacion)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, FechaContratacion, Activo 
                                    FROM Repartidor 
                                    WHERE Identificacion = @Identificacion";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@Identificacion", identificacion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Repartidor
                            {
                                Identificacion = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                PrimerApellido = reader.GetString(2),
                                SegundoApellido = reader.GetString(3),
                                FechaNacimiento = reader.GetDateTime(4),
                                FechaContratacion = reader.GetDateTime(5),
                                Activo = reader.GetBoolean(6)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
