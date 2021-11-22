using System;

namespace Barbearia.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string HoraAgentamento { get; set; }
        public bool Situacao { get; set; }
    }
}