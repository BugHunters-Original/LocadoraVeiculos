using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService : IParceiroAppService
    {
        private readonly IParceiroRepository parceiroRepository;

        public ParceiroAppService(IParceiroRepository parceiroRepo)
        {
            parceiroRepository = parceiroRepo;
        }

        public bool RegistrarNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                parceiroRepository.Inserir(parceiro);

                Serilogger.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool EditarParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                parceiroRepository.Editar(parceiro);

                Serilogger.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} EDITADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool ExcluirParceiro(Parceiro parceiro)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO PARCEIRO {Id}", parceiro.Id);

            var excluiu = parceiroRepository.Excluir(parceiro);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id}.", parceiro.Id);

            return excluiu;
        }

        public Parceiro SelecionarPorId(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O PARCEIRO ID: {Id}", id);

            var parceiro = parceiroRepository.GetById(id);

            if (parceiro == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id}", parceiro.Id);
            else
                Serilogger.Logger.Aqui().Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO", parceiro.Id);

            return parceiro;
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS PARCEIROS");

            List<Parceiro> parceiro = parceiroRepository.GetAll();

            if (parceiro.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ PARCEIROS CADASTRADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S)", parceiro.Count);

            return parceiro;
        }
    }
}
