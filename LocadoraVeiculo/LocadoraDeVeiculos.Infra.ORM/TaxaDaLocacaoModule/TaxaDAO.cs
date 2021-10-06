using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule
{
    public class TaxaDAO : BaseDAO<TaxaDaLocacao>, ITaxaRepository
    {
        public TaxaDAO(LocacaoContext context) : base(context)
        {

        }

        public List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id)
        {
            //try
            //{
            //    List<TaxaDaLocacao> taxa = Db.GetAll(sqlSelecionarTaxaLocacaoPorId, ConverterEmTaxaLocacao, AdicionarParametro("ID_LOCACAOTAXA", id));

            //    if (taxa != null)
            //        Log.Logger.Debug("SUCESSO AO SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");
            //    else
            //        Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");

            //    return taxa;
            //}
            //catch (Exception ex)
            //{
            //    Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO  ");

                return null;
            //}
        }
    }
}
