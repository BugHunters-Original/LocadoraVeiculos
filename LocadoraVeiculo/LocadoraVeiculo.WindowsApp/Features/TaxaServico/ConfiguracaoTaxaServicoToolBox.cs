using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServico
{
    class ConfiguracaoTaxaServicoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar Taxa ou Serviço";

        public string TipoCadastro => "Cadastro de Taxa ou Serviço";

        public string ToolTipEditar => "Editar uma Taxa ou Serviço";

        public string ToolTipExcluir => "Excluir uma Taxa ou Serviço";

        public string ToolTipFiltrar => "Filtrar Taxa ou Serviço";

        public string ToolTipDevolver => "";

        public bool EnabledFiltrar => false;

        public bool EnabledDevolver => false;
    }
}
