using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ServicoModule
{
    public class ServicoAppService
    {
        private readonly IServicoRepository taxaServicoRepository;

        public ServicoAppService(IServicoRepository taxaServicoRepo)
        {
            taxaServicoRepository = taxaServicoRepo;
        }

        public bool InserirServico(Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                taxaServicoRepository.Inserir(servico);

                Serilogger.Logger.Aqui().Debug("SERVIÇO {ServicoNome} REGISTRADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool EditarServico(Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                taxaServicoRepository.Editar(servico);

                Serilogger.Logger.Aqui().Debug("SERVIÇO {ServicoNome} EDITADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool ExcluirServico(Servico servico)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO SERVIÇO {Id}", servico.Id);

            var excluiu = taxaServicoRepository.Excluir(servico);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("SERVIÇO {Id} REMOVIDO COM SUCESSO", servico.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER SERVIÇO {Id}.", servico.Id);

            return excluiu;
        }

        public Servico SelecionarPorId(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O SERVIÇO ID: {Id}", id);

            var servico = taxaServicoRepository.GetById(id);

            if (servico == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR SERVIÇO ID {Id}", servico.Id);
            else
                Serilogger.Logger.Aqui().Debug("SERVIÇO ID {Id} SELECIONADO COM SUCESSO", servico.Id);

            return servico;
        }

        public List<Servico> SelecionarTodosServicos()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS SERVIÇOS");

            List<Servico> servicos = taxaServicoRepository.GetAll();

            if (servicos.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ SERVIÇOS CADASTRADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S)", servicos.Count);

            return servicos;
        }
    }
}
