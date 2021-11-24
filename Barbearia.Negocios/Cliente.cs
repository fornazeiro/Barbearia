using System.Collections.Generic;

namespace Barbearia.Negocios
{
    public class Cliente
    {
        public void Excluir(int id)
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            rCliente.Excuir(id);
        }

        public void Incuir(Entidades.Cliente cliente)
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            rCliente.Incluir(cliente);
        }

        public List<Entidades.Cliente> Listar()
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            return rCliente.Listar();
        }

        public Entidades.Cliente ListarPorId(int id)
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            return rCliente.ListarPorId(id);
        }

        public List<Entidades.Cliente> ListarPorNome(string nome)
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            return rCliente.ListarPorNome(nome);
        }

        public Entidades.Cliente ListarPorEmail(string email)
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            return rCliente.ListarPorEmail(email);
        }
    }
}
