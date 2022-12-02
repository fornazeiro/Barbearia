
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbearia.Entidades
{
    public class Retorno<T> where T : class, new()
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T ObjetoRetorno { get; set; } = new T();
        public bool Autenticado { get; set; }
        public IList<string> Roles { get; set; }

    }
}
