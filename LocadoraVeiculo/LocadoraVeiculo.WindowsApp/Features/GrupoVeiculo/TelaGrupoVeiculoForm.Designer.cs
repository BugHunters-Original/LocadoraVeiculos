
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.tabControl1.Location = new System.Drawing.Point(133, 104);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(331, 208);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDiario
            // 
            this.tabDiario.Controls.Add(this.label2);
            this.tabDiario.Controls.Add(this.txtPrecoKmDiario);
            this.tabDiario.Controls.Add(this.label1);
            this.tabDiario.Controls.Add(this.txtValorDiarioPDiario);
            this.tabDiario.Location = new System.Drawing.Point(4, 22);
            this.tabDiario.Name = "tabDiario";
            this.tabDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiario.Size = new System.Drawing.Size(323, 182);
            this.tabDiario.TabIndex = 0;
            this.tabDiario.Text = "PLANO DIÁRIO";
            this.tabDiario.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "VALOR KM DIÁRIA";
            // 
            // txtPrecoKmDiario
            // 
            this.txtPrecoKmDiario.Location = new System.Drawing.Point(132, 84);
            this.txtPrecoKmDiario.Name = "txtPrecoKmDiario";
            this.txtPrecoKmDiario.Size = new System.Drawing.Size(100, 20);
            this.txtPrecoKmDiario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VALOR DIÁRIA";
            // 
            // txtValorDiarioPDiario
            // 
            this.txtValorDiarioPDiario.Location = new System.Drawing.Point(132, 53);
            this.txtValorDiarioPDiario.Name = "txtValorDiarioPDiario";
            this.txtValorDiarioPDiario.Size = new System.Drawing.Size(100, 20);
            this.txtValorDiarioPDiario.TabIndex = 1;
            // 
            // tabControlado
            // 
            this.tabControlado.Controls.Add(this.label3);
            this.tabControlado.Controls.Add(this.txtKmDia_KmControlado);
            this.tabControlado.Controls.Add(this.label4);
            this.tabControlado.Controls.Add(this.txtValorDiarioPControlado);
            this.tabControlado.Location = new System.Drawing.Point(4, 22);
            this.tabControlado.Name = "tabControlado";
            this.tabControlado.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlado.Size = new System.Drawing.Size(323, 182);
            this.tabControlado.TabIndex = 1;
            this.tabControlado.Text = "PLANO CONTROLADO";
            this.tabControlado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "KM/DIA";
            // 
            // txtKmDia_KmControlado
            // 
            this.txtKmDia_KmControlado.Location = new System.Drawing.Point(137, 84);
            this.txtKmDia_KmControlado.Name = "txtKmDia_KmControlado";
            this.txtKmDia_KmControlado.Size = new System.Drawing.Size(100, 20);
            this.txtKmDia_KmControlado.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "VALOR CONTROLADO";
            // 
            // txtValorDiarioPControlado
            // 
            this.txtValorDiarioPControlado.Location = new System.Drawing.Point(137, 53);
            this.txtValorDiarioPControlado.Name = "txtValorDiarioPControlado";
            this.txtValorDiarioPControlado.Size = new System.Drawing.Size(100, 20);
            this.txtValorDiarioPControlado.TabIndex = 4;
            // 
            // tabLivre
            // 
            this.tabLivre.Controls.Add(this.label5);
            this.tabLivre.Controls.Add(this.txtPrecoKmLivre);
            this.tabLivre.Location = new System.Drawing.Point(4, 22);
            this.tabLivre.Name = "tabLivre";
            this.tabLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabLivre.Size = new System.Drawing.Size(323, 182);
            this.tabLivre.TabIndex = 2;
            this.tabLivre.Text = "PLANO LIVRE";
            this.tabLivre.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "VALOR KM LIVRE";
            // 
            // txtPrecoKmLivre
            // 
            this.txtPrecoKmLivre.Location = new System.Drawing.Point(136, 58);
            this.txtPrecoKmLivre.Name = "txtPrecoKmLivre";
            this.txtPrecoKmLivre.Size = new System.Drawing.Size(100, 20);
            this.txtPrecoKmLivre.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "CATEGORIA VEICULAR";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(223, 53);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(147, 22);
            this.txtNome.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(137, 18);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(41, 20);
            this.txtId.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(385, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "GRAVAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // TelaGrupoVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 391);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaGrupoVeiculoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo Veículos";
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
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button button1;
    }
}