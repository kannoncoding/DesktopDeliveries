// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez

using Entregas.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entregas.Presentacion
{
    public partial class FormConsultarArticulo : Form
    {
        public FormConsultarArticulo()
        {
            InitializeComponent();
        }

        private void FormConsultarArticulo_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarArticulos();
        }

        private void ConfigurarGrid()
        {
            dgvConsultarArticulo.Columns.Clear();
            dgvConsultarArticulo.ReadOnly = true;
            dgvConsultarArticulo.AllowUserToAddRows = false;
            dgvConsultarArticulo.AllowUserToDeleteRows = false;
            dgvConsultarArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvConsultarArticulo.Columns.Add("Id", "ID");
            dgvConsultarArticulo.Columns.Add("Nombre", "Nombre");
            dgvConsultarArticulo.Columns.Add("TipoArticulo", "Tipo de Artículo");
            dgvConsultarArticulo.Columns.Add("Valor", "Valor");
            dgvConsultarArticulo.Columns.Add("Inventario", "Inventario");
            dgvConsultarArticulo.Columns.Add("Activo", "Activo");
        }

        private void CargarArticulos()
        {
            dgvConsultarArticulo.Rows.Clear();
            var articulos = ArticuloDatos.ObtenerTodos(); // Debe retornar el arreglo de artículos

            
            foreach (var art in articulos)
            {
                if (art != null)
                {
                    // Formatea el valor como decimal con dos decimales (puedes ajustar a moneda si deseas)
                    string valorFormateado = art.Valor.ToString("N2"); // o .ToString("C2") para moneda local
                    string tipoNombre = art.TipoArticulo != null ? art.TipoArticulo.Nombre : "";
                    string activoStr = art.Activo ? "Sí" : "No";

                    dgvConsultarArticulo.Rows.Add(
                        art.Id,
                        art.Nombre,
                        tipoNombre,
                        valorFormateado,
                        art.Inventario,
                        activoStr
                    );
                    
                }
            }

            
        }
    }
}
