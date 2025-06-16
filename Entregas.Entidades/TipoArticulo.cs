// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez
// Descripción: Representa una categoría/tipo de artículo para ENTREGAS S.A. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{

    // Representa un tipo o categoría de artículo.
    public class TipoArticulo
    {
        // Identificador único del tipo de artículo.
        public int Id { get; set; }

        // Nombre del tipo de artículo (requerido).
        public required string Nombre { get; set; }

        // Descripción breve del tipo de artículo (requerido).
        public required string Descripcion { get; set; }

        // Constructor vacío
        public TipoArticulo() { }

        // Constructor
        public TipoArticulo(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        // Sobrescribe ToString() para mostrar el nombre en controles como ComboBox
        public override string ToString()
        {
            return Nombre;
        }

    }

}
