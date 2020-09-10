using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argus.Models;
using System.IO;
using System.Web.Helpers;

namespace Argus.Controllers
{
    [Authorize]
    public class CidadeController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            Cidade cidade = new Cidade();
            return View(cidade.ListarCidade(pesquisa));
        }

      
        public ActionResult Incluir()
        {
            ViewBag.ListarEstado = new SelectList(db.Estado, "CODIGO", "NOME");            
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Incluir(cidade);

                return RedirectToAction("Listar");
            }
            else
                return View(cidade);
        }
        
        public ActionResult Editar(int codigo)
        {
            Cidade cidade = db.Cidade.Find(codigo);
            ViewBag.ListarEstado = new SelectList(db.Estado, "CODIGO", "NOME");
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Atualizar(cidade);
                return RedirectToAction("Listar");
            }
            else
                return View(cidade);
        }

        
        public ActionResult Eliminar(int codigo)
        {
            Cidade cidade = db.Cidade.Find(codigo);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Eliminar(Cidade cidade)
        {
            ViewBag.mensagem = "";
            try
            {
                cidade.Eliminar(cidade);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta cidade. Ela possui informações no sistema que dependem dela.";
                return View();
            }
        }
               
    }
}
