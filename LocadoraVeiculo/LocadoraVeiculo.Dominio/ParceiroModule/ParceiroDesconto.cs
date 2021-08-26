using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ParceiroModule
{
    public class ParceiroDesconto : EntidadeBase
    {
        public ParceiroDesconto(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += QuebraDeLinha(valido) + "O campo Nome está inválido";
            if (valido == "")
                return "ESTA_VALIDO";

            return valido;
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
