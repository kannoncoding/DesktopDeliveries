// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Proporciona almacenamiento y operaciones de manejo de pedidos (órdenes) para ENTREGAS S.A.

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
    public static class PedidoDatos
    {
        // Agrega un nuevo pedido a la base de datos y devuelve el NúmeroPedido generado (IDENTITY)
        public static int AgregarPedido(Pedido pedido)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"INSERT INTO Pedido (FechaPedido, ClienteId, RepartidorId, Direccion)
                                    VALUES (@FechaPedido, @ClienteId, @RepartidorId, @Direccion);
                                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido.Date);
                    comando.Parameters.AddWithValue("@ClienteId", pedido.Cliente.Identificacion);
                    comando.Parameters.AddWithValue("@RepartidorId", pedido.Repartidor.Identificacion);
                    comando.Parameters.AddWithValue("@Direccion", pedido.Direccion);

                    // Retorna el IDENTITY generado (NúmeroPedido)
                    int nuevoNumeroPedido = Convert.ToInt32(comando.ExecuteScalar());
                    return nuevoNumeroPedido;
                }
            }
        }

        // Devuelve todos los pedidos actualmente almacenados (incluyendo cliente y repartidor)
        public static List<Pedido> ObtenerTodosLosPedidos()
        {
            var lista = new List<Pedido>();
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"
                    SELECT P.NumeroPedido, P.FechaPedido, 
                        C.Identificacion, C.Nombre, C.PrimerApellido, C.SegundoApellido, C.FechaNacimiento, C.Activo,
                        R.Identificacion, R.Nombre, R.PrimerApellido, R.SegundoApellido, R.FechaNacimiento, R.FechaContratacion, R.Activo,
                        P.Direccion
                    FROM Pedido P
                    INNER JOIN Cliente C ON P.ClienteId = C.Identificacion
                    INNER JOIN Repartidor R ON P.RepartidorId = R.Identificacion";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Pedido
                            {
                                NumeroPedido = reader.GetInt32(0),
                                FechaPedido = reader.GetDateTime(1),
                                Cliente = new Cliente
                                {
                                    Identificacion = reader.GetInt32(2),
                                    Nombre = reader.GetString(3),
                                    PrimerApellido = reader.GetString(4),
                                    SegundoApellido = reader.GetString(5),
                                    FechaNacimiento = reader.GetDateTime(6),
                                    Activo = reader.GetBoolean(7)
                                },
                                Repartidor = new Repartidor
                                {
                                    Identificacion = reader.GetInt32(8),
                                    Nombre = reader.GetString(9),
                                    PrimerApellido = reader.GetString(10),
                                    SegundoApellido = reader.GetString(11),
                                    FechaNacimiento = reader.GetDateTime(12),
                                    FechaContratacion = reader.GetDateTime(13),
                                    Activo = reader.GetBoolean(14)
                                },
                                Direccion = reader.GetString(15)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Busca un pedido por su número de pedido
        public static Pedido? ObtenerPedidoPorNumero(int numeroPedido)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sentencia = @"
                    SELECT P.NumeroPedido, P.FechaPedido, 
                        C.Identificacion, C.Nombre, C.PrimerApellido, C.SegundoApellido, C.FechaNacimiento, C.Activo,
                        R.Identificacion, R.Nombre, R.PrimerApellido, R.SegundoApellido, R.FechaNacimiento, R.FechaContratacion, R.Activo,
                        P.Direccion
                    FROM Pedido P
                    INNER JOIN Cliente C ON P.ClienteId = C.Identificacion
                    INNER JOIN Repartidor R ON P.RepartidorId = R.Identificacion
                    WHERE P.NumeroPedido = @NumeroPedido";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.AddWithValue("@NumeroPedido", numeroPedido);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pedido
                            {
                                NumeroPedido = reader.GetInt32(0),
                                FechaPedido = reader.GetDateTime(1),
                                Cliente = new Cliente
                                {
                                    Identificacion = reader.GetInt32(2),
                                    Nombre = reader.GetString(3),
                                    PrimerApellido = reader.GetString(4),
                                    SegundoApellido = reader.GetString(5),
                                    FechaNacimiento = reader.GetDateTime(6),
                                    Activo = reader.GetBoolean(7)
                                },
                                Repartidor = new Repartidor
                                {
                                    Identificacion = reader.GetInt32(8),
                                    Nombre = reader.GetString(9),
                                    PrimerApellido = reader.GetString(10),
                                    SegundoApellido = reader.GetString(11),
                                    FechaNacimiento = reader.GetDateTime(12),
                                    FechaContratacion = reader.GetDateTime(13),
                                    Activo = reader.GetBoolean(14)
                                },
                                Direccion = reader.GetString(15)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
