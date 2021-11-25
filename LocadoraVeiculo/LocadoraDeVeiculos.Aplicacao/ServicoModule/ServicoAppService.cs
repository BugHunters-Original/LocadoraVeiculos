using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ServicoModule
{
    public class ServicoAppService : IServicoAppService
    {
        private readonly IServicoRepository servicoRepository;
        private readonly INotificador notificador;

        public ServicoAppService(IServicoRepository taxaServicoRepo, INotificador notificador)
        {
            servicoRepository = taxaServicoRepo;
            this.notificador = notificador;
        }

        public bool Inserir(Servico servico)
        {
            ServicoValidator validator = new();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO SERVIÇO {ServicoNome}", servico.Nome);

            var validacao = validator.Validate(servico);

            if (!validacao.IsValid)
            {
                foreach (var erro in validacao.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

            var servicoInserido = servicoRepository.Inserir(servico);

            if (!servicoInserido)
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR SERVIÇO {ServicoNome}", servico.Nome);

                notificador.RegistrarNotificacao($"Não foi possível registrar o serviço {servico.Nome}");

                return false;
            }

            Serilogger.Logger.Aqui().Debug("SERVIÇO {ServicoNome} REGISTRADO COM SUCESSO", servico.Nome);

            return true;
        }



        public bool Editar(Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                servicoRepository.Editar(servico);

                Serilogger.Logger.Aqui().Debug("SERVIÇO {ServicoNome} EDITADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool Excluir(Servico servico)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO SERVIÇO {Id}", servico.Id);

            var excluiu = servicoRepository.Excluir(servico);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("SERVIÇO {Id} REMOVIDO COM SUCESSO", servico.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER SERVIÇO {Id}.", servico.Id);

            return excluiu;
        }

        public Servico GetById(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O SERVIÇO ID: {Id}", id);

            var servico = servicoRepository.GetById(id);

            if (servico == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR SERVIÇO ID {Id}", servico.Id);
            else
                Serilogger.Logger.Aqui().Debug("SERVIÇO ID {Id} SELECIONADO COM SUCESSO", servico.Id);

            return servico;
        }

        public List<Servico> GetAll()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS SERVIÇOS");

            List<Servico> servicos = servicoRepository.GetAll();

            if (servicos.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ SERVIÇOS CADASTRADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S)", servicos.Count);

            return servicos;
        }
    }
}
