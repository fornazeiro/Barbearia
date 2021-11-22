using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class AgendamentoController : Controller
    {
        // GET: Agendamento
        public ActionResult Index()
        {
            //if (agendamento != null)
           // {
           //     Incluir(agendamento);
           // }

            return View();
        }

        [HttpPost]
        public JsonResult Incluir(Entidades.Agendamento agendamento)
        {
            Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

            agendamento.Situacao = true;
            nAgendamento.Incluir(agendamento);

            return null;
        }

        private JsonResult Listar(Entidades.Agendamento agendamento)
        {
            Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

            nAgendamento.ListarPorData(agendamento.DataAgendamento);

            return null;
        }
    }
}