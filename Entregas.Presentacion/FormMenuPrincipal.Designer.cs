namespace Entregas.Presentacion
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            tipoArticuloToolStripMenuItem = new ToolStripMenuItem();
            registrarTipoArticuloToolStripMenuItem = new ToolStripMenuItem();
            consultarTiposDeArticuloToolStripMenuItem = new ToolStripMenuItem();
            articuloToolStripMenuItem = new ToolStripMenuItem();
            registrarArticuloToolStripMenuItem = new ToolStripMenuItem();
            consultarArticulosToolStripMenuItem = new ToolStripMenuItem();
            repartidorToolStripMenuItem = new ToolStripMenuItem();
            registrarRepartidorToolStripMenuItem = new ToolStripMenuItem();
            consultarRepartidoresToolStripMenuItem = new ToolStripMenuItem();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            registrarClienteToolStripMenuItem = new ToolStripMenuItem();
            consultarClientesToolStripMenuItem = new ToolStripMenuItem();
            pedidoToolStripMenuItem = new ToolStripMenuItem();
            registrarPedidoToolStripMenuItem = new ToolStripMenuItem();
            consultarPedidosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tipoArticuloToolStripMenuItem, articuloToolStripMenuItem, repartidorToolStripMenuItem, clienteToolStripMenuItem, pedidoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tipoArticuloToolStripMenuItem
            // 
            tipoArticuloToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarTipoArticuloToolStripMenuItem, consultarTiposDeArticuloToolStripMenuItem });
            tipoArticuloToolStripMenuItem.Name = "tipoArticuloToolStripMenuItem";
            tipoArticuloToolStripMenuItem.Size = new Size(93, 20);
            tipoArticuloToolStripMenuItem.Text = "Tipos Articulo";
            tipoArticuloToolStripMenuItem.Click += tipoArticuloToolStripMenuItem_Click;
            // 
            // registrarTipoArticuloToolStripMenuItem
            // 
            registrarTipoArticuloToolStripMenuItem.Name = "registrarTipoArticuloToolStripMenuItem";
            registrarTipoArticuloToolStripMenuItem.Size = new Size(218, 22);
            registrarTipoArticuloToolStripMenuItem.Text = "Registrar Tipo Articulo";
            registrarTipoArticuloToolStripMenuItem.Click += registrarTipoArticuloToolStripMenuItem_Click;
            // 
            // consultarTiposDeArticuloToolStripMenuItem
            // 
            consultarTiposDeArticuloToolStripMenuItem.Name = "consultarTiposDeArticuloToolStripMenuItem";
            consultarTiposDeArticuloToolStripMenuItem.Size = new Size(218, 22);
            consultarTiposDeArticuloToolStripMenuItem.Text = "Consultar Tipos de Articulo";
            // 
            // articuloToolStripMenuItem
            // 
            articuloToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarArticuloToolStripMenuItem, consultarArticulosToolStripMenuItem });
            articuloToolStripMenuItem.Name = "articuloToolStripMenuItem";
            articuloToolStripMenuItem.Size = new Size(66, 20);
            articuloToolStripMenuItem.Text = "Articulos";
            // 
            // registrarArticuloToolStripMenuItem
            // 
            registrarArticuloToolStripMenuItem.Name = "registrarArticuloToolStripMenuItem";
            registrarArticuloToolStripMenuItem.Size = new Size(175, 22);
            registrarArticuloToolStripMenuItem.Text = "Registrar Articulo";
            // 
            // consultarArticulosToolStripMenuItem
            // 
            consultarArticulosToolStripMenuItem.Name = "consultarArticulosToolStripMenuItem";
            consultarArticulosToolStripMenuItem.Size = new Size(175, 22);
            consultarArticulosToolStripMenuItem.Text = "Consultar Articulos";
            // 
            // repartidorToolStripMenuItem
            // 
            repartidorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarRepartidorToolStripMenuItem, consultarRepartidoresToolStripMenuItem });
            repartidorToolStripMenuItem.Name = "repartidorToolStripMenuItem";
            repartidorToolStripMenuItem.Size = new Size(85, 20);
            repartidorToolStripMenuItem.Text = "Repartidores";
            // 
            // registrarRepartidorToolStripMenuItem
            // 
            registrarRepartidorToolStripMenuItem.Name = "registrarRepartidorToolStripMenuItem";
            registrarRepartidorToolStripMenuItem.Size = new Size(194, 22);
            registrarRepartidorToolStripMenuItem.Text = "Registrar Repartidor";
            // 
            // consultarRepartidoresToolStripMenuItem
            // 
            consultarRepartidoresToolStripMenuItem.Name = "consultarRepartidoresToolStripMenuItem";
            consultarRepartidoresToolStripMenuItem.Size = new Size(194, 22);
            consultarRepartidoresToolStripMenuItem.Text = "Consultar Repartidores";
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarClienteToolStripMenuItem, consultarClientesToolStripMenuItem });
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(61, 20);
            clienteToolStripMenuItem.Text = "Clientes";
            // 
            // registrarClienteToolStripMenuItem
            // 
            registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            registrarClienteToolStripMenuItem.Size = new Size(170, 22);
            registrarClienteToolStripMenuItem.Text = "Registrar Cliente";
            // 
            // consultarClientesToolStripMenuItem
            // 
            consultarClientesToolStripMenuItem.Name = "consultarClientesToolStripMenuItem";
            consultarClientesToolStripMenuItem.Size = new Size(170, 22);
            consultarClientesToolStripMenuItem.Text = "Consultar Clientes";
            // 
            // pedidoToolStripMenuItem
            // 
            pedidoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarPedidoToolStripMenuItem, consultarPedidosToolStripMenuItem });
            pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            pedidoToolStripMenuItem.Size = new Size(61, 20);
            pedidoToolStripMenuItem.Text = "Pedidos";
            pedidoToolStripMenuItem.Click += pedidoToolStripMenuItem_Click;
            // 
            // registrarPedidoToolStripMenuItem
            // 
            registrarPedidoToolStripMenuItem.Name = "registrarPedidoToolStripMenuItem";
            registrarPedidoToolStripMenuItem.Size = new Size(170, 22);
            registrarPedidoToolStripMenuItem.Text = "Registrar Pedido";
            // 
            // consultarPedidosToolStripMenuItem
            // 
            consultarPedidosToolStripMenuItem.Name = "consultarPedidosToolStripMenuItem";
            consultarPedidosToolStripMenuItem.Size = new Size(170, 22);
            consultarPedidosToolStripMenuItem.Text = "Consultar Pedidos";
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenuPrincipal";
            Text = "FormMenuPrincipal";
            Load += FormMenuPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tipoArticuloToolStripMenuItem;
        private ToolStripMenuItem articuloToolStripMenuItem;
        private ToolStripMenuItem repartidorToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem pedidoToolStripMenuItem;
        private ToolStripMenuItem registrarTipoArticuloToolStripMenuItem;
        private ToolStripMenuItem consultarTiposDeArticuloToolStripMenuItem;
        private ToolStripMenuItem registrarArticuloToolStripMenuItem;
        private ToolStripMenuItem consultarArticulosToolStripMenuItem;
        private ToolStripMenuItem registrarRepartidorToolStripMenuItem;
        private ToolStripMenuItem consultarRepartidoresToolStripMenuItem;
        private ToolStripMenuItem registrarClienteToolStripMenuItem;
        private ToolStripMenuItem consultarClientesToolStripMenuItem;
        private ToolStripMenuItem registrarPedidoToolStripMenuItem;
        private ToolStripMenuItem consultarPedidosToolStripMenuItem;
    }
}