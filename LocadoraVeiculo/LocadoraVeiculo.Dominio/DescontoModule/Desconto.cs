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
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime Validade { get; set; }
        public string NomeParceiro { get; set; }


        public Desconto()
        {

        }




        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Codigo))
                valido += "O campo Codigo está inválido";

            //if (string.IsNullOrEmpty(Validar))
            //    valido += QuebraDeLinha(valido) + "O campo Endereço está inválido";

            //if (Telefone.Length != 14)
            //    valido += QuebraDeLinha(valido) + "O campo Telefone está inválido";

            //if (Cpf.Length != 14)
            //    valido += QuebraDeLinha(valido) + "O campo CPF está inválido";

            //if (Rg.Length != 9)
            //    valido += QuebraDeLinha(valido) + "O campo RG está inválido";

            //if (Cnh.Length != 11)
            //    valido += QuebraDeLinha(valido) + "O campo CNH está inválido";

            //if (DataValidade < DateTime.Now)
            //    valido += QuebraDeLinha(valido) + "O campo Data de Validade CNH está inválido";

            //if (valido == "")
            //    valido = "ESTA_VALIDO";

            return valido;
        }
    }
}
