
namespace LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature
{
    partial class TabelaTaxaServicoControl
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
            this.dgTaxas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTaxas
            // 
            this.dgTaxas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaxas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaxas.Location = new System.Drawing.Point(0, 0);
            this.dgTaxas.Name = "dgTaxas";
            this.dgTaxas.RowHeadersVisible = false;
            this.dgTaxas.Size = new System.Drawing.Size(728, 576);
            this.dgTaxas.TabIndex = 0;
            // 
            // TabelaTaxaServicoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgTaxas);
            this.Name = "TabelaTaxaServicoControl";
            this.Size = new System.Drawing.Size(728, 576);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTaxas;
    }
}
