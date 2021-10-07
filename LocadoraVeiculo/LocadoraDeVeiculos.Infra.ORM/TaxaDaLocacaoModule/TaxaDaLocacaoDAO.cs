using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule
{
    public class TaxaDaLocacaoDAO : BaseDAO<TaxaDaLocacao>, ITaxaRepository
    {
        public TaxaDaLocacaoDAO(LocacaoContext context) : base(context)
        {

        }
        public bool ExcluirTaxa(int id)
        {
            try
            {
                var taxasRelacionadasAoId = contexto.TaxasDaLocacao.Where(x => x.IdLocacao == id).ToList();
                taxasRelacionadasAoId.ForEach(x => contexto.TaxasDaLocacao.Remove(x));
                contexto.SaveChanges();
                Log.Logger.Information("SUCESSO AO REMOVER TAXA ID: {Id}  ", id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER TAXA ID: {Id}  ", id);

                return false;
            }
        }
        public List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id)
        {
            try
            {
                List<TaxaDaLocacao> taxa = contexto.TaxasDaLocacao.Where(x => x.IdLocacao == id).ToList();

                if (taxa != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");

                return taxa;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");
                
                return null;
            }
        }
    }
}
