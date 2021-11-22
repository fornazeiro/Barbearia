﻿using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using Barbearia.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioAgendamento : RepositorioBase, IAgendamentos
    {
        public void Excuir(int id)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("UPDATE agendamentos SET situacao = 0)");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public void Incluir(Entidades.Agendamento agendamento)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("INSERT INTO agendamento(DataAgendamento, HoraAgendamento, Situacao)");
            vSql.AppendFormat("VALUES '{0}', '{1}', '{2}'", agendamento.DataAgendamento, agendamento.HoraAgendamento, agendamento.Situacao);

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public List<Entidades.Agendamento> Listar()
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Agendamento> agendamentos = new List<Entidades.Agendamento>();

            vSql.AppendLine("SELECT * FROM agendamentos");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Agendamento agendamento = new Entidades.Agendamento();
                agendamento.Id = reader["id"].ConvertObjectToInt();
                agendamento.DataAgendamento = reader["dataagendamento"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["horaagendamento"].ToString();
                agendamento.Situacao = bool.Parse(reader["situacao"].ToString());

                agendamentos.Add(agendamento);
            }

            Dispose();

            return agendamentos;
        }

        public Entidades.Agendamento ListarPorId(int id)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Agendamento> agendamentos = new List<Entidades.Agendamento>();

            vSql.AppendLine("SELECT * FROM agendamentos");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            Entidades.Agendamento agendamento = new Entidades.Agendamento();

            while (reader.Read())
            {
                agendamento.Id = reader["id"].ConvertObjectToInt();
                agendamento.DataAgendamento = reader["dataagendamento"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["horaagendamento"].ToString();
                agendamento.Situacao = bool.Parse(reader["situacao"].ToString());

            }

            Dispose();

            return agendamento;
        }

        public List<Agendamento> ListarPorData(DateTime data)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Agendamento> agendamentos = new List<Entidades.Agendamento>();

            vSql.AppendLine("SELECT * FROM agendamentos");
            vSql.AppendFormat("WHERE dataagendamento = '{0}'", data.ToString("yyyy-MM-dd"));

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Agendamento agendamento = new Entidades.Agendamento();
                agendamento.Id = reader["id"].ConvertObjectToInt();
                agendamento.DataAgendamento = reader["dataagendamento"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["horaagendamento"].ToString();
                agendamento.Situacao = bool.Parse(reader["situacao"].ToString());

                agendamentos.Add(agendamento);
            }

            Dispose();

            return agendamentos;
        }

        public List<Agendamento> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
