namespace LocadoraVeiculo.WindowsApp.Features.ClienteFeature
{
    partial class TabelaClienteControl
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
            this.gridClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridClientes
            // 
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClientes.Location = new System.Drawing.Point(0, 0);
            this.gridClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.RowHeadersVisible = false;
            this.gridClientes.RowHeadersWidth = 51;
            this.gridClientes.RowTemplate.Height = 24;
            this.gridClientes.Size = new System.Drawing.Size(711, 540);
            this.gridClientes.TabIndex = 0;
            // 
            // TabelaClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridClientes);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TabelaClienteControl";
            this.Size = new System.Drawing.Size(711, 540);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridClientes;
    }
}
