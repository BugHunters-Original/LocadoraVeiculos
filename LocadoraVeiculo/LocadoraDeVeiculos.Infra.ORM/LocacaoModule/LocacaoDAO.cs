using LocadoraDeVeiculos.Dominio.LocacaoModule;
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
        public override bool Inserir(Locacao registro)
        {
            contexto.Entry(registro.Cliente).State = EntityState.Unchanged;

            contexto.Entry(registro.Condutor).State = EntityState.Unchanged;

            contexto.Entry(registro.Veiculo).State = EntityState.Unchanged;

            if (registro.Desconto != null)
                contexto.Entry(registro.Desconto).State = EntityState.Unchanged;

            if (registro.Servicos != null)
                foreach (var item in registro.Servicos)
                    contexto.Entry(item).State = EntityState.Unchanged;

            if (registro.TaxasDaLocacao != null)
                contexto.Entry(registro.TaxasDaLocacao).State = EntityState.Unchanged;

            return base.Inserir(registro);
        }
        public override List<Locacao> GetAll()
        {
            return registros.AsNoTracking().
                   Include(x => x.Cliente).
                   Include(x => x.Veiculo).
                   ThenInclude(x => x.GrupoVeiculo).
                   Include(x => x.Desconto).
                   Include(x => x.Condutor).
                   ToList();
        }
        public override Locacao GetById(int id)
        {
            return registros.AsNoTracking().
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
                int qtdLocacoesComCupom = registros.AsNoTracking().
                                          Where(x => x.Desconto.Codigo == cupom).
                                          Count();

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
                int qtdLocacoesPendentes = registros.AsNoTracking().
                                           Where(x => x.StatusLocacao == "Concluída").
                                           Count();

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
                List<Locacao> locacoes = registros.AsNoTracking().
                                           Include(x => x.Cliente).
                                           Include(x => x.Veiculo).
                                           ThenInclude(x => x.GrupoVeiculo).
                                           Include(x => x.Desconto).
                                           Include(x => x.Condutor).
                                           Where(x => x.StatusLocacao == "Concluída").
                                           ToList();

                if (locacoes.Count != 0)
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
                List<Locacao> locacoes = registros.AsNoTracking().
                                           Include(x => x.Cliente).
                                           Include(x => x.Veiculo).
                                           ThenInclude(x => x.GrupoVeiculo).
                                           Include(x => x.Desconto).
                                           Include(x => x.Condutor).
                                           Where(x => x.StatusLocacao == "Em Aberto").
                                           ToList();

                if (locacoes.Count != 0)
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

        public void AbrirLocacao(Locacao locacao)
        {
            try
            {
                locacao.StatusLocacao = "Em Aberto";

                contexto.Locacoes.Update(locacao);

                contexto.SaveChanges();

                contexto.ChangeTracker.Clear();

                Log.Logger.Information("SUCESSO AO INICIAR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO INICIAR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
        }

        public void ConcluirLocacao(Locacao locacao)
        {
            try
            {
                locacao.StatusLocacao = "Concluída";

                contexto.Locacoes.Update(locacao);

                contexto.SaveChanges();

                contexto.ChangeTracker.Clear();

                Log.Logger.Information("SUCESSO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id);
            }
        }
    }
}
