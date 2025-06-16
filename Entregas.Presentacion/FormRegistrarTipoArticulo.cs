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
using Entregas.Logica;


namespace Entregas.Presentacion
{
    public partial class FormRegistrarTipoArticulo : Form
    {
        public FormRegistrarTipoArticulo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el campo Id no esté vacío y sea numérico positivo
                if (string.IsNullOrWhiteSpace(idTipo.Text))
                {
                    MessageBox.Show("El campo 'Tipo ID' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idTipo.Focus();
                    return;
                }

                int id;
                if (!int.TryParse(idTipo.Text.Trim(), out id) || id <= 0)
                {
                    MessageBox.Show("El campo 'Tipo ID' debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idTipo.Focus();
                    return;
                }

                // Validar campos de texto obligatorios
                string nombre = nombreTipo.Text.Trim();
                string descripcion = descripcionTipo.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El campo 'Nombre de Tipo' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreTipo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    MessageBox.Show("El campo 'Descripción del Tipo' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    descripcionTipo.Focus();
                    return;
                }

                // Llamar la lógica de negocio
                string resultado = Entregas.Logica.TipoArticuloLogica.RegistrarTipoArticulo(id, nombre, descripcion);

                // Mostrar el mensaje que devuelve la lógica (éxito o error)
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si es éxito, limpiar campos
                if (resultado == "El registro se ha ingresado correctamente.")
                {
                    idTipo.Clear();
                    nombreTipo.Clear();
                    descripcionTipo.Clear();
                    idTipo.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado. Por favor intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormRegistrarTipoArticulo_Load(object sender, EventArgs e)
        {

        }
    }
}
