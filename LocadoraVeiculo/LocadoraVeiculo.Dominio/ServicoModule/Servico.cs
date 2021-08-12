using LocadoraVeiculo.Shared;
using System;

namespace LocadoraVeiculo.ServicoModule
{
    public class Servico : EntidadeBase
    {
        public Servico(string nome, decimal preco, int tipoCalculo)
        {
            Nome = nome;
            Preco = preco;
            TipoCalculo = tipoCalculo;
        }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int TipoCalculo { get; set; }
        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (Preco <= 0)
                valido += QuebraDeLinha(valido) + "O campo Preço está inválido";

            if (TipoCalculo != 1 || TipoCalculo != 0)
                valido += QuebraDeLinha(valido) + "O campo Tipo está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
