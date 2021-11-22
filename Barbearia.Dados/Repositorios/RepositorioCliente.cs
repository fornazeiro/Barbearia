using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System.Collections.Generic;
using System.Text;
using System;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioCliente : RepositorioBase, IClientes
    {
        public void Excuir(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Cliente cliente)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("INSERT INTO clientes(Nome, DataNascimento, Email, Situacao)");
            vSql.AppendFormat("VALUES '{0}', '{1}', '{2}', '{3}', '{4}'", cliente.Nome, cliente.DataNascimento.ToString("yyyy-MM-dd"), cliente.Email, cliente.Situacao);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public List<Cliente> Listar()
        {
            throw new System.NotImplementedException();
        }

        public Cliente ListarPorId(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ListarPorNome(string nome)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Cliente> clientes = new List<Entidades.Cliente>();

            vSql.AppendLine("SELECT * FROM clientes");
            vSql.AppendFormat("WHERE nome Like '%{0}%'", nome);

            OpenConnection();
           
            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Cliente cliente = new Entidades.Cliente();
                cliente.Id = int.Parse(reader["id"].ToString());
                cliente.Nome = reader["nome"].ToString();
                cliente.Email = reader["Email"].ToString();
                cliente.DataNascimento = DateTime.Parse(reader["datanascimento"].ToString());

                clientes.Add(cliente);
            }

            Dispose();

            return clientes;
        }
    }
}
