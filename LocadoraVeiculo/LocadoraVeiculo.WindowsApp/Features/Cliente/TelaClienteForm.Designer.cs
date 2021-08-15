
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
            this.txtID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(140, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(70, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(140, 109);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(404, 20);
            this.txtEndereco.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(140, 83);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(404, 20);
            this.txtNome.TabIndex = 2;
            // 
            // dtDataValidade
            // 
            this.dtDataValidade.Enabled = false;
            this.dtDataValidade.Location = new System.Drawing.Point(140, 240);
            this.dtDataValidade.Name = "dtDataValidade";
            this.dtDataValidade.Size = new System.Drawing.Size(404, 20);
            this.dtDataValidade.TabIndex = 8;
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.Enabled = false;
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(140, 293);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(404, 21);
            this.cbEmpresas.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "CPF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "CNPJ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "CNH:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data de Validade CNH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "RG:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Empresa relacionada:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Endereço:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(73, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Telefone:";
            // 
            // rbFisico
            // 
            this.rbFisico.AutoSize = true;
            this.rbFisico.Location = new System.Drawing.Point(218, 60);
            this.rbFisico.Name = "rbFisico";
            this.rbFisico.Size = new System.Drawing.Size(90, 17);
            this.rbFisico.TabIndex = 0;
            this.rbFisico.Text = "Pessoa Fìsica";
            this.rbFisico.UseVisualStyleBackColor = true;
            this.rbFisico.CheckedChanged += new System.EventHandler(this.rbFisico_CheckedChanged);
            // 
            // rbJuridico
            // 
            this.rbJuridico.AutoSize = true;
            this.rbJuridico.Location = new System.Drawing.Point(309, 60);
            this.rbJuridico.Name = "rbJuridico";
            this.rbJuridico.Size = new System.Drawing.Size(101, 17);
            this.rbJuridico.TabIndex = 1;
            this.rbJuridico.Text = "Pessoa Jurídica";
            this.rbJuridico.UseVisualStyleBackColor = true;
            this.rbJuridico.CheckedChanged += new System.EventHandler(this.rbJuridico_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(550, 356);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(469, 356);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 11;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // mskTelefone
            // 
            this.mskTelefone.Location = new System.Drawing.Point(140, 134);
            this.mskTelefone.Mask = "(00)00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(404, 20);
            this.mskTelefone.TabIndex = 4;
            // 
            // mskCpf
            // 
            this.mskCpf.Enabled = false;
            this.mskCpf.Location = new System.Drawing.Point(140, 161);
            this.mskCpf.Mask = "000.000.000-00";
            this.mskCpf.Name = "mskCpf";
            this.mskCpf.Size = new System.Drawing.Size(404, 20);
            this.mskCpf.TabIndex = 5;
            // 
            // mskCnpj
            // 
            this.mskCnpj.Enabled = false;
            this.mskCnpj.Location = new System.Drawing.Point(140, 187);
            this.mskCnpj.Mask = "00.000.000/0000-00";
            this.mskCnpj.Name = "mskCnpj";
            this.mskCnpj.Size = new System.Drawing.Size(404, 20);
            this.mskCnpj.TabIndex = 6;
            // 
            // mskRg
            // 
            this.mskRg.Enabled = false;
            this.mskRg.Location = new System.Drawing.Point(140, 266);
            this.mskRg.Mask = "0.000.000";
            this.mskRg.Name = "mskRg";
            this.mskRg.Size = new System.Drawing.Size(404, 20);
            this.mskRg.TabIndex = 9;
            // 
            // mskCnh
            // 
            this.mskCnh.Enabled = false;
            this.mskCnh.Location = new System.Drawing.Point(140, 213);
            this.mskCnh.Mask = "00000000000";
            this.mskCnh.Name = "mskCnh";
            this.mskCnh.Size = new System.Drawing.Size(404, 20);
            this.mskCnh.TabIndex = 7;
            // 
            // TelaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 391);
            this.Controls.Add(this.mskCnh);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaClienteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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