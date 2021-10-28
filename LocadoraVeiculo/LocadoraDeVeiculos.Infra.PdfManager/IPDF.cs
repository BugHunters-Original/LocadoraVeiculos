using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ReciboModule;

namespace LocadoraDeVeiculos.Infra.PdfManager
{
    public interface IPDF
    {
        public Recibo MontarPDF(Locacao locacao);
    }
}
