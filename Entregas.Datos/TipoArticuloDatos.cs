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
using System.Data;
using Microsoft.Data.SqlClient;

namespace Entregas.Datos
{
    public static class TipoArticuloDatos
    {
        // Agrega un nuevo tipo de artículo a la base de datos
        public static void AgregarTipoArticulo(TipoArticulo tipo)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"INSERT INTO TipoArticulo
                    (Id, Nombre, Descripcion)
                    VALUES (@Id, @Nombre, @Descripcion)";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", tipo.Id);
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Devuelve todos los tipos de artículo actualmente almacenados
        public static List<TipoArticulo> ObtenerTodos()
        {
            var lista = new List<TipoArticulo>();
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"SELECT Id, Nombre, Descripcion FROM TipoArticulo";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TipoArticulo
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Busca un tipo de artículo por su Id
        public static TipoArticulo? ObtenerPorId(int id)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"SELECT Id, Nombre, Descripcion FROM TipoArticulo WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TipoArticulo
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
