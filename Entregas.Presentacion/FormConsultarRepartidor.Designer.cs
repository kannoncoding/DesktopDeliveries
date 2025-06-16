namespace Entregas.Presentacion
{
    partial class FormConsultarRepartidor
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
            dgvConsultarRepartidor = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultarRepartidor).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultarRepartidor
            // 
            dgvConsultarRepartidor.AllowUserToAddRows = false;
            dgvConsultarRepartidor.AllowUserToDeleteRows = false;
            dgvConsultarRepartidor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultarRepartidor.ImeMode = ImeMode.NoControl;
            dgvConsultarRepartidor.Location = new Point(12, 12);
            dgvConsultarRepartidor.Name = "dgvConsultarRepartidor";
            dgvConsultarRepartidor.ReadOnly = true;
            dgvConsultarRepartidor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultarRepartidor.Size = new Size(776, 426);
            dgvConsultarRepartidor.TabIndex = 0;
            // 
            // FormConsultarRepartidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultarRepartidor);
            Name = "FormConsultarRepartidor";
            Text = "FormConsultarRepartidor";
            Load += FormConsultarRepartidor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultarRepartidor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultarRepartidor;
    }
}