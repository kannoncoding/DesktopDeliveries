// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 1
// Jorge Luis Arias Melendez

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
    public partial class FormRegistrarCliente : Form
    {
        public FormRegistrarCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(idCliente.Text) ||
                    string.IsNullOrWhiteSpace(nombreCliente.Text) ||
                    string.IsNullOrWhiteSpace(primerApellidoCliente.Text) ||
                    string.IsNullOrWhiteSpace(segundoApellidoCliente.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar identificación numérica
                if (!int.TryParse(idCliente.Text.Trim(), out int id))

                {
                    MessageBox.Show("La identificación debe ser numérica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idCliente.Focus();
                    return;
                }

                if (cmbActivo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar si el cliente está activo o no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbActivo.DroppedDown = true;
                    return;
                }

                string nombre = nombreCliente.Text.Trim();
                string ap1 = primerApellidoCliente.Text.Trim();
                string ap2 = segundoApellidoCliente.Text.Trim();
                DateTime fechaNac = dtpNacimientoCliente.Value.Date;
                bool activo = cmbActivo.SelectedItem?.ToString() == "Sí";

                // Llamar a la lógica (ajusta la firma según tu capa lógica)
                string resultado = Entregas.Logica.ClienteLogica.RegistrarCliente(
                    id,
                    nombre,
                    ap1,
                    ap2,
                    fechaNac,
                    activo
                );

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultado.Contains("correctamente"))
                {
                    idCliente.Clear();
                    nombreCliente.Clear();
                    primerApellidoCliente.Clear();
                    segundoApellidoCliente.Clear();
                    dtpNacimientoCliente.Value = DateTime.Today;
                    cmbActivo.SelectedIndex = 0;
                    idCliente.Focus();
                }
                if (resultado.Contains("No se pueden ingresar más registros"))
                {
                    btnRegistrar.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado. Por favor intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FormRegistrarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuración del DateTimePicker
                dtpNacimientoCliente.Format = DateTimePickerFormat.Short;
                dtpNacimientoCliente.Value = DateTime.Today;
                dtpNacimientoCliente.ShowUpDown = false; // Muestra calendario

                // Configuración del ComboBox de activo
                cmbActivo.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbActivo.Items.Clear();
                cmbActivo.Items.Add("Sí");
                cmbActivo.Items.Add("No");
                cmbActivo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al inicializar el formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegistrar.Enabled = false;
            }
        }

        private void idCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

    }
}
