﻿using System;
using System.Collections.Generic;

namespace Barbearia.Negocios
{
    public class Agendamento
    {
        public void Excuir(int id)
        {
            Dados.Repositorios.RepositorioAgendamento rAgendamento = new Dados.Repositorios.RepositorioAgendamento();

            rAgendamento.Excuir(id);
        }

        public void Incluir(Entidades.Agendamento agendamento)
        {
            Dados.Repositorios.RepositorioAgendamento rAgendamento = new Dados.Repositorios.RepositorioAgendamento();

            rAgendamento.Incluir(agendamento);
        }

        public List<Entidades.Calendario> ListarCalendario()
        {
            Dados.Repositorios.RepositorioAgendamento rAgendamento = new Dados.Repositorios.RepositorioAgendamento();

            return rAgendamento.ListarCalendario();
        }

        public List<Entidades.Agendamento> ListarPorDataHora(Entidades.Agendamento agendamento)
        {
            Dados.Repositorios.RepositorioAgendamento rAgendamento = new Dados.Repositorios.RepositorioAgendamento();

            return rAgendamento.ListarPorDataHora(agendamento);
        }

        public Entidades.Agendamento ListarPorId(int id)
        {
            Dados.Repositorios.RepositorioAgendamento rAgendamento = new Dados.Repositorios.RepositorioAgendamento();

            return rAgendamento.ListarPorId(id);
        }

        public List<Entidades.Agendamento> ListarPorNome(string nome)
        {
            Dados.Repositorios.RepositorioAgendamento rAgendamento = new Dados.Repositorios.RepositorioAgendamento();

            return rAgendamento.ListarPorNome(nome);
        }
    }
}