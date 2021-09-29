using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepo)
        {
            funcionarioRepository = funcionarioRepo;
        }

        public bool RegistrarNovoFuncionario(Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            Log.Logger.Aqui().Debug("REGISTRANDO FUNCIONÁRIO {FuncionarioNome} ", funcionario.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {           
                funcionarioRepository.Inserir(funcionario);

                Log.Logger.Aqui().Debug("FUNCIONÁRIO {FuncionarioNome} REGISTRADO COM SUCESSO", funcionario.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR FUNCIONÁRIO {FuncionarioNome}", funcionario.Nome);

                return false;
            }

           
        }
        public bool EditarFuncionario(int id, Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            Log.Logger.Aqui().Debug("EDITANDO FUNCIONÁRIO {FuncionarioNome} ", funcionario.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(id, funcionario);

                Log.Logger.Aqui().Debug("FUNCIONÁRIO {FuncionarioNome} EDITADO COM SUCESSO", funcionario.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR FUNCIONÁRIO {FuncionarioNome}", funcionario.Nome);

                return false;
            }    
        }

        public bool ExcluirFuncionario(int id)
        {
            Log.Logger.Aqui().Debug("REMOVENDO FUNCIONÁRIO {Id}", id);

            var funcionario = funcionarioRepository.SelecionarPorId(id);
            var excluiu = funcionarioRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("FUNCIONÁRIO {Id} REMOVIDO COM SUCESSO", funcionario.Id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER FUNCIONÁRIO {Id}.", funcionario.Id);

            return excluiu;
        }

        public Funcionario SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O FUNCIONÁRIO ID: {Id}", id);

            Funcionario funcionario =  funcionarioRepository.SelecionarPorId(id);

            if (funcionario == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O FUNCIONÁRIO ID {Id}", funcionario.Id);
            else
                Log.Logger.Aqui().Debug("FUNCIONÁRIO ID {Id} SELECIONADO COM SUCESSO", funcionario.Id);

            return funcionario;
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS FUNCIONÁRIOS");

            List<Funcionario>  funcionario = funcionarioRepository.SelecionarTodos();

            if (funcionario.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ FUNCIONÁRIOS CADASTRADOS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} FUNCIONÁRIO(S) EXISTENTE(S)", funcionario.Count);

            return funcionario;
        }
    }
}
