using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioLocador : RepositorioBase, ILocacao
    {
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Locacao entidade)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> Listar()
        {
            throw new NotImplementedException();
        }

        public Locacao ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
