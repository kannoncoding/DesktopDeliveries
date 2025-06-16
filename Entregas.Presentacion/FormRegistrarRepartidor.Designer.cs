namespace Entregas.Presentacion
{
    partial class FormRegistrarRepartidor
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
            label6 = new Label();
            label7 = new Label();
            idRepartidor = new TextBox();
            nombreRepartidor = new TextBox();
            primerApellidoRepartidor = new TextBox();
            segundoApellidoRepartidor = new TextBox();
            dtpNacimientoRepartidor = new DateTimePicker();
            dtpContratacionRepartidor = new DateTimePicker();
            cmbActivo = new ComboBox();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "ID Repartidor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre Repartidor";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(147, 15);
            label3.TabIndex = 2;
            label3.Text = "Primer Apellido Repartidor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 107);
            label4.Name = "label4";
            label4.Size = new Size(159, 15);
            label4.TabIndex = 3;
            label4.Text = "Segundo Apellido Repartidor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 146);
            label5.Name = "label5";
            label5.Size = new Size(161, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha Nacimiento Repartidor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 220);
            label6.Name = "label6";
            label6.Size = new Size(168, 15);
            label6.TabIndex = 5;
            label6.Text = "Fecha Contratacion Repartidor";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 298);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 6;
            label7.Text = "Activo?";
            label7.Click += label7_Click;
            // 
            // idRepartidor
            // 
            idRepartidor.Location = new Point(94, 6);
            idRepartidor.Name = "idRepartidor";
            idRepartidor.Size = new Size(118, 23);
            idRepartidor.TabIndex = 7;
            idRepartidor.KeyPress += idRepartidor_KeyPress;
            // 
            // nombreRepartidor
            // 
            nombreRepartidor.Location = new Point(127, 35);
            nombreRepartidor.Name = "nombreRepartidor";
            nombreRepartidor.Size = new Size(202, 23);
            nombreRepartidor.TabIndex = 8;
            // 
            // primerApellidoRepartidor
            // 
            primerApellidoRepartidor.Location = new Point(165, 68);
            primerApellidoRepartidor.Name = "primerApellidoRepartidor";
            primerApellidoRepartidor.Size = new Size(164, 23);
            primerApellidoRepartidor.TabIndex = 9;
            // 
            // segundoApellidoRepartidor
            // 
            segundoApellidoRepartidor.Location = new Point(177, 104);
            segundoApellidoRepartidor.Name = "segundoApellidoRepartidor";
            segundoApellidoRepartidor.Size = new Size(152, 23);
            segundoApellidoRepartidor.TabIndex = 10;
            // 
            // dtpNacimientoRepartidor
            // 
            dtpNacimientoRepartidor.Location = new Point(12, 164);
            dtpNacimientoRepartidor.Name = "dtpNacimientoRepartidor";
            dtpNacimientoRepartidor.Size = new Size(200, 23);
            dtpNacimientoRepartidor.TabIndex = 11;
            // 
            // dtpContratacionRepartidor
            // 
            dtpContratacionRepartidor.Location = new Point(12, 238);
            dtpContratacionRepartidor.Name = "dtpContratacionRepartidor";
            dtpContratacionRepartidor.Size = new Size(200, 23);
            dtpContratacionRepartidor.TabIndex = 12;
            // 
            // cmbActivo
            // 
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(12, 316);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(200, 23);
            cmbActivo.TabIndex = 13;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(526, 415);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(262, 23);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar Repartidor";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // FormRegistrarRepartidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistrar);
            Controls.Add(cmbActivo);
            Controls.Add(dtpContratacionRepartidor);
            Controls.Add(dtpNacimientoRepartidor);
            Controls.Add(segundoApellidoRepartidor);
            Controls.Add(primerApellidoRepartidor);
            Controls.Add(nombreRepartidor);
            Controls.Add(idRepartidor);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormRegistrarRepartidor";
            Text = "FormRegistrarRepartidor";
            Load += FormRegistrarRepartidor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox idRepartidor;
        private TextBox nombreRepartidor;
        private TextBox primerApellidoRepartidor;
        private TextBox segundoApellidoRepartidor;
        private DateTimePicker dtpNacimientoRepartidor;
        private DateTimePicker dtpContratacionRepartidor;
        private ComboBox cmbActivo;
        private Button btnRegistrar;
    }
}