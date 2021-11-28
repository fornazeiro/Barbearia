using Barbearia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barbearia.Controllers.Admin
{
    public class AdmAgendamentosController : Controller
    {
        // GET: Agendamentos
        public ActionResult Index()
        {
            if ((Session == null || Session.Count == 0))
            {
                Response.Redirect("/Login");
            }

            Negocios.Agendamento nAgendamento = new Negocios.Agendamento();
            var agendamentos = nAgendamento.ListarPorDataHora(null);

            return View(agendamentos);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

                var agenda = nAgendamento.ListarPorId(id);

                return View(agenda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Agendamento agendamento)
        {
            try
            {

                Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

                nAgendamento.Editar(agendamento);
                
                var agenda = nAgendamento.ListarPorDataHora(null);

                return View("Index", agenda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}