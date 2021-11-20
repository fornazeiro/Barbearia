using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Collections.Generic;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioUsuario : RepositorioBase, IUsuarios
    {
        public void Excuir(int Id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
