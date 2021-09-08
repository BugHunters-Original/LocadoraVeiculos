
namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    partial class TelaFiltroLocacaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFiltroLocacaoForm));
            this.rdbDevolucoes = new System.Windows.Forms.RadioButton();
            this.rdbChegadasPendentes = new System.Windows.Forms.RadioButton();
            this.rdbTodasLocacoes = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.header_FiltroLocacao = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.header_FiltroLocacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbDevolucoes
            // 
            this.rdbDevolucoes.AutoSize = true;
            this.rdbDevolucoes.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbDevolucoes.Location = new System.Drawing.Point(48, 139);
            this.rdbDevolucoes.Name = "rdbDevolucoes";
            this.rdbDevolucoes.Size = new System.Drawing.Size(239, 21);
            this.rdbDevolucoes.TabIndex = 2;
            this.rdbDevolucoes.Text = "Visualizar Locações Concluídas";
            this.rdbDevolucoes.UseVisualStyleBackColor = true;
            // 
            // rdbChegadasPendentes
            // 
            this.rdbChegadasPendentes.AutoSize = true;
            this.rdbChegadasPendentes.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbChegadasPendentes.Location = new System.Drawing.Point(48, 204);
            this.rdbChegadasPendentes.Name = "rdbChegadasPendentes";
            this.rdbChegadasPendentes.Size = new System.Drawing.Size(234, 21);
            this.rdbChegadasPendentes.TabIndex = 3;
            this.rdbChegadasPendentes.Text = "Visualizar Locações Pendentes";
            this.rdbChegadasPendentes.UseVisualStyleBackColor = true;
            // 
            // rdbTodasLocacoes
            // 
            this.rdbTodasLocacoes.AutoSize = true;
            this.rdbTodasLocacoes.Checked = true;
            this.rdbTodasLocacoes.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbTodasLocacoes.Location = new System.Drawing.Point(48, 74);
            this.rdbTodasLocacoes.Name = "rdbTodasLocacoes";
            this.rdbTodasLocacoes.Size = new System.Drawing.Size(224, 21);
            this.rdbTodasLocacoes.TabIndex = 1;
            this.rdbTodasLocacoes.TabStop = true;
            this.rdbTodasLocacoes.Text = "Visualizar Todas as Locações";
            this.rdbTodasLocacoes.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(212, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(131, 276);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "Filtrar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 8;
            this.bunifuElipse1.TargetControl = this;
            // 
            // header_FiltroLocacao
            // 
            this.header_FiltroLocacao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_FiltroLocacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_FiltroLocacao.Controls.Add(this.label8);
            this.header_FiltroLocacao.Location = new System.Drawing.Point(-1, -1);
            this.header_FiltroLocacao.Name = "header_FiltroLocacao";
            this.header_FiltroLocacao.Size = new System.Drawing.Size(342, 29);
            this.header_FiltroLocacao.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Filtrar Locação";
            // 
            // TelaFiltroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 324);
            this.Controls.Add(this.header_FiltroLocacao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rdbTodasLocacoes);
            this.Controls.Add(this.rdbChegadasPendentes);
            this.Controls.Add(this.rdbDevolucoes);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaFiltroLocacaoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro Locações";
            this.header_FiltroLocacao.ResumeLayout(false);
            this.header_FiltroLocacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbDevolucoes;
        private System.Windows.Forms.RadioButton rdbChegadasPendentes;
        private System.Windows.Forms.RadioButton rdbTodasLocacoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel header_FiltroLocacao;
        private System.Windows.Forms.Label label8;
    }
}