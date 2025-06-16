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
    public partial class FormRegistrarPedido : Form
    {
        private int? currentPedidoNum = null; // Guarda el número del pedido creado
        public FormRegistrarPedido()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormRegistrarPedido_Load(object sender, EventArgs e)
        {
            try
            {
                // Fecha de pedido solo hoy en adelante
                dtpFechaPedido.Format = DateTimePickerFormat.Short;
                dtpFechaPedido.MinDate = DateTime.Today;
                dtpFechaPedido.Value = DateTime.Today;

                // ComboBoxes modo selección
                cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbRepartidor.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbArticulo.DropDownStyle = ComboBoxStyle.DropDownList;

                // Cargar clientes activos
                var clientes = Entregas.Logica.ClienteLogica.ObtenerTodos()
                                .Where(c => c != null && c.Activo)
                                .ToArray();
                if (clientes.Length == 0)
                {
                    MessageBox.Show("Debe haber al menos un cliente registrado para crear un pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = false;
                    return;
                }
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "NombreCompleto"; // Requiere propiedad en entidad Cliente


                // Cargar repartidores activos
                var repartidores = Entregas.Logica.RepartidorLogica.ObtenerTodos()
                                    .Where(r => r != null && r.Activo)
                                    .ToArray();
                if (repartidores.Length == 0)
                {
                    MessageBox.Show("Debe haber al menos un repartidor registrado para crear un pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = false;
                    return;
                }
                cmbRepartidor.DataSource = repartidores;
                cmbRepartidor.DisplayMember = "NombreCompleto"; // Requiere propiedad en entidad Repartidor


                // Cargar artículos activos
                var articulos = Entregas.Logica.ArticuloLogica.ObtenerTodos()
                                 .Where(a => a != null && a.Activo)
                                 .ToArray();
                if (articulos.Length == 0)
                {
                    MessageBox.Show("Debe haber al menos un artículo activo para crear un pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = false;
                    return;
                }
                cmbArticulo.DataSource = articulos;
                cmbArticulo.DisplayMember = "Nombre";

                // NumericUpDown para cantidad (mínimo 1)
                nudCantidad.Minimum = 1;
                nudCantidad.Maximum = 1000;
                nudCantidad.Value = 1;

                // DataGridView configuración
                dgvDetalles.ReadOnly = true;
                dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDetalles.Columns.Clear();
                dgvDetalles.Columns.Add("IdArticulo", "ID Artículo");
                dgvDetalles.Columns.Add("NombreArticulo", "Nombre");
                dgvDetalles.Columns.Add("TipoArticulo", "Tipo");
                dgvDetalles.Columns.Add("Cantidad", "Cantidad");
                dgvDetalles.Columns.Add("Monto", "Monto");

                // Deshabilitar sección de detalle hasta que se registre el encabezado
                HabilitarDetalle(false);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al inicializar el formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
            }
        }

        // Función auxiliar para habilitar/deshabilitar sección detalle
        private void HabilitarDetalle(bool habilitar)
        {
            cmbArticulo.Enabled = habilitar;
            nudCantidad.Enabled = habilitar;
            btnAgregarDetalle.Enabled = habilitar;
            dgvDetalles.Enabled = habilitar;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones de encabezado
                if (string.IsNullOrWhiteSpace(numeroPedido.Text) ||
                    cmbCliente.SelectedIndex == -1 ||
                    cmbRepartidor.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(direccionPedido.Text))
                {
                    MessageBox.Show("Todos los campos del encabezado son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(numeroPedido.Text.Trim(), out int numPedido))
                {
                    MessageBox.Show("El número de pedido debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numeroPedido.Focus();
                    return;
                }

                DateTime fechaPedido = dtpFechaPedido.Value.Date;
                if (fechaPedido < DateTime.Today)
                {
                    MessageBox.Show("La fecha del pedido no puede ser anterior a hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cliente = (Entregas.Entidades.Cliente)cmbCliente.SelectedItem!;
                var repartidor = (Entregas.Entidades.Repartidor)cmbRepartidor.SelectedItem!;
                string direccion = direccionPedido.Text.Trim();

                string resultado = Entregas.Logica.PedidoLogica.RegistrarPedido(
                    numPedido, fechaPedido, cliente, repartidor, direccion);

                if (!resultado.Contains("correctamente"))
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Encabezado de pedido registrado correctamente. Ahora agregue los artículos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar número de pedido actual
                currentPedidoNum = numPedido;

                // Deshabilitar campos de encabezado
                numeroPedido.Enabled = false;
                dtpFechaPedido.Enabled = false;
                cmbCliente.Enabled = false;
                cmbRepartidor.Enabled = false;
                direccionPedido.Enabled = false;
                btnRegistrar.Enabled = false;

                // Habilitar detalles
                HabilitarDetalle(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al crear el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPedidoNum == null)
                {
                    MessageBox.Show("Debe registrar primero el encabezado del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbArticulo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbArticulo.DroppedDown = true;
                    return;
                }

                int cantidad = (int)nudCantidad.Value;
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var articulo = (Entregas.Entidades.Articulo)cmbArticulo.SelectedItem!;

                string resultado = Entregas.Logica.PedidoLogica.AgregarDetalleAPedido(
                    currentPedidoNum.Value, articulo, cantidad);

                if (!resultado.Contains("correctamente"))
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el último detalle agregado (puedes adaptar según tu lógica)
                var detalles = Entregas.Logica.PedidoLogica.ObtenerDetallesPorPedido(currentPedidoNum.Value);
                var ultimoDetalle = detalles.LastOrDefault();

                // Mostrar en DataGridView
                if (ultimoDetalle != null)
                {
                    dgvDetalles.Rows.Add(
                        ultimoDetalle.Articulo.Id,
                        ultimoDetalle.Articulo.Nombre,
                        ultimoDetalle.Articulo.TipoArticulo.Nombre,
                        ultimoDetalle.Cantidad,
                        ultimoDetalle.Monto.ToString("N2")
                    );
                }

                // Si el artículo quedó sin inventario, actualiza ComboBox
                if (!articulo.Activo)
                {
                    // Refresca el DataSource para ocultar artículos inactivos
                    var articulos = Entregas.Logica.ArticuloLogica.ObtenerTodos()
                                     .Where(a => a != null && a.Activo)
                                     .ToArray();
                    cmbArticulo.DataSource = null;
                    cmbArticulo.DataSource = articulos;
                    cmbArticulo.DisplayMember = "Nombre";
                }

                // Resetear selección para nuevo detalle
                cmbArticulo.SelectedIndex = -1;
                nudCantidad.Value = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el detalle al pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
