using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using Serilog.Core;
using System;
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

            logger.Aqui().Debug("REGISTRANDO FUNCIONÁRIO {FuncionarioNome} ", funcionario.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {           
                funcionarioRepository.Inserir(funcionario);

                logger.Aqui().Debug("FUNCIONÁRIO {FuncionarioNome} REGISTRADO COM SUCESSO", funcionario.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR FUNCIONÁRIO {FuncionarioNome}", funcionario.Nome);

                return false;
            }

           
        }
        public bool EditarFuncionario(int id, Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            logger.Aqui().Debug("EDITANDO FUNCIONÁRIO {FuncionarioNome} ", funcionario.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(id, funcionario);

                logger.Aqui().Debug("FUNCIONÁRIO {FuncionarioNome} EDITADO COM SUCESSO", funcionario.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR FUNCIONÁRIO {FuncionarioNome}", funcionario.Nome);

                return false;
            }    
        }

        public bool ExcluirFuncionario(int id)
        {
            logger.Aqui().Debug("REMOVENDO FUNCIONÁRIO {Id}", id);

            var funcionario = funcionarioRepository.SelecionarPorId(id);
            var excluiu = funcionarioRepository.Excluir(id);

            if (excluiu)
                logger.Aqui().Debug("FUNCIONÁRIO {Id} REMOVIDO COM SUCESSO", funcionario.Id);
            else
                logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER FUNCIONÁRIO {Id}.", funcionario.Id);

            return excluiu;
        }

        public List<Funcionario> SelecionarPesquisa(string comboBox, string pesquisa)
        {

            logger.Aqui().Debug("SELECIONADO FUNCIONÁRIOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<Funcionario> funcionarios = funcionarioRepository.SelecionarPesquisa(comboBox, pesquisa);


            if (funcionarios.Count == 0)
                logger.Aqui().Information("NÃO HÁ FUNCIONÁRIOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} FUNCIONÁRIO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", funcionarios.Count, pesquisa);

            return funcionarios;
        }

        public Funcionario SelecionarPorId(int id)
        {
            logger.Aqui().Debug("SELECIONANDO O FUNCIONÁRIO ID: {Id}", id);

            Funcionario funcionario =  funcionarioRepository.SelecionarPorId(id);

            if (funcionario == null)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O FUNCIONÁRIO ID {Id}", funcionario.Id);
            else
                logger.Aqui().Debug("FUNCIONÁRIO ID {Id} SELECIONADO COM SUCESSO", funcionario.Id);

            return funcionario;
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            logger.Aqui().Debug("SELECIONANDO TODOS OS FUNCIONÁRIOS");

            List<Funcionario>  funcionario = funcionarioRepository.SelecionarTodos();

            if (funcionario.Count == 0)
                logger.Aqui().Information("NÃO HÁ FUNCIONÁRIOS CADASTRADOS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} FUNCIONÁRIO(S) EXISTENTE(S)", funcionario.Count);

            return funcionario;
        }
    }
}
