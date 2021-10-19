using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
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

            Serilogger.Logger.Aqui().Debug("REGISTRANDO FUNCIONÁRIO {FuncionarioNome} ", funcionario.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {           
                funcionarioRepository.Inserir(funcionario);

                Serilogger.Logger.Aqui().Debug("FUNCIONÁRIO {FuncionarioNome} REGISTRADO COM SUCESSO", funcionario.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR FUNCIONÁRIO {FuncionarioNome}", funcionario.Nome);

                return false;
            }

           
        }
        public bool EditarFuncionario(Funcionario funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO FUNCIONÁRIO {FuncionarioNome} ", funcionario.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(funcionario);

                Serilogger.Logger.Aqui().Debug("FUNCIONÁRIO {FuncionarioNome} EDITADO COM SUCESSO", funcionario.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR FUNCIONÁRIO {FuncionarioNome}", funcionario.Nome);

                return false;
            }    
        }

        public bool ExcluirFuncionario(Funcionario funcionario)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO FUNCIONÁRIO {Id}", funcionario.Id);

            var excluiu = funcionarioRepository.Excluir(funcionario);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("FUNCIONÁRIO {Id} REMOVIDO COM SUCESSO", funcionario.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER FUNCIONÁRIO {Id}.", funcionario.Id);

            return excluiu;
        }

        public Funcionario SelecionarPorId(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O FUNCIONÁRIO ID: {Id}", id);

            Funcionario funcionario =  funcionarioRepository.GetById(id);

            if (funcionario == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O FUNCIONÁRIO ID {Id}", funcionario.Id);
            else
                Serilogger.Logger.Aqui().Debug("FUNCIONÁRIO ID {Id} SELECIONADO COM SUCESSO", funcionario.Id);

            return funcionario;
        }

        public List<Funcionario> SelecionarTodosFuncionarios()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS FUNCIONÁRIOS");

            List<Funcionario>  funcionario = funcionarioRepository.GetAll();

            if (funcionario.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ FUNCIONÁRIOS CADASTRADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} FUNCIONÁRIO(S) EXISTENTE(S)", funcionario.Count);

            return funcionario;
        }
    }
}
