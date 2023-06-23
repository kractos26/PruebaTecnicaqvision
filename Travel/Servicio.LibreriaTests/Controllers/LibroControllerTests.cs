using Microsoft.VisualStudio.TestTools.UnitTesting;
using Travel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Travel.Core.Aplicacion.Libro;
using Travel.Core.Dto;
using Assert = NUnit.Framework.Assert;

namespace Travel.Controllers.Tests
{
    [TestClass()]
    public class LibroControllerTests
    {
        private LibroController _libroController;
        private Mock<IMediator> _mockMediator;

        [SetUp]
        public void SetUp()
        {
            _mockMediator = new Mock<IMediator>();
            _libroController = new LibroController(_mockMediator.Object);
        }

        [Test]
        public async Task ObtenerListaLibros()
        {
            // Arrange
            var libroDtoList = new List<LibroDto> { new LibroDto() };

            _mockMediator.Setup(m => m.Send(It.IsAny<ObtenerLibro.ObtenerLibroCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(libroDtoList);

            // Act
            var result = await _libroController.Get();

            // Assert
            Assert.IsInstanceOf<ActionResult<List<LibroDto>>>(result);
            Assert.AreEqual(libroDtoList, result.Value);
        }

      

       

       
    }
}