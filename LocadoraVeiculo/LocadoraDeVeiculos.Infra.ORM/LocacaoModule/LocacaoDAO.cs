﻿using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    LogSerilog.Logger.Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");
                else
                    LogSerilog.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");

                return qtdLocacoesComCupom;

            }
            catch (Exception ex)
            {
                LogSerilog.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");

                return 0;
            }
        }

        public int SelecionarQuantidadeLocacoesPendentes()
        {
            try
            {
                int qtdLocacoesPendentes = registros.
                                           Where(x => x.StatusLocacao == "Em Aberto").
                                           Count();

                if (qtdLocacoesPendentes == 0)
                    LogSerilog.Logger.Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  ");
                else
                    LogSerilog.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  ");

                return qtdLocacoesPendentes;

            }
            catch (Exception ex)
            {
                LogSerilog.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCACOES PENDENTES  ");

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
                                           Where(x => x.StatusLocacao == "Concluída").
                                           ToList();

                if (locacoes.Count != 0)
                    LogSerilog.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");
                else
                    LogSerilog.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");

                return locacoes;
            }
            catch (Exception ex)
            {
                LogSerilog.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");

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
                                           Where(x => x.StatusLocacao == "Em Aberto").
                                           ToList();

                if (locacoes.Count != 0)
                    LogSerilog.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");
                else
                    LogSerilog.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");

                return locacoes;
            }
            catch (Exception ex)
            {
                LogSerilog.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");

                return null;
            }
        }

        public void AbrirLocacao(Locacao locacao)
        {
            try
            {
                locacao.StatusLocacao = "Em Aberto";

                Editar(locacao);

                LogSerilog.Logger.Information("SUCESSO AO INICIAR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
            catch (Exception ex)
            {
                LogSerilog.Logger.Error(ex, "ERRO AO INICIAR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
        }

        public void ConcluirLocacao(Locacao locacao)
        {
            try
            {
                locacao.StatusLocacao = "Concluída";

                Editar(locacao);

                LogSerilog.Logger.Information("SUCESSO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
            catch (Exception ex)
            {
                LogSerilog.Logger.Error(ex, "ERRO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
        }
    }
}
