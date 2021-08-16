﻿using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
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
        }

        public LocacaoVeiculo Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                txtID.Text = locacao.Id.ToString();
                cbCliente.Text = locacao.Cliente.ToString();
                cbVeiculo.Text = locacao.Veiculo.ToString();
                cbCondutor.Text = locacao.Condutor.ToString();
                dtSaida.Value = locacao.DataSaida;
                dtRetorno.Value = locacao.DataRetorno;
                cbTipoLocacao.Text = locacao.TipoLocacao.ToString();
                txtKmRodado.Text = locacao.KmRodado.ToString();
            }
        }

        private void PopularComboboxes()
        {
            var clientesCNPJ = controladorCNPJ.SelecionarTodos();
            var clientesCPF = controladorCPF.SelecionarTodos();
            var veiculos = controladorVeiculo.SelecionarTodos();

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

            int tipoCliente;
            ClienteCPF condutor;
            if (cbCliente.SelectedItem is ClienteCPF)
            {
                condutor = (ClienteCPF)cliente;
                tipoCliente = 0;
            }
            else
            {
                condutor = (ClienteCPF)cbCondutor.SelectedItem;
                tipoCliente = 1;
            }

            DateTime dataSaida = dtSaida.Value;
            DateTime dataRetornoEsperado = dtRetorno.Value;

            string tipoLocacao = cbTipoLocacao.Text;

            var dias = Convert.ToInt32((dtRetorno.Value - dtSaida.Value).TotalDays);

            decimal? precoTotal = 0;
            if (servicos != null)
            {
                List<Servico> servicosTaxas = servicos.ToList();

                foreach (var item in servicosTaxas)
                    precoTotal = item.TipoCalculo != 1 ? precoTotal + item.Preco * dias : precoTotal + item.Preco;
            }


            decimal? kmRodado = null;
            if (txtKmRodado.Text != "")
                kmRodado = Convert.ToDecimal(txtKmRodado.Text);


            switch (tipoLocacao)
            {
                case "Plano Diário":
                    precoTotal += (veiculo.grupoVeiculo.preco_KMDiario * dias); break;

                case "KM Controlado":
                    precoTotal += (veiculo.grupoVeiculo.valor_Diario_PControlado * dias) + (veiculo.grupoVeiculo.kmDia__KMControlado * dias * kmRodado); break;

                default: break;
            }

            locacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetornoEsperado, tipoLocacao, tipoCliente, precoTotal, kmRodado);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
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

        private void cbTipoLocacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoLocacao.Text == "KM Controlado")
                txtKmRodado.Enabled = true;
            else
                txtKmRodado.Enabled = false;
        }
    }
}