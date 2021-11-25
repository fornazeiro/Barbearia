using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioHora : RepositorioBase, IRepositorioHora
    {
        public List<Entidades.Horas> ListarHoras(DateTime data)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendFormat("SELECT * FROM horas");

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
