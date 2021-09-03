using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Shared
{
    public interface IApareciaAlteravel
    {
        void AtualizarAparencia();
    }
    public interface ICadastravel
    {
        void InserirNovoRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        UserControl ObterTabela();

        void FiltrarRegistros();

        void DevolverVeiculo();

        void PesquisarRegistro(string combobox, string pesquisa);

        List<string> PreencheComboBoxDePesquisa();
    }
}
