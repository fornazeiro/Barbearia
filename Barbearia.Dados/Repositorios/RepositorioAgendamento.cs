using Barbearia.Dados.Interfaces;
using Barbearia.Entidades;
using System;
using System.Collections.Generic;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioAgendamento : RepositorioBase, IAgendamentos
    {
        public void Excuir(int Id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Agendamento entidade)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
