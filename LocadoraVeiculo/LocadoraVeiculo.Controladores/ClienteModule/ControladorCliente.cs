using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.ClienteModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.ClienteModule
{
    public class ControladorCliente : Controlador<Cliente>
    {
        public override string Editar(int id, Cliente registro)
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

        public override string InserirNovo(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public override Cliente SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
