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
    public partial class FormConsultarTipoArticulo : Form
    {
        public FormConsultarTipoArticulo()
        {
            InitializeComponent();
        }

        private void FormConsultarTipoArticulo_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarTipos();
        }

        private void ConfigurarGrid()
        {
            // Limpia columnas existentes y configura las nuevas
            dgvConsultarTipoArticulo.Columns.Clear();
            dgvConsultarTipoArticulo.ReadOnly = true;
            dgvConsultarTipoArticulo.AllowUserToAddRows = false;
            dgvConsultarTipoArticulo.AllowUserToDeleteRows = false;
            dgvConsultarTipoArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvConsultarTipoArticulo.Columns.Add("Id", "ID");
            dgvConsultarTipoArticulo.Columns.Add("Nombre", "Nombre");
            dgvConsultarTipoArticulo.Columns.Add("Descripcion", "Descripción");
        }

        private void CargarTipos()
        {
            dgvConsultarTipoArticulo.Rows.Clear();
            var tipos = TipoArticuloDatos.ObtenerTodos(); // Este método debe devolverte el arreglo de tipos registrados

           
            foreach (var tipo in tipos)
            {
                if (tipo != null)
                {
                    dgvConsultarTipoArticulo.Rows.Add(tipo.Id, tipo.Nombre, tipo.Descripcion);
                    
                }
            }

           
        }
    }
}
