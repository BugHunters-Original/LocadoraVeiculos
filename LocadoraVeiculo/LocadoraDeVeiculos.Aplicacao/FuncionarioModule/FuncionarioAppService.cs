using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using log4net;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly ILog logger;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepo, ILog logger)
        {
            funcionarioRepository = funcionarioRepo;
            this.logger = logger;
        }

        public void RegistrarNovoFuncionario(Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando funcionário {funcionario.Nome}...");

                funcionarioRepository.Inserir(funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} registrado com sucesso!");
            }
        }
        public void EditarFuncionario(int id, Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando funcionário {funcionario.Nome}...");

                funcionarioRepository.Editar(id, funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} Editado com sucesso!");
            }
        }

        public bool ExcluirFuncionario(int id)
        {
            return funcionarioRepository.Excluir(id);
        }

        public List<Funcionario> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return funcionarioRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public Funcionario SelecionarPorId(int id)
        {
            return funcionarioRepository.SelecionarPorId(id);
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            return funcionarioRepository.SelecionarTodos();
        }
    }
}
