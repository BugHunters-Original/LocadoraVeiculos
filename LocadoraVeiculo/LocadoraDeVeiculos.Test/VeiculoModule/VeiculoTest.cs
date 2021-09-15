using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Test.VeiculoModule
{
    [TestClass]

    public class VeiculoTest
    {
        byte[] imagem;
        GrupoVeiculo grupoVeiculo;
        public VeiculoTest()
        {

            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);
        }

        [TestMethod]
        public void DeveValidar_Veiculo()
        {
            //arrange

            Veiculo veiculo = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Nome()
        {

            //arrange

            Veiculo veiculo = new Veiculo(null, "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Placa()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", null, "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Placa é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_NumeroPlaca()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Placa possui 7 dígitos");
        }

        [TestMethod]
        public void DeveValidar_Chassi()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", null, imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Chassi é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_NumeroChassi()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "4444", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Chassi possui 17 dígitos");
        }


        [TestMethod]
        public void DeveValidar_PortaMalaTamanho()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'B', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tamanho Porta-Malas deve ser P, M ou G");
        }

        [TestMethod]
        public void DeveValidar_Foto()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", new byte[] { }, "vermelho", "Ford", 2009, 9, 200, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Foto é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Cor()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, null, "Ford", 2009, 9, 200, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Cor é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Marca()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", null, 2009, 9, 200, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Marca é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Combustivel()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", "Volkswagem", 2009, 9, 200, 1, 'P', 90, null, 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Combustível é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Ano()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", "Volkswagem", null, 9, 200, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Ano é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_NroPortas()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", "Volkswagem", 2000, 0, 200, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nº de Portas é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_CapacidadeTanque()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", "Volkswagem", 2000, 1, 0, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Capacidade do Tanque é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Quilometragem()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", "Volkswagem", 2000, 1, 200, 1, 'P', 0, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Quilometragem Inicial obrigatório");
        }

        [TestMethod]
        public void DeveValidar_AnoFuturo()
        {

            //arrange            
            Veiculo veiculo = new Veiculo("NomeDoCarro", "AAA8888", "11112345671234675", imagem, "roxo", "Volkswagem", 2100, 1, 200, 1, 'P', 90, "Álcool", 1, grupoVeiculo);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Ano não pode ser maior que o ano atual ou muito antigo");
        }
    }
}
