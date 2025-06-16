namespace Entregas.Presentacion
{
    partial class FormConsultarCliente
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
            dgvConsultarCliente = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultarCliente).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultarCliente
            // 
            dgvConsultarCliente.AllowUserToAddRows = false;
            dgvConsultarCliente.AllowUserToDeleteRows = false;
            dgvConsultarCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultarCliente.Location = new Point(12, 12);
            dgvConsultarCliente.Name = "dgvConsultarCliente";
            dgvConsultarCliente.ReadOnly = true;
            dgvConsultarCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultarCliente.Size = new Size(776, 426);
            dgvConsultarCliente.TabIndex = 0;
            // 
            // FormConsultarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultarCliente);
            Name = "FormConsultarCliente";
            Text = "FormConsultarCliente";
            Load += FormConsultarCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultarCliente).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultarCliente;
    }
}