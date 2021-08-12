using LocadoraVeiculo.WindowsApp.Shared;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    class ConfiguracaoVeiculoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Adicionar um Veículo"; }
        }
        public string TipoCadastro
        {
            get { return "Cadastro de Veículos"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Veículo"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Veículo"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar Veículos"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver um Veículo"; }
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
