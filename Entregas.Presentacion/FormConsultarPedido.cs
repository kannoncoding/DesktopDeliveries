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

using Entregas.Entidades;
using Entregas.Datos;

namespace Entregas.Presentacion
{
    public partial class FormConsultarPedido : Form
    {
        public FormConsultarPedido()
        {
            InitializeComponent();
        }

        private void FormConsultarPedido_Load(object sender, EventArgs e)
        {
            ConfigurarGrids();
            CargarPedidos();
            dgvDetallePedido.Rows.Clear(); // El detalle inicia vacío
        }

        private void ConfigurarGrids()
        {
            // Configurar el grid de pedidos (encabezados)
            dgvPedidos.Columns.Clear();
            dgvPedidos.ReadOnly = true;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPedidos.Columns.Add("NumeroPedido", "Número de Pedido");
            dgvPedidos.Columns.Add("FechaPedido", "Fecha Pedido");
            dgvPedidos.Columns.Add("ClienteId", "Cliente ID");
            dgvPedidos.Columns.Add("ClienteNombre", "Cliente Nombre");
            dgvPedidos.Columns.Add("ClientePrimerApellido", "Cliente 1° Apellido");
            dgvPedidos.Columns.Add("ClienteSegundoApellido", "Cliente 2° Apellido");
            dgvPedidos.Columns.Add("RepartidorId", "Repartidor ID");
            dgvPedidos.Columns.Add("RepartidorNombre", "Repartidor Nombre");
            dgvPedidos.Columns.Add("RepartidorPrimerApellido", "Repartidor 1° Apellido");
            dgvPedidos.Columns.Add("RepartidorSegundoApellido", "Repartidor 2° Apellido");
            dgvPedidos.Columns.Add("Direccion", "Dirección");

            // Configurar el grid de detalle de pedidos
            dgvDetallePedido.Columns.Clear();
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.AllowUserToDeleteRows = false;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDetallePedido.Columns.Add("ArticuloId", "Artículo ID");
            dgvDetallePedido.Columns.Add("ArticuloNombre", "Artículo");
            dgvDetallePedido.Columns.Add("TipoArticulo", "Tipo de Artículo");
            dgvDetallePedido.Columns.Add("Cantidad", "Cantidad");
            dgvDetallePedido.Columns.Add("Monto", "Monto");
        }

        private void CargarPedidos()
        {
            dgvPedidos.Rows.Clear();
            var pedidos = PedidoDatos.ObtenerTodosLosPedidos(); // Debe retornar el arreglo de pedidos

            foreach (var pedido in pedidos)
            {
                if (pedido != null)
                {
                    dgvPedidos.Rows.Add(
                        pedido.NumeroPedido,
                        pedido.FechaPedido.ToString("dd/MM/yyyy"),
                        pedido.Cliente.Identificacion,
                        pedido.Cliente.Nombre,
                        pedido.Cliente.PrimerApellido,
                        pedido.Cliente.SegundoApellido,
                        pedido.Repartidor.Identificacion,
                        pedido.Repartidor.Nombre,
                        pedido.Repartidor.PrimerApellido,
                        pedido.Repartidor.SegundoApellido,
                        pedido.Direccion
                    );
                }
            }
        }

        // Evento para actualizar detalle al seleccionar un pedido
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            dgvDetallePedido.Rows.Clear();

            if (dgvPedidos.SelectedRows.Count > 0)
            {
                var fila = dgvPedidos.SelectedRows[0];
                int numeroPedido;

                // Intentar obtener el número de pedido de la fila seleccionada
                if (int.TryParse(fila.Cells["NumeroPedido"].Value?.ToString(), out numeroPedido))
                {
                    CargarDetallePedido(numeroPedido);
                }
            }
        }

        private void CargarDetallePedido(int numeroPedido)
        {
            dgvDetallePedido.Rows.Clear();
            var detalles = DetallePedidoDatos.ObtenerDetallesPorPedido(numeroPedido);

            foreach (var det in detalles)
            {
                if (det != null)
                {
                    string tipoNombre = det.Articulo?.TipoArticulo != null
                        ? det.Articulo.TipoArticulo.Nombre
                        : "";
                    string montoFormateado = "₡" + det.Monto.ToString("N2");

                    dgvDetallePedido.Rows.Add(
                        det.Articulo?.Id ?? 0,
                        det.Articulo?.Nombre ?? "",
                        tipoNombre,
                        det.Cantidad,
                        montoFormateado
                    );
                }
            }
        }
    }
}
