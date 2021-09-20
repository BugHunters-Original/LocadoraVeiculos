using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public class Devolucao : EntidadeBase
    {
        public string KmAtual { get; set; }
        public string KmInicial { get; set; }
        public DateTime Retorno { get; set; }
        public DateTime RetornoEsperado { get; set; }
        public string NivelTanque { get; set; }

        public Devolucao(string kmAtual, string kmInicial, DateTime retorno, DateTime retornoEsperado, string nivelTanque)
        {
            KmAtual = kmAtual;
            KmInicial = kmInicial;
            Retorno = retorno;
            RetornoEsperado = retornoEsperado;
            NivelTanque = nivelTanque;
        }


        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(KmAtual))
                valido += QuebraDeLinha(valido) + "O Campo Quilometragem Atual não pode ser nulo";

            if (Convert.ToInt32(KmInicial) >= Convert.ToInt32(KmAtual))
                valido += QuebraDeLinha(valido) + "O Campo Quilometragem Atual não pode ser menor que a esperada";

            if (string.IsNullOrEmpty(NivelTanque))
                valido += QuebraDeLinha(valido) + "O Campo Nível do Tanque não pode ser nulo";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }

    }
}
