using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule
{
    public interface IClienteCPFRepository
    {
        void InserirClienteCPF(ClienteCPF cliente);
        void EditarClienteCPF(int id, ClienteCPF cliente);
        bool ExcluirClienteCPF(int id);
        bool Existe(int id);
        ClienteCPF SelecionarPorId(int id);
        List<ClienteCPF> SelecionarTodos();
        List<ClienteCPF> SelecionarPesquisa(string coluna, string pesquisa);
        List<ClienteCPF> SelecionarPorIdEmpresa(int id);
    }
}
