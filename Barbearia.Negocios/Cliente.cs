using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Negocios
{
    public class Cliente
    {
        public void Incuir(Entidades.Cliente cliente)
        {
            Dados.Repositorios.RepositorioCliente rCliente = new Dados.Repositorios.RepositorioCliente();

            rCliente.Incluir(cliente);
        }
    }
}
