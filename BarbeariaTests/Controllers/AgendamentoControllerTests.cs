using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barbearia.Controllers.Tests
{
    [TestClass()]
    public class AgendamentoControllerTests
    {
        [TestMethod()]
        public void ListarCalendario() => Assert.IsNotNull(new Negocios.Agendamento().ListarCalendario(1));

        [TestMethod()]
        public void ListarPorId() => Assert.IsNull(new Negocios.Agendamento().ListarPorId(1));

        [TestMethod()]
        public void VerificarSeIdIgual()
        {
            var agenda = new Negocios.Agendamento().ListarPorId(1);

            Assert.Equals(1, agenda.Id);
        }

        [TestMethod()]
        public void ListarPorDataHora()
        {
            Assert.IsNotNull(new Negocios.Agendamento().ListarPorDataHora(new Entidades.Agendamento()));
        }
    }
}