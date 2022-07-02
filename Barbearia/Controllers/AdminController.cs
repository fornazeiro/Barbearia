using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if ((Session == null || Session.Count <= 1))
            {
                Response.Redirect("/Login");
            }
            else
            {
                Response.Redirect("/AdmAgendamentos");
            }

            return View();
        }

        public void Logof()
        {
            if (Session != null && Session.Count > 0)
            {
                Session.Abandon();
                Response.Redirect("/Login");
            }
        }
    }
}