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

        [HttpPost]
        public JsonResult Incluir(Entidades.Cliente cliente)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                cliente.Situacao = true;
                nCliente.Incuir(cliente);

                return Json("Cliente salvo com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
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

        [HttpPost]
        public JsonResult ListarPorEmail(string email)
        {
            Negocios.Cliente nCliente = new Negocios.Cliente();

            try
            {
                var cliente = nCliente.ListarPorEmail(email);

                if (cliente == null || string.IsNullOrEmpty(cliente.Nome))
                {
                    return Json("Cliente não encontrado!", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(cliente, JsonRequestBehavior.AllowGet);
                }
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