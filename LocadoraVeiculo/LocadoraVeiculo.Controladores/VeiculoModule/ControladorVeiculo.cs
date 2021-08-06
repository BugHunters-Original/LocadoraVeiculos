using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.VeiculoModule
{
    public class ControladorVeiculo : Controlador<Veiculo>
    {
        public override string Editar(int id, Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override string InserirNovo(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public override Veiculo SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Veiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
