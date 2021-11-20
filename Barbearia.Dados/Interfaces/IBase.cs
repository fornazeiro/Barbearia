using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dados.Interfaces
{
    public interface IBase<T> where T : class
    {
        void Incluir(T entidade);
        void Excuir(int Id);
        List<T> Listar();
        List<T> ListarPorId(int Id);
    }
}
