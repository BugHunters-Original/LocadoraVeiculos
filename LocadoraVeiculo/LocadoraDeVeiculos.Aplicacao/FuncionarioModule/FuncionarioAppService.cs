using LocadoraDeVeiculos.Dominio.FuncionarioModule;
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

            logger.Debug("REGISTRANDO FUNCIONÁRIO {FuncionarioNome} | {DataEHora} ", funcionario.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {           
                funcionarioRepository.Inserir(funcionario);

                logger.Debug("FUNCIONÁRIO {FuncionarioNome} REGISTRADO COM SUCESSO | {DataEHora}", funcionario.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR FUNCIONÁRIO {FuncionarioNome} | {DataEHora}", funcionario.Nome, DateTime.Now.ToString());

                return false;
            }

           
        }
        public bool EditarFuncionario(int id, Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            logger.Debug("EDITANDO FUNCIONÁRIO {FuncionarioNome} | {DataEHora} ", funcionario.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(id, funcionario);

                logger.Debug("FUNCIONÁRIO {FuncionarioNome} EDITADO COM SUCESSO | {DataEHora}", funcionario.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR FUNCIONÁRIO {FuncionarioNome} | {DataEHora}", funcionario.Nome, DateTime.Now.ToString());

                return false;
            }    
        }

        public bool ExcluirFuncionario(int id)
        {
            logger.Debug("REMOVENDO FUNCIONÁRIO {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var funcionario = funcionarioRepository.SelecionarPorId(id);
            var excluiu = funcionarioRepository.Excluir(id);

            if (excluiu)
                logger.Debug("FUNCIONÁRIO {Id} REMOVIDO COM SUCESSO | {DataEHora}", funcionario.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER FUNCIONÁRIO {Id} | {DataEHora}.", funcionario.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public List<Funcionario> SelecionarPesquisa(string comboBox, string pesquisa)
        {

            logger.Debug("SELECIONADO FUNCIONÁRIOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<Funcionario> funcionarios = funcionarioRepository.SelecionarPesquisa(comboBox, pesquisa);


            if (funcionarios.Count == 0)
                logger.Information("NÃO HÁ FUNCIONÁRIOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} FUNCIONÁRIO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", funcionarios.Count, pesquisa, DateTime.Now.ToString());

            return funcionarios;
        }

        public Funcionario SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O FUNCIONÁRIO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            Funcionario funcionario =  funcionarioRepository.SelecionarPorId(id);

            if (funcionario == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O FUNCIONÁRIO ID {Id} | {DataEHora}", funcionario.Id, DateTime.Now.ToString());
            else
                logger.Debug("FUNCIONÁRIO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", funcionario.Id, DateTime.Now.ToString());

            return funcionario;
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            logger.Debug("SELECIONANDO TODOS OS FUNCIONÁRIOS | {DataEHora}", DateTime.Now.ToString());

            List<Funcionario>  funcionario = funcionarioRepository.SelecionarTodos();

            if (funcionario.Count == 0)
                logger.Information("NÃO HÁ FUNCIONÁRIOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} FUNCIONÁRIO(S) EXISTENTE(S) | {DataEHora}", funcionario.Count, DateTime.Now.ToString());

            return funcionario;
        }
    }
}
