
namespace LocadoraVeiculo.WindowsApp.Features.ParceiroFeature
{
    partial class TabelaParceiroControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvParceiros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParceiros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParceiros
            // 
            this.dgvParceiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParceiros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParceiros.Location = new System.Drawing.Point(0, 0);
            this.dgvParceiros.Name = "dgvParceiros";
            this.dgvParceiros.RowHeadersVisible = false;
            this.dgvParceiros.Size = new System.Drawing.Size(498, 443);
            this.dgvParceiros.TabIndex = 0;
            // 
            // TabelaParceiroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvParceiros);
            this.Name = "TabelaParceiroControl";
            this.Size = new System.Drawing.Size(498, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParceiros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParceiros;
    }
}
