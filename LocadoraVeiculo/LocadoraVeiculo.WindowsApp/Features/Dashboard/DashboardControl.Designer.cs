
namespace LocadoraVeiculo.WindowsApp.Features.Dashboard
{
    partial class DashboardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panelCarrosAlugados = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.labelAlugados = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAlugados = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInLoco = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnInLoco = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtDashboard = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPendentes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLocacoesPendentes = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTipoVisualizacao = new System.Windows.Forms.Label();
            this.panelCarrosAlugados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDashboard)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard BeeCar";
            // 
            // panelCarrosAlugados
            // 
            this.panelCarrosAlugados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelCarrosAlugados.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCarrosAlugados.Controls.Add(this.pictureBox7);
            this.panelCarrosAlugados.Controls.Add(this.labelAlugados);
            this.panelCarrosAlugados.Controls.Add(this.pictureBox2);
            this.panelCarrosAlugados.Controls.Add(this.btnAlugados);
            this.panelCarrosAlugados.Controls.Add(this.label2);
            this.panelCarrosAlugados.Location = new System.Drawing.Point(569, 57);
            this.panelCarrosAlugados.Name = "panelCarrosAlugados";
            this.panelCarrosAlugados.Size = new System.Drawing.Size(244, 164);
            this.panelCarrosAlugados.TabIndex = 1;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.carRented;
            this.pictureBox7.Location = new System.Drawing.Point(111, 35);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(115, 95);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // labelAlugados
            // 
            this.labelAlugados.BackColor = System.Drawing.Color.Transparent;
            this.labelAlugados.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelAlugados.Location = new System.Drawing.Point(8, 63);
            this.labelAlugados.Name = "labelAlugados";
            this.labelAlugados.Size = new System.Drawing.Size(85, 37);
            this.labelAlugados.TabIndex = 9;
            this.labelAlugados.Text = "0";
            this.labelAlugados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.bordaCircular;
            this.pictureBox2.Location = new System.Drawing.Point(8, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 95);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // btnAlugados
            // 
            this.btnAlugados.FlatAppearance.BorderSize = 0;
            this.btnAlugados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlugados.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.lupa__1_;
            this.btnAlugados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlugados.Location = new System.Drawing.Point(127, 136);
            this.btnAlugados.Name = "btnAlugados";
            this.btnAlugados.Size = new System.Drawing.Size(93, 23);
            this.btnAlugados.TabIndex = 6;
            this.btnAlugados.Text = "VISUALIZAR";
            this.btnAlugados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlugados.UseVisualStyleBackColor = true;
            this.btnAlugados.Click += new System.EventHandler(this.btnAlugados_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "CARROS ALUGADOS";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.labelInLoco);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.btnInLoco);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(284, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 164);
            this.panel1.TabIndex = 4;
            // 
            // labelInLoco
            // 
            this.labelInLoco.BackColor = System.Drawing.Color.Transparent;
            this.labelInLoco.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelInLoco.Location = new System.Drawing.Point(11, 63);
            this.labelInLoco.Name = "labelInLoco";
            this.labelInLoco.Size = new System.Drawing.Size(85, 37);
            this.labelInLoco.TabIndex = 11;
            this.labelInLoco.Text = "0";
            this.labelInLoco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.bordaCircular;
            this.pictureBox4.Location = new System.Drawing.Point(11, 35);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(85, 95);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // btnInLoco
            // 
            this.btnInLoco.FlatAppearance.BorderSize = 0;
            this.btnInLoco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInLoco.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.lupa__1_;
            this.btnInLoco.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInLoco.Location = new System.Drawing.Point(122, 136);
            this.btnInLoco.Name = "btnInLoco";
            this.btnInLoco.Size = new System.Drawing.Size(93, 23);
            this.btnInLoco.TabIndex = 5;
            this.btnInLoco.Text = "VISUALIZAR ";
            this.btnInLoco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInLoco.UseVisualStyleBackColor = true;
            this.btnInLoco.Click += new System.EventHandler(this.btnInLoco_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources._293801_200;
            this.pictureBox3.Location = new System.Drawing.Point(113, 35);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(115, 95);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "CARROS DISPONÍVEIS";
            // 
            // dtDashboard
            // 
            this.dtDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDashboard.Location = new System.Drawing.Point(0, 250);
            this.dtDashboard.Name = "dtDashboard";
            this.dtDashboard.RowHeadersVisible = false;
            this.dtDashboard.Size = new System.Drawing.Size(815, 415);
            this.dtDashboard.TabIndex = 6;
            this.dtDashboard.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dtDashboard_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.labelPendentes);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnLocacoesPendentes);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(1, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 164);
            this.panel2.TabIndex = 7;
            // 
            // labelPendentes
            // 
            this.labelPendentes.BackColor = System.Drawing.Color.Transparent;
            this.labelPendentes.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelPendentes.Location = new System.Drawing.Point(12, 63);
            this.labelPendentes.Name = "labelPendentes";
            this.labelPendentes.Size = new System.Drawing.Size(85, 37);
            this.labelPendentes.TabIndex = 9;
            this.labelPendentes.Text = "0";
            this.labelPendentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.bordaCircular;
            this.pictureBox1.Location = new System.Drawing.Point(12, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnLocacoesPendentes
            // 
            this.btnLocacoesPendentes.FlatAppearance.BorderSize = 0;
            this.btnLocacoesPendentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocacoesPendentes.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources.lupa__1_;
            this.btnLocacoesPendentes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocacoesPendentes.Location = new System.Drawing.Point(124, 136);
            this.btnLocacoesPendentes.Name = "btnLocacoesPendentes";
            this.btnLocacoesPendentes.Size = new System.Drawing.Size(93, 23);
            this.btnLocacoesPendentes.TabIndex = 6;
            this.btnLocacoesPendentes.Text = "VISUALIZAR";
            this.btnLocacoesPendentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocacoesPendentes.UseVisualStyleBackColor = true;
            this.btnLocacoesPendentes.Click += new System.EventHandler(this.btnLocacoesPendentes_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::LocadoraVeiculo.WindowsApp.Properties.Resources._2565014;
            this.pictureBox6.Location = new System.Drawing.Point(114, 33);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(115, 95);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(244, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "LOCAÇÕES PENDENTES";
            // 
            // labelTipoVisualizacao
            // 
            this.labelTipoVisualizacao.AutoSize = true;
            this.labelTipoVisualizacao.BackColor = System.Drawing.Color.Transparent;
            this.labelTipoVisualizacao.Font = new System.Drawing.Font("Nirmala UI", 10.75F, System.Drawing.FontStyle.Bold);
            this.labelTipoVisualizacao.Location = new System.Drawing.Point(-3, 227);
            this.labelTipoVisualizacao.Name = "labelTipoVisualizacao";
            this.labelTipoVisualizacao.Size = new System.Drawing.Size(172, 20);
            this.labelTipoVisualizacao.TabIndex = 6;
            this.labelTipoVisualizacao.Text = "LOCAÇÕES PENDENTES";
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTipoVisualizacao);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtDashboard);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCarrosAlugados);
            this.Controls.Add(this.label1);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(815, 665);
            this.panelCarrosAlugados.ResumeLayout(false);
            this.panelCarrosAlugados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDashboard)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCarrosAlugados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtDashboard;
        private System.Windows.Forms.Button btnInLoco;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnAlugados;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLocacoesPendentes;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTipoVisualizacao;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label labelAlugados;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelPendentes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelInLoco;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
