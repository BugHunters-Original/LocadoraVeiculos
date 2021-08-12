
namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    partial class TelaVeiculoForm
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtChassi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtKm = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTipoCombustivel = new System.Windows.Forms.ComboBox();
            this.txtCapacidadeTanque = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTamanhoPortaMalas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNPortas = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCapacidadePessoas = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.MaskedTextBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.foto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(419, 231);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(133, 22);
            this.txtNome.TabIndex = 116;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label14.Location = new System.Drawing.Point(333, 234);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 115;
            this.label14.Text = "Nome:";
            // 
            // txtChassi
            // 
            this.txtChassi.Location = new System.Drawing.Point(183, 231);
            this.txtChassi.Margin = new System.Windows.Forms.Padding(4);
            this.txtChassi.Name = "txtChassi";
            this.txtChassi.Size = new System.Drawing.Size(133, 22);
            this.txtChassi.TabIndex = 113;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label13.Location = new System.Drawing.Point(73, 234);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 112;
            this.label13.Text = "Chassi:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label12.Location = new System.Drawing.Point(333, 322);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 17);
            this.label12.TabIndex = 111;
            this.label12.Text = "Quilometragem:";
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(467, 319);
            this.txtKm.Mask = "999999999";
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(85, 22);
            this.txtKm.TabIndex = 110;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label11.Location = new System.Drawing.Point(73, 292);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 109;
            this.label11.Text = "Combustível:";
            // 
            // cmbTipoCombustivel
            // 
            this.cmbTipoCombustivel.FormattingEnabled = true;
            this.cmbTipoCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Álcool",
            "Diesel"});
            this.cmbTipoCombustivel.Location = new System.Drawing.Point(183, 288);
            this.cmbTipoCombustivel.Name = "cmbTipoCombustivel";
            this.cmbTipoCombustivel.Size = new System.Drawing.Size(133, 24);
            this.cmbTipoCombustivel.TabIndex = 108;
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(276, 319);
            this.txtCapacidadeTanque.Mask = "999";
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(40, 22);
            this.txtCapacidadeTanque.TabIndex = 107;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label10.Location = new System.Drawing.Point(73, 322);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 17);
            this.label10.TabIndex = 106;
            this.label10.Text = "Capacidade do tanque (L):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(73, 263);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 17);
            this.label6.TabIndex = 105;
            this.label6.Text = "Tamanho porta-malas:";
            // 
            // cmbTamanhoPortaMalas
            // 
            this.cmbTamanhoPortaMalas.FormattingEnabled = true;
            this.cmbTamanhoPortaMalas.Items.AddRange(new object[] {
            "P",
            "M",
            "G"});
            this.cmbTamanhoPortaMalas.Location = new System.Drawing.Point(259, 259);
            this.cmbTamanhoPortaMalas.Name = "cmbTamanhoPortaMalas";
            this.cmbTamanhoPortaMalas.Size = new System.Drawing.Size(57, 24);
            this.cmbTamanhoPortaMalas.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(333, 263);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 103;
            this.label4.Text = "N° portas:";
            // 
            // txtNPortas
            // 
            this.txtNPortas.Location = new System.Drawing.Point(419, 260);
            this.txtNPortas.Mask = "99";
            this.txtNPortas.Name = "txtNPortas";
            this.txtNPortas.Size = new System.Drawing.Size(133, 22);
            this.txtNPortas.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label9.Location = new System.Drawing.Point(333, 146);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 101;
            this.label9.Text = "Tipo:";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(419, 142);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(133, 24);
            this.cmbGrupo.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label8.Location = new System.Drawing.Point(333, 292);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 17);
            this.label8.TabIndex = 99;
            this.label8.Text = "Capacidade de Pessoas:";
            // 
            // txtCapacidadePessoas
            // 
            this.txtCapacidadePessoas.Location = new System.Drawing.Point(519, 289);
            this.txtCapacidadePessoas.Mask = "99";
            this.txtCapacidadePessoas.Name = "txtCapacidadePessoas";
            this.txtCapacidadePessoas.Size = new System.Drawing.Size(33, 22);
            this.txtCapacidadePessoas.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(73, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 97;
            this.label7.Text = "Ano:";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(183, 202);
            this.txtAno.Mask = "9999";
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(133, 22);
            this.txtAno.TabIndex = 96;
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(419, 202);
            this.txtCor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(133, 22);
            this.txtCor.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label5.Location = new System.Drawing.Point(333, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 94;
            this.label5.Text = "Cor:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(419, 173);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(133, 22);
            this.txtPlaca.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(333, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 92;
            this.label3.Text = "Placa:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(183, 173);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(133, 22);
            this.txtMarca.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label2.Location = new System.Drawing.Point(73, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 90;
            this.label2.Text = "Marca:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(184, 143);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(73, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 88;
            this.label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(519, 351);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 87;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(411, 351);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(100, 28);
            this.btnGravar.TabIndex = 86;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click_1);
            // 
            // foto
            // 
            this.foto.Location = new System.Drawing.Point(183, 9);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(258, 126);
            this.foto.TabIndex = 114;
            this.foto.TabStop = false;
            // 
            // TelaVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 383);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.foto);
            this.Controls.Add(this.txtChassi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbTipoCombustivel);
            this.Controls.Add(this.txtCapacidadeTanque);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTamanhoPortaMalas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNPortas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCapacidadePessoas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Name = "TelaVeiculoForm";
            this.Text = "TelaVeiculoForm";
            ((System.ComponentModel.ISupportInitialize)(this.foto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox foto;
        private System.Windows.Forms.TextBox txtChassi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtKm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTipoCombustivel;
        private System.Windows.Forms.MaskedTextBox txtCapacidadeTanque;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTamanhoPortaMalas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtNPortas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtCapacidadePessoas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtAno;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
    }
}