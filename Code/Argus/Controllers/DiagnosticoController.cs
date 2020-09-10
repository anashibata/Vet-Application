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
    public class DiagnosticoController : Controller
    {
       private Contexto db = new Contexto();
        //
        // GET: /Diagnostico/

        public ActionResult Listar(String pesquisa = "")
        {
            Diagnostico diagnostico = new Diagnostico();
            return View(diagnostico.ListarDiagnostico(pesquisa));
        }


        public ActionResult Incluir()
        {
            ViewBag.ListarDiagnostico = new SelectList(db.Diagnostico, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                diagnostico.Incluir(diagnostico);
                return RedirectToAction("Listar");
            }
            else
                return View(diagnostico);
        }

        public ActionResult Editar(int codigo)
        {
            Diagnostico diagnostico = db.Diagnostico.Find(codigo);
            ViewBag.ListarDiagnostico = new SelectList(db.Diagnostico, "CODIGO", "NOME");
            return View(diagnostico);
        }

        [HttpPost]
        public ActionResult Editar(Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                diagnostico.Atualizar(diagnostico);
                return RedirectToAction("Listar");
            }
            else
                return View(diagnostico);
        }

        public ActionResult Eliminar(int codigo)
        {
            Diagnostico diagnostico = db.Diagnostico.Find(codigo);
            return View(diagnostico);
        }

        [HttpPost]
        public ActionResult Eliminar(Diagnostico diagnostico)
        {
            diagnostico.Eliminar(diagnostico);
            return RedirectToAction("Listar");
        }
    }



}
