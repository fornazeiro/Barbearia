using NUnit.Framework;
using Xunit;

namespace Barbearia.Teste
{
    public class BarberTest
    {
        [Fact]
        public void ListarCalendario()
        {
            var nAgendamento = new Negocios.Agendamento();            

            Assert.IsNotNull(nAgendamento.ListarCalendario(1));
        }
    }
}