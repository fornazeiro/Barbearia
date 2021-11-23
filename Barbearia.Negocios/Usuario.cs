using System.Collections.Generic;

namespace Barbearia.Negocios
{
    public class Usuario
    {
        public void Excluir(int id)
        {
            Dados.Repositorios.RepositorioUsuario rUsuario = new Dados.Repositorios.RepositorioUsuario();

            rUsuario.Excuir(id);
        }

        public void Incuir(Entidades.Usuario usuario)
        {
            Dados.Repositorios.RepositorioUsuario rUsuario = new Dados.Repositorios.RepositorioUsuario();

            rUsuario.Incluir(usuario);
        }

        public List<Entidades.Usuario> Listar()
        {
            Dados.Repositorios.RepositorioUsuario rUsuario = new Dados.Repositorios.RepositorioUsuario();

            return rUsuario.Listar();
        }

        public Entidades.Usuario ListarPorId(int id)
        {
            Dados.Repositorios.RepositorioUsuario rUsuario = new Dados.Repositorios.RepositorioUsuario();

            return rUsuario.ListarPorId(id);
        }

        public List<Entidades.Usuario> ListarPorNome(string nome)
        {
            Dados.Repositorios.RepositorioUsuario rUsuario = new Dados.Repositorios.RepositorioUsuario();

            return rUsuario.ListarPorNome(nome);
        }
    }
}
