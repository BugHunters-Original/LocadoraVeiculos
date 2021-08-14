using LocadoraVeiculo.WindowsApp.Shared;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo
{
    class ConfiguracaoGrupoVeiculoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Adicionar um Grupo Veículos"; }
        }
        public string TipoCadastro
        {
            get { return "Cadastro de Grupo de Veículos"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Grupo de Veículos"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Grupo de Veículos"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar Grupo de Veículos"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver um Grupo de Veículos"; }
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
