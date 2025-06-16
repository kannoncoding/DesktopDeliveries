namespace Entregas.Presentacion
{
    partial class FormRegistrarPedido
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnRegistrar = new Button();
            numeroPedido = new TextBox();
            dtpFechaPedido = new DateTimePicker();
            cmbCliente = new ComboBox();
            cmbRepartidor = new ComboBox();
            direccionPedido = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dgvDetalles = new DataGridView();
            cmbArticulo = new ComboBox();
            nudCantidad = new NumericUpDown();
            btnAgregarDetalle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Numero de Pedido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Fecha de Pedido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 64);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 2;
            label3.Text = "Cliente del Pedido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 92);
            label4.Name = "label4";
            label4.Size = new Size(121, 15);
            label4.TabIndex = 3;
            label4.Text = "Repartidor del Pedido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 120);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 4;
            label5.Text = "Direccion del Pedido";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(628, 415);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(160, 23);
            btnRegistrar.TabIndex = 5;
            btnRegistrar.Text = "Registrar Pedido";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // numeroPedido
            // 
            numeroPedido.Location = new Point(125, 6);
            numeroPedido.Name = "numeroPedido";
            numeroPedido.Size = new Size(240, 23);
            numeroPedido.TabIndex = 6;
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(112, 31);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(200, 23);
            dtpFechaPedido.TabIndex = 7;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(121, 60);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 8;
            // 
            // cmbRepartidor
            // 
            cmbRepartidor.FormattingEnabled = true;
            cmbRepartidor.Location = new Point(139, 89);
            cmbRepartidor.Name = "cmbRepartidor";
            cmbRepartidor.Size = new Size(121, 23);
            cmbRepartidor.TabIndex = 9;
            // 
            // direccionPedido
            // 
            direccionPedido.Location = new Point(134, 117);
            direccionPedido.Name = "direccionPedido";
            direccionPedido.Size = new Size(100, 23);
            direccionPedido.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 179);
            label6.Name = "label6";
            label6.Size = new Size(110, 15);
            label6.TabIndex = 11;
            label6.Text = "Detalles del Pedido:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 207);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 12;
            label7.Text = "Articulo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 234);
            label8.Name = "label8";
            label8.Size = new Size(119, 15);
            label8.TabIndex = 13;
            label8.Text = "Cantidad del Articulo";
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(12, 263);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(353, 122);
            dgvDetalles.TabIndex = 14;
            // 
            // cmbArticulo
            // 
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(70, 204);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(121, 23);
            cmbArticulo.TabIndex = 15;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(137, 232);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 16;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(12, 391);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(353, 23);
            btnAgregarDetalle.TabIndex = 17;
            btnAgregarDetalle.Text = "Agregar Detalle al Pedido";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // FormRegistrarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAgregarDetalle);
            Controls.Add(nudCantidad);
            Controls.Add(cmbArticulo);
            Controls.Add(dgvDetalles);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(direccionPedido);
            Controls.Add(cmbRepartidor);
            Controls.Add(cmbCliente);
            Controls.Add(dtpFechaPedido);
            Controls.Add(numeroPedido);
            Controls.Add(btnRegistrar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormRegistrarPedido";
            Text = "FormRegistrarPedido";
            Load += FormRegistrarPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnRegistrar;
        private TextBox numeroPedido;
        private DateTimePicker dtpFechaPedido;
        private ComboBox cmbCliente;
        private ComboBox cmbRepartidor;
        private TextBox direccionPedido;
        private Label label6;
        private Label label7;
        private Label label8;
        private DataGridView dgvDetalles;
        private ComboBox cmbArticulo;
        private NumericUpDown nudCantidad;
        private Button btnAgregarDetalle;
    }
}