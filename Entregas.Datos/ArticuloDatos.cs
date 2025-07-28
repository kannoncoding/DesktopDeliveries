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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


using Entregas.Entidades;

namespace Entregas.Datos
{
    public static class ArticuloDatos
    {
        // Inserta un nuevo artículo en la base de datos
        public static void AgregarArticulo(Articulo articulo)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"INSERT INTO Articulo 
                    (Id, Nombre, TipoArticuloId, Valor, Inventario, Activo)
                    VALUES (@Id, @Nombre, @TipoArticuloId, @Valor, @Inventario, @Activo)";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@Id", articulo.Id);
                    comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                    comando.Parameters.AddWithValue("@TipoArticuloId", articulo.TipoArticulo.Id);
                    comando.Parameters.AddWithValue("@Valor", articulo.Valor);
                    comando.Parameters.AddWithValue("@Inventario", articulo.Inventario);
                    comando.Parameters.AddWithValue("@Activo", articulo.Activo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        // Devuelve todos los artículos almacenados (incluyendo el nombre del tipo de artículo)
        public static List<Articulo> ObtenerTodos()
        {
            List<Articulo> lista = new List<Articulo>();
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"
                    SELECT A.Id, A.Nombre, A.TipoArticuloId, T.Nombre AS NombreTipo, T.Descripcion AS DescripcionTipo,
                           A.Valor, A.Inventario, A.Activo
                    FROM Articulo A
                    INNER JOIN TipoArticulo T ON A.TipoArticuloId = T.Id";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Articulo
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                TipoArticulo = new TipoArticulo
                                {
                                    Id = reader.GetInt32(2),
                                    Nombre = reader.GetString(3),
                                    Descripcion = reader.GetString(4)
                                },
                                Valor = Convert.ToDouble(reader.GetDecimal(5)),
                                Inventario = reader.GetInt32(6),
                                Activo = reader.GetBoolean(7)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Busca un artículo por su ID
        public static Articulo? ObtenerArticuloPorId(int id)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"
                    SELECT A.Id, A.Nombre, A.TipoArticuloId, T.Nombre AS NombreTipo, T.Descripcion AS DescripcionTipo,
                           A.Valor, A.Inventario, A.Activo
                    FROM Articulo A
                    INNER JOIN TipoArticulo T ON A.TipoArticuloId = T.Id
                    WHERE A.Id = @Id";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Articulo
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                TipoArticulo = new TipoArticulo
                                {
                                    Id = reader.GetInt32(2),
                                    Nombre = reader.GetString(3),
                                    Descripcion = reader.GetString(4)
                                },
                                Valor = Convert.ToDouble(reader.GetDecimal(5)),
                                Inventario = reader.GetInt32(6),
                                Activo = reader.GetBoolean(7)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
