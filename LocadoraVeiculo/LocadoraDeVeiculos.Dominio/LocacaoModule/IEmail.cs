using log4net;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IEmail
    {
        public bool EnviarEmail(Locacao locacao, ILog logger);
    }
}
