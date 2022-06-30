using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using Barbearia.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioLocacao : RepositorioBase, ILocacao
    {
        public void Excluir(int id)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("UPDATE locacao SET situacao = 0");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public void Incluir(Locacao locacao)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("INSERT INTO locacao(nome, cpf, telefone, endereco, bairro, cidade, cadeiras, valor, situacao)");
            vSql.AppendFormat("VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8})", locacao.Nome,
                                                                          locacao.Cpf,
                                                                          locacao.Telefone,
                                                                          locacao.Endereco,
                                                                          locacao.Bairro,
                                                                          locacao.Cidade,
                                                                          locacao.Cep,
                                                                          locacao.Cadeiras,
                                                                          locacao.ValorUnitario,
                                                                          locacao.Situacao == true ? 1 : 0);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public void Editar(Locacao locacao)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendFormat("UPDATE locacao SET nome = '{0}', " +
                              "                   cpf = '{1}', " +
                              "                   telefone = '{2}', " +
                              "                   endereco = '{3}', " +
                              "                   bairro = '{4}', " +
                              "                   cidade = '{5}', " +
                              "                   cep = '{6}', " +
                              "                   cadeiras = {7}, " +
                              "                   valor = {8} " +
                              "                   WHERE id = {9}", 
                                                  locacao.Nome,
                                                  locacao.Cpf,
                                                  locacao.Telefone,
                                                  locacao.Endereco,
                                                  locacao.Bairro,
                                                  locacao.Cidade,
                                                  locacao.Cep,
                                                  locacao.Cadeiras,
                                                  locacao.ValorUnitario,
                                                  locacao.Id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public List<Locacao> Listar()
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Locacao> locacoes = new List<Entidades.Locacao>();

            vSql.AppendLine("SELECT * FROM locacao");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Locacao locacao = new Entidades.Locacao();
                locacao.Id = reader["id"].ConvertObjectToInt();
                locacao.Nome = reader["nome"].ConvertObjectToString();
                locacao.Cpf = reader["cpf"].ConvertObjectToString();
                locacao.Telefone = reader["telefone"].ConvertObjectToString();
                locacao.Endereco = reader["endereco"].ConvertObjectToString();
                locacao.Bairro = reader["bairro"].ConvertObjectToString();
                locacao.Cidade = reader["cidade"].ConvertObjectToString();
                locacao.Cep = reader["cep"].ConvertObjectToString();
                locacao.Cadeiras = reader["cadeiras"].ConvertObjectToInt();
                locacao.ValorUnitario = reader["valor"].ConvertObjectToDecimal();
                locacao.Situacao = reader["situacao"].ConvertObjectToBoolean();

                locacoes.Add(locacao);
            }

            Dispose();

            return locacoes;
        }

        public Locacao ListarPorId(int id)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Locacao> locacoes = new List<Entidades.Locacao>();

            vSql.AppendFormat("SELECT * FROM locacao WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            Entidades.Locacao locacao = new Entidades.Locacao();

            while (reader.Read())
            {
                locacao.Id = reader["id"].ConvertObjectToInt();
                locacao.Nome = reader["nome"].ConvertObjectToString();
                locacao.Cpf = reader["cpf"].ConvertObjectToString();
                locacao.Telefone = reader["telefone"].ConvertObjectToString();
                locacao.Endereco = reader["endereco"].ConvertObjectToString();
                locacao.Bairro = reader["bairro"].ConvertObjectToString();
                locacao.Cidade = reader["cidade"].ConvertObjectToString();
                locacao.Cep = reader["cep"].ConvertObjectToString();
                locacao.Cadeiras = reader["cadeiras"].ConvertObjectToInt();
                locacao.ValorUnitario = reader["valor"].ConvertObjectToDecimal();
                locacao.Situacao = reader["situacao"].ConvertObjectToBoolean();
            }

            Dispose();

            return locacao;
        }

        public List<Locacao> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
