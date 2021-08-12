
namespace LocadoraVeiculo.WindowsApp.Features.TaxaServico
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
            this.checkBoxTaxa = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkBoxTaxa
            // 
            this.checkBoxTaxa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxTaxa.FormattingEnabled = true;
            this.checkBoxTaxa.Location = new System.Drawing.Point(0, 0);
            this.checkBoxTaxa.Name = "checkBoxTaxa";
            this.checkBoxTaxa.Size = new System.Drawing.Size(728, 576);
            this.checkBoxTaxa.TabIndex = 0;
            // 
            // TabelaTaxaServicoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxTaxa);
            this.Name = "TabelaTaxaServicoControl";
            this.Size = new System.Drawing.Size(728, 576);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkBoxTaxa;
    }
}
