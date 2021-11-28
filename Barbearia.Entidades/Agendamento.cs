using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Barbearia.Entidades
{
    public class Agendamento
    {
        public Agendamento()
        {
            Cliente = new Cliente();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "O campo Data Agendamento é obrigatório")]
        [DisplayName("Data Agendamento")]
        public DateTime DataAgendamento { get; set; }
        [Required(ErrorMessage = "O campo Hora Agendamento é obrigatório")]
        [DisplayName("Hora Agendamento")]
        public string HoraAgendamento { get; set; }
        [DisplayName("Status")]
        public bool Situacao { get; set; }
        public Cliente Cliente { get; set; }
    }
}