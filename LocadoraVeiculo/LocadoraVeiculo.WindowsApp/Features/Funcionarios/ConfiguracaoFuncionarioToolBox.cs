using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.Funcionarios
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
    }
}
