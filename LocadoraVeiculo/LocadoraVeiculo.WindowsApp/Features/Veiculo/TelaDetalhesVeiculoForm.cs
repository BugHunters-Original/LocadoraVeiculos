using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculos
{
    public partial class TelaDetalhesVeiculoForm : Form
    {
        public VeiculoModule.Veiculo veiculos;
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();

        public TelaDetalhesVeiculoForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_DetalheVeiculo.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corFundo;
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

            btnOK.BackColor = ControladorDarkMode.corFundoTxBox;
        }

        public VeiculoModule.Veiculo Veiculo
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
