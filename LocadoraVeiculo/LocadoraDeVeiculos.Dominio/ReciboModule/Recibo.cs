using LocadoraDeVeiculos.Dominio.Shared;
using System.IO;

namespace LocadoraDeVeiculos.Dominio.ReciboModule
{
    public class Recibo : EntidadeBase
    {
        
        public Recibo(string email, MemoryStream ms)
        {
            Email = email;
            Ms = ms;
        }
        public Recibo()
        {

        }
        public string Email { get; }
        public MemoryStream Ms { get; }

        public override string Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
