using LocadoraVeiculo.WindowsApp.Shared;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo
{
    class ConfiguracaoGrupoVeiculoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Adicionar um Grupo Veiculo"; }
        }
        public string TipoCadastro
        {
            get { return "Cadastro de Grupo Veiculos"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Grupo Veiculo"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Grupo Veiculo"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar Grupo Veiculo"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver um Grupo Veiculo"; }
        }

        public bool EnabledFiltrar
        {
            get { return false; }
        }

        public bool EnabledDevolver
        {
            get { return false; }
        }
    }
}
