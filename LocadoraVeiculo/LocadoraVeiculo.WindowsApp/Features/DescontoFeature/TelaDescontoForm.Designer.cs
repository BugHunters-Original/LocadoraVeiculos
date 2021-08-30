
namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    partial class TelaDescontoForm
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.header_GrupoVeiculo = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMeio = new System.Windows.Forms.TextBox();
            this.rbPorcentagem = new System.Windows.Forms.RadioButton();
            this.rbInteiro = new System.Windows.Forms.RadioButton();
            this.dtValidade = new System.Windows.Forms.DateTimePicker();
            this.cbParceiros = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtValorMinimo = new System.Windows.Forms.MaskedTextBox();
            this.header_GrupoVeiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // header_GrupoVeiculo
            // 
            this.header_GrupoVeiculo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_GrupoVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_GrupoVeiculo.Controls.Add(this.label9);
            this.header_GrupoVeiculo.Location = new System.Drawing.Point(-6, -1);
            this.header_GrupoVeiculo.Name = "header_GrupoVeiculo";
            this.header_GrupoVeiculo.Size = new System.Drawing.Size(546, 29);
            this.header_GrupoVeiculo.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cadastro de Descontos";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Location = new System.Drawing.Point(182, 75);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(59, 24);
            this.txtId.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(151, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Id:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(122, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(182, 141);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(272, 22);
            this.txtCodigo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(62, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Valor do Desconto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label2.Location = new System.Drawing.Point(116, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Validade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(117, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Parceiro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(43, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Meio de Comunicação:";
            // 
            // txtMeio
            // 
            this.txtMeio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeio.Location = new System.Drawing.Point(182, 345);
            this.txtMeio.Name = "txtMeio";
            this.txtMeio.Size = new System.Drawing.Size(272, 22);
            this.txtMeio.TabIndex = 29;
            // 
            // rbPorcentagem
            // 
            this.rbPorcentagem.AutoSize = true;
            this.rbPorcentagem.Location = new System.Drawing.Point(335, 237);
            this.rbPorcentagem.Name = "rbPorcentagem";
            this.rbPorcentagem.Size = new System.Drawing.Size(96, 19);
            this.rbPorcentagem.TabIndex = 31;
            this.rbPorcentagem.Text = "Porcentagem";
            this.rbPorcentagem.UseVisualStyleBackColor = true;
            // 
            // rbInteiro
            // 
            this.rbInteiro.AutoSize = true;
            this.rbInteiro.Checked = true;
            this.rbInteiro.Location = new System.Drawing.Point(182, 237);
            this.rbInteiro.Name = "rbInteiro";
            this.rbInteiro.Size = new System.Drawing.Size(60, 19);
            this.rbInteiro.TabIndex = 32;
            this.rbInteiro.TabStop = true;
            this.rbInteiro.Text = "Inteiro";
            this.rbInteiro.UseVisualStyleBackColor = true;
            // 
            // dtValidade
            // 
            this.dtValidade.Location = new System.Drawing.Point(182, 271);
            this.dtValidade.Name = "dtValidade";
            this.dtValidade.Size = new System.Drawing.Size(272, 24);
            this.dtValidade.TabIndex = 33;
            // 
            // cbParceiros
            // 
            this.cbParceiros.FormattingEnabled = true;
            this.cbParceiros.Location = new System.Drawing.Point(182, 310);
            this.cbParceiros.Name = "cbParceiros";
            this.cbParceiros.Size = new System.Drawing.Size(272, 23);
            this.cbParceiros.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label5.Location = new System.Drawing.Point(137, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "Tipo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnCancelar.Location = new System.Drawing.Point(367, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnGravar.Location = new System.Drawing.Point(272, 394);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(87, 27);
            this.btnGravar.TabIndex = 36;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(182, 203);
            this.txtValor.Mask = "000000";
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(272, 24);
            this.txtValor.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label8.Location = new System.Drawing.Point(90, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "Valor Mínimo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label10.Location = new System.Drawing.Point(87, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "Título Cupom:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(182, 113);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(272, 22);
            this.txtNome.TabIndex = 41;
            // 
            // txtValorMinimo
            // 
            this.txtValorMinimo.Location = new System.Drawing.Point(182, 170);
            this.txtValorMinimo.Mask = "000000";
            this.txtValorMinimo.Name = "txtValorMinimo";
            this.txtValorMinimo.Size = new System.Drawing.Size(272, 24);
            this.txtValorMinimo.TabIndex = 43;
            // 
            // TelaDescontoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 455);
            this.Controls.Add(this.txtValorMinimo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbParceiros);
            this.Controls.Add(this.dtValidade);
            this.Controls.Add(this.rbInteiro);
            this.Controls.Add(this.rbPorcentagem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMeio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.header_GrupoVeiculo);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaDescontoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaDescontoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaDescontoForm_FormClosing);
            this.header_GrupoVeiculo.ResumeLayout(false);
            this.header_GrupoVeiculo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel header_GrupoVeiculo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMeio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbInteiro;
        private System.Windows.Forms.RadioButton rbPorcentagem;
        private System.Windows.Forms.DateTimePicker dtValidade;
        private System.Windows.Forms.ComboBox cbParceiros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.MaskedTextBox txtValor;
        private System.Windows.Forms.MaskedTextBox txtValorMinimo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label8;
    }
}