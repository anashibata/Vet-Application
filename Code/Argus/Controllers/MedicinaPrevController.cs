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
    public class MedicinaPrevController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            MedicinaPrev medicinaprev = new MedicinaPrev();
            return View(medicinaprev.ListarMedicinaPrev(pesquisa));
        }

        public ActionResult Incluir()
        {
            ViewBag.ListarRaca = new SelectList(db.Raca, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(MedicinaPrev medicinaprev)
        {
            if (ModelState.IsValid)
            {
                medicinaprev.Incluir(medicinaprev);


                return RedirectToAction("Listar");
            }
            else
                return View(medicinaprev);
        }

        public ActionResult Editar(int codigo)
        {
            MedicinaPrev medicinaprev = db.MedicinaPrev.Find(codigo);
            ViewBag.ListarRaca = new SelectList(db.Raca, "CODIGO", "NOME");
            return View(medicinaprev);
        }

        [HttpPost]
        public ActionResult Editar(MedicinaPrev medicinaprev)
        {
            if (ModelState.IsValid)
            {
                medicinaprev.Atualizar(medicinaprev);
                return RedirectToAction("Listar");
            }
            else
                return View(medicinaprev);
        }

        public ActionResult Eliminar(int codigo)
        {
            MedicinaPrev medicinaprev = db.MedicinaPrev.Find(codigo);
            return View(medicinaprev);
        }

        [HttpPost]
        public ActionResult Eliminar(MedicinaPrev medicinaprev)
        {
            medicinaprev.Eliminar(medicinaprev);
            return RedirectToAction("Listar");
        }
    }
}
