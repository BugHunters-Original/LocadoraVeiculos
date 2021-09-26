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

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando funcionário {funcionario.Nome}...");

                funcionarioRepository.Inserir(funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} registrado com sucesso!");

                return true;
            }

            return false;
        }
        public bool EditarFuncionario(int id, Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando funcionário {funcionario.Nome}...");

                funcionarioRepository.Editar(id, funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} Editado com sucesso!");

                return true;
            }

            return false;
        }

        public bool ExcluirFuncionario(int id)
        {
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
            Funcionario funcionario =  funcionarioRepository.SelecionarPorId(id);

            logger.Debug($"Selecionando funcionário ID: {id}, NOME: {funcionario.Nome}.");

            return funcionario;
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            List<Funcionario>  funcionario = funcionarioRepository.SelecionarTodos();

            if (funcionario.Count == 0)
                logger.Debug($"Não há funcionários cadastrados");
            else
                logger.Debug($"Selecionando todos os {funcionario.Count} funcionários.");

            return funcionario;
        }
    }
}
