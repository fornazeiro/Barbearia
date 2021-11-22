using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            if ((Session == null || Session.Count == 0))
            {
                Response.Redirect("/Login");
            }

            return View();
        }

        public JsonResult Incluir(Entidades.Cliente cliente)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                nCliente.Incuir(cliente);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}