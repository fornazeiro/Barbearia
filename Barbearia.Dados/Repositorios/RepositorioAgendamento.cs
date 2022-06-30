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
        public void Excluir(int id)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("UPDATE agendamentos SET situacao = 0");
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

            vSql.AppendLine("INSERT INTO agendamentos(idcliente, data, hora, idlocacao, situacao)");
            vSql.AppendFormat("VALUES('{0}', '{1}', '{2}', {3}, {4})", agendamento.IdCliente,
                                                             agendamento.DataAgendamento.ToString("yyyy-MM-dd"),
                                                             agendamento.HoraAgendamento,
                                                             agendamento.IdLocacao,
                                                             agendamento.Situacao == true ? 1 : 0);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public void Editar(Entidades.Agendamento agendamento)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendFormat("UPDATE agendamentos SET data = '{0}', hora = '{1}', situacao = {2} WHERE id = {3}", agendamento.DataAgendamento.ToString("yyyy-MM-dd"),
                                                             agendamento.HoraAgendamento,
                                                             agendamento.Situacao == true ? 1 : 0,
                                                             agendamento.Id);

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

            vSql.AppendLine("SELECT a.id, a.data, a.hora, a.situacao, a.idcliente, c.nome AS cliente, l.nome AS Locador FROM agendamentos a");
            vSql.AppendLine("INNER JOIN clientes c ON c.id = a.idcliente");
            vSql.AppendLine("INNER JOIN locacao l ON l.id = a.idlocacao");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            Entidades.Agendamento agendamento = null;

            while (reader.Read())
            {
                agendamento = new Entidades.Agendamento();
                agendamento.Id = reader["id"].ConvertObjectToInt();
                agendamento.DataAgendamento = reader["data"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["hora"].ConvertObjectToString();
                agendamento.Cliente.Id = reader["idcliente"].ConvertObjectToInt();
                agendamento.Cliente.Nome = reader["cliente"].ConvertObjectToString();
                agendamento.Situacao = reader["situacao"].ConvertObjectToBoolean();

                agendamentos.Add(agendamento);
            }

            reader.Close();
            reader.Dispose();

            Dispose();

            return agendamentos;
        }

        public Entidades.Agendamento ListarPorId(int id)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Agendamento> agendamentos = new List<Entidades.Agendamento>();

            vSql.AppendLine("SELECT a.id, a.data, a.hora, a.situacao, a.idcliente, c.nome AS cliente FROM agendamentos a");
            vSql.AppendLine("INNER JOIN clientes c ON c.Id = a.IdCliente");
            vSql.AppendFormat("WHERE a.id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            Entidades.Agendamento agendamento = null;

            while (reader.Read())
            {
                agendamento = new Entidades.Agendamento();
                agendamento.Id = reader["id"].ConvertObjectToInt();
                agendamento.DataAgendamento = reader["data"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["hora"].ConvertObjectToString();
                agendamento.Cliente.Id = reader["idcliente"].ConvertObjectToInt();
                agendamento.Cliente.Nome = reader["cliente"].ConvertObjectToString();
                agendamento.Situacao = reader["situacao"].ConvertObjectToBoolean();
            }

            reader.Close();
            reader.Dispose();

            Dispose();

            return agendamento;
        }

        public List<Agendamento> ListarPorDataHora(Entidades.Agendamento agendamento = null)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Agendamento> agendamentos = new List<Entidades.Agendamento>();

            //vSql.AppendLine("SELECT a.id, a.data, a.hora, a.situacao, a.idcliente, c.nome AS cliente FROM agendamentos a");
            //vSql.AppendLine("INNER JOIN clientes c ON c.Id = a.IdCliente");
           
            vSql.AppendLine("SELECT a.id, a.data, a.hora, a.situacao, a.idcliente, c.nome AS cliente, l.nome AS profissional FROM agendamentos a");
            vSql.AppendLine("INNER JOIN clientes c ON c.id = a.idcliente");
            vSql.AppendLine("INNER JOIN locacao l ON l.id = a.idlocacao");

            if (agendamento != null)
            {
                if (!string.IsNullOrEmpty(agendamento.DataAgendamento.ToString()))
                    vSql.AppendFormat(" AND data = '{0}'", agendamento.DataAgendamento.ToString("yyyy-MM-dd"));

                if (!string.IsNullOrEmpty(agendamento.HoraAgendamento))
                    vSql.AppendFormat(" AND hora = '{0}'", agendamento.HoraAgendamento);
            }

            vSql.AppendLine("ORDER BY a.data");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                agendamento = new Entidades.Agendamento();
                agendamento.Id = reader["id"].ConvertObjectToInt();
                agendamento.DataAgendamento = reader["data"].ConvertObjectToDateTime();
                agendamento.HoraAgendamento = reader["hora"].ConvertObjectToString();
                agendamento.Cliente.Id = reader["idcliente"].ConvertObjectToInt();
                agendamento.Cliente.Nome = reader["cliente"].ConvertObjectToString();
                agendamento.Locacao.Nome = reader["profissional"].ConvertObjectToString();
                agendamento.Situacao = reader["situacao"].ConvertObjectToBoolean();

                agendamentos.Add(agendamento);
            }

            reader.Close();
            reader.Dispose();

            Dispose();

            return agendamentos;
        }

        public List<Agendamento> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Calendario> ListarCalendario(int IdLocacao)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Calendario> calendarios = new List<Entidades.Calendario>();

            vSql.AppendLine("SELECT data, Count(*) AS quantidade FROM agendamentos");

            if (IdLocacao > 0) vSql.AppendLine("WHERE idlocacao = " + IdLocacao);
            
            vSql.AppendLine("GROUP BY data");

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

            reader.Close();
            reader.Dispose();

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

            reader.Close();
            reader.Dispose();

            Dispose();

            return calendarios;
        }


    }
}