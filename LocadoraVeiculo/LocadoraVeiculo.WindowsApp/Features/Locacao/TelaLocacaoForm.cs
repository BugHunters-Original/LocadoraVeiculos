using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using LocadoraVeiculo.WindowsApp.Features.Locacao.TaxasServicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LocadoraVeiculo.TaxaDaLocacaoModule;
using LocadoraVeiculo.Controladores.TaxaDaLocacaoModule;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.Controladores.DescontoModule;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public partial class TelaLocacaoForm : Form
    {
        private LocacaoVeiculo locacao;
        private readonly ControladorClienteCPF controladorCPF;
        private readonly ControladorClienteCNPJ controladorCNPJ;
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorTaxaDaLocacao controladorTaxaDaLocacao;
        private readonly ControladorDesconto controladorDesconto;
        readonly TelaAdicionarTaxasForm telaDasTaxas;
        public List<Servico> Servicos { get; set; }


        public TelaLocacaoForm()
        {
            controladorCPF = new ControladorClienteCPF();
            controladorCNPJ = new ControladorClienteCNPJ();
            controladorVeiculo = new ControladorVeiculo();
            controladorTaxaDaLocacao = new ControladorTaxaDaLocacao();
            controladorDesconto = new ControladorDesconto();
            telaDasTaxas = new TelaAdicionarTaxasForm();
            InitializeComponent();
            PopularComboboxes();

            SetColor();
        }


        public LocacaoVeiculo Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                txtID.Text = locacao.Id.ToString();
                cbCliente.Text = locacao.Cliente.ToString();

                cbVeiculo.Items.Add(locacao.Veiculo);
                cbVeiculo.SelectedIndex = cbVeiculo.Items.Count - 1;

                cbCondutor.Items.Add(locacao.Condutor);
                cbCondutor.SelectedIndex = 0;

                PreencherListaTaxa();
                dtSaida.Value = locacao.DataSaida;
                dtRetorno.Value = locacao.DataRetorno;
                cbTipoLocacao.Text = locacao.TipoLocacao.ToString();
                txtCupom.Text = locacao.Desconto?.Codigo;
            }
        }
        private void SetColor()
        {
            header_Locacao.BackColor = ControladorDarkMode.corHeader;
            BackColor = ControladorDarkMode.corPanel;
            ForeColor = ControladorDarkMode.corFonte;

            txtID.BackColor = ControladorDarkMode.corFundoTxBox;
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

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnTaxa.BackColor = ControladorDarkMode.corFundoTxBox;
        }
        private void PopularComboboxes()
        {
            var clientesCNPJ = controladorCNPJ.SelecionarTodos();
            var clientesCPF = controladorCPF.SelecionarTodos();
            var veiculos = controladorVeiculo.SelecionarTodosDisponiveis();

            foreach (var clienteCPF in clientesCPF)
                cbCliente.Items.Add(clienteCPF);

            foreach (var clienteCNPJ in clientesCNPJ)
                cbCliente.Items.Add(clienteCNPJ);

            foreach (var veiculo in veiculos)
                cbVeiculo.Items.Add(veiculo);
        }
        private void MudarDisponibilidadeVeiculo(Veiculo veiculo)
        {
            veiculo.disponibilidade_Veiculo = 0;

            controladorVeiculo.Editar(veiculo.Id, veiculo);
        }
        private static decimal? CalcularPrecoPlanoPorDias(Veiculo veiculo, string tipoLocacao, int dias)
        {
            switch (tipoLocacao)
            {
                case "Plano Diário":
                    return (veiculo.grupoVeiculo.ValorDiarioPDiario * dias);

                case "KM Livre":
                    return (veiculo.grupoVeiculo.ValorDiarioPLivre * dias);

                case "KM Controlado":
                    return (veiculo.grupoVeiculo.ValorDiarioPControlado * dias);

                default: return 0;
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

            telaDasTaxas.CheckBoxTaxas(lista);
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cbCliente.SelectedItem;

            Veiculo veiculo = (Veiculo)cbVeiculo.SelectedItem;

            Desconto desconto = txtCupom.Text != "" ? controladorDesconto.VerificarCodigoValido(txtCupom.Text) : null;

            int tipoCliente = cbCliente.SelectedItem is ClienteCPF ? 0 : 1;

            ClienteCPF condutor = cbCliente.SelectedItem is ClienteCPF ? (ClienteCPF)cliente : (ClienteCPF)cbCondutor.SelectedItem;

            DateTime dataSaida = dtSaida.Value;

            DateTime dataRetornoEsperado = dtRetorno.Value;

            string tipoLocacao = cbTipoLocacao.Text;

            var dias = Convert.ToInt32((dtRetorno.Value - dtSaida.Value).TotalDays);

            decimal? precoServicos = 0;

            if (Servicos != null)
                foreach (var item in Servicos.ToList())
                    precoServicos = item.TipoCalculo != 1 ? precoServicos + item.Preco * dias : precoServicos + item.Preco;


            decimal? precoPlano = CalcularPrecoPlanoPorDias(veiculo, tipoLocacao, dias);

            locacao = new LocacaoVeiculo(cliente, veiculo, desconto, condutor, dataSaida, dataRetornoEsperado, tipoLocacao,
                                    tipoCliente, precoServicos, dias, "Em Aberto", null, precoPlano, null);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
            else
                MudarDisponibilidadeVeiculo(veiculo);
        }
        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedItem is ClienteCPF)
                cbCondutor.Enabled = false;
            else
            {
                ClienteCNPJ cliente = (ClienteCNPJ)cbCliente.SelectedItem;
                var id = cliente.Id;
                cbCondutor.Enabled = true;

                List<ClienteCPF> condutoresRelacionados = controladorCPF.SelecionarPorIdEmpresa(id);

                foreach (var condutor in condutoresRelacionados)
                    cbCondutor.Items.Add(condutor);
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
                foreach (var servico in Servicos)
                    listServicos.Items.Add(servico);
        }

        private void txtCupom_Leave(object sender, EventArgs e)
        {
            if (txtCupom.Text == "")
                return;
            Desconto desconto = controladorDesconto.VerificarCodigoValido(txtCupom.Text);
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
