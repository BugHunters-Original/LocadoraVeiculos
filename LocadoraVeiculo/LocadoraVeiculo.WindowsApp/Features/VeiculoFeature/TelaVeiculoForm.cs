using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.VeiculoFeature
{
    public partial class TelaVeiculoForm : Form
    {
        public Veiculo veiculo;
        GrupoVeiculoAppService grupoService;

        public TelaVeiculoForm(GrupoVeiculoAppService grupoService)
        {
            this.grupoService = grupoService;
            InitializeComponent();
            SetColor();
            CarregarGrupos();
            veiculo = new();
        }

        private void SetColor()
        {
            this.header_Veiculo.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;
            txtId.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = DarkMode.corFundoTxBox;
            txtMarca.BackColor = DarkMode.corFundoTxBox;
            txtChassi.BackColor = DarkMode.corFundoTxBox;
            txtPlaca.BackColor = DarkMode.corFundoTxBox;
            txtNPortas.BackColor = DarkMode.corFundoTxBox;
            txtCor.BackColor = DarkMode.corFundoTxBox;
            txtKm.BackColor = DarkMode.corFundoTxBox;
            txtAno.BackColor = DarkMode.corFundoTxBox;
            txtCapacidadePessoas.BackColor = DarkMode.corFundoTxBox;
            txtCapacidadeTanque.BackColor = DarkMode.corFundoTxBox;
            cmbGrupo.BackColor = DarkMode.corFundoTxBox;
            cmbTamanhoPortaMalas.BackColor = DarkMode.corFundoTxBox;
            cmbTipoCombustivel.BackColor = DarkMode.corFundoTxBox;

            txtId.ForeColor = DarkMode.corFonte;
            txtNome.ForeColor = DarkMode.corFonte;
            txtMarca.ForeColor = DarkMode.corFonte;
            txtChassi.ForeColor = DarkMode.corFonte;
            txtPlaca.ForeColor = DarkMode.corFonte;
            txtNPortas.ForeColor = DarkMode.corFonte;
            txtCor.ForeColor = DarkMode.corFonte;
            txtKm.ForeColor = DarkMode.corFonte;
            txtAno.ForeColor = DarkMode.corFonte;
            txtCapacidadePessoas.ForeColor = DarkMode.corFonte;
            txtCapacidadeTanque.ForeColor = DarkMode.corFonte;
            cmbGrupo.ForeColor = DarkMode.corFonte;
            cmbTamanhoPortaMalas.ForeColor = DarkMode.corFonte;
            cmbTipoCombustivel.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
            btnBuscarFoto.BackColor = DarkMode.corFundoTxBox;

        }

        private void CarregarGrupos()
        {
            cmbGrupo.DataSource = grupoService.SelecionarTodosGruposVeiculos();
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                txtId.Text = veiculo.Id.ToString();
                txtNome.Text = veiculo.Nome;
                txtPlaca.Text = veiculo.NumeroPlaca;
                txtChassi.Text = veiculo.NumeroChassi;
                if (veiculo.Foto != null)
                {
                    pictureBoxImagem.Image = (Image)(new Bitmap(ConverteByteArrayParaImagem(veiculo.Foto), new Size(214, 126)));
                    pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                txtCor.Text = veiculo.Cor;
                txtMarca.Text = veiculo.Marca;
                txtAno.Text = veiculo.Ano.ToString();
                txtNPortas.Text = veiculo.NumeroPortas.ToString();
                txtCapacidadeTanque.Text = veiculo.CapacidadeTanque.ToString();
                txtCapacidadePessoas.Text = veiculo.CapacidadePessoas.ToString();
                cmbTamanhoPortaMalas.Text = veiculo.TamanhoPortaMalas.ToString();
                txtKm.Text = veiculo.KmInicial.ToString();
                cmbTipoCombustivel.Text = veiculo.TipoCombustivel;
                cmbGrupo.Text = veiculo.GrupoVeiculo.NomeTipo;
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            veiculo.DisponibilidadeVeiculo = veiculo.Nome == null ? 1 : veiculo.DisponibilidadeVeiculo;
            veiculo.Nome = txtNome.Text;
            veiculo.NumeroChassi = txtChassi.Text;
            veiculo.NumeroPlaca = txtPlaca.Text;
            veiculo.Foto = ConverteImagemParaByteArray(pictureBoxImagem.Image, pictureBoxImagem);
            veiculo.Cor = txtCor.Text;
            veiculo.Marca = txtMarca.Text;
            veiculo.Ano = txtAno.Text != "" ? Convert.ToInt32(txtAno.Text) : null;

            veiculo.NumeroPortas = txtNPortas.Text != "" ?
                Convert.ToInt32(txtNPortas.Text) : null;

            veiculo.CapacidadeTanque = txtCapacidadeTanque.Text != "" ?
                Convert.ToInt32(txtCapacidadeTanque.Text) : null;

            veiculo.CapacidadePessoas = txtCapacidadePessoas.Text != "" ?
                 Convert.ToInt32(txtCapacidadePessoas.Text) : null;

            veiculo.KmInicial = txtKm.Text != "" ? Convert.ToInt32(txtKm.Text) : null;

            veiculo.TamanhoPortaMalas = cmbTamanhoPortaMalas.Text != " " ?
                Convert.ToChar(cmbTamanhoPortaMalas.Text) : ' ';

            veiculo.TipoCombustivel = cmbTipoCombustivel.Text;
            veiculo.GrupoVeiculo = (GrupoVeiculo)cmbGrupo.SelectedItem;
             
            string resultadoValidacao = veiculo.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            openFileDialogImagem.Title = "Imagem do produto";
            openFileDialogImagem.Filter = "Images (*.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.)| *.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.icon; *.JFIF";
            if (openFileDialogImagem.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImagem.Image = Image.FromFile(openFileDialogImagem.FileName);

                pictureBoxImagem.Image = (Image)(new Bitmap(pictureBoxImagem.Image, new Size(214, 126)));

                pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public static byte[] ConverteImagemParaByteArray(Image img, PictureBox pictureBox)
        {
            MemoryStream ms = new MemoryStream();
            if (pictureBox.Image != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        public static Image ConverteByteArrayParaImagem(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch
            {
                return null;
            }
        }
    }
}