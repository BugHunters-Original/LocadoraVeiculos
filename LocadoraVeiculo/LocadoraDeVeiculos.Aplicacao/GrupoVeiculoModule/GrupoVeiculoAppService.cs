using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using log4net;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule
{
    public class GrupoVeiculoAppService
    {
        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;
        private readonly ILog logger;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository, ILog logger)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
            this.logger = logger;
        }

        public void RegistrarNovoGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando grupo veículo {grupoVeiculo}...");

                grupoVeiculoRepository.InserirGrupoVeiculo(grupoVeiculo);

                logger.Debug($"Grupo Veículo {grupoVeiculo} registrado com sucesso!");
            }

        }

        public void EditarNovoGrupoVeiculo(int id, GrupoVeiculo grupoVeiculo) {

            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando funcionário {grupoVeiculo.NomeTipo}...");

                grupoVeiculoRepository.EditarGrupoVeiculo(id, grupoVeiculo);

                logger.Debug($"Grupo Veículo {grupoVeiculo.NomeTipo} editando com sucesso!");
            }
        }

        public bool ExcluirGrupoVeiculo(int id)
        {
            return grupoVeiculoRepository.ExcluirGrupoVeiculo(id);
        }

        public List<GrupoVeiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return grupoVeiculoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            return grupoVeiculoRepository.SelecionarPorId(id);
        }

        public List<GrupoVeiculo> SelecionarTodosGruposVeiculos()
        {
            return grupoVeiculoRepository.SelecionarTodos();
        }
    }
}
