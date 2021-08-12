
namespace LocadoraVeiculo.WindowsApp.Features.Funcionarios
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
            this.text_salarioFuncionario = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data de Entrada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Salário:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Senha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Id:";
            // 
            // text_CPFFuncionario
            // 
            this.text_CPFFuncionario.Location = new System.Drawing.Point(189, 128);
            this.text_CPFFuncionario.Mask = "000.000.000-00";
            this.text_CPFFuncionario.Name = "text_CPFFuncionario";
            this.text_CPFFuncionario.Size = new System.Drawing.Size(100, 20);
            this.text_CPFFuncionario.TabIndex = 7;
            // 
            // text_IdFuncionario
            // 
            this.text_IdFuncionario.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.text_IdFuncionario.Enabled = false;
            this.text_IdFuncionario.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.text_IdFuncionario.Location = new System.Drawing.Point(189, 62);
            this.text_IdFuncionario.Name = "text_IdFuncionario";
            this.text_IdFuncionario.Size = new System.Drawing.Size(100, 20);
            this.text_IdFuncionario.TabIndex = 8;
            // 
            // text_NomeFuncionario
            // 
            this.text_NomeFuncionario.Location = new System.Drawing.Point(189, 97);
            this.text_NomeFuncionario.Name = "text_NomeFuncionario";
            this.text_NomeFuncionario.Size = new System.Drawing.Size(332, 20);
            this.text_NomeFuncionario.TabIndex = 9;
            // 
            // text_UsuarioFuncionario
            // 
            this.text_UsuarioFuncionario.Location = new System.Drawing.Point(189, 262);
            this.text_UsuarioFuncionario.Name = "text_UsuarioFuncionario";
            this.text_UsuarioFuncionario.Size = new System.Drawing.Size(100, 20);
            this.text_UsuarioFuncionario.TabIndex = 11;
            // 
            // text_SenhaFuncionario
            // 
            this.text_SenhaFuncionario.Location = new System.Drawing.Point(189, 290);
            this.text_SenhaFuncionario.Name = "text_SenhaFuncionario";
            this.text_SenhaFuncionario.Size = new System.Drawing.Size(100, 20);
            this.text_SenhaFuncionario.TabIndex = 12;
            // 
            // bt_GravarFuncionario
            // 
            this.bt_GravarFuncionario.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_GravarFuncionario.Location = new System.Drawing.Point(423, 339);
            this.bt_GravarFuncionario.Name = "bt_GravarFuncionario";
            this.bt_GravarFuncionario.Size = new System.Drawing.Size(75, 23);
            this.bt_GravarFuncionario.TabIndex = 13;
            this.bt_GravarFuncionario.Text = "Gravar";
            this.bt_GravarFuncionario.UseVisualStyleBackColor = true;
            this.bt_GravarFuncionario.Click += new System.EventHandler(this.bt_GravarFuncionario_Click);
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancelar.Location = new System.Drawing.Point(524, 339);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancelar.TabIndex = 14;
            this.bt_Cancelar.Text = "Cancelar";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
            // 
            // date_EntradaFuncionario
            // 
            this.date_EntradaFuncionario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_EntradaFuncionario.Location = new System.Drawing.Point(423, 129);
            this.date_EntradaFuncionario.Name = "date_EntradaFuncionario";
            this.date_EntradaFuncionario.Size = new System.Drawing.Size(98, 20);
            this.date_EntradaFuncionario.TabIndex = 15;
            // 
            // text_salarioFuncionario
            // 
            this.text_salarioFuncionario.Location = new System.Drawing.Point(189, 170);
            this.text_salarioFuncionario.Name = "text_salarioFuncionario";
            this.text_salarioFuncionario.Size = new System.Drawing.Size(100, 20);
            this.text_salarioFuncionario.TabIndex = 16;
            this.text_salarioFuncionario.ValidatingType = typeof(int);
            // 
            // TelaFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 391);
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
            this.Name = "TelaFuncionarioForm";
            this.ShowIcon = false;
            this.Text = "Cadastro de Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaFuncionarioForm_FormClosing);
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
        private System.Windows.Forms.MaskedTextBox text_salarioFuncionario;
    }
}