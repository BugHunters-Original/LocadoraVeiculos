using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.VeiculoModule
{
    public class VeiculoDAO : BaseDAO<Veiculo>, IVeiculoRepository
    {
        public VeiculoDAO(LocacaoContext contexto) : base(contexto)
        {

        }
        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public void DevolverVeiculo(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public void EditarDisponibilidade(Veiculo atual, Veiculo antigo)
        {
            throw new NotImplementedException();
        }

        public void LocarVeiculo(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public int ReturnQuantidadeAlugados()
        {
            throw new NotImplementedException();
        }

        public int ReturnQuantidadeDisponiveis()
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodosAlugados()
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            throw new NotImplementedException();
        }
    }
}
