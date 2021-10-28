using LocadoraDeVeiculos.Dominio.ReciboModule;
using Serilog.Core;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IPDF
    {
        public ReciboModule.Recibo MontarPDF(Locacao locacao);
    }
}
