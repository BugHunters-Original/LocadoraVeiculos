﻿
namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    partial class TabelaLocacaoControl
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
            this.gridLocacao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLocacao
            // 
            this.gridLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLocacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLocacao.Location = new System.Drawing.Point(0, 0);
            this.gridLocacao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridLocacao.Name = "gridLocacao";
            this.gridLocacao.RowHeadersVisible = false;
            this.gridLocacao.RowHeadersWidth = 51;
            this.gridLocacao.RowTemplate.Height = 24;
            this.gridLocacao.Size = new System.Drawing.Size(711, 540);
            this.gridLocacao.TabIndex = 0;
            // 
            // TabelaLocacaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLocacao);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TabelaLocacaoControl";
            this.Size = new System.Drawing.Size(711, 540);
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridLocacao;
    }
}
