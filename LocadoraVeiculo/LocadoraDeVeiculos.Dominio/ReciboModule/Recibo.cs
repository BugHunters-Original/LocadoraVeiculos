using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Dominio.ReciboModule
{
    public class Recibo : EntidadeBase
    {
        
        public Recibo(string email, MemoryStream ms)
        {
            Email = email;
            Pdf = ms;
        }
        public Recibo()
        {

        }
        public string Email { get; }
        public MemoryStream Pdf { get; }
        public StatusEnvio Status { get; set; } = StatusEnvio.Pendente;

        public override string Validar()
        {
            throw new System.NotImplementedException();
        }
        public enum StatusEnvio
        {
            Enviado, Pendente
        }

    }
}
