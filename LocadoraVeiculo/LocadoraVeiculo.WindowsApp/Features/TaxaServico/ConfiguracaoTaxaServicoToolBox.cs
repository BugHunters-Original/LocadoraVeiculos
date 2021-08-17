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
        public string ToolTipAdicionar => "Adicionar uma Taxa e Serviço";

        public string TipoCadastro => "Cadastro de Taxas e Serviços";

        public string ToolTipEditar => "Editar uma Taxa e Serviço";

        public string ToolTipExcluir => "Excluir uma Taxa e Serviço";

        public string ToolTipFiltrar => "Filtrar Taxas e Serviços";

        public string ToolTipDevolver => "Devolver Veículo";

        public bool EnabledFiltrar => false;

        public bool EnabledDevolver => false;
    }
}
