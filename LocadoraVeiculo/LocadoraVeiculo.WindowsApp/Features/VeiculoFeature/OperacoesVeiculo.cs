using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.VeiculoFeature
{
    public class OperacoesVeiculo : ICadastravel
    {
        private readonly VeiculoAppService veiculoService;
        private readonly GrupoVeiculoAppService grupoVeiculoService;
        private readonly TabelaVeiculoControl tabelaVeiculos;

        public OperacoesVeiculo(VeiculoAppService veiculoService, GrupoVeiculoAppService grupoVeiculoService)
        {
            this.veiculoService = veiculoService;
            this.grupoVeiculoService = grupoVeiculoService;
            tabelaVeiculos = new TabelaVeiculoControl(veiculoService);
        }

        public void InserirNovoRegistro()
        {
            if (grupoVeiculoService.GetAll().Count == 0)
            {
                MessageBox.Show("Cadastre primeiro um Grupo de Veículos!", "Adição de Veículos",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaVeiculoForm tela = new TelaVeiculoForm(grupoVeiculoService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                veiculoService.Inserir(tela.Veiculo);

                List<Veiculo> veiculos = veiculoService.GetAll();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculo.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            Veiculo veiculoSelecionado = veiculoService.GetById(id);

            TelaVeiculoForm tela = new TelaVeiculoForm(grupoVeiculoService);

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                veiculoService.Editar(tela.Veiculo);

                List<Veiculo> veiculos = veiculoService.GetAll();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculo.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Veiculo veiculoSelecionada = veiculoService.GetById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Veículo: [{veiculoSelecionada.Nome}] ?",
                "Exclusão de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool excluiu = veiculoService.Excluir(veiculoSelecionada);

                if (excluiu)
                {
                    List<Veiculo> veiculos = veiculoService.GetAll();

                    tabelaVeiculos.AtualizarRegistros(veiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionada.Nome}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Remova primeiro as Locações vinculadas ao Veículo e tente novamente",
                        "Exclusão de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FiltrarRegistros()
        {

        }

        public UserControl ObterTabela()
        {
            List<Veiculo> veiculos = veiculoService.GetAll();

            tabelaVeiculos.AtualizarRegistros(veiculos);

            return tabelaVeiculos;
        }

        public void PesquisarRegistro(string pesquisa)
        {
            List<Veiculo> veiculos = veiculoService.GetAll();

            var palavras = pesquisa.Split(' ');

            List<Veiculo> filtrados = veiculos.Where(i => palavras.Any(p => i.ToString().IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            tabelaVeiculos.AtualizarRegistros(filtrados);
        }

      

        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Veículo para poder {acao}!", $"{onde} de Veículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        public void DevolverVeiculo()
        {
            throw new System.NotImplementedException();
        }
    }
}

