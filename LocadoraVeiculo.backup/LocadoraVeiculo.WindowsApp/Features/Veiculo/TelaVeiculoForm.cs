using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculos
{
    public partial class TelaVeiculoForm : Form
    {
        public Veiculo veiculo;
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();

        public TelaVeiculoForm()
        {
            InitializeComponent();
            SetColor();
            CarregarGrupos();
        }

        private void SetColor()
        {
            this.header_Veiculo.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtId.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = ControladorDarkMode.corFundoTxBox;
            txtMarca.BackColor = ControladorDarkMode.corFundoTxBox;
            txtChassi.BackColor = ControladorDarkMode.corFundoTxBox;
            txtPlaca.BackColor = ControladorDarkMode.corFundoTxBox;
            txtNPortas.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCor.BackColor = ControladorDarkMode.corFundoTxBox;
            txtKm.BackColor = ControladorDarkMode.corFundoTxBox;
            txtAno.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCapacidadePessoas.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCapacidadeTanque.BackColor = ControladorDarkMode.corFundoTxBox;
            cmbGrupo.BackColor = ControladorDarkMode.corFundoTxBox;
            cmbTamanhoPortaMalas.BackColor = ControladorDarkMode.corFundoTxBox;
            cmbTipoCombustivel.BackColor = ControladorDarkMode.corFundoTxBox;

            txtId.ForeColor = ControladorDarkMode.corFonte;
            txtNome.ForeColor = ControladorDarkMode.corFonte;
            txtMarca.ForeColor = ControladorDarkMode.corFonte;
            txtChassi.ForeColor = ControladorDarkMode.corFonte;
            txtPlaca.ForeColor = ControladorDarkMode.corFonte;
            txtNPortas.ForeColor = ControladorDarkMode.corFonte;
            txtCor.ForeColor = ControladorDarkMode.corFonte;
            txtKm.ForeColor = ControladorDarkMode.corFonte;
            txtAno.ForeColor = ControladorDarkMode.corFonte;
            txtCapacidadePessoas.ForeColor = ControladorDarkMode.corFonte;
            txtCapacidadeTanque.ForeColor = ControladorDarkMode.corFonte;
            cmbGrupo.ForeColor = ControladorDarkMode.corFonte;
            cmbTamanhoPortaMalas.ForeColor = ControladorDarkMode.corFonte;
            cmbTipoCombustivel.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnBuscarFoto.BackColor = ControladorDarkMode.corFundoTxBox;

        }

        private void CarregarGrupos()
        {
            cmbGrupo.DataSource = controladorGrupoVeiculo.SelecionarTodos();
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
            byte[] foto = ConverteImagemParaByteArray(pictureBoxImagem.Image, pictureBoxImagem);
            string nome = txtNome.Text;
            string placa = txtPlaca.Text;
            string chassi = txtChassi.Text;
            string cor = txtCor.Text;
            string marca = txtMarca.Text;

            int? ano = null;
            if (!string.IsNullOrEmpty(txtAno.Text))
                ano = Convert.ToInt32(txtAno.Text);

            int? NPortas = null;
            if (!string.IsNullOrEmpty(txtNPortas.Text))
                NPortas = Convert.ToInt32(txtNPortas.Text);

            int? CapacidadeTanque = null;
            if (!string.IsNullOrEmpty(txtCapacidadeTanque.Text))
                CapacidadeTanque = Convert.ToInt32(txtCapacidadeTanque.Text);

            int? CapacidadePessoas = null;
            if (!string.IsNullOrEmpty(txtCapacidadePessoas.Text))
                CapacidadePessoas = Convert.ToInt32(txtCapacidadePessoas.Text);

            int? Km = null;
            if (!string.IsNullOrEmpty(txtKm.Text))
                Km = Convert.ToInt32(txtKm.Text);

            char TamanhoPortaMalas = ' ';
            if (cmbTamanhoPortaMalas.Text.ToString() != "")
                TamanhoPortaMalas = Convert.ToChar(cmbTamanhoPortaMalas.Text);
            string TipoCombustivel = cmbTipoCombustivel.Text;

            GrupoVeiculoModule.GrupoVeiculo grupo = (GrupoVeiculoModule.GrupoVeiculo)cmbGrupo.SelectedItem;

            int disponibilidade = veiculo == null ? 1 : veiculo.DisponibilidadeVeiculo;

            veiculo = new Veiculo(nome, placa, chassi, foto, cor, marca, ano, NPortas, CapacidadeTanque,
                CapacidadePessoas, TamanhoPortaMalas, Km, TipoCombustivel, disponibilidade, grupo);

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