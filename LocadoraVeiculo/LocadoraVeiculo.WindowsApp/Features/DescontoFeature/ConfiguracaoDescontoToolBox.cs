using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    class ConfiguracaoDescontoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Adicionar um Desconto"; }
        }
        public string TipoCadastro
        {
            get { return "Cadastro de Descontos"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Desconto"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Desconto"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar Descontos"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver Veículo"; }
        }


        public bool EnabledAdicionar
        {
            get { return true; }
        }

        public bool EnabledEditar
        {
            get { return true; }
        }

        public bool EnabledExcluir
        {
            get { return true; }
        }


        public bool EnabledFiltrar
        {
            get { return false; }
        }

        public bool EnabledDevolver
        {
            get { return false; }
        }

        public bool EnabledPesquisar => true;
    }
}
