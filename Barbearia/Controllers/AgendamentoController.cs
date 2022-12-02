using Barbearia.Entidades;
using Barbearia.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class AgendamentoController : Controller
    {
        // GET: Agendamento
        public async Task<ActionResult> Index()
        {
            Negocios.Locacao nLocacao = new Negocios.Locacao();
            //if (agendamento != null)
            // {
            //     Incluir(agendamento);
            // }

            ViewBag.Locacoes = nLocacao.Listar();
            ViewBag.Horas = await  ListarHoras();


            return View();
        }


        [HttpPost]
        public async Task<JsonResult> Incluir(Entidades.Agendamento agendamento)
        {
            try
            {
                Negocios.Agendamento nAgendamento = new Negocios.Agendamento();

                var agendas = await ListarPorDataHora(agendamento);

                if (agendas == null || agendas.Count() == 0)
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

        [HttpPost]
        public async Task<List<Entidades.Agendamento>> ListarPorDataHora(Entidades.Agendamento agendamento)
        {
            string Baseurl = ConfigurationManager.AppSettings.Get("BasicApiUrl");

            List<Agendamento> agendamentos = new List<Agendamento>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                var ResponseTask = await client.PostAsync("api/Agendamento/ListarPorDataHora", new StringContent(JsonConvert.SerializeObject(agendamento), Encoding.UTF8, "application/json"));
                //Checking the response is successful or not which is sent using HttpClient
                if (ResponseTask.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = ResponseTask.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var retorno = JsonConvert.DeserializeObject<Retorno<List<Agendamento>>>(EmpResponse);

                    agendamentos = retorno.ObjetoRetorno.ConvertToObject<List<Agendamento>>();
                }

            }

            return agendamentos;
        }

        [HttpGet]
        public async Task<PartialViewResult> ListarPorData(string data)
        {
            string Baseurl = ConfigurationManager.AppSettings.Get("BasicApiUrl");

            List<Agendamento> agendamentos = new List<Agendamento>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                var ResponseTask = await client.PostAsync("api/Agendamento/ListarPorData", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
                //Checking the response is successful or not which is sent using HttpClient
                if (ResponseTask.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = ResponseTask.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var retorno = JsonConvert.DeserializeObject<Retorno<List<Agendamento>>>(EmpResponse);

                    agendamentos = retorno.ObjetoRetorno.ConvertToObject<List<Agendamento>>();
                }

            }

            return PartialView("_Agendamentos", agendamentos);
        }

        //[HttpPost]
        public async Task<JsonResult> ListarCalendario(int IdLocacao = 1)
        {
            string Baseurl = ConfigurationManager.AppSettings.Get("BasicApiUrl");

            List<Calendario> calendarios = new List<Calendario>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                var ResponseTask = await client.PostAsync("api/Agendamento/ListarCalendario", new StringContent(JsonConvert.SerializeObject(IdLocacao), Encoding.UTF8, "application/json"));
                //Checking the response is successful or not which is sent using HttpClient
                if (ResponseTask.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = ResponseTask.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var retorno = JsonConvert.DeserializeObject<Retorno<List<Calendario>>>(EmpResponse);

                    calendarios = retorno.ObjetoRetorno.ConvertToObject<List<Calendario>>();
                }

            }

            return Json(calendarios, JsonRequestBehavior.AllowGet);
        }

        public async Task<List<Horas>> ListarHoras()
        {
            string Baseurl = ConfigurationManager.AppSettings.Get("BasicApiUrl");

            List<Horas> horas = new List<Horas>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                var ResponseTask = await client.PostAsync("api/Agendamento/ListarHoras", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
                //Checking the response is successful or not which is sent using HttpClient
                if (ResponseTask.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = ResponseTask.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var retorno = JsonConvert.DeserializeObject<Retorno<List<Horas>>>(EmpResponse);

                    horas = retorno.ObjetoRetorno.ConvertToObject<List<Horas>>();
                }
            }

            return horas;
        }
    }
}