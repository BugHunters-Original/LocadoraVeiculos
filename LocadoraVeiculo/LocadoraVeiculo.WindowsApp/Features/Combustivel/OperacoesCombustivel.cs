using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraVeiculo.Controladores.CombustivelModule;

namespace LocadoraVeiculo.WindowsApp.Features.Combustivel
{
    public class OperacoesCombustivel
    {
        private readonly ControladorCombustivel controlador = null;

        public OperacoesCombustivel(ControladorCombustivel ctrlCombustivel)
        {
            controlador = ctrlCombustivel;
        }

        public void Editar()
        {
            CombustivelModule.Combustivel combustivelSelecionado = controlador.SelecionarPorId(1);

            TelaCombustivelForm tela = new TelaCombustivelForm();

            tela.Combustivel = combustivelSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(1, tela.Combustivel);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Preço Combustiveis: editada com sucesso");
            }
        }
    }
}
