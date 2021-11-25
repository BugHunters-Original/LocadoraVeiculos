using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService : IParceiroAppService
    {
        private readonly IParceiroRepository parceiroRepository;
        private readonly INotificador notificador;

        public ParceiroAppService(IParceiroRepository parceiroRepo, INotificador notificador)
        {
            parceiroRepository = parceiroRepo;
            this.notificador = notificador;
        }

        public bool Inserir(Parceiro parceiro)
        {
            ParceiroValidator validator = new();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            var validacao = validator.Validate(parceiro);

            if (!validacao.IsValid)
            {
                foreach (var erro in validacao.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

            var nomeExistente = parceiroRepository.ExisteParceiroNome(parceiro.Nome);

            if (nomeExistente)
            {
                notificador.RegistrarNotificacao($"O nome {parceiro.Nome} já está registrando em nossa base de dados");

                return false;
            }

            var parceiroInserido = parceiroRepository.Inserir(parceiro);

            if (!parceiroInserido)
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                notificador.RegistrarNotificacao($"Não foi possível registrar o parceiro {parceiro.Nome}");

                return false;
            }

            Serilogger.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO", parceiro.Nome);

            return true;

        }

        public bool Editar(Parceiro parceiro)
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

        public bool Excluir(Parceiro parceiro)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO PARCEIRO {Id}", parceiro.Id);

            var excluiu = parceiroRepository.Excluir(parceiro);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id}.", parceiro.Id);

            return excluiu;
        }

        public Parceiro GetById(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O PARCEIRO ID: {Id}", id);

            var parceiro = parceiroRepository.GetById(id);

            if (parceiro == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id}", parceiro.Id);
            else
                Serilogger.Logger.Aqui().Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO", parceiro.Id);

            return parceiro;
        }

        public List<Parceiro> GetAll()
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
