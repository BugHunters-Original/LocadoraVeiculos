using LocadoraVeiculo.Controladores.TaxaDaLocacaoModule;
using LocadoraVeiculo.ExportacaoPDF;
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
    public partial class TelaDetalhesLocacaoConcluidaForm : Form
    {
        private LocacaoVeiculo locacao;
        private readonly ControladorTaxaDaLocacao controladorTaxaDaLocacao;

        public TelaDetalhesLocacaoConcluidaForm()
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

                txtCliente.Text = locacao.Cliente.ToString();
                txtPlano.Text = locacao.TipoLocacao.ToString();
                txtServico.Text = "R$" + locacao.PrecoServicos.ToString();
                txtGas.Text = "R$" + locacao.PrecoCombustivel.ToString();
                txtPrecoPlano.Text = "R$" + locacao.PrecoPlano.ToString();
                txtTotal.Text = "R$" + locacao.PrecoTotal.ToString();
                
                if (locacao.Veiculo.foto != null)
                {
                    pictureBoxImagem.Image = (Image)(new Bitmap(ConverteByteArrayParaImagem(locacao.Veiculo.foto), new Size(214, 126)));
                    pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void PreencherListaTaxa()
        {
            List<TaxaDaLocacao> lista = controladorTaxaDaLocacao.SelecionarTaxasDeUmaLocacao(locacao.Id);

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
            btnReenviar.BackColor = ControladorDarkMode.corFundoTxBox;

            txtID.ForeColor = ControladorDarkMode.corFonte;
            cbCliente.ForeColor = ControladorDarkMode.corFonte;
            cbVeiculo.ForeColor = ControladorDarkMode.corFonte;
            cbCondutor.ForeColor = ControladorDarkMode.corFonte;
            dtSaida.ForeColor = ControladorDarkMode.corFonte;
            dtRetorno.ForeColor = ControladorDarkMode.corFonte;
            cbTipoLocacao.ForeColor = ControladorDarkMode.corFonte;
            txtCupom.ForeColor = ControladorDarkMode.corFonte;

            txtPlano.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCliente.BackColor = ControladorDarkMode.corFundoTxBox;
            txtPrecoPlano.BackColor = ControladorDarkMode.corFundoTxBox;
            txtGas.BackColor = ControladorDarkMode.corFundoTxBox;
            txtServico.BackColor = ControladorDarkMode.corFundoTxBox;
            txtTotal.BackColor = ControladorDarkMode.corFundoTxBox;

            txtPlano.ForeColor = ControladorDarkMode.corFonte;
            txtCliente.ForeColor = ControladorDarkMode.corFonte;
            txtPrecoPlano.ForeColor = ControladorDarkMode.corFonte;
            txtGas.ForeColor = ControladorDarkMode.corFonte;
            txtServico.ForeColor = ControladorDarkMode.corFonte;
            txtTotal.ForeColor = ControladorDarkMode.corFonte;

            btnOK.BackColor = ControladorDarkMode.corFundoTxBox;
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            Task.Run(() => ExportaPdf.EmailEnviar(locacao));
        }
    }
}
