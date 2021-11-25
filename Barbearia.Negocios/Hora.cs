using System;
using System.Collections.Generic;

namespace Barbearia.Negocios
{
    public class Hora
    {
        public List<Entidades.Horas> ListarHoras(DateTime data)
        {
            Dados.Repositorios.RepositorioHora nHora = new Dados.Repositorios.RepositorioHora();
            return nHora.ListarHoras(data);
        }
    }
}
