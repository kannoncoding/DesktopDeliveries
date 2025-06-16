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
    public partial class FormRegistrarRepartidor : Form
    {
        public FormRegistrarRepartidor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistrarRepartidor_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuración de los DateTimePickers
                dtpNacimientoRepartidor.Format = DateTimePickerFormat.Short;
                dtpNacimientoRepartidor.Value = DateTime.Today;
                dtpNacimientoRepartidor.ShowUpDown = false;

                dtpContratacionRepartidor.Format = DateTimePickerFormat.Short;
                dtpContratacionRepartidor.Value = DateTime.Today;
                dtpContratacionRepartidor.ShowUpDown = false;

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

        private void idRepartidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(idRepartidor.Text) ||
                    string.IsNullOrWhiteSpace(nombreRepartidor.Text) ||
                    string.IsNullOrWhiteSpace(primerApellidoRepartidor.Text) ||
                    string.IsNullOrWhiteSpace(segundoApellidoRepartidor.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar identificación numérica
                if (!int.TryParse(idRepartidor.Text.Trim(), out int id))
                {
                    MessageBox.Show("El ID del repartidor debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idRepartidor.Focus();
                    return;
                }

                if (cmbActivo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar si el repartidor está activo o no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbActivo.DroppedDown = true;
                    return;
                }

                string nombre = nombreRepartidor.Text.Trim();
                string ap1 = primerApellidoRepartidor.Text.Trim();
                string ap2 = segundoApellidoRepartidor.Text.Trim();
                DateTime fechaNac = dtpNacimientoRepartidor.Value.Date;
                DateTime fechaCont = dtpContratacionRepartidor.Value.Date;
                bool activo = cmbActivo.SelectedItem?.ToString() == "Sí";

                // Llamar a la lógica (ajusta la firma si es necesario)
                string resultado = Entregas.Logica.RepartidorLogica.RegistrarRepartidor(
                    id,
                    nombre,
                    ap1,
                    ap2,
                    fechaNac,
                    fechaCont,
                    activo
                );

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultado.Contains("correctamente"))
                {
                    idRepartidor.Clear();
                    nombreRepartidor.Clear();
                    primerApellidoRepartidor.Clear();
                    segundoApellidoRepartidor.Clear();
                    dtpNacimientoRepartidor.Value = DateTime.Today;
                    dtpContratacionRepartidor.Value = DateTime.Today;
                    cmbActivo.SelectedIndex = 0;
                    idRepartidor.Focus();
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

    }
}
