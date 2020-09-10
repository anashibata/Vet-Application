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
    public class MotivoBaixaController : Controller
    {
         private Contexto db = new Contexto();
        //
        // GET: /MotivoBaixa/

        public ActionResult Listar(String pesquisa = "")
        {
            MotivoBaixa motivobaixa = new MotivoBaixa();
            return View(motivobaixa.ListarMotivoBaixa(pesquisa));
        }


        public ActionResult Incluir()
        {
            ViewBag.ListarMotivoBaixa = new SelectList(db.MotivoBaixa, "CODIGO", "NOME");
            return View();
        }
        
        [HttpPost]
        public ActionResult Incluir(MotivoBaixa motivobaixa)
        {
            if (ModelState.IsValid)
            {
                motivobaixa.Incluir(motivobaixa);

                return RedirectToAction("Listar");
            }
            else
                return View(motivobaixa);
        }
                
        public ActionResult Editar(int codigo)
        {
            MotivoBaixa motivobaixa = db.MotivoBaixa.Find(codigo);
            ViewBag.ListarMotivoBaixa = new SelectList(db.MotivoBaixa, "CODIGO", "NOME");
            return View(motivobaixa);
        }

        [HttpPost]
        public ActionResult Editar(MotivoBaixa motivobaixa)
        {
            if (ModelState.IsValid)
            {
                motivobaixa.Atualizar(motivobaixa);
                return RedirectToAction("Listar");
            }
            else
                return View(motivobaixa);
        }

        public ActionResult Eliminar(int codigo)
        {
            MotivoBaixa motivobaixa = db.MotivoBaixa.Find(codigo);
            return View(motivobaixa);
        }

        [HttpPost] 
        public ActionResult Eliminar(MotivoBaixa motivobaixa)
        {
            motivobaixa.Eliminar(motivobaixa);
            return RedirectToAction("Listar");
        }        
    }


    
}
