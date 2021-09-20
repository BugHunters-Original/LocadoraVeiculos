using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Combustivel;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.DevolucaoLocacao
{
    public partial class TelaDevolucaoForm : Form
    {
        private Locacao locacao;
        private static decimal? precoDias;
        private double multa = 1;
        private double total = 0;

        public TelaDevolucaoForm()
        {
            InitializeComponent();
            SetColor();
        }


        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;
                txtKmInicial.Text = locacao.Veiculo.KmInicial.ToString();
                dtRetornoEsperada.Value = locacao.DataRetorno;
                txtServico.Text = "R$" + locacao.PrecoServicos.ToString();
                precoDias = locacao.PrecoPlano;
                txtMulta.Text = "Sem Multa";
            }
        }

        private void SetColor()
        {
            header_Devolucao.BackColor = DarkMode.corHeader;
            BackColor = DarkMode.corPanel;
            ForeColor = DarkMode.corFonte;

            dtRetornoEsperada.BackColor = DarkMode.corFundoTxBox;
            dtRetorno.BackColor = DarkMode.corFundoTxBox;
            txtKmInicial.BackColor = DarkMode.corFundoTxBox;
            txtKmAtual.BackColor = DarkMode.corFundoTxBox;
            cbNivelTanque.BackColor = DarkMode.corFundoTxBox;
            txtCombustivel.BackColor = DarkMode.corFundoTxBox;
            txtServico.BackColor = DarkMode.corFundoTxBox;
            txtMulta.BackColor = DarkMode.corFundoTxBox;
            txtTotal.BackColor = DarkMode.corFundoTxBox;

            dtRetornoEsperada.ForeColor = DarkMode.corFonte;
            dtRetorno.ForeColor = DarkMode.corFonte;
            txtKmInicial.ForeColor = DarkMode.corFonte;
            txtKmAtual.ForeColor = DarkMode.corFonte;
            cbNivelTanque.ForeColor = DarkMode.corFonte;
            txtCombustivel.ForeColor = DarkMode.corFonte;
            txtServico.ForeColor = DarkMode.corFonte;
            txtMulta.ForeColor = DarkMode.corFonte;
            txtTotal.ForeColor = DarkMode.corFonte;

            btnNota.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
        }

        private decimal? CalcularPrecoTipoCombustivel()
        {
            switch (locacao.Veiculo.TipoCombustivel)
            {
                case "Gasolina": return Convert.ToDecimal(PrecoCombustivel.PrecoGasolina);
                case "Álcool": return Convert.ToDecimal(PrecoCombustivel.PrecoAlcool);
                case "Diesel": return Convert.ToDecimal(PrecoCombustivel.PrecoDiesel);
                default: return 0;
            }
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
                case "Plano Diário": return totalKm * locacao.Veiculo.GrupoVeiculo.ValorKmRodadoPDiario;
                case "KM Controlado": return (CalcularKmRodado(totalKm)) * locacao.Veiculo.GrupoVeiculo.ValorKmRodadoPControlado;
                default: return 0;
            }
        }

        private decimal? CalcularKmRodado(int? totalKm)
        {
            var resto = totalKm - locacao.Veiculo.GrupoVeiculo.LimitePControlado;
            return resto < 0 ? 0 : resto;
        }

        private double CalcularDesconto(double totalSemDesconto)
        {
            double desconto = 0;
            if (locacao.Desconto != null && locacao.Desconto.ValorMinimo <= Convert.ToDecimal(total)
                 && dtRetorno.Value.Date <= locacao.Desconto.Validade)
            {
                switch (locacao.Desconto.Tipo)
                {
                    case "Inteiro": desconto = Convert.ToDouble(locacao.Desconto.Valor); break;
                    case "Porcentagem": desconto = totalSemDesconto * Convert.ToDouble(locacao.Desconto.Valor / 100); break;
                    default: break;
                }
                txtCupom.Text = $"R${desconto}";
            }
            else
                txtCupom.Text = "Sem Desconto";

            return desconto;
        }

        private void AtualizarTotal()
        {
            double totalSuposto = Convert.ToDouble(locacao.PrecoServicos) + Convert.ToDouble(locacao.PrecoPlano) +
                                                Convert.ToDouble(locacao.PrecoCombustivel) * multa;
            total = totalSuposto;
            total -= CalcularDesconto(totalSuposto);
            txtTotal.Text = total < 0 ? "R$0" : "R$" + total.ToString();
        }

        private void FinalizarDevolucao()
        {
            var kmatual = txtKmAtual.Text;
            var kmInicial = txtKmInicial.Text;
            var dataRetorno = dtRetorno.Value;
            var dataEsperada = dtRetornoEsperada.Value;
            var nivelTanque = cbNivelTanque.Text;

            Devolucao devolucao = new(kmatual, kmInicial, dataRetorno, dataEsperada, nivelTanque);

            string resultadoValidacao = devolucao.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                DialogResult = DialogResult.None;

                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
                return;
            }

            locacao.PrecoTotal = total < 0 ? 0 : Convert.ToDecimal(total);

            locacao.Veiculo.KmInicial = Convert.ToInt32(txtKmAtual.Text);
        }
        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal? totalTanque = Convert.ToDecimal(locacao.Veiculo.CapacidadeTanque);

            decimal? combustivelGasto = CalcularPrecoTanqueCombustivel(totalTanque);

            combustivelGasto *= CalcularPrecoTipoCombustivel();

            locacao.PrecoCombustivel = combustivelGasto;

            txtCombustivel.Text = "R$" + combustivelGasto.ToString();

            AtualizarTotal();
        }

        private void txtKmAtual_Leave(object sender, EventArgs e)
        {
            if (txtKmAtual.Text == "")
                return;

            var totalKm = Convert.ToInt32(txtKmAtual.Text) - locacao.Veiculo.KmInicial;

            locacao.PrecoPlano = precoDias;

            locacao.PrecoPlano += CalcularPrecoKmRodado(totalKm);

            AtualizarTotal();
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            FinalizarDevolucao();
        }

        private void dtRetorno_ValueChanged(object sender, EventArgs e)
        {
            if (dtRetorno.Value.Date > dtRetornoEsperada.Value.Date)
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

        private void txtKmAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
