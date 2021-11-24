﻿using System;
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
    }
}