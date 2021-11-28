using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioHora : RepositorioBase, IHoras
    {
        public List<Entidades.Horas> ListarHoras(string data = null)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("SELECT hora FROM horas");

            if (!string.IsNullOrEmpty(data))
                vSql.AppendFormat("WHERE hora NOT IN (SELECT hora FROM agendamentos WHERE data = '{0}')", data);


            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            List<Horas> horas = new List<Horas>();
            
            while (reader.Read())
            {
                Entidades.Horas hora = new Horas();
                hora.Hora = reader["hora"].ToString();
                horas.Add(hora);
            }

            reader.Close();
            reader.Dispose();

            Dispose();

            return horas;
        }
    }
}
