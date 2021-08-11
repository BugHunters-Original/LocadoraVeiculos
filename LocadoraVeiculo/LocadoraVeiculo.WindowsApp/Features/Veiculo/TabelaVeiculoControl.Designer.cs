
namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    partial class TabelaVeiculoControl
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
            this.gridVeiculos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVeiculos
            // 
            this.gridVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVeiculos.Location = new System.Drawing.Point(0, 0);
            this.gridVeiculos.Name = "gridVeiculos";
            this.gridVeiculos.RowHeadersWidth = 51;
            this.gridVeiculos.RowTemplate.Height = 24;
            this.gridVeiculos.Size = new System.Drawing.Size(948, 665);
            this.gridVeiculos.TabIndex = 0;
            // 
            // TabelaVeiculoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridVeiculos);
            this.Name = "TabelaVeiculoControl";
            this.Size = new System.Drawing.Size(948, 665);
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridVeiculos;
    }
}
