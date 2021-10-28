using LocadoraDeVeiculos.Dominio.ReciboModule;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IEmail
    {
        public bool EnviarEmail(Recibo recibo);
    }
}
