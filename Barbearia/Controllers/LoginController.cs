using Barbearia.Entidades;
using Barbearia.Shared;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Barbearia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session.Add("App", "Barber");
            return View();
        }

        [HttpPost]
        public async Task Logon(Login login)
        {
            // string Baseurl = "api.newtisolutions.com.br/";
            string Baseurl = "https://localhost:5001/";

            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Senha))
                Response.Redirect("/Login");
            else
            {

                //Negocios.Login nLogin = new Negocios.Login();

                login.Senha = login.Senha.cryptographyPass();

                var usuario = new Usuario();

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.PostAsync("api/login", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        var user = JsonConvert.DeserializeObject<UsuarioObj>(EmpResponse);

                        usuario = user.Usuario;
                    }
                }

                if (usuario != null && usuario.Id > 0)
                {
                    Session.Add("usuario", usuario.Nome);
                    Session.Add("email", usuario.Email);
                    Response.Redirect("/AdmAgendamentos");
                }
                else
                {
                    Response.Redirect("/Login");
                }
            }
        }
    }
}