using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.VeiculoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    public partial class TelaVeiculoForm : Form
    {
        public VeiculoModule.Veiculo veiculos;
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();

        public TelaVeiculoForm()
        {
            InitializeComponent();

            CarregarGrupos();
        }

        private void CarregarGrupos()
        {
            cmbGrupo.DataSource = controladorGrupoVeiculo.SelecionarTodos();
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

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            byte[] foto = ConverteImagemParaByteArray(pictureBoxImagem.Image, pictureBoxImagem);
            string nome = txtNome.Text;
            string placa = txtPlaca.Text;
            string chassi = txtChassi.Text;
            string cor = txtCor.Text;
            string marca = txtMarca.Text;
            int ano = Convert.ToInt32(txtAno.Text);
            int NPortas = Convert.ToInt32(txtNPortas.Text);
            int CapacidadeTanque = Convert.ToInt32(txtCapacidadeTanque.Text);
            char TamanhoPortaMalas = Convert.ToChar(cmbTamanhoPortaMalas.Text);
            int Km = Convert.ToInt32(txtKm.Text);
            string TipoCombustivel = cmbTipoCombustivel.Text;
            int disponibidade = 1;
            GrupoVeiculoModule.GrupoVeiculo grupo = (GrupoVeiculoModule.GrupoVeiculo)cmbGrupo.SelectedItem;

            veiculos = new VeiculoModule.Veiculo(nome, placa, chassi, foto, cor, marca, ano, NPortas, CapacidadeTanque, TamanhoPortaMalas, Km, TipoCombustivel, disponibidade, grupo);

            string resultadoValidacao = veiculos.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            openFileDialogImagem.Title = "Imagem do produto";
            openFileDialogImagem.Filter = "Images (*.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.)| *.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.icon; *.JFIF";
            if (openFileDialogImagem.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImagem.Image = Image.FromFile(openFileDialogImagem.FileName);

                pictureBoxImagem.Image = (Image)(new Bitmap(pictureBoxImagem.Image, new Size(214, 126)));

                pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage; 
            }
        }

        public static byte[] ConverteImagemParaByteArray(Image img, PictureBox pictureBox)
        {
            MemoryStream ms = new MemoryStream();
            if (pictureBox.Image != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
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