using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if ((Session == null || Session.Count == 0))
            {
                Response.Redirect("/Login");
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