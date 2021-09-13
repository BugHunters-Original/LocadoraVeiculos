using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule
{
    public class TaxaDaLocacao : EntidadeBase
    {
        private Servico taxaLocacao;
        private Locacao locacaoEscolhida;

        public TaxaDaLocacao(Servico taxaLocacao, Locacao locacaoEscolhida)
        {
            this.TaxaLocacao = taxaLocacao;
            this.LocacaoEscolhida = locacaoEscolhida;
        }

        public Servico TaxaLocacao { get => taxaLocacao; set => taxaLocacao = value; }
        public Locacao LocacaoEscolhida { get => locacaoEscolhida; set => locacaoEscolhida = value; }

        public override string Validar()
        {
            string resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
