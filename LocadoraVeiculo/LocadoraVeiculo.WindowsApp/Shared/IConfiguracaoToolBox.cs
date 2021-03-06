namespace LocadoraVeiculo.WindowsApp.Shared
{
    public interface IConfiguracaoToolBox
    {
        string ToolTipAdicionar { get; }
        string TipoCadastro { get; }
        string ToolTipEditar { get; }
        string ToolTipExcluir { get; }
        string ToolTipFiltrar { get; }
        string ToolTipDevolver { get; }

        bool EnabledAdicionar { get; }
        bool EnabledEditar { get; }
        bool EnabledExcluir { get; }
        bool EnabledFiltrar { get; }
        bool EnabledDevolver { get; }
        bool EnabledPesquisar { get; }
    }
}
