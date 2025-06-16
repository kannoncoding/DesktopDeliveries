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
    public partial class FormConsultarRepartidor : Form
    {
        public FormConsultarRepartidor()
        {
            InitializeComponent();
        }

        private void FormConsultarRepartidor_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarRepartidores();
        }

        private void ConfigurarGrid()
        {
            dgvConsultarRepartidor.Columns.Clear();
            dgvConsultarRepartidor.ReadOnly = true;
            dgvConsultarRepartidor.AllowUserToAddRows = false;
            dgvConsultarRepartidor.AllowUserToDeleteRows = false;
            dgvConsultarRepartidor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvConsultarRepartidor.Columns.Add("Identificacion", "Identificación");
            dgvConsultarRepartidor.Columns.Add("Nombre", "Nombre");
            dgvConsultarRepartidor.Columns.Add("PrimerApellido", "Primer Apellido");
            dgvConsultarRepartidor.Columns.Add("SegundoApellido", "Segundo Apellido");
            dgvConsultarRepartidor.Columns.Add("FechaNacimiento", "Fecha Nacimiento");
            dgvConsultarRepartidor.Columns.Add("FechaContratacion", "Fecha Contratación");
            dgvConsultarRepartidor.Columns.Add("Activo", "Activo");
        }

        private void CargarRepartidores()
        {
            dgvConsultarRepartidor.Rows.Clear();
            var repartidores = RepartidorDatos.ObtenerTodos(); // Debe retornar el arreglo de repartidores registrados

            foreach (var rep in repartidores)
            {
                if (rep != null)
                {
                    string fechaNacimiento = rep.FechaNacimiento.ToString("dd/MM/yyyy");
                    string fechaContratacion = rep.FechaContratacion.ToString("dd/MM/yyyy");
                    string activoStr = rep.Activo ? "Sí" : "No";

                    dgvConsultarRepartidor.Rows.Add(
                        rep.Identificacion,
                        rep.Nombre,
                        rep.PrimerApellido,
                        rep.SegundoApellido,
                        fechaNacimiento,
                        fechaContratacion,
                        activoStr
                    );
                }
            }
        }
    }
}
