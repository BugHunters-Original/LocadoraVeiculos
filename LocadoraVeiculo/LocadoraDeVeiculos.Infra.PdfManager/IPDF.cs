using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ReciboModule;
using Serilog.Core;

namespace LocadoraDeVeiculos.Infra.PdfManager
{
    public interface IPDF
    {
        public Recibo MontarPDF(Locacao locacao);
    }
}
