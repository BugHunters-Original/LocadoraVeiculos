using LocadoraVeiculo.Combustivel;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao.Devolucao
{
    public partial class TelaDevolucaoForm : Form
    {
        private LocacaoVeiculo locacao;
        private static decimal? precoDias;
        private double multa = 1;
        private double total = 0;

        public TelaDevolucaoForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_Devolucao.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;

            dtRetornoEsperada.BackColor = ControladorDarkMode.corFundoTxBox;
            dtRetorno.BackColor = ControladorDarkMode.corFundoTxBox;
            txtKmInicial.BackColor = ControladorDarkMode.corFundoTxBox;
            txtKmAtual.BackColor = ControladorDarkMode.corFundoTxBox;
            cbNivelTanque.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCombustivel.BackColor = ControladorDarkMode.corFundoTxBox;
            txtServico.BackColor = ControladorDarkMode.corFundoTxBox;
            txtMulta.BackColor = ControladorDarkMode.corFundoTxBox;
            txtTotal.BackColor = ControladorDarkMode.corFundoTxBox;

            dtRetornoEsperada.ForeColor = ControladorDarkMode.corFonte;
            dtRetorno.ForeColor = ControladorDarkMode.corFonte;
            txtKmInicial.ForeColor = ControladorDarkMode.corFonte;
            txtKmAtual.ForeColor = ControladorDarkMode.corFonte;
            cbNivelTanque.ForeColor = ControladorDarkMode.corFonte;
            txtCombustivel.ForeColor = ControladorDarkMode.corFonte;
            txtServico.ForeColor = ControladorDarkMode.corFonte;
            txtMulta.ForeColor = ControladorDarkMode.corFonte;
            txtTotal.ForeColor = ControladorDarkMode.corFonte;

            btnNota.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
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
                    return (CalcularKmRodado(totalKm)) * locacao.Veiculo.grupoVeiculo.ValorKmRodadoPControlado;
                default: return 0;
            }

        }

        private decimal? CalcularKmRodado(int? totalKm)
        {
            var resto = totalKm - locacao.Veiculo.grupoVeiculo.LimitePControlado;
            return resto < 0 ? 0 : resto;
        }
        private double CalcularDesconto(double total)
        {
            double desconto = 0;
            if (dtRetorno.Value.Date <= locacao.Desconto.Validade)
            {
                switch (locacao.Desconto.Tipo)
                {
                    case "Inteiro":
                        desconto = Convert.ToDouble(locacao.Desconto.Valor);
                        break;
                    case "Porcentagem":
                        desconto = total * Convert.ToDouble(locacao.Desconto.Valor / 100);
                        break;
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
            double totalSuposto = Convert.ToDouble(locacao.PrecoServicos) + Convert.ToDouble(locacao.PrecoPlano) + Convert.ToDouble(locacao.PrecoCombustivel) * multa;
            total = totalSuposto - CalcularDesconto(totalSuposto);
            txtTotal.Text = total < 0 ? "R$0" : "R$" + total.ToString();
        }
        private string ValidarCampos()
        {
            string valido = "";

            if (Convert.ToInt32(txtKmInicial.Text) >= Convert.ToInt32(txtKmAtual.Text))
                valido += "O Campo Quilometragem Atual não pode ser menor que a esperada\r\n";

            if (dtRetorno.Value.Day < dtRetornoEsperada.Value.Day)
                valido += "A Data de Retorno não pode ser menor que a Data de Retorno Esperada\r\n";

            if (txtKmAtual.Text == "")
                valido += "O Campo Quilometragem Atual não pode ser nulo\r\n";

            if (cbNivelTanque.Text == "")
                valido += "O Campo Nível do Tanque não pode ser nulo\r\n";

            if (valido == "")
                return "Valido";

            return valido;
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
            if (ValidarCampos() != "Valido")
            {
                DialogResult = DialogResult.None;

                string primeiroErro = new StringReader(ValidarCampos()).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
                return;
            }

            locacao.PrecoTotal = total < 0 ? 0 : Convert.ToDecimal(total);
            locacao.Veiculo.km_Inicial = Convert.ToInt32(txtKmAtual.Text);
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

    }
}
