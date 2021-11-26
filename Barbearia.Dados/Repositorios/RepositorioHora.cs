using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioHora : RepositorioBase, IRepositorioHora
    {
        public List<Entidades.Horas> ListarHoras(string data = null)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendFormat("SELECT * FROM horas");

            //OpenConnection();

            //var command = Connection.CreateCommand();
            //command.CommandType = System.Data.CommandType.Text;
            //command.CommandText = vSql.ToString();

            //var reader = command.ExecuteReader();

           List<Horas> horas = new List<Horas>();

            Horas hora = new Horas();
            hora.Hora = "08:00";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "08:30";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "09:00";
            horas.Add(hora);
            
            hora = new Horas();
            hora.Hora = "09:30";
            horas.Add(hora);
            
            hora = new Horas();
            hora.Hora = "10:00";
            horas.Add(hora);
            
            hora = new Horas();
            hora.Hora = "10:30";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "11:00";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "11:30";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "12:30";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "13:00";
            horas.Add(hora);

            hora = new Horas();
            hora.Hora = "13:30";
            horas.Add(hora);



            //while (reader.Read())
            //{
            //    Entidades.Horas hora = new Horas();
            //    hora.Hora = reader["hora"].ToString();
            //    horas.Add(hora);
            //}

            //reader.Close();
            //reader.Dispose();

            //Dispose();

            return horas;
        }
    }
}
