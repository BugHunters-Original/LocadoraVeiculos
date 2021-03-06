
namespace LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature
{
    partial class TelaTaxaServicoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaTaxaServicoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.rdFixo = new System.Windows.Forms.RadioButton();
            this.rdDiario = new System.Windows.Forms.RadioButton();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPreco = new System.Windows.Forms.MaskedTextBox();
            this.header_TaxaServico = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.header_TaxaServico.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(82, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label2.Location = new System.Drawing.Point(25, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Calculo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(60, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(62, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Preço:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(111, 58);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(186, 24);
            this.txtID.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(111, 94);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(186, 24);
            this.txtNome.TabIndex = 0;
            // 
            // rdFixo
            // 
            this.rdFixo.AutoSize = true;
            this.rdFixo.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.rdFixo.Location = new System.Drawing.Point(118, 174);
            this.rdFixo.Name = "rdFixo";
            this.rdFixo.Size = new System.Drawing.Size(48, 19);
            this.rdFixo.TabIndex = 2;
            this.rdFixo.Text = "Fixo";
            this.rdFixo.UseVisualStyleBackColor = true;
            // 
            // rdDiario
            // 
            this.rdDiario.AutoSize = true;
            this.rdDiario.Checked = true;
            this.rdDiario.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.rdDiario.Location = new System.Drawing.Point(235, 174);
            this.rdDiario.Name = "rdDiario";
            this.rdDiario.Size = new System.Drawing.Size(57, 19);
            this.rdDiario.TabIndex = 3;
            this.rdDiario.TabStop = true;
            this.rdDiario.Text = "Diário";
            this.rdDiario.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(116, 241);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(87, 27);
            this.btnGravar.TabIndex = 4;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(210, 241);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(111, 130);
            this.txtPreco.Mask = "00000";
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(186, 24);
            this.txtPreco.TabIndex = 1;
            // 
            // header_TaxaServico
            // 
            this.header_TaxaServico.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_TaxaServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_TaxaServico.Controls.Add(this.label10);
            this.header_TaxaServico.Location = new System.Drawing.Point(-2, -1);
            this.header_TaxaServico.Name = "header_TaxaServico";
            this.header_TaxaServico.Size = new System.Drawing.Size(348, 29);
            this.header_TaxaServico.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Cadastro de Taxas e Serviços";
            // 
            // TelaTaxaServicoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 291);
            this.Controls.Add(this.header_TaxaServico);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rdDiario);
            this.Controls.Add(this.rdFixo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaTaxaServicoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Taxas e Serviços";
            this.header_TaxaServico.ResumeLayout(false);
            this.header_TaxaServico.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.RadioButton rdFixo;
        private System.Windows.Forms.RadioButton rdDiario;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox txtPreco;
        private System.Windows.Forms.Panel header_TaxaServico;
        private System.Windows.Forms.Label label10;
    }
}