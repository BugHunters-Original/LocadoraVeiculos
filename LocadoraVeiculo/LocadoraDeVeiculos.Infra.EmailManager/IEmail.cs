using LocadoraDeVeiculos.Dominio.ReciboModule;

namespace LocadoraDeVeiculos.Infra.EmailManager
{
    public interface IEmail
    {
        public bool EnviarEmail(Recibo recibo);
    }
}
