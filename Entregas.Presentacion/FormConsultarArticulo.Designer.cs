namespace Entregas.Presentacion
{
    partial class FormConsultarArticulo
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
            dgvConsultarArticulo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultarArticulo).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultarArticulo
            // 
            dgvConsultarArticulo.AllowUserToAddRows = false;
            dgvConsultarArticulo.AllowUserToDeleteRows = false;
            dgvConsultarArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultarArticulo.Location = new Point(12, 12);
            dgvConsultarArticulo.Name = "dgvConsultarArticulo";
            dgvConsultarArticulo.ReadOnly = true;
            dgvConsultarArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultarArticulo.Size = new Size(776, 426);
            dgvConsultarArticulo.TabIndex = 0;
            // 
            // FormConsultarArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultarArticulo);
            Name = "FormConsultarArticulo";
            Text = "FormConsultarArticulo";
            Load += FormConsultarArticulo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultarArticulo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultarArticulo;
    }
}