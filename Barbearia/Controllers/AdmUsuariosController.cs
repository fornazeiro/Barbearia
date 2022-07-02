using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class AdmUsuariosController : Controller
    {
        // GET: AdmUsuarios
        public ActionResult Index()
        {
            if ((Session == null || Session.Count <= 1))
            {
                Response.Redirect("/Login");
            }

            return View();
        }
    }
}