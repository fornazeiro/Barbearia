using Barbearia.Entidades;
using Barbearia.Shared;
using Newtonsoft.Json;
using System;
using System.Configuration;
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
        public async Task Logon(Entidades.Login login)
        {
            //string Baseurl = "api.newtisolutions.com.br/";
            string Baseurl = ConfigurationManager.AppSettings.Get("BasicApiUrl");
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Senha))
                Response.Redirect("/Login");
            else
            {

                Negocios.Login nLogin = new Negocios.Login();

                login.Senha = login.Senha.cryptographyPass();

                //var usuario = nLogin.Logon(login);
                var user = new Usuario();

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    var ResponseTask = await client.PostAsync("api/Login/Logar", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));
                    //Checking the response is successful or not which is sent using HttpClient
                    if (ResponseTask.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = ResponseTask.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        var retorno = JsonConvert.DeserializeObject<Retorno<Usuario>>(EmpResponse);

                        user = retorno.ObjetoRetorno.ConvertToObject<Usuario>();
                    }                     
                }

                if (user != null && user.Id > 0)
                {
                    Session.Add("usuario", user.Nome);
                    Session.Add("email", user.Email);
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