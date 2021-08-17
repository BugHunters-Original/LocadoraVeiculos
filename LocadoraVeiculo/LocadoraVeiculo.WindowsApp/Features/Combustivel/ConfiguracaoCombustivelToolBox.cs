﻿using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.Combustivel
{
    class ConfiguracaoCombustivelToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Adicionar"; }
        }
        public string TipoCadastro
        {
            get { return "Configuração de Combustíveis"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver"; }
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
