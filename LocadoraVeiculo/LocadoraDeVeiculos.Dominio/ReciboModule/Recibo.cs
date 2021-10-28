using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Dominio.ReciboModule
{
    public class Recibo : EntidadeBase
    {
        
        public Recibo(Locacao locacao, MemoryStream ms)
        {
            Locacao = locacao;
            Pdf = ms;
        }
        public Recibo()
        {

        }
        public Locacao Locacao { get; }
        public MemoryStream Pdf { get; }
        public StatusEnvio Status { get; set; } = StatusEnvio.Pendente;

        public override string Validar()
        {
            throw new System.NotImplementedException();
        }
        public enum StatusEnvio
        {
            Enviado, Pendente
        }

    }
}
