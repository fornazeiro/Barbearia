using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Text;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioLogin : RepositorioBase, ILogin
    {
        public Entidades.Usuario Logon(Entidades.Login login)
        {
            StringBuilder vSql = new StringBuilder();

            vSql.AppendFormat("SELECT * FROM usuarios WHERE ((email = '{0}' OR nome = '{0}') AND senha = '{1}')", login.Email, login.Senha);

            Entidades.Usuario usuario = new Usuario();

            OpenConnection();

            var command = Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = vSql.ToString();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                usuario.Nome = reader["nome"].ToString();
                usuario.Email = reader["email"].ToString();
            }

            reader.Close();
            reader.Dispose();

            Dispose();

            return usuario;
        }
    }
}
