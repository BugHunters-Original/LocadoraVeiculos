
namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    partial class TabelaDescontoControl
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
            this.gridDesconto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesconto)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDesconto
            // 
            this.gridDesconto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDesconto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDesconto.Location = new System.Drawing.Point(0, 0);
            this.gridDesconto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridDesconto.Name = "gridDesconto";
            this.gridDesconto.RowHeadersVisible = false;
            this.gridDesconto.RowHeadersWidth = 51;
            this.gridDesconto.RowTemplate.Height = 24;
            this.gridDesconto.Size = new System.Drawing.Size(452, 386);
            this.gridDesconto.TabIndex = 0;
            // 
            // TabelaDescontoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDesconto);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TabelaDescontoControl";
            this.Size = new System.Drawing.Size(452, 386);
            ((System.ComponentModel.ISupportInitialize)(this.gridDesconto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDesconto;
    }
}
