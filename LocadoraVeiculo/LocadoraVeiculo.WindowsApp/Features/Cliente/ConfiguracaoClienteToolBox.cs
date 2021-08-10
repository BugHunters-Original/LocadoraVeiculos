using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.Cliente
{
    public class ConfiguracaoClienteToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        { 
            get { return "Adicionar um Cliente"; }
        }
        public string TipoCadastro
        {
            get { return "Cadastro de Clientes"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Cliente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Cliente"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar Clientes"; }
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
