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
        private ControladorVeiculo controlador;
        public TelaDevolucaoForm()
        {
            controlador = new ControladorVeiculo();
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
                txtServico.Text = locacao.PrecoServicos.ToString();
                txtCaucao.Text = "1000";
            }
        }

        private decimal? CalcularTipoCombustivel(decimal? combustivelGasto)
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
        private decimal? CalcularGastosCombustível(decimal? totalTanque)
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
        private decimal? CalcularGastosLocacao(int? totalKm)
        {
            switch (locacao.TipoLocacao)
            {
                case "Plano Diário":
                    return (locacao.Veiculo.grupoVeiculo.ValorDiarioPDiario * locacao.Dias) + (totalKm * locacao.Veiculo.grupoVeiculo.ValorKmRodadoPDiario);
                case "KM Controlado":
                    return (locacao.Veiculo.grupoVeiculo.ValorDiarioPControlado * locacao.Dias) + ((totalKm - locacao.Veiculo.grupoVeiculo.LimitePControlado) * locacao.Veiculo.grupoVeiculo.ValorKmRodadoPControlado);
                case "KM Livre":
                    return locacao.Dias * locacao.Veiculo.grupoVeiculo.ValorDiarioPLivre;
                default: return 0;
            }

        }
        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal? totalTanque = Convert.ToDecimal(locacao.Veiculo.capacidade_Tanque);

            decimal? combustivelGasto = CalcularGastosCombustível(totalTanque);

            combustivelGasto = CalcularTipoCombustivel(combustivelGasto);

            locacao.PrecoCombustivel = combustivelGasto;

            txtCombustivel.Text = combustivelGasto.ToString();

        }
        private void txtKmAtual_Leave(object sender, EventArgs e)
        {
            if (txtKmAtual.Text == "")
                return;

            var totalKm = Convert.ToInt32(txtKmAtual.Text) - locacao.Veiculo.km_Inicial;

            locacao.PrecoPlano = CalcularGastosLocacao(totalKm);
        }

        private void txtCombustivel_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (locacao.PrecoServicos + locacao.PrecoPlano + locacao.PrecoCombustivel + 1000).ToString();
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            locacao.PrecoTotal = locacao.PrecoCombustivel + locacao.PrecoPlano + locacao.PrecoServicos;
            locacao.Veiculo.km_Inicial = Convert.ToInt32(txtKmAtual.Text);
            controlador.Editar(locacao.Veiculo.Id, locacao.Veiculo);
        }
    }
}
