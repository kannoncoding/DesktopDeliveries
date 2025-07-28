// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 2
// Jorge Luis Arias Melendez
// Descripción del archivo: Clase base para gestionar la conexión a SQL Server usando ADO.NET en ENTREGAS S.A.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace Entregas.Datos
{
    public static class ConexionBD
    {
        // Obtiene la cadena de conexión desde App.config
        private static readonly string cadenaConexion =
            System.Configuration.ConfigurationManager.ConnectionStrings["BD_Entregas"].ConnectionString;

        // Método para obtener una conexión abierta
        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }
    }
}
