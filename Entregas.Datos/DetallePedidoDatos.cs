// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo para los detalles de pedido (líneas de pedido) en ENTREGAS S.A.

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
    public static class DetallePedidoDatos
    {
        // Agrega un nuevo detalle de pedido a la base de datos
        public static void AgregarDetalle(DetallePedido detalle)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"INSERT INTO DetallePedido 
                    (NumeroPedido, ArticuloId, Cantidad, Monto)
                    VALUES (@NumeroPedido, @ArticuloId, @Cantidad, @Monto)";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@NumeroPedido", detalle.NumeroPedido);
                    comando.Parameters.AddWithValue("@ArticuloId", detalle.Articulo.Id);
                    comando.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    comando.Parameters.AddWithValue("@Monto", detalle.Monto);
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Devuelve todos los detalles para un pedido específico (incluyendo la información del artículo y su tipo)
        public static List<DetallePedido> ObtenerDetallesPorPedido(int numeroPedido)
        {
            var lista = new List<DetallePedido>();
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"
                    SELECT DP.NumeroPedido, DP.ArticuloId, DP.Cantidad, DP.Monto,
                           A.Nombre, A.TipoArticuloId, T.Nombre AS NombreTipo, T.Descripcion AS DescripcionTipo,
                           A.Valor, A.Inventario, A.Activo
                    FROM DetallePedido DP
                    INNER JOIN Articulo A ON DP.ArticuloId = A.Id
                    INNER JOIN TipoArticulo T ON A.TipoArticuloId = T.Id
                    WHERE DP.NumeroPedido = @NumeroPedido";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@NumeroPedido", numeroPedido);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetallePedido
                            {
                                NumeroPedido = reader.GetInt32(0),
                                Articulo = new Articulo
                                {
                                    Id = reader.GetInt32(1),
                                    Nombre = reader.GetString(4),
                                    TipoArticulo = new TipoArticulo
                                    {
                                        Id = reader.GetInt32(5),
                                        Nombre = reader.GetString(6),
                                        Descripcion = reader.GetString(7)
                                    },
                                    Valor = Convert.ToDouble(reader.GetDecimal(8)),
                                    Inventario = reader.GetInt32(9),
                                    Activo = reader.GetBoolean(10)
                                },
                                Cantidad = reader.GetInt32(2),
                                Monto = Convert.ToDouble(reader.GetDecimal(3))
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
