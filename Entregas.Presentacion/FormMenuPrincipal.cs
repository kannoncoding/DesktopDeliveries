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
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        // Registrar
        private void registrarTipoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarTipoArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarCliente())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarRepartidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarRepartidor())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarPedido())
            {
                frm.ShowDialog(this);
            }
        }

        // Consultar
        private void consultarTipoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarTipoArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarCliente())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarRepartidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarRepartidor())
            {
                frm.ShowDialog(this);
            }
        }

        private void consultarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormConsultarPedido())
            {
                frm.ShowDialog(this);
            }
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o mostrar bienvenida.
        }
    }
}
