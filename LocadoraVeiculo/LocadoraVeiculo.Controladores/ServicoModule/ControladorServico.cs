using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.ServicoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.ServicoModule
{
    public class ControladorServico : Controlador<Servico>
    {
        public override string Editar(int id, Servico registro)
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

        public override string InserirNovo(Servico registro)
        {
            throw new NotImplementedException();
        }

        public override Servico SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Servico> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
