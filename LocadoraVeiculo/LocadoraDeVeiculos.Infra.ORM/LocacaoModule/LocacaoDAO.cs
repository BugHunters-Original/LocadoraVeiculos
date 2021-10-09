﻿using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.LocacaoModule
{
    public class LocacaoDAO : BaseDAO<Locacao>, ILocacaoRepository
    {
        public LocacaoDAO(LocacaoContext context):base(context)
        {

        }

        public void ConcluirLocacao(Locacao locacao)
        {
            try
            {
                locacao.StatusLocacao = "Concluída";

                contexto.Locacoes.Update(locacao);

                Log.Logger.Information("SUCESSO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
        }

        public int SelecionarLocacoesComCupons(string cupom)
        {
            try
            {
                int qtdLocacoesComCupom = contexto.Locacoes.Where(x => x.Desconto.Codigo == cupom).Count();

                if (qtdLocacoesComCupom == 0)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");

                return qtdLocacoesComCupom;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  ");

                return 0;
            }
        }

        public int SelecionarQuantidadeLocacoesPendentes()
        {
            try
            {
                int qtdLocacoesPendentes = contexto.Locacoes.Where(x => x.StatusLocacao == "Concluída").Count();

                if (qtdLocacoesPendentes == 0)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  ");

                return qtdLocacoesPendentes;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCACOES PENDENTES  ");

                return 0;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            try
            {
                List<Locacao> locacoes = contexto.Locacoes.Where(x => x.StatusLocacao == "Concluída").ToList();

                if (locacoes != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");

                return locacoes;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  ");

                return null;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            try
            {
                List<Locacao> locacoes = contexto.Locacoes.Where(x => x.StatusLocacao == "Pendente").ToList();

                if (locacoes != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");

                return locacoes;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES PENDENTES  ");

                return null;
            }
        }
    }
}