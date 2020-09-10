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
    public class EspecieCheckupController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            EspecieCheckup especiecheckup = new EspecieCheckup();
            return View(especiecheckup.ListarEspecieCheckup(pesquisa));
        }

        public ActionResult Incluir()
        {
            ViewBag.ListarEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(EspecieCheckup especiecheckup)
        {
            if (ModelState.IsValid)
            {
                especiecheckup.Incluir(especiecheckup);                
                return RedirectToAction("Listar");
            }
            else
                return View(especiecheckup);
        }

        public ActionResult Editar(int codigo)
        {
            EspecieCheckup especiecheckup = db.EspecieCheckup.Find(codigo);
            ViewBag.ListarEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View(especiecheckup);
        }

        [HttpPost]
        public ActionResult Editar(EspecieCheckup especiecheckup)
        {
            if (ModelState.IsValid)
            {
                especiecheckup.Atualizar(especiecheckup);
                return RedirectToAction("Listar");
            }
            else
                return View(especiecheckup);
        }

        public ActionResult Eliminar(int codigo)
        {
            EspecieCheckup especiecheckup = db.EspecieCheckup.Find(codigo);
            return View(especiecheckup);
        }

        [HttpPost]
        public ActionResult Eliminar(EspecieCheckup especiecheckup)
        {
            especiecheckup.Eliminar(especiecheckup);
            return RedirectToAction("Listar");
        }
    }
}
