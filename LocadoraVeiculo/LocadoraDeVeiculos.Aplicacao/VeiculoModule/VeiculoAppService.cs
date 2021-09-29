using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog.Core;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.VeiculoModule
{
    public class VeiculoAppService
    {
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoAppService(IVeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }

        public void RegistrarNovoVeiculo(Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            Log.Logger.Aqui().Debug("REGISTRANDO VEÍCULO {VeiculoNome}", veiculo.Nome);


            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                veiculoRepository.Inserir(veiculo);
                Log.Logger.Aqui().Debug("VEÍCULO {VeiculoNome} REGISTRADO COM SUCESSO", veiculo.Nome);

            }
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR VEÍCULO {VeiculoNome}", veiculo.Nome);


        }

        public void EditarVeiculo(int id, Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            Log.Logger.Aqui().Debug("EDITANDO VEÍCULO {VeiculoNome}", veiculo.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
               
                veiculoRepository.Editar(id, veiculo);
                Log.Logger.Aqui().Debug("VEÍCULO {VeiculoNome} EDITADO COM SUCESSO", veiculo.Nome);

            }

            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR VEÍCULO {VeiculoNome}", veiculo.Nome);


        }

        public bool ExcluirVeiculo(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O VEÍCULO ID: {Id}", id);

            var veiculo = veiculoRepository.SelecionarPorId(id);
            var excluiu = veiculoRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("VEÍCULO {Id} REMOVIDO COM SUCESSO", veiculo.Id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER GRUPO VEÍCULO {Id}.", veiculo.Id);

            return excluiu;
        }

        public Veiculo SelecionarVeiculoPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O VEÍCULO ID: {Id}", id);

            Veiculo veiculo =  veiculoRepository.SelecionarPorId(id);


            if (veiculo == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O VEÍCULO ID {Id}", veiculo.Id);
            else
                Log.Logger.Aqui().Debug("VEÍCULO ID {Id} SELECIONADO COM SUCESSO", veiculo.Id);

            return veiculo;
        }

        public List<Veiculo> SelecionarTodosVeiculos()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS VEÍCULOS");

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodos();

            if (veiculo.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS CADASTRADOS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) EXISTENTE(S)", veiculo.Count);

            return veiculo;
             
        }

        public List<Veiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            Log.Logger.Aqui().Debug("SELECIONADO VEÍCULOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<Veiculo> veiculos = veiculoRepository.SelecionarPesquisa(comboBox, pesquisa);


            if (veiculos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", veiculos.Count, pesquisa);

            return veiculos;           
        }

        public void EditarDisponibilidadeVeiculo(Veiculo atual, Veiculo antigo)
        {
            Log.Logger.Aqui().Debug("EDITANDO DISPONIBILIDADE DOS VEÍCULOS {VeiculoNomeAtual} E {VeiculoNomeAntigo}", atual.Nome, antigo.Nome);

            veiculoRepository.EditarDisponibilidade(atual, antigo);
        }

        public List<Veiculo> SelecionarTodosVeiculosAlugados()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS VEÍCULOS ALUGADOS");

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodosAlugados();

            if (veiculo.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS ALUGADOS| {DataEHora}");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) ALUGADO(S)", veiculo.Count);

            return veiculo;
            
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS VEÍCULOS DISPONÍVEIS");

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodosDisponiveis();

            if (veiculo.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS DISPONÍVEIS| {DataEHora}");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) DISPONÍVEIS", veiculo.Count);

            return veiculo;
           
        }

        public int ReturnQuantidadeVeiculosAlugados()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO QUANTIDADE DE VEÍCULOS ALUGADOS");

            int quantidade = veiculoRepository.ReturnQuantidadeAlugados();

            if (quantidade == 0)
                Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS ALUGADOS| {DataEHora}");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) ALUGADOS",  quantidade);

            return quantidade;
           
        }

        public int ReturnQuantidadeVeiculosDisponiveis()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO QUANTIDADE DE VEÍCULOS DISPONÍVEIS");

            int quantidade = veiculoRepository.ReturnQuantidadeDisponiveis();

            if (quantidade == 0)
                Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS DISPONÍVEIS| {DataEHora}");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) DISPONÍVEIS", quantidade);

            return quantidade;
           
        }

    }
}

