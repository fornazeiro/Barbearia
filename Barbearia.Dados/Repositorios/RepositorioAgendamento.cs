using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using Barbearia.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

            vSql.AppendLine("INSERT INTO agendamentos(data, hora, situacao)");
            vSql.AppendFormat("VALUES('{0}', '{1}', {2})", agendamento.DataAgendamento.ToString("yyyy-MM-dd"),
                                                             agendamento.HoraAgendamento,
                                                             agendamento.Situacao == true ? 1 : 0);

            OpenConnection();

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
                //calendario.start = reader["data"].ConvertObjectToString() + " " + reader["hora"].ConvertObjectToString();
                //calendario.title = "teste";

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
                agendamento.DataAgendamento = reader["data"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["hora"].ConvertObjectToString();
                agendamento.Situacao = reader["situacao"].ConvertObjectToBoolean();
            }

            Dispose();

            return agendamento;
        }

        public List<Agendamento> ListarPorDataHora(Entidades.Agendamento agendamento = null)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Agendamento> agendamentos = new List<Entidades.Agendamento>();

            //vSql.AppendLine("SELECT * FROM agendamentos");

            //if (agendamento != null)
            //{
            //    if (!string.IsNullOrEmpty(agendamento.HoraAgendamento))
            //        vSql.AppendFormat(" WHERE data = '{0}'", agendamento.DataAgendamento.ToString("yyyy-MM-dd"));

            //    if (!string.IsNullOrEmpty(agendamento.HoraAgendamento))
            //        vSql.AppendFormat(" AND data = '{0}'", agendamento.HoraAgendamento);
            //}

            //vSql.AppendLine(" ORDER BY HORA");

            //OpenConnection();

            agendamento = new Entidades.Agendamento();
            agendamento.DataAgendamento = Convert.ToDateTime("2021-11-10");
            agendamento.HoraAgendamento = "08:00";
            agendamento.Situacao =true;
            agendamento.IdCliente = 2;
            agendamentos.Add(agendamento);

            agendamento = new Entidades.Agendamento();
            agendamento.DataAgendamento = Convert.ToDateTime("2021-11-11");
            agendamento.HoraAgendamento = "08:00";
            agendamento.Situacao = true;
            agendamento.IdCliente = 2;
            agendamentos.Add(agendamento);

            agendamento = new Entidades.Agendamento();
            agendamento.DataAgendamento = Convert.ToDateTime("2021-11-12");
            agendamento.HoraAgendamento = "08:00";
            agendamento.Situacao = true;
            agendamento.IdCliente = 2;
            agendamentos.Add(agendamento);

            //var command = Connection.CreateCommand();
            //command.CommandType = System.Data.CommandType.Text;
            //command.CommandText = vSql.ToString();

            //var reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    agendamento = new Entidades.Agendamento();
            //    agendamento.Id = reader["id"].ConvertObjectToInt();
            //    agendamento.DataAgendamento = reader["data"].ConvertObjectToDateTime();
            //    agendamento.HoraAgendamento = reader["hora"].ConvertObjectToString();
            //    agendamento.Situacao = reader["situacao"].ConvertObjectToBoolean();

            //    agendamentos.Add(agendamento);
            //}

            //Dispose();

            return agendamentos;
        }

        public List<Agendamento> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Calendario> ListarCalendario()
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Calendario> calendarios = new List<Entidades.Calendario>();

            vSql.AppendLine("SELECT * FROM agendamentos");

            Entidades.Calendario calendario = new Entidades.Calendario();
            calendario.start = "2021-11-10";
            calendario.title = "5";
            calendario.color = "black";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.start = "2021-11-12";
            calendario.title = "7";
            calendario.color = "black";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.start = "2021-11-15";
            calendario.title = "9";
            calendario.color = "black";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.start = "2021-11-16";
            calendario.title = "3";
            calendario.color = "black";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.start = "2021-11-13";
            calendario.title = "2";
            calendario.color = "black";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.start = "2021-11-14";
            calendario.title = "1";
            calendario.color = "black";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.start = "2021-12-10";
            calendario.title = "5";
            calendario.color = "black";
            calendarios.Add(calendario);

            //OpenConnection();

            //var command = Connection.CreateCommand();
            //command.CommandType = System.Data.CommandType.Text;
            //command.CommandText = vSql.ToString();

            //var reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    Entidades.Calendario calendario = new Entidades.Calendario();
            //    calendario.start = DateTime.Parse(reader["data"].ToString()).ToString("yyyy-MM-dd") + " " + reader["hora"].ConvertObjectToString();
            //    calendario.title = "teste";

            //    calendarios.Add(calendario);
            //}

            /*Entidades.Calendario calendario = new Entidades.Calendario();
            calendario.title = "Nelson";
            calendario.start = "2021-11-10T08:00:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Regina";
            calendario.start = "2021-11-10T08:40:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Daniel";
            calendario.start = "2021-11-10T09:00:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Felipe";
            calendario.start = "2021-11-10T09:40:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Marcos";
            calendario.start = "2021-11-15T09:00:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Andre";
            calendario.start = "2021-11-16 08:00:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Miriam";
            calendario.start = "2021-11-18 09:30:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Jose";
            calendario.start = "2021-11-20 15:00:00";
            calendarios.Add(calendario);

            calendario = new Entidades.Calendario();
            calendario.title = "Aline";
            calendario.start = "2021-12-20 15:00:00";
            calendarios.Add(calendario);*/

            //var ListarCalendarios = calendarios.Select(x => x.start).Distinct().ToList();

            //foreach (var item in ListarCalendarios)
            //{

            //}

            Dispose();

            return calendarios;
        }

        public List<Entidades.Calendario> ListarCalendarioInicial()
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Calendario> calendarios = new List<Entidades.Calendario>();

            vSql.AppendLine("SELECT data, Count(data) AS quantidade FROM agendamentos GROUP BY data");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Calendario calendario = new Entidades.Calendario();
                calendario.start = DateTime.Parse(reader["data"].ToString()).ToString("yyyy-MM-dd");
                calendario.title = reader["quantidade"].ToString();

                calendarios.Add(calendario);
            }           

            Dispose();

            return calendarios;
        }


    }
}