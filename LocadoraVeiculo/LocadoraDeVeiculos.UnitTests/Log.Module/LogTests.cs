using FluentAssertions;
using LocadoraDeVeiculos.Infra.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.UnitTests.Log.Module
{
    [TestClass]
    public class LogTests
    {
        [TestMethod]
        public void DeveNotificarErro()
        {
            //arrange
            Exception ex = new("problema");
            //action
            bool resultadoValidacao = NotificaErro.EnviarEmailErro(ex);

            //assert
            resultadoValidacao.Should().Be(true);
        }

    }
}
