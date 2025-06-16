namespace Entregas.Presentacion
{
    partial class FormRegistrarTipoArticulo
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
            id = new Label();
            idTipo = new TextBox();
            nombreTipotxt = new Label();
            nombreTipo = new TextBox();
            descripcionTipotxt = new Label();
            descripcionTipo = new TextBox();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(12, 9);
            id.Name = "id";
            id.Size = new Size(45, 15);
            id.TabIndex = 0;
            id.Text = "Tipo ID";
            id.Click += label1_Click;
            // 
            // idTipo
            // 
            idTipo.Location = new Point(63, 1);
            idTipo.Name = "idTipo";
            idTipo.Size = new Size(519, 23);
            idTipo.TabIndex = 1;
            // 
            // nombreTipotxt
            // 
            nombreTipotxt.AutoSize = true;
            nombreTipotxt.Location = new Point(12, 52);
            nombreTipotxt.Name = "nombreTipotxt";
            nombreTipotxt.Size = new Size(94, 15);
            nombreTipotxt.TabIndex = 2;
            nombreTipotxt.Text = "Nombre de Tipo";
            // 
            // nombreTipo
            // 
            nombreTipo.Location = new Point(112, 49);
            nombreTipo.Name = "nombreTipo";
            nombreTipo.Size = new Size(470, 23);
            nombreTipo.TabIndex = 3;
            // 
            // descripcionTipotxt
            // 
            descripcionTipotxt.AutoSize = true;
            descripcionTipotxt.Location = new Point(12, 96);
            descripcionTipotxt.Name = "descripcionTipotxt";
            descripcionTipotxt.Size = new Size(115, 15);
            descripcionTipotxt.TabIndex = 4;
            descripcionTipotxt.Text = "Descripcion del Tipo";
            // 
            // descripcionTipo
            // 
            descripcionTipo.Location = new Point(133, 93);
            descripcionTipo.Name = "descripcionTipo";
            descripcionTipo.Size = new Size(449, 23);
            descripcionTipo.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(591, 415);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(197, 23);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrar Tipo de Articulo";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // FormRegistrarTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistrar);
            Controls.Add(descripcionTipo);
            Controls.Add(descripcionTipotxt);
            Controls.Add(nombreTipo);
            Controls.Add(nombreTipotxt);
            Controls.Add(idTipo);
            Controls.Add(id);
            Name = "FormRegistrarTipoArticulo";
            Text = "FormRegistrarTipoArticulo";
            Load += FormRegistrarTipoArticulo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label id;
        private TextBox idTipo;
        private Label nombreTipotxt;
        private TextBox nombreTipo;
        private Label descripcionTipotxt;
        private TextBox descripcionTipo;
        private Button btnRegistrar;
    }
}