
namespace LocadoraVeiculo.WindowsApp
{
    partial class TelaConfigGeralForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxasEServiçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupoDeVeículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combustívelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolboxAcoes = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.statusStripFooter = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolboxAcoes.SuspendLayout();
            this.statusStripFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.cadastrosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(992, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taxasEServiçosToolStripMenuItem,
            this.grupoDeVeículosToolStripMenuItem,
            this.combustívelToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // taxasEServiçosToolStripMenuItem
            // 
            this.taxasEServiçosToolStripMenuItem.Name = "taxasEServiçosToolStripMenuItem";
            this.taxasEServiçosToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.taxasEServiçosToolStripMenuItem.Text = "Taxas e Serviços";
            this.taxasEServiçosToolStripMenuItem.Click += new System.EventHandler(this.taxasEServiçosToolStripMenuItem_Click);
            // 
            // grupoDeVeículosToolStripMenuItem
            // 
            this.grupoDeVeículosToolStripMenuItem.Name = "grupoDeVeículosToolStripMenuItem";
            this.grupoDeVeículosToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.grupoDeVeículosToolStripMenuItem.Text = "Grupo de Veículos";
            this.grupoDeVeículosToolStripMenuItem.Click += new System.EventHandler(this.grupoDeVeículosToolStripMenuItem_Click);
            // 
            // combustívelToolStripMenuItem
            // 
            this.combustívelToolStripMenuItem.Name = "combustívelToolStripMenuItem";
            this.combustívelToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.combustívelToolStripMenuItem.Text = "Combustível";
            this.combustívelToolStripMenuItem.Click += new System.EventHandler(this.combustívelToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            this.cadastrosToolStripMenuItem.Click += new System.EventHandler(this.cadastrosToolStripMenuItem_Click);
            // 
            // toolboxAcoes
            // 
            this.toolboxAcoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolboxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.labelTipoCadastro});
            this.toolboxAcoes.Location = new System.Drawing.Point(0, 24);
            this.toolboxAcoes.Name = "toolboxAcoes";
            this.toolboxAcoes.Size = new System.Drawing.Size(992, 41);
            this.toolboxAcoes.TabIndex = 5;
            this.toolboxAcoes.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionar.Enabled = false;
            this.btnAdicionar.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.outline_add_circle_outline_black_24dp;
            this.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdicionar.Size = new System.Drawing.Size(38, 38);
            this.btnAdicionar.Text = "toolStripButton1";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.outline_mode_edit_black_24dp;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "toolStripButton1";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.outline_delete_black_24dp;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(38, 38);
            this.btnExcluir.Text = "toolStripButton1";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(218, 38);
            this.labelTipoCadastro.Text = "Configuração Selecionada: Nenhuma";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRegistros.Location = new System.Drawing.Point(22, 100);
            this.panelRegistros.Margin = new System.Windows.Forms.Padding(4);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(948, 665);
            this.panelRegistros.TabIndex = 6;
            // 
            // statusStripFooter
            // 
            this.statusStripFooter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStripFooter.Location = new System.Drawing.Point(0, 769);
            this.statusStripFooter.Name = "statusStripFooter";
            this.statusStripFooter.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStripFooter.Size = new System.Drawing.Size(992, 22);
            this.statusStripFooter.TabIndex = 7;
            this.statusStripFooter.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(58, 17);
            this.labelRodape.Text = "Tudo Ok";
            // 
            // TelaConfigGeralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 791);
            this.Controls.Add(this.statusStripFooter);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolboxAcoes);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TelaConfigGeralForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaConfigGeralForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolboxAcoes.ResumeLayout(false);
            this.toolboxAcoes.PerformLayout();
            this.statusStripFooter.ResumeLayout(false);
            this.statusStripFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxasEServiçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupoDeVeículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combustívelToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolboxAcoes;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.StatusStrip statusStripFooter;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
    }
}