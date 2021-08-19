﻿
namespace LocadoraVeiculo.WindowsApp.Features.Clientes
{
    partial class TelaClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaClienteForm));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dtDataValidade = new System.Windows.Forms.DateTimePicker();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbFisico = new System.Windows.Forms.RadioButton();
            this.rbJuridico = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.mskCpf = new System.Windows.Forms.MaskedTextBox();
            this.mskCnpj = new System.Windows.Forms.MaskedTextBox();
            this.mskRg = new System.Windows.Forms.MaskedTextBox();
            this.mskCnh = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(171, 27);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Size = new System.Drawing.Size(81, 24);
            this.txtID.Size = new System.Drawing.Size(92, 22);
            this.txtID.TabIndex = 0;
            // 
            // txtEndereco
            this.txtEndereco.Location = new System.Drawing.Point(168, 126);
            this.txtEndereco.Location = new System.Drawing.Point(192, 134);
            this.txtEndereco.Size = new System.Drawing.Size(242, 24);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(276, 22);
            this.txtEndereco.TabIndex = 3;
            // 
            this.txtNome.Location = new System.Drawing.Point(169, 96);
            // 
            this.txtNome.Size = new System.Drawing.Size(242, 24);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(276, 22);
            this.txtNome.TabIndex = 2;
            // 
            this.dtDataValidade.Location = new System.Drawing.Point(169, 276);
            // 
            this.dtDataValidade.Size = new System.Drawing.Size(242, 24);
            this.dtDataValidade.Location = new System.Drawing.Point(193, 294);
            this.dtDataValidade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDataValidade.Name = "dtDataValidade";
            this.dtDataValidade.Size = new System.Drawing.Size(276, 22);
            this.dtDataValidade.TabIndex = 8;
            // 
            this.cbEmpresas.Location = new System.Drawing.Point(169, 336);
            // 
            this.cbEmpresas.Size = new System.Drawing.Size(242, 23);
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(193, 358);
            this.cbEmpresas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(276, 24);
            this.cbEmpresas.TabIndex = 10;
            this.label1.Location = new System.Drawing.Point(143, 32);
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(164, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 11;
            this.label3.Location = new System.Drawing.Point(121, 99);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(135, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label4.Location = new System.Drawing.Point(132, 192);
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(151, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label5.Location = new System.Drawing.Point(126, 222);
            this.label4.TabIndex = 14;
            this.label4.Text = "CPF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label5.Location = new System.Drawing.Point(144, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Location = new System.Drawing.Point(127, 252);
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "CNPJ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(145, 268);
            this.label7.Location = new System.Drawing.Point(36, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "CNH:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label8.Location = new System.Drawing.Point(138, 312);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data de Validade CNH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 339);
            this.label8.Location = new System.Drawing.Point(157, 332);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "RG:";
            // 
            // label9
            // 
            this.label10.Location = new System.Drawing.Point(103, 129);
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label9.Location = new System.Drawing.Point(28, 366);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Empresa relacionada:";
            // 
            // label10
            this.label11.Location = new System.Drawing.Point(105, 159);
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label10.Location = new System.Drawing.Point(111, 140);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Endereço:";
            // 
            this.rbFisico.Location = new System.Drawing.Point(171, 62);
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label11.Location = new System.Drawing.Point(116, 172);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Telefone:";
            // 
            // rbFisico
            this.rbJuridico.Location = new System.Drawing.Point(289, 62);
            this.rbFisico.AutoSize = true;
            this.rbFisico.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.rbFisico.Location = new System.Drawing.Point(196, 66);
            this.rbFisico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbFisico.Name = "rbFisico";
            this.rbFisico.Size = new System.Drawing.Size(95, 19);
            this.rbFisico.TabIndex = 0;
            this.rbFisico.Text = "Pessoa Fìsica";
            this.rbFisico.UseVisualStyleBackColor = true;
            this.rbFisico.CheckedChanged += new System.EventHandler(this.rbFisico_CheckedChanged);
            // 
            this.btnCancelar.Location = new System.Drawing.Point(324, 392);
            // 
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.rbJuridico.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.rbJuridico.Location = new System.Drawing.Point(331, 66);
            this.rbJuridico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbJuridico.Name = "rbJuridico";
            this.rbJuridico.Size = new System.Drawing.Size(105, 19);
            this.rbJuridico.TabIndex = 1;
            this.rbJuridico.Text = "Pessoa Jurídica";
            this.rbJuridico.UseVisualStyleBackColor = true;
            this.btnGravar.Location = new System.Drawing.Point(230, 392);
            // 
            this.btnGravar.Size = new System.Drawing.Size(87, 27);
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnCancelar.Location = new System.Drawing.Point(371, 418);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.mskTelefone.Location = new System.Drawing.Point(169, 156);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.mskTelefone.Size = new System.Drawing.Size(242, 24);
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnGravar.Location = new System.Drawing.Point(263, 418);
            this.mskCpf.Location = new System.Drawing.Point(169, 186);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(100, 28);
            this.mskCpf.Size = new System.Drawing.Size(242, 24);
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // mskTelefone
            this.mskCnpj.Location = new System.Drawing.Point(169, 216);
            this.mskTelefone.Location = new System.Drawing.Point(193, 166);
            this.mskTelefone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskCnpj.Size = new System.Drawing.Size(242, 24);
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(276, 22);
            this.mskTelefone.TabIndex = 4;
            // 
            // mskCpf
            this.mskRg.Location = new System.Drawing.Point(169, 306);
            this.mskCpf.Enabled = false;
            this.mskCpf.Location = new System.Drawing.Point(193, 198);
            this.mskRg.Size = new System.Drawing.Size(242, 24);
            this.mskCpf.Mask = "000.000.000-00";
            this.mskCpf.Name = "mskCpf";
            this.mskCpf.Size = new System.Drawing.Size(276, 22);
            this.mskCpf.TabIndex = 5;
            // 
            this.mskCnh.Location = new System.Drawing.Point(169, 246);
            // 
            this.mskCnpj.Enabled = false;
            this.mskCnh.Size = new System.Drawing.Size(242, 24);
            this.mskCnpj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskCnpj.Mask = "00.000.000/0000-00";
            this.mskCnpj.Name = "mskCnpj";
            this.mskCnpj.Size = new System.Drawing.Size(276, 22);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            // 
            this.ClientSize = new System.Drawing.Size(459, 441);
            // 
            this.mskRg.Enabled = false;
            this.mskRg.Location = new System.Drawing.Point(193, 326);
            this.mskRg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskRg.Mask = "0.000.000";
            this.mskRg.Name = "mskRg";
            this.mskRg.Size = new System.Drawing.Size(276, 22);
            this.mskRg.TabIndex = 9;
            // 
            // mskCnh
            // 
            this.mskCnh.Enabled = false;
            this.mskCnh.Location = new System.Drawing.Point(193, 262);
            this.mskCnh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskCnh.Mask = "00000000000";
            this.mskCnh.Name = "mskCnh";
            this.mskCnh.Size = new System.Drawing.Size(276, 22);
            this.mskCnh.TabIndex = 7;
            // 
            // TelaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 470);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Controls.Add(this.mskRg);
            this.Controls.Add(this.mskCnpj);
            this.Controls.Add(this.mskCpf);
            this.Controls.Add(this.mskTelefone);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rbJuridico);
            this.Controls.Add(this.rbFisico);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEmpresas);
            this.Controls.Add(this.dtDataValidade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaClienteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaClienteForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DateTimePicker dtDataValidade;
        private System.Windows.Forms.ComboBox cbEmpresas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbFisico;
        private System.Windows.Forms.RadioButton rbJuridico;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.MaskedTextBox mskCpf;
        private System.Windows.Forms.MaskedTextBox mskCnpj;
        private System.Windows.Forms.MaskedTextBox mskRg;
        private System.Windows.Forms.MaskedTextBox mskCnh;
    }
}