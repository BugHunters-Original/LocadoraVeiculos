using LocadoraVeiculo.WindowsApp.Features.Clientes;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Cliente
{
    public partial class TelaFiltroClienteForm : Form
    {
        public TelaFiltroClienteForm()
        {
            InitializeComponent();
            SetColor();
        }
        private void SetColor()
        {
            this.header_FiltroLocacao.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
        }
        public FiltroClienteEnum TipoFiltro
        {
            get
            {
                if (rdbCNPJ.Checked)
                    return FiltroClienteEnum.PessoaJuridica;
                else
                    return FiltroClienteEnum.PessoaFisica;
            }
        }
    }
}
