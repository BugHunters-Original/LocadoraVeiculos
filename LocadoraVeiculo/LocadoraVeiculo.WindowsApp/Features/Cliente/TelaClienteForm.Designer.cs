
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
            this.components = new System.ComponentModel.Container();
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
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbFisico = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.mskCpf = new System.Windows.Forms.MaskedTextBox();
            this.mskCnpj = new System.Windows.Forms.MaskedTextBox();
            this.mskRg = new System.Windows.Forms.MaskedTextBox();
            this.mskCnh = new System.Windows.Forms.MaskedTextBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.rbJuridico = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.header_Cliente = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.header_Cliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(168, 57);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(81, 24);
            this.txtID.TabIndex = 0;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(171, 161);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(242, 24);
            this.txtEndereco.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(171, 131);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(242, 24);
            this.txtNome.TabIndex = 2;
            // 
            // dtDataValidade
            // 
            this.dtDataValidade.Enabled = false;
            this.dtDataValidade.Location = new System.Drawing.Point(171, 311);
            this.dtDataValidade.Name = "dtDataValidade";
            this.dtDataValidade.Size = new System.Drawing.Size(242, 24);
            this.dtDataValidade.TabIndex = 8;
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(171, 400);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(242, 23);
            this.cbEmpresas.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(143, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(118, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(130, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "CPF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label5.Location = new System.Drawing.Point(125, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "CNPJ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(126, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "CNH:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(35, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data de Validade CNH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label8.Location = new System.Drawing.Point(135, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "RG:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label10.Location = new System.Drawing.Point(100, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Endereço:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label11.Location = new System.Drawing.Point(104, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Telefone:";
            // 
            // rbFisico
            // 
            this.rbFisico.AutoSize = true;
            this.rbFisico.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.rbFisico.Location = new System.Drawing.Point(171, 96);
            this.rbFisico.Name = "rbFisico";
            this.rbFisico.Size = new System.Drawing.Size(95, 19);
            this.rbFisico.TabIndex = 0;
            this.rbFisico.Text = "Pessoa Física";
            this.rbFisico.UseVisualStyleBackColor = true;
            this.rbFisico.CheckedChanged += new System.EventHandler(this.rbFisico_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnCancelar.Location = new System.Drawing.Point(326, 435);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnGravar.Location = new System.Drawing.Point(232, 435);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(87, 27);
            this.btnGravar.TabIndex = 11;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // mskTelefone
            // 
            this.mskTelefone.Location = new System.Drawing.Point(171, 190);
            this.mskTelefone.Mask = "(00)00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(242, 24);
            this.mskTelefone.TabIndex = 4;
            // 
            // mskCpf
            // 
            this.mskCpf.Enabled = false;
            this.mskCpf.Location = new System.Drawing.Point(171, 220);
            this.mskCpf.Mask = "000.000.000-00";
            this.mskCpf.Name = "mskCpf";
            this.mskCpf.Size = new System.Drawing.Size(242, 24);
            this.mskCpf.TabIndex = 5;
            // 
            // mskCnpj
            // 
            this.mskCnpj.Enabled = false;
            this.mskCnpj.Location = new System.Drawing.Point(171, 250);
            this.mskCnpj.Mask = "00.000.000/0000-00";
            this.mskCnpj.Name = "mskCnpj";
            this.mskCnpj.Size = new System.Drawing.Size(242, 24);
            this.mskCnpj.TabIndex = 6;
            // 
            // mskRg
            // 
            this.mskRg.Enabled = false;
            this.mskRg.Location = new System.Drawing.Point(171, 340);
            this.mskRg.Mask = "0.000.000";
            this.mskRg.Name = "mskRg";
            this.mskRg.Size = new System.Drawing.Size(242, 24);
            this.mskRg.TabIndex = 9;
            // 
            // mskCnh
            // 
            this.mskCnh.Enabled = false;
            this.mskCnh.Location = new System.Drawing.Point(171, 280);
            this.mskCnh.Mask = "00000000000";
            this.mskCnh.Name = "mskCnh";
            this.mskCnh.Size = new System.Drawing.Size(242, 24);
            this.mskCnh.TabIndex = 7;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 8;
            this.bunifuElipse1.TargetControl = this;
            // 
            // rbJuridico
            // 
            this.rbJuridico.AutoSize = true;
            this.rbJuridico.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.rbJuridico.Location = new System.Drawing.Point(308, 96);
            this.rbJuridico.Name = "rbJuridico";
            this.rbJuridico.Size = new System.Drawing.Size(105, 19);
            this.rbJuridico.TabIndex = 1;
            this.rbJuridico.Text = "Pessoa Jurídica";
            this.rbJuridico.UseVisualStyleBackColor = true;
            this.rbJuridico.CheckedChanged += new System.EventHandler(this.rbJuridico_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label2.Location = new System.Drawing.Point(38, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Empresa relacionada:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label9.Location = new System.Drawing.Point(140, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Id:";
            // 
            // header_Cliente
            // 
            this.header_Cliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_Cliente.Controls.Add(this.label12);
            this.header_Cliente.Location = new System.Drawing.Point(-4, -1);
            this.header_Cliente.Name = "header_Cliente";
            this.header_Cliente.Size = new System.Drawing.Size(502, 29);
            this.header_Cliente.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Cadastro de Clientes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label13.Location = new System.Drawing.Point(118, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 27;
            this.label13.Text = "E-Mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(171, 370);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 24);
            this.txtEmail.TabIndex = 26;
            // 
            // TelaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 474);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.header_Cliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbJuridico);
            this.Controls.Add(this.mskCnh);
            this.Controls.Add(this.mskRg);
            this.Controls.Add(this.mskCnpj);
            this.Controls.Add(this.mskCpf);
            this.Controls.Add(this.mskTelefone);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rbFisico);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
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
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaClienteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaClienteForm_FormClosing);
            this.header_Cliente.ResumeLayout(false);
            this.header_Cliente.PerformLayout();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbFisico;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.MaskedTextBox mskCpf;
        private System.Windows.Forms.MaskedTextBox mskCnpj;
        private System.Windows.Forms.MaskedTextBox mskRg;
        private System.Windows.Forms.MaskedTextBox mskCnh;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.RadioButton rbJuridico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel header_Cliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmail;
    }
}