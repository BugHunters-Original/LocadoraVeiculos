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
        public TaxaDaLocacao()
        {

        }
        public TaxaDaLocacao(Servico servico, Locacao locacaoEscolhida)
        {
            this.Servico = servico;
            this.LocacaoEscolhida = locacaoEscolhida;
        }

        public int? IdLocacao { get; set; }
        public int? IdTaxa { get; set; }

        public virtual Servico Servico { get; set; }
        public virtual Locacao LocacaoEscolhida { get; set; }

        public override string Validar()
        {
            string resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
