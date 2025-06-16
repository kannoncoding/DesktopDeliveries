namespace Entregas.Presentacion
{
    partial class FormConsultarTipoArticulo
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
            dgvConsultarTipoArticulo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultarTipoArticulo).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultarTipoArticulo
            // 
            dgvConsultarTipoArticulo.AllowUserToAddRows = false;
            dgvConsultarTipoArticulo.AllowUserToDeleteRows = false;
            dgvConsultarTipoArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultarTipoArticulo.Location = new Point(12, 12);
            dgvConsultarTipoArticulo.Name = "dgvConsultarTipoArticulo";
            dgvConsultarTipoArticulo.ReadOnly = true;
            dgvConsultarTipoArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultarTipoArticulo.Size = new Size(776, 426);
            dgvConsultarTipoArticulo.TabIndex = 0;
            // 
            // FormConsultarTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultarTipoArticulo);
            Name = "FormConsultarTipoArticulo";
            Text = "FormConsultarTipoArticulo";
            Load += FormConsultarTipoArticulo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultarTipoArticulo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultarTipoArticulo;
    }
}