using Microsoft.VisualStudio.TestTools.UnitTesting;
using Barbearia.Teste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Teste.Tests
{
    [TestClass()]
    public class BarberTestTests
    {
        [TestMethod()]
        public void ListarCalendarioTest()
        {
            Assert.IsNotNull(new Negocios.Agendamento().ListarCalendario(1));
        }
    }
}