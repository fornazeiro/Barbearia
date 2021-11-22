using Barbearia.Shared;
using System.Web.Mvc;


namespace Barbearia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
           
            return View();
        }

        public void Logon(Entidades.Login login)
        {
            Negocios.Login nLogin = new Negocios.Login();

#if DEBUG
            {
                string senha = "Dy@515286";
                login.Email = "nafornazeiro@gmail.com";
                login.Senha = senha.cryptographyPass();
            }
#endif

            var usuario = nLogin.Logon(login);

            if (usuario != null)
            {
                Session["usuario"] = usuario.Nome;
                Session["email"] = usuario.Email;
            }

            Response.Redirect("/Admin");
        }        
    }
}