using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.Logger;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao;

namespace LocadoraDeVeiculos.Infra.ORM.LocacaoModule
{
    public class LocacaoDAO : BaseDAO<Locacao>, ILocacaoRepository
    {
        public LocacaoDAO(LocacaoContext context) : base(context)
        {

        }
        public override List<Locacao> GetAll()
        {
            return registros.
                   Include(x => x.Cliente).
                   Include(x => x.Veiculo).
                   ThenInclude(x => x.GrupoVeiculo).
                   Include(x => x.Desconto).
                   Include(x => x.Condutor).
                   ToList();
        }
        public override Locacao GetById(int id)
        {
            return registros.
                   Include(x => x.Cliente).
                   Include(x => x.Veiculo).
                   ThenInclude(x => x.GrupoVeiculo).
                   Include(x => x.Desconto).
                   Include(x => x.Condutor).
                   SingleOrDefault(x => x.Id == id);
        }

        public int SelecionarLocacoesComCupons(string cupom)
        {
            try
            {
                int qtdLocacoesComCupom = registros.
                                          Where(x => x.Desconto.Codigo == cupom).
                                          Count();

                if (qtdLocacoesComCupom == 0)
                    Serilogger.Logger.Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");
                else
                    Serilogger.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");

                return qtdLocacoesComCupom;

            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");

                return 0;
            }
        }

        public int SelecionarQuantidadeLocacoesPendentes()
        {
            try
            {
                int qtdLocacoesPendentes = registros.
                                           Where(x => x.Status == StatusLocacao.Pendente).
                                           Count();

                if (qtdLocacoesPendentes == 0)
                    Serilogger.Logger.Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  ");
                else
                    Serilogger.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  ");

                return qtdLocacoesPendentes;

            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCACOES PENDENTES  ");

                return 0;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            try
            {
                List<Locacao> locacoes = registros.
                                           Include(x => x.Cliente).
                                           Include(x => x.Veiculo).
                                           ThenInclude(x => x.GrupoVeiculo).
                                           Include(x => x.Desconto).
                                           Include(x => x.Condutor).
                                           Where(x => x.Status == StatusLocacao.Concluido).
                                           ToList();

                if (locacoes.Count != 0)
                    Serilogger.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");
                else
                    Serilogger.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");

                return locacoes;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");

                return null;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            try
            {
                List<Locacao> locacoes = registros.
                                           Include(x => x.Cliente).
                                           Include(x => x.Veiculo).
                                           ThenInclude(x => x.GrupoVeiculo).
                                           Include(x => x.Desconto).
                                           Include(x => x.Condutor).
                                           Where(x => x.Status == StatusLocacao.Pendente).
                                           ToList();

                if (locacoes.Count != 0)
                    Serilogger.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");
                else
                    Serilogger.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");

                return locacoes;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");

                return null;
            }
        }

        public void ConcluirLocacao(Locacao locacao)
        {
            try
            {
                locacao.Status = StatusLocacao.Concluido;

                Editar(locacao);

                Serilogger.Logger.Information("SUCESSO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
        }
    }
}
