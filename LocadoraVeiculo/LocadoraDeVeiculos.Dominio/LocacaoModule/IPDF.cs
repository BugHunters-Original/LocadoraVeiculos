using Serilog.Core;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IPDF
    {
        public void MontarPDF(Locacao locacao, Logger logger);
    }
}
