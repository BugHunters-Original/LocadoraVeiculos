using LocadoraVeiculo.Shared;
using System;

namespace LocadoraVeiculo.ClienteModule
{
    public class Cliente : EntidadeBase
    {
        public override string Validar()
        {
            throw new NotImplementedException();
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
