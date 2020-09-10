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
    public class ExameReferenciaController : Controller
    {
         private Contexto db = new Contexto();
        //
        // GET: /ExameReferencia/

        public ActionResult Listar(String pesquisa = "")
        {
            ExameReferencia examereferencia = new ExameReferencia();
            return View(examereferencia.ListarExameReferencia(pesquisa));
        }


        public ActionResult Incluir()
        {
            ViewBag.ListaeExames = new SelectList(db.Exame, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ExameReferencia examereferencia)
        {
            if (ModelState.IsValid)
            {
                examereferencia.Incluir(examereferencia);
                return RedirectToAction("Listar");
            }
            else
                return View(examereferencia);
        }

        public ActionResult Editar(int codigo, int codigoitem)
        {
            ExameReferencia examereferencia = db.ExameReferencia.Find(codigo, codigoitem);
            ViewBag.ListaeExames = new SelectList(db.Exame, "CODIGO", "NOME");
            return View(examereferencia);
        }

        [HttpPost]
        public ActionResult Editar(ExameReferencia examereferencia)
        {
            if (ModelState.IsValid)
            {
                examereferencia.Atualizar(examereferencia);
                return RedirectToAction("Listar");
            }
            else
                return View(examereferencia);
        }

        public ActionResult Eliminar(int codigo, int codigoitem)
        {
            ExameReferencia examereferencia = db.ExameReferencia.Find(codigo, codigoitem);
            return View(examereferencia);
        }

        [HttpPost]
        public ActionResult Eliminar(ExameReferencia examereferencia)
        {
            examereferencia.Eliminar(examereferencia);
            return RedirectToAction("Listar");
        }
    }



}
