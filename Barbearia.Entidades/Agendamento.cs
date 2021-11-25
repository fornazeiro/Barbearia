﻿using System;

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
        public DateTime DataAgendamento { get; set; }
        public string HoraAgendamento { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public bool Situacao { get; set; }
        public Cliente Cliente { get; set; }
    }
}