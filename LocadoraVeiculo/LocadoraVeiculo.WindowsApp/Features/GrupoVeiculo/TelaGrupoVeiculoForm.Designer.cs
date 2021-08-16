﻿
namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo
{
    partial class TelaGrupoVeiculoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaGrupoVeiculoForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiario = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecoKmDiario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorDiarioPDiario = new System.Windows.Forms.TextBox();
            this.tabControlado = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKmDia_KmControlado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorDiarioPControlado = new System.Windows.Forms.TextBox();
            this.tabLivre = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecoKmLivre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_GravarFuncionario = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabDiario.SuspendLayout();
            this.tabControlado.SuspendLayout();
            this.tabLivre.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDiario);
            this.tabControl1.Controls.Add(this.tabControlado);
            this.tabControl1.Controls.Add(this.tabLivre);
            this.tabControl1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.tabControl1.Location = new System.Drawing.Point(96, 74);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 256);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // tabDiario
            // 
            this.tabDiario.Controls.Add(this.label2);
            this.tabDiario.Controls.Add(this.txtPrecoKmDiario);
            this.tabDiario.Controls.Add(this.label1);
            this.tabDiario.Controls.Add(this.txtValorDiarioPDiario);
            this.tabDiario.Location = new System.Drawing.Point(4, 25);
            this.tabDiario.Margin = new System.Windows.Forms.Padding(4);
            this.tabDiario.Name = "tabDiario";
            this.tabDiario.Padding = new System.Windows.Forms.Padding(4);
            this.tabDiario.Size = new System.Drawing.Size(433, 227);
            this.tabDiario.TabIndex = 0;
            this.tabDiario.Text = "PLANO DIÁRIO";
            this.tabDiario.UseVisualStyleBackColor = true;
            this.tabDiario.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "VALOR KM DIÁRIA";
            // 
            // txtPrecoKmDiario
            // 
            this.txtPrecoKmDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtPrecoKmDiario.Location = new System.Drawing.Point(176, 103);
            this.txtPrecoKmDiario.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecoKmDiario.Name = "txtPrecoKmDiario";
            this.txtPrecoKmDiario.Size = new System.Drawing.Size(132, 22);
            this.txtPrecoKmDiario.TabIndex = 2;
            this.txtPrecoKmDiario.Text = "0";
            this.txtPrecoKmDiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "VALOR DIÁRIA";
            // 
            // txtValorDiarioPDiario
            // 
            this.txtValorDiarioPDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtValorDiarioPDiario.Location = new System.Drawing.Point(176, 65);
            this.txtValorDiarioPDiario.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorDiarioPDiario.Name = "txtValorDiarioPDiario";
            this.txtValorDiarioPDiario.Size = new System.Drawing.Size(132, 22);
            this.txtValorDiarioPDiario.TabIndex = 1;
            this.txtValorDiarioPDiario.Text = "0";
            this.txtValorDiarioPDiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabControlado
            // 
            this.tabControlado.Controls.Add(this.label3);
            this.tabControlado.Controls.Add(this.txtKmDia_KmControlado);
            this.tabControlado.Controls.Add(this.label4);
            this.tabControlado.Controls.Add(this.txtValorDiarioPControlado);
            this.tabControlado.Location = new System.Drawing.Point(4, 25);
            this.tabControlado.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlado.Name = "tabControlado";
            this.tabControlado.Padding = new System.Windows.Forms.Padding(4);
            this.tabControlado.Size = new System.Drawing.Size(433, 227);
            this.tabControlado.TabIndex = 1;
            this.tabControlado.Text = "PLANO CONTROLADO";
            this.tabControlado.UseVisualStyleBackColor = true;
            this.tabControlado.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "KM/DIA";
            // 
            // txtKmDia_KmControlado
            // 
            this.txtKmDia_KmControlado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtKmDia_KmControlado.Location = new System.Drawing.Point(183, 103);
            this.txtKmDia_KmControlado.Margin = new System.Windows.Forms.Padding(4);
            this.txtKmDia_KmControlado.Name = "txtKmDia_KmControlado";
            this.txtKmDia_KmControlado.Size = new System.Drawing.Size(132, 22);
            this.txtKmDia_KmControlado.TabIndex = 6;
            this.txtKmDia_KmControlado.Text = "0";
            this.txtKmDia_KmControlado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "VALOR CONTROLADO";
            // 
            // txtValorDiarioPControlado
            // 
            this.txtValorDiarioPControlado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtValorDiarioPControlado.Location = new System.Drawing.Point(183, 65);
            this.txtValorDiarioPControlado.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorDiarioPControlado.Name = "txtValorDiarioPControlado";
            this.txtValorDiarioPControlado.Size = new System.Drawing.Size(132, 22);
            this.txtValorDiarioPControlado.TabIndex = 4;
            this.txtValorDiarioPControlado.Text = "0";
            this.txtValorDiarioPControlado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabLivre
            // 
            this.tabLivre.Controls.Add(this.label5);
            this.tabLivre.Controls.Add(this.txtPrecoKmLivre);
            this.tabLivre.Location = new System.Drawing.Point(4, 25);
            this.tabLivre.Margin = new System.Windows.Forms.Padding(4);
            this.tabLivre.Name = "tabLivre";
            this.tabLivre.Padding = new System.Windows.Forms.Padding(4);
            this.tabLivre.Size = new System.Drawing.Size(433, 227);
            this.tabLivre.TabIndex = 2;
            this.tabLivre.Text = "PLANO LIVRE";
            this.tabLivre.UseVisualStyleBackColor = true;
            this.tabLivre.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "VALOR KM LIVRE";
            // 
            // txtPrecoKmLivre
            // 
            this.txtPrecoKmLivre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtPrecoKmLivre.Location = new System.Drawing.Point(181, 72);
            this.txtPrecoKmLivre.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecoKmLivre.Name = "txtPrecoKmLivre";
            this.txtPrecoKmLivre.Size = new System.Drawing.Size(132, 22);
            this.txtPrecoKmLivre.TabIndex = 2;
            this.txtPrecoKmLivre.Text = "0";
            this.txtPrecoKmLivre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(231, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "CATEGORIA VEICULAR";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(213, 40);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(195, 26);
            this.txtNome.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(103, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "ID";
            // 
            // bt_GravarFuncionario
            // 
            this.bt_GravarFuncionario.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_GravarFuncionario.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.bt_GravarFuncionario.Location = new System.Drawing.Point(411, 342);
            this.bt_GravarFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.bt_GravarFuncionario.Name = "bt_GravarFuncionario";
            this.bt_GravarFuncionario.Size = new System.Drawing.Size(100, 28);
            this.bt_GravarFuncionario.TabIndex = 14;
            this.bt_GravarFuncionario.Text = "Gravar";
            this.bt_GravarFuncionario.UseVisualStyleBackColor = true;
            this.bt_GravarFuncionario.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Location = new System.Drawing.Point(136, 43);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(53, 22);
            this.txtId.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnCancelar.Location = new System.Drawing.Point(519, 342);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaGrupoVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 383);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.bt_GravarFuncionario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaGrupoVeiculoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Grupo de Veículos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaGrupoVeiculoForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabDiario.ResumeLayout(false);
            this.tabDiario.PerformLayout();
            this.tabControlado.ResumeLayout(false);
            this.tabControlado.PerformLayout();
            this.tabLivre.ResumeLayout(false);
            this.tabLivre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDiario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecoKmDiario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorDiarioPDiario;
        private System.Windows.Forms.TabPage tabControlado;
        private System.Windows.Forms.TabPage tabLivre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKmDia_KmControlado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorDiarioPControlado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecoKmLivre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_GravarFuncionario;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnCancelar;
    }
}