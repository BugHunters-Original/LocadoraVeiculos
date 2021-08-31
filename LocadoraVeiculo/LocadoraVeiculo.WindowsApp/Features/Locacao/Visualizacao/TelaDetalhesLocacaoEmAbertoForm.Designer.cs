
namespace LocadoraVeiculo.WindowsApp.Features.Locacao.Visualizacao
{
    partial class TelaDetalhesLocacaoEmAbertoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCupom = new System.Windows.Forms.TextBox();
            this.listServicos = new System.Windows.Forms.ListBox();
            this.header_Locacao = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.cbCliente = new System.Windows.Forms.TextBox();
            this.cbVeiculo = new System.Windows.Forms.TextBox();
            this.cbCondutor = new System.Windows.Forms.TextBox();
            this.cbTipoLocacao = new System.Windows.Forms.TextBox();
            this.dtSaida = new System.Windows.Forms.TextBox();
            this.dtRetorno = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.header_Locacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Cupom:";
            // 
            // txtCupom
            // 
            this.txtCupom.Location = new System.Drawing.Point(212, 262);
            this.txtCupom.Name = "txtCupom";
            this.txtCupom.ReadOnly = true;
            this.txtCupom.Size = new System.Drawing.Size(399, 28);
            this.txtCupom.TabIndex = 49;
            // 
            // listServicos
            // 
            this.listServicos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listServicos.FormattingEnabled = true;
            this.listServicos.ItemHeight = 16;
            this.listServicos.Location = new System.Drawing.Point(212, 296);
            this.listServicos.Name = "listServicos";
            this.listServicos.Size = new System.Drawing.Size(195, 96);
            this.listServicos.TabIndex = 48;
            // 
            // header_Locacao
            // 
            this.header_Locacao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_Locacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_Locacao.Controls.Add(this.label9);
            this.header_Locacao.Location = new System.Drawing.Point(-2, -1);
            this.header_Locacao.Name = "header_Locacao";
            this.header_Locacao.Size = new System.Drawing.Size(717, 29);
            this.header_Locacao.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Detalhes da Locação";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "Tipo de Locação:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "Data de Retorno Esperada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 43;
            this.label6.Text = "Data de Saída:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Condutor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Veículo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Id:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(212, 45);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(99, 28);
            this.txtID.TabIndex = 37;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 8;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(524, 408);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 51;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cbCliente
            // 
            this.cbCliente.Location = new System.Drawing.Point(212, 78);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.ReadOnly = true;
            this.cbCliente.Size = new System.Drawing.Size(399, 28);
            this.cbCliente.TabIndex = 52;
            // 
            // cbVeiculo
            // 
            this.cbVeiculo.Location = new System.Drawing.Point(212, 109);
            this.cbVeiculo.Name = "cbVeiculo";
            this.cbVeiculo.ReadOnly = true;
            this.cbVeiculo.Size = new System.Drawing.Size(399, 28);
            this.cbVeiculo.TabIndex = 53;
            // 
            // cbCondutor
            // 
            this.cbCondutor.Location = new System.Drawing.Point(212, 140);
            this.cbCondutor.Name = "cbCondutor";
            this.cbCondutor.ReadOnly = true;
            this.cbCondutor.Size = new System.Drawing.Size(399, 28);
            this.cbCondutor.TabIndex = 54;
            // 
            // cbTipoLocacao
            // 
            this.cbTipoLocacao.Location = new System.Drawing.Point(212, 233);
            this.cbTipoLocacao.Name = "cbTipoLocacao";
            this.cbTipoLocacao.ReadOnly = true;
            this.cbTipoLocacao.Size = new System.Drawing.Size(399, 28);
            this.cbTipoLocacao.TabIndex = 55;
            // 
            // dtSaida
            // 
            this.dtSaida.Location = new System.Drawing.Point(212, 171);
            this.dtSaida.Name = "dtSaida";
            this.dtSaida.ReadOnly = true;
            this.dtSaida.Size = new System.Drawing.Size(399, 28);
            this.dtSaida.TabIndex = 56;
            // 
            // dtRetorno
            // 
            this.dtRetorno.Location = new System.Drawing.Point(212, 202);
            this.dtRetorno.Name = "dtRetorno";
            this.dtRetorno.ReadOnly = true;
            this.dtRetorno.Size = new System.Drawing.Size(399, 28);
            this.dtRetorno.TabIndex = 57;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Location = new System.Drawing.Point(416, 296);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(195, 100);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 59;
            this.pictureBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 17);
            this.label10.TabIndex = 60;
            this.label10.Text = "Lista de Serviços:";
            // 
            // TelaDetalhesLocacaoEmAbertoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 447);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.dtRetorno);
            this.Controls.Add(this.dtSaida);
            this.Controls.Add(this.cbTipoLocacao);
            this.Controls.Add(this.cbCondutor);
            this.Controls.Add(this.cbVeiculo);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCupom);
            this.Controls.Add(this.listServicos);
            this.Controls.Add(this.header_Locacao);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaDetalhesLocacaoEmAbertoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaDetalhesLocacaoForm";
            this.header_Locacao.ResumeLayout(false);
            this.header_Locacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCupom;
        private System.Windows.Forms.ListBox listServicos;
        private System.Windows.Forms.Panel header_Locacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox cbTipoLocacao;
        private System.Windows.Forms.TextBox cbCondutor;
        private System.Windows.Forms.TextBox cbVeiculo;
        private System.Windows.Forms.TextBox cbCliente;
        private System.Windows.Forms.TextBox dtSaida;
        private System.Windows.Forms.TextBox dtRetorno;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label10;
    }
}