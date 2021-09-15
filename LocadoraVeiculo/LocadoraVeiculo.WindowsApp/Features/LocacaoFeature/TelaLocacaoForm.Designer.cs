namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    partial class TelaLocacaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLocacaoForm));
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.dtSaida = new System.Windows.Forms.DateTimePicker();
            this.dtRetorno = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnTaxa = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTipoLocacao = new System.Windows.Forms.ComboBox();
            this.header_Locacao = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCondutor = new System.Windows.Forms.ComboBox();
            this.cbVeiculo = new System.Windows.Forms.ComboBox();
            this.listServicos = new System.Windows.Forms.ListBox();
            this.txtCupom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.header_Locacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(212, 79);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(399, 23);
            this.cbCliente.TabIndex = 0;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // dtSaida
            // 
            this.dtSaida.Location = new System.Drawing.Point(212, 167);
            this.dtSaida.Name = "dtSaida";
            this.dtSaida.Size = new System.Drawing.Size(399, 24);
            this.dtSaida.TabIndex = 3;
            // 
            // dtRetorno
            // 
            this.dtRetorno.Location = new System.Drawing.Point(212, 200);
            this.dtRetorno.Name = "dtRetorno";
            this.dtRetorno.Size = new System.Drawing.Size(399, 24);
            this.dtRetorno.TabIndex = 4;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(212, 47);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(99, 24);
            this.txtID.TabIndex = 6;
            // 
            // btnTaxa
            // 
            this.btnTaxa.Location = new System.Drawing.Point(429, 298);
            this.btnTaxa.Name = "btnTaxa";
            this.btnTaxa.Size = new System.Drawing.Size(182, 27);
            this.btnTaxa.TabIndex = 6;
            this.btnTaxa.Text = "Configurar Serviços";
            this.btnTaxa.UseVisualStyleBackColor = true;
            this.btnTaxa.Click += new System.EventHandler(this.btnTaxa_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(524, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(429, 412);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(87, 27);
            this.btnGravar.TabIndex = 7;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Veículo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Condutor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Data de Saída:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Data de Retorno Esperada:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "Tipo de Locação:";
            // 
            // cbTipoLocacao
            // 
            this.cbTipoLocacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoLocacao.FormattingEnabled = true;
            this.cbTipoLocacao.Items.AddRange(new object[] {
            "Plano Diário",
            "KM Controlado",
            "KM Livre"});
            this.cbTipoLocacao.Location = new System.Drawing.Point(212, 233);
            this.cbTipoLocacao.Name = "cbTipoLocacao";
            this.cbTipoLocacao.Size = new System.Drawing.Size(399, 23);
            this.cbTipoLocacao.TabIndex = 5;
            // 
            // header_Locacao
            // 
            this.header_Locacao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_Locacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_Locacao.Controls.Add(this.label9);
            this.header_Locacao.Location = new System.Drawing.Point(-2, -1);
            this.header_Locacao.Name = "header_Locacao";
            this.header_Locacao.Size = new System.Drawing.Size(717, 29);
            this.header_Locacao.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cadastro de Locação";
            // 
            // cbCondutor
            // 
            this.cbCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondutor.Enabled = false;
            this.cbCondutor.FormattingEnabled = true;
            this.cbCondutor.Location = new System.Drawing.Point(212, 138);
            this.cbCondutor.Name = "cbCondutor";
            this.cbCondutor.Size = new System.Drawing.Size(399, 23);
            this.cbCondutor.TabIndex = 2;
            // 
            // cbVeiculo
            // 
            this.cbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVeiculo.FormattingEnabled = true;
            this.cbVeiculo.Location = new System.Drawing.Point(212, 109);
            this.cbVeiculo.Name = "cbVeiculo";
            this.cbVeiculo.Size = new System.Drawing.Size(399, 23);
            this.cbVeiculo.TabIndex = 28;
            // 
            // listServicos
            // 
            this.listServicos.FormattingEnabled = true;
            this.listServicos.ItemHeight = 15;
            this.listServicos.Location = new System.Drawing.Point(212, 298);
            this.listServicos.Name = "listServicos";
            this.listServicos.Size = new System.Drawing.Size(211, 109);
            this.listServicos.TabIndex = 29;
            // 
            // txtCupom
            // 
            this.txtCupom.Location = new System.Drawing.Point(212, 266);
            this.txtCupom.Name = "txtCupom";
            this.txtCupom.Size = new System.Drawing.Size(399, 24);
            this.txtCupom.TabIndex = 30;
            this.txtCupom.Leave += new System.EventHandler(this.txtCupom_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Cupom:";
            // 
            // TelaLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 451);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCupom);
            this.Controls.Add(this.listServicos);
            this.Controls.Add(this.cbVeiculo);
            this.Controls.Add(this.cbCondutor);
            this.Controls.Add(this.header_Locacao);
            this.Controls.Add(this.cbTipoLocacao);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnTaxa);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dtRetorno);
            this.Controls.Add(this.dtSaida);
            this.Controls.Add(this.cbCliente);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLocacaoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Locações";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaLocacaoForm_FormClosing);
            this.header_Locacao.ResumeLayout(false);
            this.header_Locacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.DateTimePicker dtSaida;
        private System.Windows.Forms.DateTimePicker dtRetorno;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnTaxa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTipoLocacao;
        private System.Windows.Forms.Panel header_Locacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCondutor;
        private System.Windows.Forms.ComboBox cbVeiculo;
        private System.Windows.Forms.ListBox listServicos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCupom;
    }
}