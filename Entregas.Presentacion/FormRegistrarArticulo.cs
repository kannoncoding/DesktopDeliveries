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
    public partial class FormRegistrarArticulo : Form
    {
        public FormRegistrarArticulo()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistrarArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                // ComboBoxes sólo selección, no editable
                cmbTipoArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbActivo.DropDownStyle = ComboBoxStyle.DropDownList;

                // Limpiar y poblar cmbActivo
                cmbActivo.Items.Clear();
                cmbActivo.Items.Add("Sí");
                cmbActivo.Items.Add("No");
                cmbActivo.SelectedIndex = 0;

                // Poblar cmbTipoArticulo con los tipos existentes
                cmbTipoArticulo.Items.Clear();
                var tipos = Entregas.Logica.TipoArticuloLogica.ObtenerTodos();
                if (tipos == null || tipos.Count == 0)
                {
                    MessageBox.Show("Debe registrar al menos un Tipo de Artículo antes de agregar artículos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnRegistrar.Enabled = false;
                    return;
                }

                foreach (var tipo in tipos)
                {
                    cmbTipoArticulo.Items.Add(tipo);
                }

                cmbTipoArticulo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al cargar los tipos de artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegistrar.Enabled = false;
            }
        }

        private void valorArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números, punto decimal, y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // Solo un punto decimal
            var txt = sender as TextBox;
            if (e.KeyChar == '.' && txt != null && txt.Text.IndexOf('.') > -1)
                e.Handled = true;
        }


        private void inventarioArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(idArticulo.Text) ||
                    string.IsNullOrWhiteSpace(nombreArticulo.Text) ||
                    string.IsNullOrWhiteSpace(valorArticulo.Text) ||
                    string.IsNullOrWhiteSpace(inventarioArticulo.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var tipoSeleccionado = cmbTipoArticulo.SelectedItem as Entregas.Entidades.TipoArticulo;
                if (tipoSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un Tipo de Artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbActivo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar si el artículo está activo o no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbActivo.DroppedDown = true;
                    return;
                }

                string resultado = Entregas.Logica.ArticuloLogica.RegistrarArticulo(
                    int.Parse(idArticulo.Text.Trim()),
                    nombreArticulo.Text.Trim(),
                    tipoSeleccionado,
                    valorArticulo.Text.Trim(),
                    inventarioArticulo.Text.Trim(),
                    cmbActivo.SelectedItem?.ToString() == "Sí"
                );

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultado.Contains("correctamente"))
                {
                    idArticulo.Clear();
                    nombreArticulo.Clear();
                    valorArticulo.Clear();
                    inventarioArticulo.Clear();
                    cmbTipoArticulo.SelectedIndex = 0;
                    cmbActivo.SelectedIndex = 0;
                    idArticulo.Focus();
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
