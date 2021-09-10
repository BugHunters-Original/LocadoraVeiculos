
namespace LocadoraVeiculo.WindowsApp.Features.LoginFeature
{
    partial class TelaLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogar = new System.Windows.Forms.Button();
            this.Footer = new System.Windows.Forms.StatusStrip();
            this.labelFooter = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnModo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
            this.label1.Location = new System.Drawing.Point(96, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(182, 156);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(255, 26);
            this.txtUsuario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 20F);
            this.label2.Location = new System.Drawing.Point(237, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "BeeCar ";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(182, 201);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(255, 26);
            this.txtSenha.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
            this.label4.Location = new System.Drawing.Point(108, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Senha:";
            // 
            // btnLogar
            // 
            this.btnLogar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogar.Location = new System.Drawing.Point(265, 268);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(88, 36);
            this.btnLogar.TabIndex = 6;
            this.btnLogar.Text = "ENTRAR";
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Footer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelFooter});
            this.Footer.Location = new System.Drawing.Point(0, 361);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(632, 22);
            this.Footer.TabIndex = 7;
            this.Footer.Text = "statusStrip1";
            // 
            // labelFooter
            // 
            this.labelFooter.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(72, 17);
            this.labelFooter.Text = "Bem vindo!";
            // 
            // btnModo
            // 
            this.btnModo.BackColor = System.Drawing.Color.Transparent;
            this.btnModo.FlatAppearance.BorderSize = 0;
            this.btnModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModo.ForeColor = System.Drawing.Color.Transparent;
            this.btnModo.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.whiteMode;
            this.btnModo.Location = new System.Drawing.Point(550, 12);
            this.btnModo.Name = "btnModo";
            this.btnModo.Size = new System.Drawing.Size(30, 30);
            this.btnModo.TabIndex = 9;
            this.btnModo.UseVisualStyleBackColor = false;
            this.btnModo.Click += new System.EventHandler(this.btnModo_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(590, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 10;
            // 
            // TelaLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(632, 383);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnModo);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.StatusStrip Footer;
        private System.Windows.Forms.ToolStripStatusLabel labelFooter;
        private System.Windows.Forms.Button btnModo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
    }
}