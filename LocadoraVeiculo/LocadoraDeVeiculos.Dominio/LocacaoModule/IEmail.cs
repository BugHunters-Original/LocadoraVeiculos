using Serilog.Core;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IEmail
    {
        public bool EnviarEmail(Locacao locacao, Logger logger);
    }
}
