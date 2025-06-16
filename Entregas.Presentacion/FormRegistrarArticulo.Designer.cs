namespace Entregas.Presentacion
{
    partial class FormRegistrarArticulo
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
            idArticulo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            nombreArticulo = new TextBox();
            valorArticulo = new TextBox();
            inventarioArticulo = new TextBox();
            cmbTipoArticulo = new ComboBox();
            cmbActivo = new ComboBox();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // idArticulo
            // 
            idArticulo.Location = new Point(81, 6);
            idArticulo.Name = "idArticulo";
            idArticulo.Size = new Size(411, 23);
            idArticulo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "ID Articulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre Articulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 94);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 3;
            label3.Text = "Valor Articulo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 142);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 4;
            label4.Text = "Inventario";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 192);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 5;
            label5.Text = "Tipo de Articulo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 240);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 6;
            label6.Text = "Activo?";
            // 
            // nombreArticulo
            // 
            nombreArticulo.Location = new Point(114, 46);
            nombreArticulo.Name = "nombreArticulo";
            nombreArticulo.Size = new Size(378, 23);
            nombreArticulo.TabIndex = 7;
            // 
            // valorArticulo
            // 
            valorArticulo.Location = new Point(96, 91);
            valorArticulo.Name = "valorArticulo";
            valorArticulo.Size = new Size(135, 23);
            valorArticulo.TabIndex = 8;
            valorArticulo.KeyPress += valorArticulo_KeyPress;
            // 
            // inventarioArticulo
            // 
            inventarioArticulo.Location = new Point(78, 139);
            inventarioArticulo.Name = "inventarioArticulo";
            inventarioArticulo.Size = new Size(153, 23);
            inventarioArticulo.TabIndex = 9;
            inventarioArticulo.KeyPress += inventarioArticulo_KeyPress;
            // 
            // cmbTipoArticulo
            // 
            cmbTipoArticulo.FormattingEnabled = true;
            cmbTipoArticulo.Location = new Point(110, 189);
            cmbTipoArticulo.Name = "cmbTipoArticulo";
            cmbTipoArticulo.Size = new Size(121, 23);
            cmbTipoArticulo.TabIndex = 12;
            // 
            // cmbActivo
            // 
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(64, 237);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(167, 23);
            cmbActivo.TabIndex = 13;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(648, 415);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(140, 23);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar Articulo";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // FormRegistrarArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistrar);
            Controls.Add(cmbActivo);
            Controls.Add(cmbTipoArticulo);
            Controls.Add(inventarioArticulo);
            Controls.Add(valorArticulo);
            Controls.Add(nombreArticulo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(idArticulo);
            Name = "FormRegistrarArticulo";
            Text = "FormRegistrarArticulo";
            Load += FormRegistrarArticulo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idArticulo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox nombreArticulo;
        private TextBox valorArticulo;
        private TextBox inventarioArticulo;
        private ComboBox cmbTipoArticulo;
        private ComboBox cmbActivo;
        private Button btnRegistrar;
    }
}