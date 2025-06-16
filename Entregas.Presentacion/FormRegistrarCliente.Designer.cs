namespace Entregas.Presentacion
{
    partial class FormRegistrarCliente
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
            btnRegistrar = new Button();
            idCliente = new TextBox();
            nombreCliente = new TextBox();
            dtpNacimientoCliente = new DateTimePicker();
            cmbActivo = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            primerApellidoCliente = new TextBox();
            segundoApellidoCliente = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "ID Cliente";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre Cliente";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 156);
            label3.Name = "label3";
            label3.Size = new Size(159, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha de Nacimiento Cliente";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 209);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 3;
            label4.Text = "Activo?";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(620, 415);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(168, 23);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar Cliente";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // idCliente
            // 
            idCliente.Location = new Point(76, 6);
            idCliente.Name = "idCliente";
            idCliente.Size = new Size(136, 23);
            idCliente.TabIndex = 5;
            idCliente.KeyPress += idCliente_KeyPress;
            // 
            // nombreCliente
            // 
            nombreCliente.Location = new Point(109, 37);
            nombreCliente.Name = "nombreCliente";
            nombreCliente.Size = new Size(359, 23);
            nombreCliente.TabIndex = 6;
            // 
            // dtpNacimientoCliente
            // 
            dtpNacimientoCliente.Location = new Point(12, 174);
            dtpNacimientoCliente.Name = "dtpNacimientoCliente";
            dtpNacimientoCliente.Size = new Size(200, 23);
            dtpNacimientoCliente.TabIndex = 7;
            // 
            // cmbActivo
            // 
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(12, 227);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(200, 23);
            cmbActivo.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 81);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 9;
            label5.Text = "Primer Apellido Cliente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 117);
            label6.Name = "label6";
            label6.Size = new Size(141, 15);
            label6.TabIndex = 10;
            label6.Text = "Segundo Apellido Cliente";
            // 
            // primerApellidoCliente
            // 
            primerApellidoCliente.Location = new Point(147, 78);
            primerApellidoCliente.Name = "primerApellidoCliente";
            primerApellidoCliente.Size = new Size(321, 23);
            primerApellidoCliente.TabIndex = 11;
            // 
            // segundoApellidoCliente
            // 
            segundoApellidoCliente.Location = new Point(159, 114);
            segundoApellidoCliente.Name = "segundoApellidoCliente";
            segundoApellidoCliente.Size = new Size(309, 23);
            segundoApellidoCliente.TabIndex = 12;
            // 
            // FormRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(segundoApellidoCliente);
            Controls.Add(primerApellidoCliente);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbActivo);
            Controls.Add(dtpNacimientoCliente);
            Controls.Add(nombreCliente);
            Controls.Add(idCliente);
            Controls.Add(btnRegistrar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormRegistrarCliente";
            Text = "FormRegistrarCliente";
            Load += FormRegistrarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnRegistrar;
        private TextBox idCliente;
        private TextBox nombreCliente;
        private DateTimePicker dtpNacimientoCliente;
        private ComboBox cmbActivo;
        private Label label5;
        private Label label6;
        private TextBox primerApellidoCliente;
        private TextBox segundoApellidoCliente;
    }
}