using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System.Collections.Generic;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioCliente : RepositorioBase, IClientes
    {
        public void Excuir(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Cliente entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> Listar()
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ListarPorId(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
