﻿
namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    partial class TelaDevolucaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaDevolucaoForm));
            this.dtRetorno = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKmAtual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNivelTanque = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtCombustivel = new System.Windows.Forms.TextBox();
            this.btnNota = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKmInicial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtRetornoEsperada = new System.Windows.Forms.DateTimePicker();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtRetorno
            // 
            this.dtRetorno.Location = new System.Drawing.Point(147, 56);
            this.dtRetorno.Name = "dtRetorno";
            this.dtRetorno.Size = new System.Drawing.Size(216, 20);
            this.dtRetorno.TabIndex = 0;
            this.dtRetorno.ValueChanged += new System.EventHandler(this.dtRetorno_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data de Retorno:";
            // 
            // txtKmAtual
            // 
            this.txtKmAtual.Location = new System.Drawing.Point(147, 109);
            this.txtKmAtual.Name = "txtKmAtual";
            this.txtKmAtual.Size = new System.Drawing.Size(216, 20);
            this.txtKmAtual.TabIndex = 2;
            this.txtKmAtual.Leave += new System.EventHandler(this.txtKmAtual_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quilometragem Atual:";
            // 
            // cbNivelTanque
            // 
            this.cbNivelTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivelTanque.FormattingEnabled = true;
            this.cbNivelTanque.Items.AddRange(new object[] {
            "1/8",
            "1/4",
            "3/8",
            "1/2",
            "5/8",
            "3/4",
            "7/8",
            "Cheio"});
            this.cbNivelTanque.Location = new System.Drawing.Point(147, 136);
            this.cbNivelTanque.Name = "cbNivelTanque";
            this.cbNivelTanque.Size = new System.Drawing.Size(216, 21);
            this.cbNivelTanque.TabIndex = 4;
            this.cbNivelTanque.SelectedIndexChanged += new System.EventHandler(this.cbNivelTanque_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nível do Tanque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Combustível:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(147, 241);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(216, 20);
            this.txtTotal.TabIndex = 9;
            // 
            // txtCombustivel
            // 
            this.txtCombustivel.Location = new System.Drawing.Point(147, 163);
            this.txtCombustivel.Name = "txtCombustivel";
            this.txtCombustivel.ReadOnly = true;
            this.txtCombustivel.Size = new System.Drawing.Size(216, 20);
            this.txtCombustivel.TabIndex = 11;
            // 
            // btnNota
            // 
            this.btnNota.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNota.Location = new System.Drawing.Point(306, 276);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(75, 23);
            this.btnNota.TabIndex = 12;
            this.btnNota.Text = "Gerar Nota";
            this.btnNota.UseVisualStyleBackColor = true;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(387, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Quilometragem Inicial:";
            // 
            // txtKmInicial
            // 
            this.txtKmInicial.Location = new System.Drawing.Point(147, 82);
            this.txtKmInicial.Name = "txtKmInicial";
            this.txtKmInicial.ReadOnly = true;
            this.txtKmInicial.Size = new System.Drawing.Size(216, 20);
            this.txtKmInicial.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Data de Previsão:";
            // 
            // dtRetornoEsperada
            // 
            this.dtRetornoEsperada.Enabled = false;
            this.dtRetornoEsperada.Location = new System.Drawing.Point(147, 30);
            this.dtRetornoEsperada.Name = "dtRetornoEsperada";
            this.dtRetornoEsperada.Size = new System.Drawing.Size(216, 20);
            this.dtRetornoEsperada.TabIndex = 16;
            // 
            // txtServico
            // 
            this.txtServico.Location = new System.Drawing.Point(147, 189);
            this.txtServico.Name = "txtServico";
            this.txtServico.ReadOnly = true;
            this.txtServico.Size = new System.Drawing.Size(216, 20);
            this.txtServico.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Serviços:";
            // 
            // txtMulta
            // 
            this.txtMulta.Location = new System.Drawing.Point(147, 215);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.ReadOnly = true;
            this.txtMulta.Size = new System.Drawing.Size(216, 20);
            this.txtMulta.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Multa:";
            // 
            // TelaDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 311);
            this.Controls.Add(this.txtMulta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtServico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtRetornoEsperada);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKmInicial);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNota);
            this.Controls.Add(this.txtCombustivel);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbNivelTanque);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKmAtual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtRetorno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaDevolucaoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução de Locações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtRetorno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKmAtual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNivelTanque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtCombustivel;
        private System.Windows.Forms.Button btnNota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKmInicial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtRetornoEsperada;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.Label label9;
    }
}