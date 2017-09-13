using Concesionarios.Core;
using Concesionarios.Service;
using Concesionarios.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Concesionarios.WebApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<ConcesionarioService> mockConcesionarioService;

        [TestInitialize]
        public void SetupTests()
        {
            mockConcesionarioService = new Mock<ConcesionarioService>();
            mockConcesionarioService.Setup(c => c.GetAll()).Returns((IEnumerable<Concesionario> Concesionarios) => { return Concesionarios; });
        }



        [TestMethod]
        public void TestMethod1()
        {
            ConcesionarioController concesionarioController = new ConcesionarioController(mockConcesionarioService.Object);
            IEnumerable<Concesionario> concesionarios = concesionarioController.Get();
            Assert.IsInstanceOfType(concesionarios, typeof(IEnumerable<Concesionario>));
        }
    }
}
