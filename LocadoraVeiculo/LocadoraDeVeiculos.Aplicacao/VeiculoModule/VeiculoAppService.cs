using LocadoraDeVeiculos.Dominio.VeiculoModule;
using log4net;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.VeiculoModule
{
    public class VeiculoAppService
    {
        private readonly IVeiculoRepository veiculoRepository;
        private readonly ILog logger;

        public VeiculoAppService(IVeiculoRepository veiculoRepository, ILog logger)
        {
            this.veiculoRepository = veiculoRepository;
            this.logger = logger;
        }

        public void RegistrarNovoVeiculo(Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando Veículo {veiculo}...");

                veiculoRepository.InserirVeiculo(veiculo);

                logger.Debug($"Veículo {veiculo} registrado com sucesso!");
            }
        }

        public void EditarVeiculo(int id, Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando veículo {veiculo}...");

                veiculoRepository.EditarVeiculo(id, veiculo);

                logger.Debug($"Veículo {veiculo} editado com sucesso!");
            }
        }

        public bool ExcluirVeiculo(int id)
        {
            return veiculoRepository.ExcluirVeiculo(id);
        }

        public Veiculo SelecionarVeiculoPorId(int id)
        {
            return veiculoRepository.SelecionarPorId(id);
        }

        public List<Veiculo> SelecionarTodosVeiculos()
        {
            return veiculoRepository.SelecionarTodos();
        }

        public List<Veiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return veiculoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public void EditarDisponibilidadeVeiculo(Veiculo atual, Veiculo antigo)
        {
            veiculoRepository.EditarDisponibilidade(atual, antigo);
        }

        public List<Veiculo> SelecionarTodosVeiculosAlugados()
        {
            return veiculoRepository.SelecionarTodosAlugados();
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            return veiculoRepository.SelecionarTodosDisponiveis();
        }

        public int ReturnQuantidadeVeiculosAlugados()
        {
            return veiculoRepository.ReturnQuantidadeAlugados();
        }

        public int ReturnQuantidadeVeiculosDisponiveis()
        {
            return veiculoRepository.ReturnQuantidadeDisponiveis();
        }

    }
}

