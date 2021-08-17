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
        private double total = 1000;
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

        private double CalcularTipoCombustivel(double combustivelGasto)
        {
            switch (locacao.Veiculo.tipo_Combustivel)
            {
                case "Gasolina": combustivelGasto *= Config.PrecoGasolina; break;
                case "Álcool": combustivelGasto *= Config.PrecoAlcool; break;
                case "Diesel": combustivelGasto *= Config.PrecoDiesel; break;
                default: break;
            }

            return combustivelGasto;
        }
        private double CalcularGastosCombustível(double totalTanque)
        {
            switch (cbNivelTanque.SelectedItem.ToString())
            {
                case "1/8": return totalTanque - (totalTanque * 1 / 8);
                case "1/4": return totalTanque - (totalTanque * 1 / 4);
                case "3/8": return totalTanque - (totalTanque * 3 / 8);
                case "1/2": return totalTanque - (totalTanque * 1 / 2);
                case "5/8": return totalTanque - (totalTanque * 5 / 8);
                case "3/4": return totalTanque - (totalTanque * 3 / 4);
                case "7/8": return totalTanque - (totalTanque * 7 / 8);
                default: return 0;
            }

        }
        private double CalcularGastosLocacao(int? totalKm)
        {
            switch (locacao.TipoLocacao)
            {
                case "Plano Diário":
                    return (double)((locacao.Veiculo.grupoVeiculo.valor_Diario_PDiario * locacao.Dias) + (totalKm * locacao.Veiculo.grupoVeiculo.preco_KMDiario));
                case "KM Controlado":
                    return (double)((locacao.Veiculo.grupoVeiculo.valor_Diario_PControlado * locacao.Dias) + (totalKm * locacao.Veiculo.grupoVeiculo.kmDia__KMControlado));
                case "KM Livre":
                    return (double)(locacao.Dias * locacao.Veiculo.grupoVeiculo.preco_KMLivre);
                default: return 0;
            }

        }
        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            var totalTanque = Convert.ToDouble(locacao.Veiculo.capacidade_Tanque);

            double combustivelGasto = CalcularGastosCombustível(totalTanque);

            combustivelGasto = CalcularTipoCombustivel(combustivelGasto);

            txtCombustivel.Text = combustivelGasto.ToString();

        }
        private void txtKmAtual_Leave(object sender, EventArgs e)
        {
            var totalKm = Convert.ToInt32(txtKmAtual.Text) - locacao.Veiculo.km_Inicial;

            total += CalcularGastosLocacao(totalKm);

            txtTotal.Text = total.ToString();
        }

        private void txtCombustivel_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (total + Convert.ToDouble(txtCombustivel.Text)).ToString();
        }
    }
}
