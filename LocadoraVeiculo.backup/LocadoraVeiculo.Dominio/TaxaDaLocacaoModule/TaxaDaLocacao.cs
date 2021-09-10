using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TaxaDaLocacaoModule
{
    public class TaxaDaLocacao : EntidadeBase
    {
        private Servico taxaLocacao;
        private LocacaoVeiculo locacaoEscolhida;

        public TaxaDaLocacao(Servico taxaLocacao, LocacaoVeiculo locacaoEscolhida)
        {
            this.TaxaLocacao = taxaLocacao;
            this.LocacaoEscolhida = locacaoEscolhida;
        }

        public Servico TaxaLocacao { get => taxaLocacao; set => taxaLocacao = value; }
        public LocacaoVeiculo LocacaoEscolhida { get => locacaoEscolhida; set => locacaoEscolhida = value; }

        public override string Validar()
        {
            string resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
