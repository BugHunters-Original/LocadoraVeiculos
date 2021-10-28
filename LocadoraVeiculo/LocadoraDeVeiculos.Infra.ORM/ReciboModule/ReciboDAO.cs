using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.Logger;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ReciboModule
{
    public class ReciboDAO : BaseDAO<Recibo>, IReciboRepository
    {
        public ReciboDAO(LocacaoContext contexto) : base(contexto)
        {

        }

        public List<Recibo> GetAllRecibosPendentes()
        {
            return registros.Where(x => x.Status == Recibo.StatusEnvio.Pendente).ToList();
        }
        public void ConcluirRecibo(Recibo recibo)
        {
            try
            {
                recibo.Status = Recibo.StatusEnvio.Enviado;

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
