
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaGrupoVeiculoForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiario = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorKmRodadoPDiario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorDiarioPDiario = new System.Windows.Forms.TextBox();
            this.tabControlado = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorKmRodadoPControlado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLimitePControlado = new System.Windows.Forms.TextBox();
            this.txtValorDiarioPControlado = new System.Windows.Forms.TextBox();
            this.tabLivre = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiariaPLivre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.header_GrupoVeiculo = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDiario.SuspendLayout();
            this.tabControlado.SuspendLayout();
            this.tabLivre.SuspendLayout();
            this.header_GrupoVeiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDiario);
            this.tabControl1.Controls.Add(this.tabControlado);
            this.tabControl1.Controls.Add(this.tabLivre);
            this.tabControl1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.tabControl1.Location = new System.Drawing.Point(37, 141);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 193);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // tabDiario
            // 
            this.tabDiario.Controls.Add(this.label2);
            this.tabDiario.Controls.Add(this.txtValorKmRodadoPDiario);
            this.tabDiario.Controls.Add(this.label1);
            this.tabDiario.Controls.Add(this.txtValorDiarioPDiario);
            this.tabDiario.Location = new System.Drawing.Point(4, 25);
            this.tabDiario.Name = "tabDiario";
            this.tabDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiario.Size = new System.Drawing.Size(378, 164);
            this.tabDiario.TabIndex = 0;
            this.tabDiario.Text = "Plano Diário";
            this.tabDiario.UseVisualStyleBackColor = true;
            this.tabDiario.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor KM Rodado:";
            // 
            // txtValorKmRodadoPDiario
            // 
            this.txtValorKmRodadoPDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtValorKmRodadoPDiario.Location = new System.Drawing.Point(166, 84);
            this.txtValorKmRodadoPDiario.Name = "txtValorKmRodadoPDiario";
            this.txtValorKmRodadoPDiario.Size = new System.Drawing.Size(116, 22);
            this.txtValorKmRodadoPDiario.TabIndex = 3;
            this.txtValorKmRodadoPDiario.Text = "0";
            this.txtValorKmRodadoPDiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor Diária:";
            // 
            // txtValorDiarioPDiario
            // 
            this.txtValorDiarioPDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtValorDiarioPDiario.Location = new System.Drawing.Point(166, 54);
            this.txtValorDiarioPDiario.Name = "txtValorDiarioPDiario";
            this.txtValorDiarioPDiario.Size = new System.Drawing.Size(116, 22);
            this.txtValorDiarioPDiario.TabIndex = 2;
            this.txtValorDiarioPDiario.Text = "0";
            this.txtValorDiarioPDiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabControlado
            // 
            this.tabControlado.Controls.Add(this.label8);
            this.tabControlado.Controls.Add(this.txtValorKmRodadoPControlado);
            this.tabControlado.Controls.Add(this.label4);
            this.tabControlado.Controls.Add(this.label3);
            this.tabControlado.Controls.Add(this.txtLimitePControlado);
            this.tabControlado.Controls.Add(this.txtValorDiarioPControlado);
            this.tabControlado.Location = new System.Drawing.Point(4, 25);
            this.tabControlado.Name = "tabControlado";
            this.tabControlado.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlado.Size = new System.Drawing.Size(378, 164);
            this.tabControlado.TabIndex = 1;
            this.tabControlado.Text = "Plano Controlado";
            this.tabControlado.UseVisualStyleBackColor = true;
            this.tabControlado.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Valor KM Rodado:";
            // 
            // txtValorKmRodadoPControlado
            // 
            this.txtValorKmRodadoPControlado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtValorKmRodadoPControlado.Location = new System.Drawing.Point(166, 70);
            this.txtValorKmRodadoPControlado.Name = "txtValorKmRodadoPControlado";
            this.txtValorKmRodadoPControlado.Size = new System.Drawing.Size(116, 22);
            this.txtValorKmRodadoPControlado.TabIndex = 6;
            this.txtValorKmRodadoPControlado.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valor Diária:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Limite KM:";
            // 
            // txtLimitePControlado
            // 
            this.txtLimitePControlado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtLimitePControlado.Location = new System.Drawing.Point(166, 102);
            this.txtLimitePControlado.Name = "txtLimitePControlado";
            this.txtLimitePControlado.Size = new System.Drawing.Size(116, 22);
            this.txtLimitePControlado.TabIndex = 7;
            this.txtLimitePControlado.Text = "0";
            this.txtLimitePControlado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtValorDiarioPControlado
            // 
            this.txtValorDiarioPControlado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtValorDiarioPControlado.Location = new System.Drawing.Point(166, 39);
            this.txtValorDiarioPControlado.Name = "txtValorDiarioPControlado";
            this.txtValorDiarioPControlado.Size = new System.Drawing.Size(116, 22);
            this.txtValorDiarioPControlado.TabIndex = 5;
            this.txtValorDiarioPControlado.Text = "0";
            this.txtValorDiarioPControlado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabLivre
            // 
            this.tabLivre.Controls.Add(this.label5);
            this.tabLivre.Controls.Add(this.txtDiariaPLivre);
            this.tabLivre.Location = new System.Drawing.Point(4, 25);
            this.tabLivre.Name = "tabLivre";
            this.tabLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabLivre.Size = new System.Drawing.Size(378, 164);
            this.tabLivre.TabIndex = 2;
            this.tabLivre.Text = "Plano Livre";
            this.tabLivre.UseVisualStyleBackColor = true;
            this.tabLivre.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Valor Diária:";
            // 
            // txtDiariaPLivre
            // 
            this.txtDiariaPLivre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtDiariaPLivre.Location = new System.Drawing.Point(166, 73);
            this.txtDiariaPLivre.Name = "txtDiariaPLivre";
            this.txtDiariaPLivre.Size = new System.Drawing.Size(116, 22);
            this.txtDiariaPLivre.TabIndex = 9;
            this.txtDiariaPLivre.Text = "0";
            this.txtDiariaPLivre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label6.Location = new System.Drawing.Point(39, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Categoria Veicular:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(182, 100);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(236, 26);
            this.txtNome.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.label7.Location = new System.Drawing.Point(152, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Id:";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnGravar.Location = new System.Drawing.Point(241, 359);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(87, 27);
            this.btnGravar.TabIndex = 10;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Location = new System.Drawing.Point(182, 56);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(59, 28);
            this.txtId.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnCancelar.Location = new System.Drawing.Point(336, 359);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 8;
            this.bunifuElipse1.TargetControl = this;
            // 
            // header_GrupoVeiculo
            // 
            this.header_GrupoVeiculo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_GrupoVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_GrupoVeiculo.Controls.Add(this.label9);
            this.header_GrupoVeiculo.Location = new System.Drawing.Point(-6, -1);
            this.header_GrupoVeiculo.Name = "header_GrupoVeiculo";
            this.header_GrupoVeiculo.Size = new System.Drawing.Size(546, 29);
            this.header_GrupoVeiculo.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cadastro de Grupo de Veículos";
            // 
            // TelaGrupoVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 410);
            this.Controls.Add(this.header_GrupoVeiculo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.header_GrupoVeiculo.ResumeLayout(false);
            this.header_GrupoVeiculo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDiario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorKmRodadoPDiario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorDiarioPDiario;
        private System.Windows.Forms.TabPage tabControlado;
        private System.Windows.Forms.TabPage tabLivre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLimitePControlado;
        private System.Windows.Forms.TextBox txtValorDiarioPControlado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiariaPLivre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorKmRodadoPControlado;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel header_GrupoVeiculo;
        private System.Windows.Forms.Label label9;
    }
}