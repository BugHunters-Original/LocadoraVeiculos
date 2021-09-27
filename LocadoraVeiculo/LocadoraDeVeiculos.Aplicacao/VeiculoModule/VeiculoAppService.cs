using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Serilog.Core;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.VeiculoModule
{
    public class VeiculoAppService
    {
        private readonly IVeiculoRepository veiculoRepository;
        private readonly Logger logger;

        public VeiculoAppService(IVeiculoRepository veiculoRepository, Logger logger)
        {
            this.veiculoRepository = veiculoRepository;
            this.logger = logger;
        }

        public void RegistrarNovoVeiculo(Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            logger.Debug("REGISTRANDO VEÍCULO {VeiculoNome} | {DataEHora} ", veiculo.Nome, DateTime.Now.ToString());


            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                veiculoRepository.Inserir(veiculo);
                logger.Debug("VEÍCULO {VeiculoNome} REGISTRADO COM SUCESSO | {DataEHora}", veiculo.Nome, DateTime.Now.ToString());

            }
            else
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR VEÍCULO {VeiculoNome} | {DataEHora}", veiculo.Nome, DateTime.Now.ToString());


        }

        public void EditarVeiculo(int id, Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();
            logger.Debug("EDITANDO VEÍCULO {VeiculoNome} | {DataEHora} ", veiculo.Nome, DateTime.Now.ToString());


            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
               
                veiculoRepository.Editar(id, veiculo);
                logger.Debug("VEÍCULO {VeiculoNome} EDITADO COM SUCESSO | {DataEHora}", veiculo.Nome, DateTime.Now.ToString());

            }

            else
                logger.Error("NÃO FOI POSSÍVEL EDITAR VEÍCULO {VeiculoNome} | {DataEHora}", veiculo.Nome, DateTime.Now.ToString());


        }

        public bool ExcluirVeiculo(int id)
        {
            logger.Debug("SELECIONANDO O VEÍCULO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var veiculo = veiculoRepository.SelecionarPorId(id);
            var excluiu = veiculoRepository.Excluir(id);

            if (excluiu)
                logger.Debug("VEÍCULO {Id} REMOVIDO COM SUCESSO | {DataEHora}", veiculo.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER GRUPO VEÍCULO {Id} | {DataEHora}.", veiculo.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public Veiculo SelecionarVeiculoPorId(int id)
        {
            logger.Debug("SELECIONANDO O VEÍCULO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            Veiculo veiculo =  veiculoRepository.SelecionarPorId(id);


            if (veiculo == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O VEÍCULO ID {Id} | {DataEHora}", veiculo.Id, DateTime.Now.ToString());
            else
                logger.Debug("VEÍCULO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", veiculo.Id, DateTime.Now.ToString());

            return veiculo;
        }

        public List<Veiculo> SelecionarTodosVeiculos()
        {
            logger.Debug("SELECIONANDO TODOS OS VEÍCULOS | {DataEHora}", DateTime.Now.ToString());

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodos();

            if (veiculo.Count == 0)
                logger.Information("NÃO HÁ VEÍCULOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) EXISTENTE(S) | {DataEHora}", veiculo.Count, DateTime.Now.ToString());

            return veiculo;
             
        }

        public List<Veiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO VEÍCULOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<Veiculo> veiculos = veiculoRepository.SelecionarPesquisa(comboBox, pesquisa);


            if (veiculos.Count == 0)
                logger.Information("NÃO HÁ VEÍCULOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", veiculos.Count, pesquisa, DateTime.Now.ToString());

            return veiculos;

           
        }

        public void EditarDisponibilidadeVeiculo(Veiculo atual, Veiculo antigo)
        {
            logger.Debug("EDITANDO DISPONIBILIDADE DOS VEÍCULOS {VeiculoNomeAtual} E {VeiculoNomeAntigo} | {DataEHora} ", atual.Nome, antigo.Nome, DateTime.Now.ToString());

            veiculoRepository.EditarDisponibilidade(atual, antigo);
        }

        public List<Veiculo> SelecionarTodosVeiculosAlugados()
        {
            logger.Debug("SELECIONANDO TODOS OS VEÍCULOS ALUGADOS | {DataEHora}", DateTime.Now.ToString());

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodosAlugados();

            if (veiculo.Count == 0)
                logger.Information("NÃO HÁ VEÍCULOS ALUGADOS| {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) ALUGADO(S) | {DataEHora}", veiculo.Count, DateTime.Now.ToString());

            return veiculo;
            
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            logger.Debug("SELECIONANDO TODOS OS VEÍCULOS DISPONÍVEIS | {DataEHora}", DateTime.Now.ToString());

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodosDisponiveis();

            if (veiculo.Count == 0)
                logger.Information("NÃO HÁ VEÍCULOS DISPONÍVEIS| {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) DISPONÍVEIS | {DataEHora}", veiculo.Count, DateTime.Now.ToString());

            return veiculo;
           
        }

        public int ReturnQuantidadeVeiculosAlugados()
        {
            logger.Debug("SELECIONANDO QUANTIDADE DE VEÍCULOS ALUGADOS | {DataEHora}", DateTime.Now.ToString());

            int quantidade = veiculoRepository.ReturnQuantidadeAlugados();

            if (quantidade == 0)
                logger.Information("NÃO HÁ VEÍCULOS ALUGADOS| {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) ALUGADOS | {DataEHora}",  quantidade, DateTime.Now.ToString());

            return quantidade;
           
        }

        public int ReturnQuantidadeVeiculosDisponiveis()
        {
            logger.Debug("SELECIONANDO QUANTIDADE DE VEÍCULOS DISPONÍVEIS | {DataEHora}", DateTime.Now.ToString());

            int quantidade = veiculoRepository.ReturnQuantidadeDisponiveis();

            if (quantidade == 0)
                logger.Information("NÃO HÁ VEÍCULOS DISPONÍVEIS| {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) DISPONÍVEIS | {DataEHora}", quantidade, DateTime.Now.ToString());

            return quantidade;
           
        }

    }
}

