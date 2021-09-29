using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Shared
{    
    public interface ICadastravel 
    {
        void InserirNovoRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        UserControl ObterTabela();

        void FiltrarRegistros();

        void PesquisarRegistro(string pesquisa);

        void DevolverVeiculo();
    }
}
