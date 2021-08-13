
namespace LocadoraVeiculo.WindowsApp.Features.Funcionarios
{
    partial class TabelaFuncionarioControl
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
            this.gridFuncionarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFuncionarios
            // 
            this.gridFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFuncionarios.Location = new System.Drawing.Point(0, 0);
            this.gridFuncionarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridFuncionarios.Name = "gridFuncionarios";
            this.gridFuncionarios.RowHeadersWidth = 51;
            this.gridFuncionarios.RowTemplate.Height = 24;
            this.gridFuncionarios.Size = new System.Drawing.Size(711, 540);
            this.gridFuncionarios.TabIndex = 0;
            // 
            // TabelaFuncionarioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridFuncionarios);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TabelaFuncionarioControl";
            this.Size = new System.Drawing.Size(711, 540);
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridFuncionarios;
    }
}
