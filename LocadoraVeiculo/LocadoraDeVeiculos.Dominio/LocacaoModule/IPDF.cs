using Serilog.Core;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IPDF
    {
        public bool MontarPDF(Locacao locacao);
    }
}
