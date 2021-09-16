namespace LocadoraVeiculo.WindowsApp.Features.CombustivelFeature
{
    partial class TelaCombustivelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCombustivelForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGasolina = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGasolina = new System.Windows.Forms.TextBox();
            this.tabPageAlcool = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlcool = new System.Windows.Forms.TextBox();
            this.tabPageDiesel = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiesel = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.header_Combustivel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageGasolina.SuspendLayout();
            this.tabPageAlcool.SuspendLayout();
            this.tabPageDiesel.SuspendLayout();
            this.header_Combustivel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "preço da gasolina";
            this.tabControl1.Controls.Add(this.tabPageGasolina);
            this.tabControl1.Controls.Add(this.tabPageAlcool);
            this.tabControl1.Controls.Add(this.tabPageDiesel);
            this.tabControl1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.tabControl1.Location = new System.Drawing.Point(10, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(290, 133);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // tabPageGasolina
            // 
            this.tabPageGasolina.Controls.Add(this.label1);
            this.tabPageGasolina.Controls.Add(this.txtGasolina);
            this.tabPageGasolina.Location = new System.Drawing.Point(4, 24);
            this.tabPageGasolina.Name = "tabPageGasolina";
            this.tabPageGasolina.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGasolina.Size = new System.Drawing.Size(282, 105);
            this.tabPageGasolina.TabIndex = 0;
            this.tabPageGasolina.Text = "Gasolina";
            this.tabPageGasolina.UseVisualStyleBackColor = true;
            this.tabPageGasolina.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Preço:";
            // 
            // txtGasolina
            // 
            this.txtGasolina.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtGasolina.Location = new System.Drawing.Point(76, 38);
            this.txtGasolina.Name = "txtGasolina";
            this.txtGasolina.Size = new System.Drawing.Size(116, 19);
            this.txtGasolina.TabIndex = 1;
            this.txtGasolina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxJustNumbers_KeyPress);
            // 
            // tabPageAlcool
            // 
            this.tabPageAlcool.Controls.Add(this.label2);
            this.tabPageAlcool.Controls.Add(this.txtAlcool);
            this.tabPageAlcool.Location = new System.Drawing.Point(4, 24);
            this.tabPageAlcool.Name = "tabPageAlcool";
            this.tabPageAlcool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlcool.Size = new System.Drawing.Size(282, 105);
            this.tabPageAlcool.TabIndex = 1;
            this.tabPageAlcool.Text = "Álcool";
            this.tabPageAlcool.UseVisualStyleBackColor = true;
            this.tabPageAlcool.Leave += new System.EventHandler(this.txtBoxZerado_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Preço:";
            // 
            // txtAlcool
            // 
            this.txtAlcool.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtAlcool.Location = new System.Drawing.Point(76, 38);
            this.txtAlcool.Name = "txtAlcool";
            this.txtAlcool.Size = new System.Drawing.Size(116, 19);
            this.txtAlcool.TabIndex = 3;
            this.txtAlcool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxJustNumbers_KeyPress);
            // 
            // tabPageDiesel
            // 
            this.tabPageDiesel.Controls.Add(this.label3);
            this.tabPageDiesel.Controls.Add(this.txtDiesel);
            this.tabPageDiesel.Location = new System.Drawing.Point(4, 24);
            this.tabPageDiesel.Name = "tabPageDiesel";
            this.tabPageDiesel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiesel.Size = new System.Drawing.Size(282, 105);
            this.tabPageDiesel.TabIndex = 2;
            this.tabPageDiesel.Text = "Diesel";
            this.tabPageDiesel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Preço:";
            // 
            // txtDiesel
            // 
            this.txtDiesel.AccessibleName = "preço do diesel";
            this.txtDiesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtDiesel.Location = new System.Drawing.Point(76, 38);
            this.txtDiesel.Name = "txtDiesel";
            this.txtDiesel.Size = new System.Drawing.Size(116, 19);
            this.txtDiesel.TabIndex = 5;
            this.txtDiesel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxJustNumbers_KeyPress);
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnSalvar.Location = new System.Drawing.Point(119, 186);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(87, 27);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Gravar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.btnCancelar.Location = new System.Drawing.Point(213, 186);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // header_Combustivel
            // 
            this.header_Combustivel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header_Combustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header_Combustivel.Controls.Add(this.label8);
            this.header_Combustivel.Location = new System.Drawing.Point(-3, -1);
            this.header_Combustivel.Name = "header_Combustivel";
            this.header_Combustivel.Size = new System.Drawing.Size(342, 29);
            this.header_Combustivel.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cadastro de Combustível";
            // 
            // TelaCombustivelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 234);
            this.Controls.Add(this.header_Combustivel);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCombustivelForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preço Combustível";
            this.tabControl1.ResumeLayout(false);
            this.tabPageGasolina.ResumeLayout(false);
            this.tabPageGasolina.PerformLayout();
            this.tabPageAlcool.ResumeLayout(false);
            this.tabPageAlcool.PerformLayout();
            this.tabPageDiesel.ResumeLayout(false);
            this.tabPageDiesel.PerformLayout();
            this.header_Combustivel.ResumeLayout(false);
            this.header_Combustivel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGasolina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGasolina;
        private System.Windows.Forms.TabPage tabPageAlcool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlcool; 
        private System.Windows.Forms.TabPage tabPageDiesel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiesel;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel header_Combustivel;
        private System.Windows.Forms.Label label8;
    }
}