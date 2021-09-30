using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.ParceiroFeature
{
    public class ConfiguracaoParceiroToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar um Parceiro";

        public string TipoCadastro => "Cadsatro de Parceiros";

        public string ToolTipEditar => "Editar um Parceiro";

        public string ToolTipExcluir => "Excluir um Parceiro";

        public string ToolTipFiltrar => "Filtrar Parceiros";

        public string ToolTipDevolver => "Devolver Veículo";

        public bool EnabledFiltrar => false;

        public bool EnabledDevolver => false;

        public bool EnabledAdicionar => true;

        public bool EnabledEditar => true;

        public bool EnabledExcluir => true;

        public bool EnabledPesquisar => true;
    }
}
