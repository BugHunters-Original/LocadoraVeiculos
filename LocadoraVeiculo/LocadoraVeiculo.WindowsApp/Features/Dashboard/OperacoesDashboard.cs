using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Dashboard
{
    public class OperacoesDashboard
    {
        private readonly ControladorVeiculo controladorVeiculo = null;
        private readonly ControladorLocacao controladorLocacao = null;
        private readonly DashboardControl dashboardControl = null;

        public OperacoesDashboard(ControladorVeiculo controladorVeiculo, ControladorLocacao controladorLocacao)
        {
            this.controladorLocacao = controladorLocacao;
            this.controladorVeiculo = controladorVeiculo;
            dashboardControl = new DashboardControl();
        }

    }
}
