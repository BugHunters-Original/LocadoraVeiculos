using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.Logger;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule
{
    public class TaxaDaLocacaoDAO : BaseDAO<TaxaDaLocacao>, ITaxaRepository
    {
        public TaxaDaLocacaoDAO(LocacaoContext context) : base(context)
        {

        }
        public override bool Inserir(TaxaDaLocacao registro)
        {
            contexto.Entry(registro.Servico).State = EntityState.Unchanged;
            return base.Inserir(registro);
        }
        public override List<TaxaDaLocacao> GetAll()
        {
            return registros.Include(x => x.LocacaoEscolhida).Include(x => x.Servico).ToList();
        }
        public override TaxaDaLocacao GetById(int id)
        {
            return registros.Include(x => x.LocacaoEscolhida).Include(x => x.Servico).SingleOrDefault(x => x.Id == id);
        }
        public bool ExcluirTaxa(int id)
        {
            try
            {
                var taxasRelacionadasAoId = registros.Where(x => x.IdLocacao == id).ToList();

                taxasRelacionadasAoId.ForEach(x => contexto.TaxasDaLocacao.Remove(x));

                contexto.SaveChanges();

                Serilogger.Logger.Information("SUCESSO AO REMOVER TAXA ID: {Id}  ", id);

                return true;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO REMOVER TAXA ID: {Id}  ", id);

                return false;
            }
        }
        public List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id)
        {
            try
            {
                List<TaxaDaLocacao> taxa = registros.
                                           Where(x => x.IdLocacao == id).
                                           Include(x => x.Servico).
                                           ToList();

                if (taxa != null)
                    Serilogger.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");
                else
                    Serilogger.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");

                return taxa;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");

                return null;
            }
        }
    }
}
