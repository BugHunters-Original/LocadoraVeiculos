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

            Log.Logger.Aqui().Debug("REGISTRANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                taxaServicoRepository.Inserir(servico);

                Log.Logger.Aqui().Debug("SERVIÇO {ServicoNome} REGISTRADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool EditarServico(int id, Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            Log.Logger.Aqui().Debug("EDITANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                taxaServicoRepository.Editar(id, servico);

                Log.Logger.Aqui().Debug("SERVIÇO {ServicoNome} EDITADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool ExcluirServico(int id)
        {
            Log.Logger.Aqui().Debug("REMOVENDO SERVIÇO {Id}", id);

            var parceiro = taxaServicoRepository.SelecionarPorId(id);

            var excluiu = taxaServicoRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("SERVIÇO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER SERVIÇO {Id}.", parceiro.Id);

            return excluiu;
        }

        public List<Servico> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            Log.Logger.Aqui().Debug("SELECIONADO SERVIÇO DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<Servico> servicos = taxaServicoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (servicos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ SERVIÇOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", servicos.Count, pesquisa);

            return servicos;
        }

        public Servico SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O SERVIÇO ID: {Id}", id);

            var servico = taxaServicoRepository.SelecionarPorId(id);

            if (servico == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR SERVIÇO ID {Id}", servico.Id);
            else
                Log.Logger.Aqui().Debug("SERVIÇO ID {Id} SELECIONADO COM SUCESSO", servico.Id);

            return servico;
        }

        public List<Servico> SelecionarTodosServicos()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS SERVIÇOS");

            List<Servico> servicos = taxaServicoRepository.SelecionarTodos();

            if (servicos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ SERVIÇOS CADASTRADOS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S)", servicos.Count);

            return servicos;
        }
    }
}
