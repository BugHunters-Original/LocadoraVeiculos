using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.Logger;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static LocadoraDeVeiculos.Dominio.ReciboModule.Recibo;

namespace LocadoraDeVeiculos.Infra.ORM.ReciboModule
{
    public class ReciboDAO : BaseDAO<Recibo>, IReciboRepository
    {
        public ReciboDAO(LocacaoContext contexto) : base(contexto)
        {

        }
        public void ExcluirReciboLocacao(Locacao locacao)
        {
            var recibo = registros.Where(x => x.Locacao == locacao).First();
            Excluir(recibo);
        }
        public List<Recibo> GetAllRecibosPendentes()
        {
            return registros.Include(x=>x.Locacao).ThenInclude(x=>x.Cliente).Where(x => x.Status == StatusEnvio.Pendente).ToList();
        }
        public void ConcluirRecibo(Recibo recibo)
        {
            try
            {
                recibo.Status = StatusEnvio.Enviado;

                Editar(recibo);

                Serilogger.Logger.Information("SUCESSO AO EDITAR STATUS DO RECIBO ID: {Id}  ", recibo.Id);
            }

            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO EDITAR STATUS DO RECIBO ID: {Id}  ", recibo.Id);
            }

        }
    }
}
