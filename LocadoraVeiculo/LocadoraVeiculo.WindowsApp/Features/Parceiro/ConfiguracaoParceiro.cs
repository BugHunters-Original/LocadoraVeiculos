using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.Parceiro
{
    public class ConfiguracaoParceiro : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar um Parceiro";

        public string TipoCadastro => "Cadsatro de Parceiros";

        public string ToolTipEditar => "Editar um Parceiro";

        public string ToolTipExcluir => "Excluir um Parceiro";

        public string ToolTipFiltrar => "Filtrar Parceiros";

        public string ToolTipDevolver => throw new NotImplementedException();

        public bool EnabledFiltrar => false;

        public bool EnabledDevolver => false;
    }
}
