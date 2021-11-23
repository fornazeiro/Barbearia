using Barbearia.Dados.Interfaces;
using Barbearia.Shared;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioCliente : RepositorioBase, IClientes
    {
        public void Excuir(int id)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("UPDATE clientes SET situacao = 0");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public void Incluir(Entidades.Cliente cliente)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("INSERT INTO clientes(nome, datanascimento, email, telefone, situacao)");
            vSql.AppendFormat("VALUES '{0}', '{1}', '{2}', '{3}', '{4}'", cliente.Nome, 
                                                                          cliente.DataNascimento.ToString("yyyy-MM-dd"),
                                                                          cliente.Email,
                                                                          cliente.Telefone,
                                                                          cliente.Situacao);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public List<Entidades.Cliente> Listar()
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Cliente> clientes = new List<Entidades.Cliente>();

            vSql.AppendLine("SELECT * FROM clientes");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Cliente cliente = new Entidades.Cliente();
                cliente.Id = reader["id"].ConvertObjectToInt();
                cliente.Nome = reader["nome"].ConvertObjectToString();
                cliente.Email = reader["Email"].ConvertObjectToString();
                cliente.DataNascimento = reader["datanascimento"].ConvertObjectToDateTime();
                cliente.Situacao = reader["situacao"].ConvertObjectToBoolean();

                clientes.Add(cliente);
            }

            Dispose();

            return clientes;
        }

        public Entidades.Cliente ListarPorId(int id)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Cliente> clientes = new List<Entidades.Cliente>();

            vSql.AppendLine("SELECT * FROM clientes");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            Entidades.Cliente cliente = new Entidades.Cliente();

            while (reader.Read())
            {
                cliente.Id = reader["id"].ConvertObjectToInt();
                cliente.Nome = reader["nome"].ConvertObjectToString();
                cliente.Email = reader["Email"].ConvertObjectToString();
                cliente.DataNascimento = reader["datanascimento"].ConvertObjectToDateTime();
                cliente.Situacao = reader["situacao"].ConvertObjectToBoolean();
            }

            Dispose();

            return cliente;
        }

        public List<Entidades.Cliente> ListarPorNome(string nome)
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
                cliente.Id = reader["id"].ConvertObjectToInt();
                cliente.Nome = reader["nome"].ConvertObjectToString();
                cliente.Email = reader["Email"].ConvertObjectToString();
                cliente.DataNascimento = reader["datanascimento"].ConvertObjectToDateTime();
                cliente.Situacao = reader["situacao"].ConvertObjectToBoolean();

                clientes.Add(cliente);
            }

            Dispose();

            return clientes;
        }      
    }
}
