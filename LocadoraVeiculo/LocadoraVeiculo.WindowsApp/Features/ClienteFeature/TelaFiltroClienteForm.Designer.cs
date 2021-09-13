
namespace LocadoraVeiculo.WindowsApp.Features.ClienteFeature
{
    partial class TelaFiltroClienteForm
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
            this.components = new System.ComponentModel.Container();
            this.header_FiltroLocacao = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.rdbCPF = new System.Windows.Forms.RadioButton();
            this.rdbCNPJ = new System.Windows.Forms.RadioButton();
            this.header_FiltroLocacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // header_FiltroLocacao
            // 
            this.header_FiltroLocacao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_FiltroLocacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_FiltroLocacao.Controls.Add(this.label8);
            this.header_FiltroLocacao.Location = new System.Drawing.Point(-2, 0);
            this.header_FiltroLocacao.Name = "header_FiltroLocacao";
            this.header_FiltroLocacao.Size = new System.Drawing.Size(342, 29);
            this.header_FiltroLocacao.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Filtrar Cliente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(211, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(130, 277);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "Filtrar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // rdbCPF
            // 
            this.rdbCPF.AutoSize = true;
            this.rdbCPF.Checked = true;
            this.rdbCPF.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbCPF.Location = new System.Drawing.Point(47, 75);
            this.rdbCPF.Name = "rdbCPF";
            this.rdbCPF.Size = new System.Drawing.Size(182, 21);
            this.rdbCPF.TabIndex = 2;
            this.rdbCPF.TabStop = true;
            this.rdbCPF.Text = "Visualizar Clientes CPF";
            this.rdbCPF.UseVisualStyleBackColor = true;
            // 
            // rdbCNPJ
            // 
            this.rdbCNPJ.AutoSize = true;
            this.rdbCNPJ.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbCNPJ.Location = new System.Drawing.Point(47, 140);
            this.rdbCNPJ.Name = "rdbCNPJ";
            this.rdbCNPJ.Size = new System.Drawing.Size(188, 21);
            this.rdbCNPJ.TabIndex = 3;
            this.rdbCNPJ.Text = "Visualizar Clientes CNPJ";
            this.rdbCNPJ.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 324);
            this.Controls.Add(this.header_FiltroLocacao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rdbCPF);
            this.Controls.Add(this.rdbCNPJ);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaFiltroClienteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaFiltroClienteForm";
            this.header_FiltroLocacao.ResumeLayout(false);
            this.header_FiltroLocacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel header_FiltroLocacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.RadioButton rdbCPF;
        private System.Windows.Forms.RadioButton rdbCNPJ;
    }
}