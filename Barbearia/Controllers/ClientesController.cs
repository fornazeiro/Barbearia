using System;
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

        public JsonResult Listar(Entidades.Cliente cliente)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                nCliente.Listar();

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult ListarPorId(int id)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                nCliente.ListarPorId(id);

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult ListarPorNome(string nome)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                nCliente.ListarPorNome(nome);

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Excluir(int id)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                nCliente.Excluir(id);

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}