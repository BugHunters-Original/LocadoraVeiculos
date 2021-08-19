using LocadoraVeiculo.Combustivel;
using LocadoraVeiculo.Controladores.VeiculoModule;
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
        private static decimal? precoDias;
        private double multa = 1;
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
                txtServico.Text = "R$" + locacao.PrecoServicos.ToString();
                precoDias = locacao.PrecoPlano;
                txtMulta.Text = "Sem Multa";
            }
        }

        private decimal? CalcularPrecoTipoCombustivel(decimal? combustivelGasto)
        {
            switch (locacao.Veiculo.tipo_Combustivel)
            {
                case "Gasolina": combustivelGasto *= Convert.ToDecimal(Config.PrecoGasolina); break;
                case "Álcool": combustivelGasto *= Convert.ToDecimal(Config.PrecoAlcool); break;
                case "Diesel": combustivelGasto *= Convert.ToDecimal(Config.PrecoDiesel); break;
                default: break;
            }

            return combustivelGasto;
        }
        private decimal? CalcularPrecoTanqueCombustivel(decimal? totalTanque)
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
        private decimal? CalcularPrecoKmRodado(int? totalKm)
        {
            switch (locacao.TipoLocacao)
            {
                case "Plano Diário":
                    return totalKm * locacao.Veiculo.grupoVeiculo.ValorKmRodadoPDiario;
                case "KM Controlado":
                    return (totalKm - locacao.Veiculo.grupoVeiculo.LimitePControlado) * locacao.Veiculo.grupoVeiculo.ValorKmRodadoPControlado;
                default: return 0;
            }

        }
        private void AtualizarTotal()
        {
            double total = Convert.ToDouble(locacao.PrecoServicos) + Convert.ToDouble(locacao.PrecoPlano) + Convert.ToDouble(locacao.PrecoCombustivel);
            txtTotal.Text = "R$" + (total * multa).ToString();
        }
        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal? totalTanque = Convert.ToDecimal(locacao.Veiculo.capacidade_Tanque);

            decimal? combustivelGasto = CalcularPrecoTanqueCombustivel(totalTanque);

            combustivelGasto = CalcularPrecoTipoCombustivel(combustivelGasto);

            locacao.PrecoCombustivel = combustivelGasto;

            txtCombustivel.Text = "R$" + combustivelGasto.ToString();

            AtualizarTotal();
        }
        private void txtKmAtual_Leave(object sender, EventArgs e)
        {
            if (txtKmAtual.Text == "")
                return;

            var totalKm = Convert.ToInt32(txtKmAtual.Text) - locacao.Veiculo.km_Inicial;

            locacao.PrecoPlano = precoDias;
            locacao.PrecoPlano += CalcularPrecoKmRodado(totalKm);

            AtualizarTotal();
        }


        private void btnNota_Click(object sender, EventArgs e)
        {
            locacao.PrecoTotal = Convert.ToDecimal(multa) * (locacao.PrecoCombustivel + locacao.PrecoPlano + locacao.PrecoServicos);
            locacao.Veiculo.km_Inicial = Convert.ToInt32(txtKmAtual.Text);
        }

        private void dtRetorno_ValueChanged(object sender, EventArgs e)
        {
            if (dtRetorno.Value > dtRetornoEsperada.Value)
            {
                multa = 1.1;
                txtMulta.Text = "10% no total";
            }
            else
            {
                multa = 1;
                txtMulta.Text = "Sem Multa";
            }
            AtualizarTotal();
        }
    }
}
