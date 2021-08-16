using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    public partial class TelaDetalhesVeiculoForm : Form
    {
        public VeiculoModule.Veiculo veiculos;
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();

        public TelaDetalhesVeiculoForm()
        {
            InitializeComponent();
        }

        public VeiculoModule.Veiculo Veiculo
        {
            get { return veiculos; }

            set
            {
                veiculos = value;

                txtId.Text = veiculos.Id.ToString();
                txtNome.Text = veiculos.nome;
                txtPlaca.Text = veiculos.numero_Placa;
                txtChassi.Text = veiculos.numero_Chassi;
                if (veiculos.foto != null)
                {
                    pictureBoxImagem.Image = (Image)(new Bitmap(ConverteByteArrayParaImagem(veiculos.foto), new Size(214, 126)));
                    pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                txtCor.Text = veiculos.cor;
                txtMarca.Text = veiculos.marca;
                txtAno.Text = veiculos.ano.ToString();
                txtNPortas.Text = veiculos.numero_Portas.ToString();
                txtCapacidadeTanque.Text = veiculos.capacidade_Tanque.ToString();
                cmbTamanhoPortaMalas.Text = veiculos.tamanhoPortaMalas.ToString();
                txtKm.Text = veiculos.km_Inicial.ToString();
                cmbTipoCombustivel.Text = veiculos.tipo_Combustivel;
                cmbGrupo.Text = veiculos.grupoVeiculo.categoriaVeiculo;
            }
        }

        public static Image ConverteByteArrayParaImagem(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch
            {
                return null;
            }
        }
    }
}
