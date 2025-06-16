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

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tipoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarTipoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistrarTipoArticulo())
            {
                frm.ShowDialog(this);
            }
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
