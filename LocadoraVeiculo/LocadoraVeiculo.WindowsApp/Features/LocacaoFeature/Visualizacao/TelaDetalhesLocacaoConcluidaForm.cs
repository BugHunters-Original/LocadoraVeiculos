using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.EmailLocadora;
using LocadoraDeVeiculos.Infra.InternetServices;
using LocadoraDeVeiculos.Infra.PDFLocacao;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.TaxaDaLocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.Visualizacao
{
    public partial class TelaDetalhesLocacaoConcluidaForm : Form
    {
        private Locacao locacao;
        private readonly TaxaDaLocacaoDAO TaxaDaLocacaoDAO;

        public TelaDetalhesLocacaoConcluidaForm()
        {
            TaxaDaLocacaoDAO = new TaxaDaLocacaoDAO();
            InitializeComponent();
            SetColor();
        }

        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                txtID.Text = locacao.Id.ToString();
                cbCliente.Text = locacao.Cliente.Nome;

                cbVeiculo.Text = locacao.Veiculo.Nome;

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

                if (locacao.Veiculo.Foto != null)
                {
                    pictureBoxImagem.Image = (Image)(new Bitmap(ConverteByteArrayParaImagem(locacao.Veiculo.Foto), new Size(214, 126)));
                    pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void PreencherListaTaxa()
        {
            List<TaxaDaLocacao> lista = TaxaDaLocacaoDAO.SelecionarTaxasDeUmaLocacao(locacao.Id);

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
            header_Locacao.BackColor = DarkMode.corHeader;
            BackColor = DarkMode.corPanel;
            ForeColor = DarkMode.corFonte;

            txtID.BackColor = Color.DarkSeaGreen;
            cbCliente.BackColor = DarkMode.corFundoTxBox;
            cbVeiculo.BackColor = DarkMode.corFundoTxBox;
            cbCondutor.BackColor = DarkMode.corFundoTxBox;
            dtSaida.BackColor = DarkMode.corFundoTxBox;
            dtRetorno.BackColor = DarkMode.corFundoTxBox;
            cbTipoLocacao.BackColor = DarkMode.corFundoTxBox;
            txtCupom.BackColor = DarkMode.corFundoTxBox;
            btnReenviar.BackColor = DarkMode.corFundoTxBox;

            txtID.ForeColor = DarkMode.corFonte;
            cbCliente.ForeColor = DarkMode.corFonte;
            cbVeiculo.ForeColor = DarkMode.corFonte;
            cbCondutor.ForeColor = DarkMode.corFonte;
            dtSaida.ForeColor = DarkMode.corFonte;
            dtRetorno.ForeColor = DarkMode.corFonte;
            cbTipoLocacao.ForeColor = DarkMode.corFonte;
            txtCupom.ForeColor = DarkMode.corFonte;

            txtPlano.BackColor = DarkMode.corFundoTxBox;
            txtCliente.BackColor = DarkMode.corFundoTxBox;
            txtPrecoPlano.BackColor = DarkMode.corFundoTxBox;
            txtGas.BackColor = DarkMode.corFundoTxBox;
            txtServico.BackColor = DarkMode.corFundoTxBox;
            txtTotal.BackColor = DarkMode.corFundoTxBox;

            txtPlano.ForeColor = DarkMode.corFonte;
            txtCliente.ForeColor = DarkMode.corFonte;
            txtPrecoPlano.ForeColor = DarkMode.corFonte;
            txtGas.ForeColor = DarkMode.corFonte;
            txtServico.ForeColor = DarkMode.corFonte;
            txtTotal.ForeColor = DarkMode.corFonte;

            btnOK.BackColor = DarkMode.corFundoTxBox;
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            Task.Run(() => ExportarRecibo());
        }

        private void ExportarRecibo()
        {
            EnviaEmail email = new EnviaEmail();
            string mensagem = email.EnviarEmail(locacao) ? $"Recibo enviado com sucesso para o e-mail [{locacao.Cliente.Email}]!" : $"Erro ao enviar recibo para o e-mail [{locacao.Cliente.Email}]!";
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
        }
    }
}
