using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.VeiculoFeature
{
    public partial class TelaDetalhesVeiculoForm : Form
    {
        public Veiculo veiculos;

        public TelaDetalhesVeiculoForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_DetalheVeiculo.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corFundo;
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

            btnOK.BackColor = DarkMode.corFundoTxBox;
        }

        public Veiculo Veiculo
        {
            get { return veiculos; }

            set
            {
                veiculos = value;

                txtId.Text = veiculos.Id.ToString();
                txtNome.Text = veiculos.Nome;
                txtPlaca.Text = veiculos.NumeroPlaca;
                txtChassi.Text = veiculos.NumeroChassi;
                if (veiculos.Foto != null)
                {
                    pictureBoxImagem.Image = (Image)(new Bitmap(ConverteByteArrayParaImagem(veiculos.Foto), new Size(214, 126)));
                    pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                txtCor.Text = veiculos.Cor;
                txtMarca.Text = veiculos.Marca;
                txtAno.Text = veiculos.Ano.ToString();
                txtNPortas.Text = veiculos.NumeroPortas.ToString();
                txtCapacidadeTanque.Text = veiculos.CapacidadeTanque.ToString();
                txtCapacidadePessoas.Text = veiculos.CapacidadePessoas.ToString();
                cmbTamanhoPortaMalas.Text = veiculos.TamanhoPortaMalas.ToString();
                txtKm.Text = veiculos.KmInicial.ToString();
                cmbTipoCombustivel.Text = veiculos.TipoCombustivel;
                cmbGrupo.Text = veiculos.GrupoVeiculo.NomeTipo;
            }
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
