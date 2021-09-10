
namespace LocadoraVeiculo.WindowsApp.Features.NotaFiscalFeature
{
    partial class TelaNotaFiscalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaNotaFiscalForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtPlano = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecoPlano = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_Voltar = new System.Windows.Forms.Button();
            this.bt_ConcluirLocacao = new System.Windows.Forms.Button();
            this.txtCaução = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.header_NotaFiscal = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.header_NotaFiscal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(174, 82);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(248, 24);
            this.txtCliente.TabIndex = 20;
            // 
            // txtPlano
            // 
            this.txtPlano.Location = new System.Drawing.Point(174, 52);
            this.txtPlano.Name = "txtPlano";
            this.txtPlano.ReadOnly = true;
            this.txtPlano.Size = new System.Drawing.Size(248, 24);
            this.txtPlano.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plano:";
            // 
            // txtPrecoPlano
            // 
            this.txtPrecoPlano.Location = new System.Drawing.Point(174, 112);
            this.txtPrecoPlano.Name = "txtPrecoPlano";
            this.txtPrecoPlano.ReadOnly = true;
            this.txtPrecoPlano.Size = new System.Drawing.Size(248, 24);
            this.txtPrecoPlano.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Preço do plano:";
            // 
            // txtGas
            // 
            this.txtGas.Location = new System.Drawing.Point(174, 142);
            this.txtGas.Name = "txtGas";
            this.txtGas.ReadOnly = true;
            this.txtGas.Size = new System.Drawing.Size(248, 24);
            this.txtGas.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Taxa do Combustível:";
            // 
            // txtServico
            // 
            this.txtServico.Location = new System.Drawing.Point(174, 174);
            this.txtServico.Name = "txtServico";
            this.txtServico.ReadOnly = true;
            this.txtServico.Size = new System.Drawing.Size(248, 24);
            this.txtServico.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Taxa de Serviços:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(174, 251);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(248, 24);
            this.txtTotal.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(108, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "TOTAL:";
            // 
            // bt_Voltar
            // 
            this.bt_Voltar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Voltar.Location = new System.Drawing.Point(335, 300);
            this.bt_Voltar.Name = "bt_Voltar";
            this.bt_Voltar.Size = new System.Drawing.Size(87, 27);
            this.bt_Voltar.TabIndex = 1;
            this.bt_Voltar.Text = "Cancelar";
            this.bt_Voltar.UseVisualStyleBackColor = true;
            // 
            // bt_ConcluirLocacao
            // 
            this.bt_ConcluirLocacao.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ConcluirLocacao.Location = new System.Drawing.Point(241, 300);
            this.bt_ConcluirLocacao.Name = "bt_ConcluirLocacao";
            this.bt_ConcluirLocacao.Size = new System.Drawing.Size(87, 27);
            this.bt_ConcluirLocacao.TabIndex = 0;
            this.bt_ConcluirLocacao.Text = "Gravar";
            this.bt_ConcluirLocacao.UseVisualStyleBackColor = true;
            this.bt_ConcluirLocacao.Click += new System.EventHandler(this.bt_ConcluirLocacao_Click);
            // 
            // txtCaução
            // 
            this.txtCaução.Location = new System.Drawing.Point(174, 204);
            this.txtCaução.Name = "txtCaução";
            this.txtCaução.ReadOnly = true;
            this.txtCaução.Size = new System.Drawing.Size(248, 24);
            this.txtCaução.TabIndex = 23;
            this.txtCaução.Text = "R$1000,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Caução:";
            // 
            // header_NotaFiscal
            // 
            this.header_NotaFiscal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_NotaFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_NotaFiscal.Controls.Add(this.label10);
            this.header_NotaFiscal.Location = new System.Drawing.Point(-4, 0);
            this.header_NotaFiscal.Name = "header_NotaFiscal";
            this.header_NotaFiscal.Size = new System.Drawing.Size(493, 29);
            this.header_NotaFiscal.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nota Fiscal";
            // 
            // TelaNotaFiscalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 358);
            this.Controls.Add(this.header_NotaFiscal);
            this.Controls.Add(this.txtCaução);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_Voltar);
            this.Controls.Add(this.bt_ConcluirLocacao);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtServico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecoPlano);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlano);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaNotaFiscalForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota Fiscal da Locação";
            this.header_NotaFiscal.ResumeLayout(false);
            this.header_NotaFiscal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtPlano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecoPlano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bt_Voltar;
        private System.Windows.Forms.Button bt_ConcluirLocacao;
        private System.Windows.Forms.TextBox txtCaução;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel header_NotaFiscal;
        private System.Windows.Forms.Label label10;
    }
}