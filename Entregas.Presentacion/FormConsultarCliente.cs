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
    public partial class FormConsultarCliente : Form
    {
        public FormConsultarCliente()
        {
            InitializeComponent();
        }

        private void FormConsultarCliente_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarClientes();
        }

        private void ConfigurarGrid()
        {
            dgvConsultarCliente.Columns.Clear();
            dgvConsultarCliente.ReadOnly = true;
            dgvConsultarCliente.AllowUserToAddRows = false;
            dgvConsultarCliente.AllowUserToDeleteRows = false;
            dgvConsultarCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvConsultarCliente.Columns.Add("Identificacion", "Identificación");
            dgvConsultarCliente.Columns.Add("Nombre", "Nombre");
            dgvConsultarCliente.Columns.Add("PrimerApellido", "Primer Apellido");
            dgvConsultarCliente.Columns.Add("SegundoApellido", "Segundo Apellido");
            dgvConsultarCliente.Columns.Add("FechaNacimiento", "Fecha Nacimiento");
            dgvConsultarCliente.Columns.Add("Activo", "Activo");
        }

        private void CargarClientes()
        {
            dgvConsultarCliente.Rows.Clear();
            var clientes = ClienteDatos.ObtenerTodos(); // Debe retornar el arreglo de clientes registrados

            foreach (var cli in clientes)
            {
                if (cli != null)
                {
                    string fechaFormateada = cli.FechaNacimiento.ToString("dd/MM/yyyy");
                    string activoStr = cli.Activo ? "Sí" : "No";

                    dgvConsultarCliente.Rows.Add(
                        cli.Identificacion,
                        cli.Nombre,
                        cli.PrimerApellido,
                        cli.SegundoApellido,
                        fechaFormateada,
                        activoStr
                    );
                }
            }
        }
    }
}