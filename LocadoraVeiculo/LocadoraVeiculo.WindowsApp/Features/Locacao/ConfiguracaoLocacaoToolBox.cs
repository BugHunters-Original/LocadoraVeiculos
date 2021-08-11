﻿using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public class ConfiguracaoLocacaoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Efetuar uma Locação"; }
        }

        public string TipoCadastro
        {
            get { return "Cadastro de Locações"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar uma Locação"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir uma Locação"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Filtrar uma Locação"; }
        }

        public string ToolTipDevolver
        {
            get { return "Devolver um veículo"; }
        }

        public bool EnabledFiltrar
        {
            get { return true; }
        }
        public bool EnabledDevolver
        {
            get { return true; }
        }
    }
}