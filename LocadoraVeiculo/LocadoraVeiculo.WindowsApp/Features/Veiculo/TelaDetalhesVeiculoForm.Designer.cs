
namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    partial class TelaDetalhesVeiculoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaDetalhesVeiculoForm));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtChassi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCapacidadeTanque = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNPortas = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.btnOK = new System.Windows.Forms.Button();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.cmbTamanhoPortaMalas = new System.Windows.Forms.TextBox();
            this.cmbTipoCombustivel = new System.Windows.Forms.TextBox();
            this.cmbGrupo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtNome.Location = new System.Drawing.Point(182, 65);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(642, 28);
            this.txtNome.TabIndex = 126;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label14.Location = new System.Drawing.Point(120, 71);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 147;
            this.label14.Text = "Nome:";
            // 
            // txtChassi
            // 
            this.txtChassi.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtChassi.Location = new System.Drawing.Point(439, 143);
            this.txtChassi.Margin = new System.Windows.Forms.Padding(4);
            this.txtChassi.Name = "txtChassi";
            this.txtChassi.ReadOnly = true;
            this.txtChassi.Size = new System.Drawing.Size(133, 28);
            this.txtChassi.TabIndex = 119;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label13.Location = new System.Drawing.Point(372, 149);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 145;
            this.label13.Text = "Chassi:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label12.Location = new System.Drawing.Point(55, 227);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 17);
            this.label12.TabIndex = 144;
            this.label12.Text = "Quilometragem:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label11.Location = new System.Drawing.Point(584, 227);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 143;
            this.label11.Text = "Combustível:";
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(439, 221);
            this.txtCapacidadeTanque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCapacidadeTanque.Mask = "999";
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.ReadOnly = true;
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(133, 28);
            this.txtCapacidadeTanque.TabIndex = 122;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(355, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 140;
            this.label4.Text = "N° portas:";
            // 
            // txtNPortas
            // 
            this.txtNPortas.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtNPortas.Location = new System.Drawing.Point(439, 182);
            this.txtNPortas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNPortas.Mask = "11";
            this.txtNPortas.Name = "txtNPortas";
            this.txtNPortas.ReadOnly = true;
            this.txtNPortas.Size = new System.Drawing.Size(133, 28);
            this.txtNPortas.TabIndex = 139;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label9.Location = new System.Drawing.Point(638, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 138;
            this.label9.Text = "Tipo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label8.Location = new System.Drawing.Point(1, 188);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 17);
            this.label8.TabIndex = 137;
            this.label8.Text = "Capacidade de Pessoas:";
            // 
            // txtCapacidadePessoas
            // 
            this.txtCapacidadePessoas.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtCapacidadePessoas.Location = new System.Drawing.Point(181, 182);
            this.txtCapacidadePessoas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCapacidadePessoas.Mask = "12";
            this.txtCapacidadePessoas.Name = "txtCapacidadePessoas";
            this.txtCapacidadePessoas.ReadOnly = true;
            this.txtCapacidadePessoas.Size = new System.Drawing.Size(133, 28);
            this.txtCapacidadePessoas.TabIndex = 136;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(132, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 135;
            this.label7.Text = "Ano:";
            // 
            // txtAno
            // 
            this.txtAno.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtAno.Location = new System.Drawing.Point(181, 143);
            this.txtAno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAno.Mask = "9999";
            this.txtAno.Name = "txtAno";
            this.txtAno.ReadOnly = true;
            this.txtAno.Size = new System.Drawing.Size(133, 28);
            this.txtAno.TabIndex = 118;
            // 
            // txtCor
            // 
            this.txtCor.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtCor.Location = new System.Drawing.Point(439, 104);
            this.txtCor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCor.Name = "txtCor";
            this.txtCor.ReadOnly = true;
            this.txtCor.Size = new System.Drawing.Size(133, 28);
            this.txtCor.TabIndex = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label5.Location = new System.Drawing.Point(392, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 134;
            this.label5.Text = "Cor:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtPlaca.Location = new System.Drawing.Point(691, 143);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.ReadOnly = true;
            this.txtPlaca.Size = new System.Drawing.Size(133, 28);
            this.txtPlaca.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(634, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 133;
            this.label3.Text = "Placa:";
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtMarca.Location = new System.Drawing.Point(181, 104);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(133, 28);
            this.txtMarca.TabIndex = 117;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label2.Location = new System.Drawing.Point(119, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 132;
            this.label2.Text = "Marca:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtId.Location = new System.Drawing.Point(181, 26);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 28);
            this.txtId.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(147, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 130;
            this.label1.Text = "Id:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(724, 454);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 128;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxImagem.Location = new System.Drawing.Point(182, 269);
            this.pictureBoxImagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(510, 213);
            this.pictureBoxImagem.TabIndex = 146;
            this.pictureBoxImagem.TabStop = false;
            // 
            // txtKm
            // 
            this.txtKm.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.txtKm.Location = new System.Drawing.Point(181, 221);
            this.txtKm.Name = "txtKm";
            this.txtKm.ReadOnly = true;
            this.txtKm.Size = new System.Drawing.Size(133, 28);
            this.txtKm.TabIndex = 148;
            // 
            // cmbTamanhoPortaMalas
            // 
            this.cmbTamanhoPortaMalas.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.cmbTamanhoPortaMalas.Location = new System.Drawing.Point(691, 182);
            this.cmbTamanhoPortaMalas.Name = "cmbTamanhoPortaMalas";
            this.cmbTamanhoPortaMalas.ReadOnly = true;
            this.cmbTamanhoPortaMalas.Size = new System.Drawing.Size(133, 28);
            this.cmbTamanhoPortaMalas.TabIndex = 149;
            // 
            // cmbTipoCombustivel
            // 
            this.cmbTipoCombustivel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.cmbTipoCombustivel.Location = new System.Drawing.Point(691, 221);
            this.cmbTipoCombustivel.Name = "cmbTipoCombustivel";
            this.cmbTipoCombustivel.ReadOnly = true;
            this.cmbTipoCombustivel.Size = new System.Drawing.Size(133, 28);
            this.cmbTipoCombustivel.TabIndex = 150;
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.cmbGrupo.Location = new System.Drawing.Point(691, 104);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.ReadOnly = true;
            this.cmbGrupo.Size = new System.Drawing.Size(133, 28);
            this.cmbGrupo.TabIndex = 151;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label10.Location = new System.Drawing.Point(322, 218);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 34);
            this.label10.TabIndex = 152;
            this.label10.Text = "Capacidade\r\n do tanque (L):";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(584, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 34);
            this.label6.TabIndex = 153;
            this.label6.Text = "Tamanho \r\nporta-malas:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label15.Location = new System.Drawing.Point(129, 278);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 17);
            this.label15.TabIndex = 154;
            this.label15.Text = "Foto:";
            // 
            // TelaDetalhesVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 495);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.cmbTipoCombustivel);
            this.Controls.Add(this.cmbTamanhoPortaMalas);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBoxImagem);
            this.Controls.Add(this.txtChassi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCapacidadeTanque);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNPortas);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaDetalhesVeiculoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes do Veículo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.TextBox txtChassi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtCapacidadeTanque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtNPortas;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.TextBox cmbTamanhoPortaMalas;
        private System.Windows.Forms.TextBox cmbTipoCombustivel;
        private System.Windows.Forms.TextBox cmbGrupo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
    }
}