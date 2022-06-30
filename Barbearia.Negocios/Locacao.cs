using System.Collections.Generic;

namespace Barbearia.Negocios
{
    public class Locacao 
    {
        public void Excluir(int id)
        {
            Dados.Repositorios.RepositorioLocacao rLocacao = new Dados.Repositorios.RepositorioLocacao();

            rLocacao.Excluir(id);
        }

        public void Editar(Entidades.Locacao locacao)
        {
            Dados.Repositorios.RepositorioLocacao rLocacao = new Dados.Repositorios.RepositorioLocacao();

            rLocacao.Editar(locacao);
        }

        public void Incuir(Entidades.Locacao locacao)
        {
            Dados.Repositorios.RepositorioLocacao rLocacao = new Dados.Repositorios.RepositorioLocacao();

            rLocacao.Incluir(locacao);
        }

        public List<Entidades.Locacao> Listar()
        {
            Dados.Repositorios.RepositorioLocacao rLocacao = new Dados.Repositorios.RepositorioLocacao();

            return rLocacao.Listar();
        }

        public Entidades.Locacao ListarPorId(int id)
        {
            Dados.Repositorios.RepositorioLocacao rLocacao = new Dados.Repositorios.RepositorioLocacao();

            return rLocacao.ListarPorId(id);
        }

        public List<Entidades.Locacao> ListarPorNome(string nome)
        {
            Dados.Repositorios.RepositorioLocacao rLocacao = new Dados.Repositorios.RepositorioLocacao();

            return rLocacao.ListarPorNome(nome);
        }
    }
}
