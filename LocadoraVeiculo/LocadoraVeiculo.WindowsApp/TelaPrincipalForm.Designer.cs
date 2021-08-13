
namespace LocadoraVeiculo.WindowsApp
{
    partial class TelaPrincipalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipalForm));
            this.toolboxAcoes = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.btnDevolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLocacao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVeiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripFooter = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.toolboxAcoes.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStripFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolboxAcoes
            // 
            this.toolboxAcoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolboxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.btnFiltrar,
            this.btnDevolver,
            this.toolStripSeparator2,
            this.labelTipoCadastro});
            this.toolboxAcoes.Location = new System.Drawing.Point(0, 24);
            this.toolboxAcoes.Name = "toolboxAcoes";
            this.toolboxAcoes.Size = new System.Drawing.Size(992, 41);
            this.toolboxAcoes.TabIndex = 4;
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
            // btnFiltrar
            // 
            this.btnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFiltrar.Enabled = false;
            this.btnFiltrar.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.outline_filter_alt_black_24dp;
            this.btnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(5);
            this.btnFiltrar.Size = new System.Drawing.Size(38, 38);
            this.btnFiltrar.Text = "btn";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDevolver.Enabled = false;
            this.btnDevolver.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.devolver1;
            this.btnDevolver.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Padding = new System.Windows.Forms.Padding(5);
            this.btnDevolver.Size = new System.Drawing.Size(38, 38);
            this.btnDevolver.Text = "toolStripButton1";
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
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
            this.labelTipoCadastro.Size = new System.Drawing.Size(188, 38);
            this.labelTipoCadastro.Text = "Cadastro Selecionado: Nenhum";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(992, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLocacao,
            this.menuItemCliente,
            this.menuItemVeiculo,
            this.menuItemFuncionario});
            this.cadastrosToolStripMenuItem.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // menuItemLocacao
            // 
            this.menuItemLocacao.Name = "menuItemLocacao";
            this.menuItemLocacao.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuItemLocacao.Size = new System.Drawing.Size(163, 22);
            this.menuItemLocacao.Text = "Locações";
            this.menuItemLocacao.Click += new System.EventHandler(this.menuItemLocacao_Click);
            // 
            // menuItemCliente
            // 
            this.menuItemCliente.Name = "menuItemCliente";
            this.menuItemCliente.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuItemCliente.Size = new System.Drawing.Size(163, 22);
            this.menuItemCliente.Text = "Clientes";
            this.menuItemCliente.Click += new System.EventHandler(this.menuItemCliente_Click);
            // 
            // menuItemVeiculo
            // 
            this.menuItemVeiculo.Name = "menuItemVeiculo";
            this.menuItemVeiculo.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuItemVeiculo.Size = new System.Drawing.Size(163, 22);
            this.menuItemVeiculo.Text = "Veículos";
            this.menuItemVeiculo.Click += new System.EventHandler(this.menuItemVeiculo_Click);
            // 
            // menuItemFuncionario
            // 
            this.menuItemFuncionario.Name = "menuItemFuncionario";
            this.menuItemFuncionario.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuItemFuncionario.Size = new System.Drawing.Size(163, 22);
            this.menuItemFuncionario.Text = "Funcionário";
            this.menuItemFuncionario.Click += new System.EventHandler(this.menuItemFuncionario_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.configuraçõesToolStripMenuItem.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5, 0, 15, 0);
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
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
            this.statusStripFooter.TabIndex = 6;
            this.statusStripFooter.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(58, 17);
            this.labelRodape.Text = "Tudo Ok";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRegistros.Location = new System.Drawing.Point(18, 92);
            this.panelRegistros.Margin = new System.Windows.Forms.Padding(4);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(948, 665);
            this.panelRegistros.TabIndex = 5;
            // 
            // TelaPrincipalForm
            // 
            this.AccessibleDescription = "Engloba todas as funcionalidades do programa";
            this.AccessibleName = "Tela Principal";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(992, 791);
            this.Controls.Add(this.statusStripFooter);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolboxAcoes);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora Rech";
            this.toolboxAcoes.ResumeLayout(false);
            this.toolboxAcoes.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStripFooter.ResumeLayout(false);
            this.statusStripFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolboxAcoes;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLocacao;
        private System.Windows.Forms.ToolStripMenuItem menuItemCliente;
        private System.Windows.Forms.ToolStripMenuItem menuItemVeiculo;
        private System.Windows.Forms.StatusStrip statusStripFooter;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripButton btnDevolver;
        private System.Windows.Forms.ToolStripMenuItem menuItemFuncionario;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
    }
}

