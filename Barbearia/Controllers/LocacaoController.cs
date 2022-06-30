using Barbearia.Entidades;
using System;
using System.Web.Mvc;

namespace Barbearia.Controllers
{
    public class LocacaoController : Controller
    {
        // GET: Locacao
        public ActionResult Index()
        {
            if ((Session == null || Session.Count == 0))
            {
                Response.Redirect("/Login");
            }

            Negocios.Locacao nLocacao = new Negocios.Locacao();
            var locacoes = nLocacao.Listar();

            return View(locacoes);
        }

        public ActionResult Edit(int id, Locacao locacao)
        {
            Negocios.Locacao nLocacao = new Negocios.Locacao();
            locacao = nLocacao.ListarPorId(id);

            return View(locacao);
        }

        [HttpPost]
        public JsonResult Edit(Locacao locacao)
        {
            Negocios.Locacao nLocacao = new Negocios.Locacao();

            try
            {
                nLocacao.Editar(locacao);

                return Json("Locação salva com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Create()
        {
            Locacao locacao = new Locacao();
            return View(locacao);
        }

        [HttpPost]
        public JsonResult Create(Locacao locacao)
        {
            Negocios.Locacao nLocacao = new Negocios.Locacao();

            try
            {
                locacao.Situacao = true;
                nLocacao.Incuir(locacao);

                return Json("Locação salva com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}