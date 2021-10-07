using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.LocacaoModule
{
    public class LocacaoDAO : BaseDAO<Locacao>, ILocacaoRepository
    {
        public LocacaoDAO(LocacaoContext context):base(context)
        {

        }

        public void ConcluirLocacao(int id, Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public int SelecionarLocacoesComCupons(string cupom)
        {
            throw new NotImplementedException();
        }

        public int SelecionarQuantidadeLocacoesPendentes()
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            throw new NotImplementedException();
        }
    }
}
