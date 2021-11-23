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
            try
            {
                Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

                var agenda = ListarPorDataHora(agendamento);

                if (agenda == null || agenda.Count == 0)
                {
                    agendamento.Situacao = true;
                    nAgendamento.Incluir(agendamento);
                }
                else
                {
                    throw new Exception("já existe um agendamento com esses dados.");
                }

                return Json("Agendamento efetuado com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Entidades.Agendamento> ListarPorDataHora(Entidades.Agendamento agendamento)
        {
            Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

            var agendamentos = nAgendamento.ListarPorDataHora(agendamento);

            return agendamentos;
        }

        //[HttpPost]
        public JsonResult ListarCalendario()
        {
            Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

            var agendamentos = nAgendamento.ListarCalendario();

            return Json(agendamentos, JsonRequestBehavior.AllowGet);
        }
    }
}