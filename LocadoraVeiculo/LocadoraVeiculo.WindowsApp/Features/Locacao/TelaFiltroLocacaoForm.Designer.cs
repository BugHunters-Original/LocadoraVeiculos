
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFiltroLocacaoForm));
            this.rdbDevolucoes = new System.Windows.Forms.RadioButton();
            this.rdbChegadasPendentes = new System.Windows.Forms.RadioButton();
            this.rdbTodasLocacoes = new System.Windows.Forms.RadioButton();
            this.rdbReservasHoje = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbDevolucoes
            // 
            this.rdbDevolucoes.AutoSize = true;
            this.rdbDevolucoes.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbDevolucoes.Location = new System.Drawing.Point(35, 106);
            this.rdbDevolucoes.Name = "rdbDevolucoes";
            this.rdbDevolucoes.Size = new System.Drawing.Size(213, 25);
            this.rdbDevolucoes.TabIndex = 0;
            this.rdbDevolucoes.TabStop = true;
            this.rdbDevolucoes.Text = "Visualizar Devoluções";
            this.rdbDevolucoes.UseVisualStyleBackColor = true;
            // 
            // rdbChegadasPendentes
            // 
            this.rdbChegadasPendentes.AutoSize = true;
            this.rdbChegadasPendentes.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbChegadasPendentes.Location = new System.Drawing.Point(35, 180);
            this.rdbChegadasPendentes.Name = "rdbChegadasPendentes";
            this.rdbChegadasPendentes.Size = new System.Drawing.Size(288, 25);
            this.rdbChegadasPendentes.TabIndex = 1;
            this.rdbChegadasPendentes.TabStop = true;
            this.rdbChegadasPendentes.Text = "Visualizar Chegadas Pendentes";
            this.rdbChegadasPendentes.UseVisualStyleBackColor = true;
            // 
            // rdbTodasLocacoes
            // 
            this.rdbTodasLocacoes.AutoSize = true;
            this.rdbTodasLocacoes.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbTodasLocacoes.Location = new System.Drawing.Point(35, 254);
            this.rdbTodasLocacoes.Name = "rdbTodasLocacoes";
            this.rdbTodasLocacoes.Size = new System.Drawing.Size(273, 25);
            this.rdbTodasLocacoes.TabIndex = 2;
            this.rdbTodasLocacoes.TabStop = true;
            this.rdbTodasLocacoes.Text = "Visualizar Todas as Locações";
            this.rdbTodasLocacoes.UseVisualStyleBackColor = true;
            // 
            // rdbReservasHoje
            // 
            this.rdbReservasHoje.AutoSize = true;
            this.rdbReservasHoje.Enabled = false;
            this.rdbReservasHoje.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.rdbReservasHoje.Location = new System.Drawing.Point(35, 32);
            this.rdbReservasHoje.Name = "rdbReservasHoje";
            this.rdbReservasHoje.Size = new System.Drawing.Size(277, 25);
            this.rdbReservasHoje.TabIndex = 3;
            this.rdbReservasHoje.TabStop = true;
            this.rdbReservasHoje.Text = "Visualizar Reservas para Hoje";
            this.rdbReservasHoje.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 324);
            this.Controls.Add(this.rdbReservasHoje);
            this.Controls.Add(this.rdbTodasLocacoes);
            this.Controls.Add(this.rdbChegadasPendentes);
            this.Controls.Add(this.rdbDevolucoes);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaFiltroLocacaoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro Locações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbDevolucoes;
        private System.Windows.Forms.RadioButton rdbChegadasPendentes;
        private System.Windows.Forms.RadioButton rdbTodasLocacoes;
        private System.Windows.Forms.RadioButton rdbReservasHoje;
    }
}