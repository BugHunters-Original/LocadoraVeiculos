using LocadoraVeiculo.WindowsApp.Shared;

namespace LocadoraVeiculo.WindowsApp.Features.FuncionarioFeature
{
    public class ConfiguracaoFuncionarioToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Cadastrar um Funcionário"; }
        }

        public string TipoCadastro
        {
            get { return "Cadastro de Funcionários"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Funcionário"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Funcionário"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar Funcionários"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver um veículo"; }
        }

        public bool EnabledFiltrar
        {
            get { return false; }
        }
        public bool EnabledDevolver
        {
            get { return false; }
        }

        public bool EnabledAdicionar => true;

        public bool EnabledEditar => true;

        public bool EnabledExcluir => true;
    }
}
