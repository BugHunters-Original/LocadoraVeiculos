using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Serilog.Core;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly Logger logger;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepo, Logger logger)
        {
            funcionarioRepository = funcionarioRepo;
            this.logger = logger;
        }

        public bool RegistrarNovoFuncionario(Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            logger.Debug($"Registrando funcionário {funcionario.Nome}...");

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {           
                funcionarioRepository.Inserir(funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} registrado com sucesso!");

                return true;
            }
            else
            {
                logger.Error($"Não foi possível registrar o Funcionário: {funcionario.Nome}.");

                return false;
            }

           
        }
        public bool EditarFuncionario(int id, Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            logger.Debug($"Editando funcionário {funcionario.Nome}...");

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(id, funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} Editado com sucesso!");

                return true;
            }
            else
            {
                logger.Error($"Não foi possível editar o Funcionário: {funcionario.Nome}.");

                return false;
            }    
        }

        public bool ExcluirFuncionario(int id)
        {
            logger.Debug($"Excluindo o funcionário ID: {id}.");

            var funcionario = funcionarioRepository.SelecionarPorId(id);
            var excluiu = funcionarioRepository.Excluir(id);

            if (excluiu)
                logger.Debug($"Excluiu Funcionário {funcionario.Nome} com ID {funcionario.Id}!");
            else
                logger.Error($"Não excluiu Funcionário {funcionario.Nome} com ID {funcionario.Id}!");

            return excluiu;
        }

        public List<Funcionario> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return funcionarioRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public Funcionario SelecionarPorId(int id)
        {
            logger.Debug($"Selecionando o funcionário ID: {id}.");

            Funcionario funcionario =  funcionarioRepository.SelecionarPorId(id);

            if (funcionario == null)
                logger.Warn($"Não foi possível encontrar o funcionário com ID: {id}");
            else
                logger.Debug($"Selecionando funcionário ID: {id}, NOME: {funcionario.Nome}.");

            return funcionario;
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            logger.Debug($"Selecionando todos os Funcionários.");

            List<Funcionario>  funcionario = funcionarioRepository.SelecionarTodos();

            if (funcionario.Count == 0)
                logger.Warn($"Não há funcionários cadastrados");
            else
                logger.Debug($"Selecionou os {funcionario.Count} Funcionários existentes.");

            return funcionario;
        }
    }
}
