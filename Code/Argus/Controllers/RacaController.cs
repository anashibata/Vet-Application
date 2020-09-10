using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argus.Models;
using System.IO;

namespace Argus.Controllers
{
    [Authorize]
    public class RacaController : Controller
    {

        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            Raca raca = new Raca();
            return View(raca.ListarRaca(pesquisa));
        }

        public ActionResult Relatorio(String pesquisa = "")
        {
            Raca raca = new Raca();
            return View(raca.ListarRaca(pesquisa));
        }

        public ActionResult Incluir()
        {

            ViewBag.ListaEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Raca raca)
        {
            if (ModelState.IsValid)
            {
                raca.Incluir(raca);


                return RedirectToAction("Listar");
            }
            else
                return View(raca);
        }

        public ActionResult Editar(int codigo)
        {
            Raca raca = db.Raca.Find(codigo);

            ViewBag.ListaEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View(raca);
        }

        [HttpPost]
        public ActionResult Editar(Raca raca)
        {
            if (ModelState.IsValid)
            {
                raca.Atualizar(raca);
                return RedirectToAction("Listar");
            }
            else
                return View(raca);
        }

        public ActionResult Eliminar(int codigo)
        {
                Raca raca = db.Raca.Find(codigo);
                return View(raca);
        }

        [HttpPost]
        public ActionResult Eliminar(Raca raca)
        {
            ViewBag.mensagem = "";
            try
            {
                raca.Eliminar(raca);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta raça.  O sistema tem dados que dependem dela.";
                return View();
            }
        }
    }

}
