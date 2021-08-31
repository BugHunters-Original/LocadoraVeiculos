using LocadoraVeiculo.Controladores.TaxaDaLocacaoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.TaxaDaLocacaoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.Locacao.Visualizacao
{
    public partial class TelaDetalhesLocacaoEmAbertoForm : Form
    {
        private LocacaoVeiculo locacao;
        private readonly ControladorTaxaDaLocacao controladorTaxaDaLocacao;

        public TelaDetalhesLocacaoEmAbertoForm()
        {
            controladorTaxaDaLocacao = new ControladorTaxaDaLocacao();
            InitializeComponent();
            SetColor();
        }

        public LocacaoVeiculo Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                txtID.Text = locacao.Id.ToString();
                cbCliente.Text = locacao.Cliente.Nome;

                cbVeiculo.Text = locacao.Veiculo.nome;

                cbCondutor.Text = locacao.Condutor.Nome;


                PreencherListaTaxa();
                dtSaida.Text = locacao.DataSaida.ToString("d");
                dtRetorno.Text = locacao.DataRetorno.ToString("d");
                cbTipoLocacao.Text = locacao.TipoLocacao.ToString();

                if (locacao.Desconto?.Codigo == null)
                    txtCupom.Text = "SEM CUPOM CADASTRADO";
                else
                    txtCupom.Text = locacao.Desconto?.Codigo;

                if (locacao.Veiculo.foto != null)
                {
                    pictureBox.Image = (Image)(new Bitmap(ConverteByteArrayParaImagem(locacao.Veiculo.foto)));
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void PreencherListaTaxa()
        {
            List<TaxaDaLocacao> lista = controladorTaxaDaLocacao.SelecionarTodasTaxas(locacao.Id);

            if (lista != null)
                foreach (var servico in lista)
                {
                    listServicos.Items.Add(servico.TaxaLocacao);
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

        private void SetColor()
        {
            header_Locacao.BackColor = ControladorDarkMode.corHeader;
            BackColor = ControladorDarkMode.corPanel;
            ForeColor = ControladorDarkMode.corFonte;

            txtID.BackColor = Color.DarkSeaGreen;
            cbCliente.BackColor = ControladorDarkMode.corFundoTxBox;
            cbVeiculo.BackColor = ControladorDarkMode.corFundoTxBox;
            cbCondutor.BackColor = ControladorDarkMode.corFundoTxBox;
            dtSaida.BackColor = ControladorDarkMode.corFundoTxBox;
            dtRetorno.BackColor = ControladorDarkMode.corFundoTxBox;
            cbTipoLocacao.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCupom.BackColor = ControladorDarkMode.corFundoTxBox;

            txtID.ForeColor = ControladorDarkMode.corFonte;
            cbCliente.ForeColor = ControladorDarkMode.corFonte;
            cbVeiculo.ForeColor = ControladorDarkMode.corFonte;
            cbCondutor.ForeColor = ControladorDarkMode.corFonte;
            dtSaida.ForeColor = ControladorDarkMode.corFonte;
            dtRetorno.ForeColor = ControladorDarkMode.corFonte;
            cbTipoLocacao.ForeColor = ControladorDarkMode.corFonte;
            txtCupom.ForeColor = ControladorDarkMode.corFonte;

            btnOK.BackColor = ControladorDarkMode.corFundoTxBox;
            listServicos.BackColor = ControladorDarkMode.corPanel;
            listServicos.ForeColor = ControladorDarkMode.corFonte;
        }
    }
}
