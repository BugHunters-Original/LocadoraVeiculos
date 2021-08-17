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

            }
        }

        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            var teste = Convert.ToDouble(locacao.Veiculo.capacidade_Tanque);
            switch (cbNivelTanque.SelectedItem.ToString())
            {
                case "1/2": teste /= 2; break;
                default:
                    break;
            }

            switch (locacao.Veiculo.tipo_Combustivel)
            {
                case "Gasolina": teste *= Config.PrecoGasolina; break;
                case "Álcool": teste *= Config.PrecoAlcool; break;
                case "Diesel": teste *= Config.PrecoDiesel; break;
                default: break;
            }

            txtCombustivel.Text = "R$" + teste.ToString();

        }
    }
}
