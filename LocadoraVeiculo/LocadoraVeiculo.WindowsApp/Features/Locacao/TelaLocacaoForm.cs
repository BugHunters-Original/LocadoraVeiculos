using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public partial class TelaLocacaoForm : Form
    {
        private LocacaoVeiculo locacao;
        private ControladorClienteCPF controladorCPF;
        private ControladorClienteCNPJ controladorCNPJ;
        private ControladorVeiculo controladorVeiculo;
        private List<Servico> servicos;
        public TelaLocacaoForm()
        {
            controladorCPF = new ControladorClienteCPF();
            controladorCNPJ = new ControladorClienteCNPJ();
            controladorVeiculo = new ControladorVeiculo();
            InitializeComponent();
            PopularComboboxes();
            SetColor();
        }

        private void SetColor()
        {
            this.header_Locacao.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;

            txtID.BackColor = ControladorDarkMode.corFundoTxBox;
            cbCliente.BackColor = ControladorDarkMode.corFundoTxBox;
            cbVeiculo.BackColor = ControladorDarkMode.corFundoTxBox;
            cbCondutor.BackColor = ControladorDarkMode.corFundoTxBox;
            dtSaida.BackColor = ControladorDarkMode.corFundoTxBox;
            dtRetorno.BackColor = ControladorDarkMode.corFundoTxBox;

            txtID.ForeColor = ControladorDarkMode.corFonte;
            cbCliente.ForeColor = ControladorDarkMode.corFonte;
            cbVeiculo.ForeColor = ControladorDarkMode.corFonte;
            cbCondutor.ForeColor = ControladorDarkMode.corFonte;
            dtSaida.ForeColor = ControladorDarkMode.corFonte;
            dtRetorno.ForeColor = ControladorDarkMode.corFonte;
            cbTipoLocacao.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnTaxa.BackColor = ControladorDarkMode.corFundoTxBox;
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
                cbVeiculo.SelectedIndex = 0;
                cbVeiculo.Enabled = false;

                cbCondutor.Items.Add(locacao.Condutor);
                cbCondutor.SelectedIndex = 0;

                dtSaida.Value = locacao.DataSaida;
                dtRetorno.Value = locacao.DataRetorno;
                cbTipoLocacao.Text = locacao.TipoLocacao.ToString();
            }
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cbCliente.SelectedItem;

            VeiculoModule.Veiculo veiculo = (VeiculoModule.Veiculo)cbVeiculo.SelectedItem;

            int tipoCliente = cbCliente.SelectedItem is ClienteCPF ? 0 : 1;

            ClienteCPF condutor = cbCliente.SelectedItem is ClienteCPF ? (ClienteCPF)cliente : (ClienteCPF)cbCondutor.SelectedItem;

            DateTime dataSaida = dtSaida.Value;

            DateTime dataRetornoEsperado = dtRetorno.Value;

            string tipoLocacao = cbTipoLocacao.Text;

            var dias = Convert.ToInt32((dtRetorno.Value - dtSaida.Value).TotalDays);

            decimal? precoServicos = 0;
            if (servicos != null)
                foreach (var item in servicos.ToList())
                    precoServicos = item.TipoCalculo != 1 ? precoServicos + item.Preco * dias : precoServicos + item.Preco;

            decimal? precoPlano = CalcularPrecoPlanoPorDias(veiculo, tipoLocacao, dias);

            locacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetornoEsperado, tipoLocacao,
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

        private static decimal? CalcularPrecoPlanoPorDias(VeiculoModule.Veiculo veiculo, string tipoLocacao, int dias)
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

        private void MudarDisponibilidadeVeiculo(VeiculoModule.Veiculo veiculo)
        {
            veiculo.disponibilidade_Veiculo = 0;

            controladorVeiculo.Editar(veiculo.Id, veiculo);
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
            TelaAdicionarTaxasForm tela = new TelaAdicionarTaxasForm();
            tela.ShowDialog();
            servicos = tela.Servicos;
        }


    }
}
