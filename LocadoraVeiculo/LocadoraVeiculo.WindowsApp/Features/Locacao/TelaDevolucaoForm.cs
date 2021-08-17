using LocadoraVeiculo.Combustivel;
using LocadoraVeiculo.LocacaoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public partial class TelaDevolucaoForm : Form
    {
        private LocacaoVeiculo locacao;
        public TelaDevolucaoForm()
        {
            InitializeComponent();
        }

        public LocacaoVeiculo Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;
                txtKmInicial.Text = locacao.Veiculo.km_Inicial.ToString();
                dtRetornoEsperada.Value = locacao.DataRetorno;

            }
        }
        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            double combustivelGasto = 0;
            var totalTanque = Convert.ToDouble(locacao.Veiculo.capacidade_Tanque);
            switch (cbNivelTanque.SelectedItem.ToString())
            {
                case "1/8": combustivelGasto = totalTanque - (totalTanque * 1 / 8); break;
                case "1/4": combustivelGasto = totalTanque - (totalTanque * 1 / 4); break;
                case "3/8": combustivelGasto = totalTanque - (totalTanque * 3 / 8); break;
                case "1/2": combustivelGasto = totalTanque - (totalTanque * 1 / 2); break;
                case "5/8": combustivelGasto = totalTanque - (totalTanque * 5 / 8); break;
                case "3/4": combustivelGasto = totalTanque - (totalTanque * 3 / 4); break;
                case "7/8": combustivelGasto = totalTanque - (totalTanque * 7 / 8); break;
                default: break;
            }

            switch (locacao.Veiculo.tipo_Combustivel)
            {
                case "Gasolina": combustivelGasto *= Config.PrecoGasolina; break;
                case "Álcool": combustivelGasto *= Config.PrecoAlcool; break;
                case "Diesel": combustivelGasto *= Config.PrecoDiesel; break;
                default: break;
            }

            txtCombustivel.Text = "R$" + combustivelGasto.ToString();

        }
    }
}
