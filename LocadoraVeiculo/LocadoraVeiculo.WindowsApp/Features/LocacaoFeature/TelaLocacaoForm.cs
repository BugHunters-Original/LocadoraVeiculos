using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.TaxasServicos;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Context;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    public partial class TelaLocacaoForm : Form
    {
        private Locacao locacao;
        private readonly ClienteCPFAppService cpfService;
        private readonly ClienteCNPJAppService cnpjService;
        private readonly VeiculoAppService veiculoService;
        private readonly DescontoAppService descontoService;
        private readonly LocacaoAppService locacaoService;
        private readonly TaxaDaLocacaoDAO taxaDaLocacaoDAO;
        readonly TelaAdicionarTaxasForm telaDasTaxas;
        public List<Servico> Servicos { get; set; }


        public TelaLocacaoForm(ClienteCPFAppService cpfService, VeiculoAppService veiculoService,
                               ClienteCNPJAppService cnpjService, DescontoAppService descontoService,
                               LocacaoAppService locacaoService, TaxaDaLocacaoDAO taxaDaLocacaoDAO)
        {
            this.cpfService = cpfService;
            this.cnpjService = cnpjService;
            this.veiculoService = veiculoService;
            this.descontoService = descontoService;
            this.locacaoService = locacaoService;
            this.taxaDaLocacaoDAO = taxaDaLocacaoDAO;
            telaDasTaxas = new TelaAdicionarTaxasForm();
            locacao = new();
            InitializeComponent();
            PopularComboboxes();
            SetColor();
        }


        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                PreencherListaTaxa();

                txtID.Text = locacao.Id.ToString();

                cbCliente.Items.Add(locacao.Cliente);

                cbCliente.SelectedIndex = cbCliente.Items.Count - 1;

                cbVeiculo.Items.Add(locacao.Veiculo);

                cbVeiculo.SelectedIndex = cbVeiculo.Items.Count - 1;

                cbCondutor.SelectedItem = locacao.Condutor;

                dtSaida.Value = locacao.DataSaida;

                dtRetorno.Value = locacao.DataRetorno;

                cbTipoLocacao.Text = locacao.TipoLocacao.ToString();

                txtCupom.Text = locacao.Desconto?.Codigo;
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

            txtID.ForeColor = DarkMode.corFonte;
            cbCliente.ForeColor = DarkMode.corFonte;
            cbVeiculo.ForeColor = DarkMode.corFonte;
            cbCondutor.ForeColor = DarkMode.corFonte;
            dtSaida.ForeColor = DarkMode.corFonte;
            dtRetorno.ForeColor = DarkMode.corFonte;
            cbTipoLocacao.ForeColor = DarkMode.corFonte;
            txtCupom.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
            btnTaxa.BackColor = DarkMode.corFundoTxBox;
        }
        private void PopularComboboxes()
        {
            var locacoes = locacaoService.SelecionarTodasLocacoesPendentes();

            var clientesCPF = cpfService.SelecionarTodosClientesCPF();

            var clientesCNPJ = cnpjService.SelecionarTodosClientesCNPJ();

            var veiculos = veiculoService.SelecionarTodosDisponiveis();

            locacoes.ForEach(x => clientesCPF.Remove(x.Condutor));

            clientesCPF.ForEach(x => cbCliente.Items.Add(x));

            clientesCNPJ.ForEach(x => cbCliente.Items.Add(x));

            veiculos.ForEach(x => cbVeiculo.Items.Add(x));
            cbVeiculo.SelectedIndex = 0;
        }
        private static decimal? CalcularPrecoPlanoPorDias(Veiculo veiculo, string tipoLocacao, int dias)
        {
            switch (tipoLocacao)
            {
                case "Plano Diário":
                    return (veiculo.GrupoVeiculo.ValorDiarioPDiario * dias);

                case "KM Livre":
                    return (veiculo.GrupoVeiculo.ValorDiarioPLivre * dias);

                case "KM Controlado":
                    return (veiculo.GrupoVeiculo.ValorDiarioPControlado * dias);

                default: return 0;
            }
        }
        private void PreencherListaTaxa()
        {
            List<TaxaDaLocacao> lista = taxaDaLocacaoDAO.SelecionarTaxasDeUmaLocacao(locacao.Id);

            if (lista != null)
                lista.ForEach(x => listServicos.Items.Add(x.Servico));

            telaDasTaxas.CheckBoxTaxas(lista);
        }
        private void PopularComboboxCondutores()
        {
            ClienteCNPJ cliente = (ClienteCNPJ)cbCliente.SelectedItem;

            List<ClienteCPF> condutoresRelacionados = cpfService.SelecionarPorIdEmpresa(cliente.Id);

            cbCondutor.Items.Clear();

            condutoresRelacionados.ForEach(x => cbCondutor.Items.Add(x));
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ConfigurarLocacao();

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarLocacao()
        {
            locacao.Cliente = (ClienteBase)cbCliente.SelectedItem;

            locacao.Veiculo = (Veiculo)cbVeiculo.SelectedItem;

            locacao.Desconto = txtCupom.Text != "" ? descontoService.VerificarCodigoValido(txtCupom.Text) : null;

            locacao.TipoCliente = cbCliente.SelectedItem is ClienteCPF ? 0 : 1;

            locacao.Condutor = cbCliente.SelectedItem is ClienteCPF ? (ClienteCPF)locacao.Cliente : (ClienteCPF)cbCondutor.SelectedItem;

            locacao.DataSaida = dtSaida.Value;

            locacao.DataRetorno = dtRetorno.Value;

            locacao.TipoLocacao = cbTipoLocacao.Text;

            locacao.Dias = Convert.ToInt32((dtRetorno.Value - dtSaida.Value).TotalDays);

            locacao.PrecoServicos = 0;

            if (Servicos != null)
                foreach (var item in Servicos.ToList())
                    locacao.PrecoServicos = item.TipoCalculo != 1 ? locacao.PrecoServicos + item.Preco * locacao.Dias : locacao.PrecoServicos + item.Preco;


            locacao.PrecoPlano = CalcularPrecoPlanoPorDias(locacao.Veiculo, locacao.TipoLocacao, locacao.Dias);

            locacao.PrecoTotal = locacao.PrecoPlano + locacao.PrecoServicos;

            locacao.Servicos = Servicos;
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedItem is ClienteCPF)
                cbCondutor.Enabled = false;
            else
            {
                cbCondutor.Enabled = true;
                PopularComboboxCondutores();
            }
        }

        private void TelaLocacaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
        private void btnTaxa_Click(object sender, EventArgs e)
        {
            listServicos.Items.Clear();
            telaDasTaxas.ShowDialog();
            Servicos = telaDasTaxas.Servicos;

            if (Servicos != null)
                Servicos.ForEach(x => listServicos.Items.Add(x));
        }

        private void txtCupom_Leave(object sender, EventArgs e)
        {
            if (txtCupom.Text == "")
                return;
            Desconto desconto = descontoService.VerificarCodigoValido(txtCupom.Text);
            if (desconto == null || desconto.Validade.Date < dtRetorno.Value.Date)
            {
                MessageBox.Show("Cupom Inválido, verifique se o código do cupom está correto, ou se sua" +
                    " data do cupom está válida e tente novamente!",
                    "Devolução de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCupom.Text = "";
                txtCupom.Focus();
            }
        }

    }
}
