using LocadoraVeiculo.Shared;
using System;
using System.Net.Mail;

namespace LocadoraVeiculo.ClienteModule
{
    public class ClienteBase : EntidadeBase
    {
        public override string Validar()
        {
            throw new NotImplementedException();
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
