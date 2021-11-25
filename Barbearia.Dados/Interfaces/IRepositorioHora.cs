using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dados.Interfaces
{
    public interface IRepositorioHora
    {
        List<Entidades.Horas> ListarHoras(DateTime data);
    }
}
