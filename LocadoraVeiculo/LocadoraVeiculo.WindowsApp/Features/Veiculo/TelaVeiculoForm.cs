using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.VeiculoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.Veiculos
{
    public partial class TelaVeiculoForm : Form
    {
        public VeiculoModule.Veiculo veiculos;
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();

        public TelaVeiculoForm()
        {
            InitializeComponent();
            SetColor();
            CarregarGrupos();
        }

        private void SetColor()
        {
            this.header_Veiculo.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtId.BackColor = ControladorDarkMode.corFundoTxBox;
            txtNome.BackColor = ControladorDarkMode.corFundoTxBox;
            txtMarca.BackColor = ControladorDarkMode.corFundoTxBox;
            txtChassi.BackColor = ControladorDarkMode.corFundoTxBox;
            txtPlaca.BackColor = ControladorDarkMode.corFundoTxBox;
            txtNPortas.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCor.BackColor = ControladorDarkMode.corFundoTxBox;
            txtKm.BackColor = ControladorDarkMode.corFundoTxBox;
            txtAno.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCapacidadePessoas.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCapacidadeTanque.BackColor = ControladorDarkMode.corFundoTxBox;
            cmbGrupo.BackColor = ControladorDarkMode.corFundoTxBox;
            cmbTamanhoPortaMalas.BackColor = ControladorDarkMode.corFundoTxBox;
            cmbTipoCombustivel.BackColor = ControladorDarkMode.corFundoTxBox;

            txtId.ForeColor = ControladorDarkMode.corFonte;
            txtNome.ForeColor = ControladorDarkMode.corFonte;
            txtMarca.ForeColor = ControladorDarkMode.corFonte;
            txtChassi.ForeColor = ControladorDarkMode.corFonte;
            txtPlaca.ForeColor = ControladorDarkMode.corFonte;
            txtNPortas.ForeColor = ControladorDarkMode.corFonte;
            txtCor.ForeColor = ControladorDarkMode.corFonte;
            txtKm.ForeColor = ControladorDarkMode.corFonte;
            txtAno.ForeColor = ControladorDarkMode.corFonte;
            txtCapacidadePessoas.ForeColor = ControladorDarkMode.corFonte;
            txtCapacidadeTanque.ForeColor = ControladorDarkMode.corFonte;
            cmbGrupo.ForeColor = ControladorDarkMode.corFonte;
            cmbTamanhoPortaMalas.ForeColor = ControladorDarkMode.corFonte;
            cmbTipoCombustivel.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnBuscarFoto.BackColor = ControladorDarkMode.corFundoTxBox;
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
                txtCapacidadePessoas.Text = veiculos.capacidade_Pessoas.ToString();
                cmbTamanhoPortaMalas.Text = veiculos.tamanhoPortaMalas.ToString();
                txtKm.Text = veiculos.km_Inicial.ToString();
                cmbTipoCombustivel.Text = veiculos.tipo_Combustivel;
                cmbGrupo.Text = veiculos.grupoVeiculo.NomeTipo;
                txtDisponivel.Text = veiculos.disponibilidade_Veiculo.ToString();
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

            int? ano = null;
            if (!string.IsNullOrEmpty(txtAno.Text))
                ano = Convert.ToInt32(txtAno.Text);

            int? NPortas = null;
            if (!string.IsNullOrEmpty(txtNPortas.Text))
                NPortas = Convert.ToInt32(txtNPortas.Text);

            int? CapacidadeTanque = null;
            if (!string.IsNullOrEmpty(txtCapacidadeTanque.Text))
                CapacidadeTanque = Convert.ToInt32(txtCapacidadeTanque.Text);

            int? CapacidadePessoas = null;
            if (!string.IsNullOrEmpty(txtCapacidadePessoas.Text))
                CapacidadePessoas = Convert.ToInt32(txtCapacidadePessoas.Text);

            int? Km = null;
            if (!string.IsNullOrEmpty(txtKm.Text))
                Km = Convert.ToInt32(txtKm.Text);

            char TamanhoPortaMalas = ' ';
            if (cmbTamanhoPortaMalas.Text.ToString() != "")
                TamanhoPortaMalas = Convert.ToChar(cmbTamanhoPortaMalas.Text);
            string TipoCombustivel = cmbTipoCombustivel.Text;

            int disponibilidade = Convert.ToInt32(txtDisponivel.Text);

            GrupoVeiculoModule.GrupoVeiculo grupo = (GrupoVeiculoModule.GrupoVeiculo)cmbGrupo.SelectedItem;

            veiculos = new VeiculoModule.Veiculo(nome, placa, chassi, foto, cor, marca, ano, NPortas, CapacidadeTanque, CapacidadePessoas, TamanhoPortaMalas, Km, TipoCombustivel, disponibilidade, grupo);

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