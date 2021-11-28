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
        void Excluir(int id);
        List<T> Listar();
        T ListarPorId(int id);
        List<T> ListarPorNome(string nome);
    }
}
