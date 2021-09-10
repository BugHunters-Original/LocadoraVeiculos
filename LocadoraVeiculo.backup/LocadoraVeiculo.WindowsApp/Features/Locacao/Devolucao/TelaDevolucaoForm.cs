﻿using LocadoraVeiculo.Combustivel;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.IO;
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


        public LocacaoVeiculo Locacao
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
            header_Devolucao.BackColor = ControladorDarkMode.corHeader;
            BackColor = ControladorDarkMode.corPanel;
            ForeColor = ControladorDarkMode.corFonte;

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
        private decimal? CalcularPrecoTipoCombustivel(decimal? combustivelGasto)
        {
            switch (locacao.Veiculo.TipoCombustivel)
            {
                case "Gasolina": combustivelGasto *= Convert.ToDecimal(LocadoraVeiculo.Combustivel.Combustivel.PrecoGasolina); break;
                case "Álcool": combustivelGasto *= Convert.ToDecimal(LocadoraVeiculo.Combustivel.Combustivel.PrecoAlcool); break;
                case "Diesel": combustivelGasto *= Convert.ToDecimal(LocadoraVeiculo.Combustivel.Combustivel.PrecoDiesel); break;
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
                    return totalKm * locacao.Veiculo.GrupoVeiculo.ValorKmRodadoPDiario;
                case "KM Controlado":
                    return (CalcularKmRodado(totalKm)) * locacao.Veiculo.GrupoVeiculo.ValorKmRodadoPControlado;
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
                    case "Inteiro":
                        desconto = Convert.ToDouble(locacao.Desconto.Valor);
                        break;
                    case "Porcentagem":
                        desconto = totalSemDesconto * Convert.ToDouble(locacao.Desconto.Valor / 100);
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
            double totalSuposto = Convert.ToDouble(locacao.PrecoServicos) + Convert.ToDouble(locacao.PrecoPlano) +
                                                Convert.ToDouble(locacao.PrecoCombustivel) * multa;
            total = totalSuposto;
            total -= CalcularDesconto(totalSuposto);
            txtTotal.Text = total < 0 ? "R$0" : "R$" + total.ToString();
        }
        private string ValidarCampos()
        {
            string valido = "";

            if (txtKmAtual.Text == "")
                return "O Campo Quilometragem Atual não pode ser nulo\r\n";

            if (Convert.ToInt32(txtKmInicial.Text) >= Convert.ToInt32(txtKmAtual.Text))
                valido += "O Campo Quilometragem Atual não pode ser menor que a esperada\r\n";

            if (dtRetorno.Value.Date < dtRetornoEsperada.Value.Date)
                valido += "A Data de Retorno não pode ser menor que a Data de Retorno Esperada\r\n";

            if (cbNivelTanque.Text == "")
                valido += "O Campo Nível do Tanque não pode ser nulo\r\n";

            if (valido == "")
                return "Valido";

            return valido;
        }
        private void cbNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal? totalTanque = Convert.ToDecimal(locacao.Veiculo.CapacidadeTanque);

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

            var totalKm = Convert.ToInt32(txtKmAtual.Text) - locacao.Veiculo.KmInicial;

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
            locacao.Veiculo.KmInicial = Convert.ToInt32(txtKmAtual.Text);
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