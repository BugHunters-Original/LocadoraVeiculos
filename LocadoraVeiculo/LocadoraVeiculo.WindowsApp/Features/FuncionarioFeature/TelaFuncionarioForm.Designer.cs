
namespace LocadoraVeiculo.WindowsApp.Features.FuncionarioFeature
{
    partial class TelaFuncionarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFuncionarioForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.text_CPFFuncionario = new System.Windows.Forms.MaskedTextBox();
            this.text_IdFuncionario = new System.Windows.Forms.TextBox();
            this.text_NomeFuncionario = new System.Windows.Forms.TextBox();
            this.text_UsuarioFuncionario = new System.Windows.Forms.TextBox();
            this.text_SenhaFuncionario = new System.Windows.Forms.TextBox();
            this.bt_GravarFuncionario = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.date_EntradaFuncionario = new System.Windows.Forms.DateTimePicker();
            this.text_salarioFuncionario = new System.Windows.Forms.TextBox();
            this.header_Funcionario = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.header_Funcionario.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label1.Location = new System.Drawing.Point(59, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label2.Location = new System.Drawing.Point(71, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label3.Location = new System.Drawing.Point(280, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data de Entrada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label4.Location = new System.Drawing.Point(49, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label5.Location = new System.Drawing.Point(55, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Salário:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(332, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Senha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(81, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Id:";
            // 
            // text_CPFFuncionario
            // 
            this.text_CPFFuncionario.Location = new System.Drawing.Point(107, 134);
            this.text_CPFFuncionario.Mask = "000.000.000-00";
            this.text_CPFFuncionario.Name = "text_CPFFuncionario";
            this.text_CPFFuncionario.Size = new System.Drawing.Size(116, 24);
            this.text_CPFFuncionario.TabIndex = 1;
            // 
            // text_IdFuncionario
            // 
            this.text_IdFuncionario.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.text_IdFuncionario.Enabled = false;
            this.text_IdFuncionario.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.text_IdFuncionario.Location = new System.Drawing.Point(107, 53);
            this.text_IdFuncionario.Name = "text_IdFuncionario";
            this.text_IdFuncionario.Size = new System.Drawing.Size(116, 24);
            this.text_IdFuncionario.TabIndex = 8;
            // 
            // text_NomeFuncionario
            // 
            this.text_NomeFuncionario.Location = new System.Drawing.Point(107, 92);
            this.text_NomeFuncionario.Name = "text_NomeFuncionario";
            this.text_NomeFuncionario.Size = new System.Drawing.Size(387, 24);
            this.text_NomeFuncionario.TabIndex = 0;
            // 
            // text_UsuarioFuncionario
            // 
            this.text_UsuarioFuncionario.Location = new System.Drawing.Point(107, 172);
            this.text_UsuarioFuncionario.Name = "text_UsuarioFuncionario";
            this.text_UsuarioFuncionario.Size = new System.Drawing.Size(116, 24);
            this.text_UsuarioFuncionario.TabIndex = 3;
            // 
            // text_SenhaFuncionario
            // 
            this.text_SenhaFuncionario.Location = new System.Drawing.Point(379, 172);
            this.text_SenhaFuncionario.Name = "text_SenhaFuncionario";
            this.text_SenhaFuncionario.Size = new System.Drawing.Size(116, 24);
            this.text_SenhaFuncionario.TabIndex = 4;
            // 
            // bt_GravarFuncionario
            // 
            this.bt_GravarFuncionario.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_GravarFuncionario.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.bt_GravarFuncionario.Location = new System.Drawing.Point(312, 273);
            this.bt_GravarFuncionario.Name = "bt_GravarFuncionario";
            this.bt_GravarFuncionario.Size = new System.Drawing.Size(87, 27);
            this.bt_GravarFuncionario.TabIndex = 6;
            this.bt_GravarFuncionario.Text = "Gravar";
            this.bt_GravarFuncionario.UseVisualStyleBackColor = true;
            this.bt_GravarFuncionario.Click += new System.EventHandler(this.bt_GravarFuncionario_Click);
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.bt_Cancelar.Location = new System.Drawing.Point(407, 273);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(87, 27);
            this.bt_Cancelar.TabIndex = 7;
            this.bt_Cancelar.Text = "Cancelar";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
            // 
            // date_EntradaFuncionario
            // 
            this.date_EntradaFuncionario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_EntradaFuncionario.Location = new System.Drawing.Point(380, 134);
            this.date_EntradaFuncionario.Name = "date_EntradaFuncionario";
            this.date_EntradaFuncionario.Size = new System.Drawing.Size(114, 24);
            this.date_EntradaFuncionario.TabIndex = 2;
            // 
            // text_salarioFuncionario
            // 
            this.text_salarioFuncionario.Location = new System.Drawing.Point(107, 214);
            this.text_salarioFuncionario.Name = "text_salarioFuncionario";
            this.text_salarioFuncionario.Size = new System.Drawing.Size(116, 24);
            this.text_salarioFuncionario.TabIndex = 5;
            this.text_salarioFuncionario.Text = "0";
            this.text_salarioFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // header_Funcionario
            // 
            this.header_Funcionario.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_Funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_Funcionario.Controls.Add(this.label8);
            this.header_Funcionario.Location = new System.Drawing.Point(-3, -1);
            this.header_Funcionario.Name = "header_Funcionario";
            this.header_Funcionario.Size = new System.Drawing.Size(546, 29);
            this.header_Funcionario.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cadastro de Funcionários";
            // 
            // TelaFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 327);
            this.Controls.Add(this.header_Funcionario);
            this.Controls.Add(this.text_salarioFuncionario);
            this.Controls.Add(this.date_EntradaFuncionario);
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.bt_GravarFuncionario);
            this.Controls.Add(this.text_SenhaFuncionario);
            this.Controls.Add(this.text_UsuarioFuncionario);
            this.Controls.Add(this.text_NomeFuncionario);
            this.Controls.Add(this.text_IdFuncionario);
            this.Controls.Add(this.text_CPFFuncionario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaFuncionarioForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaFuncionarioForm_FormClosing);
            this.header_Funcionario.ResumeLayout(false);
            this.header_Funcionario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox text_CPFFuncionario;
        private System.Windows.Forms.TextBox text_IdFuncionario;
        private System.Windows.Forms.TextBox text_NomeFuncionario;
        private System.Windows.Forms.TextBox text_UsuarioFuncionario;
        private System.Windows.Forms.TextBox text_SenhaFuncionario;
        private System.Windows.Forms.Button bt_GravarFuncionario;
        private System.Windows.Forms.Button bt_Cancelar;
        private System.Windows.Forms.DateTimePicker date_EntradaFuncionario;
        private System.Windows.Forms.TextBox text_salarioFuncionario;
        private System.Windows.Forms.Panel header_Funcionario;
        private System.Windows.Forms.Label label8;
    }
}