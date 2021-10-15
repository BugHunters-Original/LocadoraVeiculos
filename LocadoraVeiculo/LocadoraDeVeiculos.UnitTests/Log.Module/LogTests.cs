﻿using FluentAssertions;
using LocadoraDeVeiculos.Infra.LogManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool resultadoValidacao = NotificarErro.EnviarEmailErro(ex);

            //assert
            resultadoValidacao.Should().Be(true);
        }

    }
}
