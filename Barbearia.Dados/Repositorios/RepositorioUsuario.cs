using Barbearia.Dados.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioUsuario : RepositorioBase, IUsuarios
    {
        public void Excuir(int id)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("UPDATE usuarios SET situacao = 0");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public void Incluir(Entidades.Usuario usuario)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendLine("INSERT INTO usuarios(nome, email, senha, situacao)");
            vSql.AppendFormat("VALUES '{0}', '{1}', '{2}', '{3}'", usuario.Nome,
                                                                   usuario.Email,
                                                                   usuario.Senha,
                                                                   usuario.Situacao);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            command.ExecuteNonQuery();

            Dispose();
        }

        public List<Entidades.Usuario> Listar()
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Usuario> usuarios = new List<Entidades.Usuario>();

            vSql.AppendLine("SELECT * FROM usuarios");

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Id = int.Parse(reader["id"].ToString());
                usuario.Nome = reader["nome"].ToString();
                usuario.Email = reader["Email"].ToString();
                usuario.Situacao = bool.Parse(reader["situacao"].ToString());

                usuarios.Add(usuario);
            }

            Dispose();

            return usuarios;
        }

        public Entidades.Usuario ListarPorId(int id)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Usuario> usuarios = new List<Entidades.Usuario>();

            vSql.AppendLine("SELECT * FROM usuarios");
            vSql.AppendFormat("WHERE id = {0}", id);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            Entidades.Usuario usuario = new Entidades.Usuario();

            while (reader.Read())
            {
                usuario.Id = int.Parse(reader["id"].ToString());
                usuario.Nome = reader["nome"].ToString();
                usuario.Email = reader["Email"].ToString();
                usuario.Situacao = bool.Parse(reader["situacao"].ToString());
            }

            Dispose();

            return usuario;
        }

        public List<Entidades.Usuario> ListarPorNome(string nome)
        {
            StringBuilder vSql = new StringBuilder();
            List<Entidades.Usuario> usuarios = new List<Entidades.Usuario>();

            vSql.AppendLine("SELECT * FROM usuarios");
            vSql.AppendFormat("WHERE nome Like '%{0}%'", nome);

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Id = int.Parse(reader["id"].ToString());
                usuario.Nome = reader["nome"].ToString();
                usuario.Email = reader["Email"].ToString();
                usuario.Situacao = bool.Parse(reader["situacao"].ToString());

                usuarios.Add(usuario);
            }

            Dispose();

            return usuarios;
        }
    }
}
