using FluentAssertions;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Tests.VeiculoModule
{
    [TestClass]
    public class ControladorVeiculoTest
    {
        ControladorGrupoVeiculo controladorGrupo = null;
        ControladorVeiculo controlador = null;
        GrupoVeiculo Grupo;
        byte[] imagem;
        public ControladorVeiculoTest()
        {
            controladorGrupo = new ControladorGrupoVeiculo();
            controlador = new ControladorVeiculo();
            Db.Update("DELETE FROM [TBVEICULOS]");
            Db.Update("DELETE FROM [TBTIPOVEICULO]");

            Grupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(Grupo);
            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            var veiculo = new Veiculo("marea","1234567","12345678901234567",imagem,"azul","fiat",2000,2,80,'G',1000,"gasolina",1, Grupo);
            
            //action
            controlador.InserirNovo(veiculo);

            //assert
            var veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(veiculo);

        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 'G', 1000, "gasolina", 1, Grupo);
            controlador.InserirNovo(veiculo);

            var VeiculoEditado = new Veiculo("uneiras", "7654321", "12345678901234567", imagem, "preto", "audi", 2012, 2, 80, 'G', 1000, "gasolina", 1, Grupo);

            //action
            controlador.Editar(veiculo.Id, VeiculoEditado);

            //assert
            var veiculoAtualizado = controlador.SelecionarPorId(veiculo.Id);
            veiculoAtualizado.Should().Be(VeiculoEditado);
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            //arrange            
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 'G', 1000, "gasolina", 1, Grupo);
            controlador.InserirNovo(veiculo);

            //action            
            controlador.Excluir(veiculo.Id);

            //assert
            var veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 'G', 1000, "gasolina", 1, Grupo);
            controlador.InserirNovo(veiculo);

            //action
            var veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);

            //assert
            veiculoEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var v1 = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 'G', 1000, "gasolina", 1, Grupo);
            controlador.InserirNovo(v1);

            var v2 = new Veiculo("uno", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 'G', 1000, "gasolina", 1, Grupo);
            controlador.InserirNovo(v2);

            var v3 = new Veiculo("corsa", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 'G', 1000, "gasolina", 1, Grupo);
            controlador.InserirNovo(v3);

            //action
            var veiculos = controlador.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].nome.Should().Be("marea");
            veiculos[1].nome.Should().Be("uno");
            veiculos[2].nome.Should().Be("corsa");
        }
    }
}
