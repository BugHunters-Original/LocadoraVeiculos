using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule
{
    public interface IClienteCNPJRepository
    {
        public void InserirClienteCNPJ(ClienteCNPJ registro);

        public void EditarClienteCNPJ(int id, ClienteCNPJ registro);

        public bool ExcluirClienteCNPJ(int id);

        public bool Existe(int id);

        public ClienteCNPJ SelecionarPorId(int id);

        public List<ClienteCNPJ> SelecionarTodos();

        public List<ClienteCNPJ> SelecionarPesquisa(string combobox, string pesquisa);

    }
}
