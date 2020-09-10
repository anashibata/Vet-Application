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
    public class EspecieDoencaController : Controller
    {
        
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            EspecieDoenca especiedoenca = new EspecieDoenca();
            return View(especiedoenca.ListarEspecieDoenca(pesquisa));
        }

        public ActionResult Relatorio(String pesquisa = "")
        {
            EspecieDoenca especiedoenca = new EspecieDoenca();
            return View(especiedoenca.RelatorioEspecieDoenca(pesquisa));
        }


        public ActionResult Incluir()
        {           
            ViewBag.ListaEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(EspecieDoenca especiedoenca)
        {
            if (ModelState.IsValid)
            {
                especiedoenca.Incluir(especiedoenca);
                return RedirectToAction("Listar");
            }
            else
                return View(especiedoenca);
        }

        public ActionResult Editar(int codigo)
        {
            EspecieDoenca especiedoenca = db.EspecieDoenca.Find(codigo);                       
            ViewBag.ListaEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View(especiedoenca);
        }

        [HttpPost]
        public ActionResult Editar(EspecieDoenca especiedoenca)
        {
            if (ModelState.IsValid)
            {
                especiedoenca.Atualizar(especiedoenca);
                return RedirectToAction("Listar");
            }
            else
                return View(especiedoenca);
        }

        public ActionResult Eliminar(int codigo)
        {
            EspecieDoenca especiedoenca = db.EspecieDoenca.Find(codigo);
            return View(especiedoenca);
        }

        [HttpPost]
        public ActionResult Eliminar(EspecieDoenca especiedoenca)
        {
            especiedoenca.Eliminar(especiedoenca);
            return RedirectToAction("Listar");
        }
    }
        
}
