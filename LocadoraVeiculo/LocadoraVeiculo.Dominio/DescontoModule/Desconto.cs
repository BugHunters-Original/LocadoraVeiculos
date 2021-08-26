using LocadoraVeiculo.ParceiroModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.DescontoModule
{
    public class Desconto : EntidadeBase
    {
        public Desconto(string codigo, decimal valor, string tipo, DateTime validade, ParceiroTaxa parceiro, string meio)
        {
            Codigo = codigo;
            Valor = valor;
            Tipo = tipo;
            Validade = validade;
            Parceiro = parceiro;
            Meio = meio;
        }

        public string Codigo { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime Validade { get; set; }
        public ParceiroTaxa Parceiro { get; set; }
        public string Meio { get; set; }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Codigo))
                valido += "O campo Codigo está inválido";

            if (Valor <= 0)
                valido += QuebraDeLinha(valido) + "O campo Valor não pode ser zero ou negativo";

            if (Valor > 100 && Tipo == "Porcentagem")
                valido += QuebraDeLinha(valido) + "O campo Valor não pode ter uma porcentagem maior que 100%";

            if (string.IsNullOrEmpty(Tipo))
                valido += QuebraDeLinha(valido) + "O campo Tipo está inválido";

            if (Validade < DateTime.Now)
                valido += QuebraDeLinha(valido) + "O campo Data de Validade está inválido";

            if (Parceiro == null)
                valido += QuebraDeLinha(valido) + "O campo Parceiro não pode ser nulo";

            if (string.IsNullOrEmpty(Meio))
                valido += "O campo Meio está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
    }
}
