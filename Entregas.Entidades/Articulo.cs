// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Representa un artículo gestionado por ENTREGAS S.A., incluyendo identificación, nombre, tipo, valor, inventario y estado de actividad.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class Articulo
    {
        // Identificador único para cada artículo
        public int Id { get; set; }


        // Nombre del artículo
        public required string Nombre { get; set; }


        public int TipoArticuloId { get; set; } // Id de relación para BD

        // Referencia al objeto TipoArticulo (debe seleccionarse de los tipos existentes)
        public required TipoArticulo TipoArticulo { get; set; }



        // Precio del artículo (debe ser numérico)
        public double Valor { get; set; }

        // Cantidad disponible en inventario
        public int Inventario { get; set; }

        // Estado del artículo: activo (true) o inactivo (false)
        public bool Activo { get; set; }

        // Constructor vacío
        public Articulo() { }

        // Constructor
        public Articulo(int id, string nombre, TipoArticulo tipoArticulo, double valor, int inventario, bool activo)
        {
            Id = id;
            Nombre = nombre;
            TipoArticulo = tipoArticulo;
            Valor = valor;
            Inventario = inventario;
            Activo = activo;
        }
    }
}
