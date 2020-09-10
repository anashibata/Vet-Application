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
    public class ExameFisicoItemController : Controller
    {
        //
        // GET: /ExameFisicoItem/

        private Contexto db = new Contexto();

        public ActionResult Listar(int codigo, String pesquisa = "")
        {
            ViewBag.codigoexameFisicoItem = codigo;                
            ExameFisicoItem examefisicoitem = new ExameFisicoItem();
            return View(examefisicoitem.ListarExameFisicoItem(codigo, pesquisa));
        }

        public ActionResult ListarExames()
        {
            return RedirectToAction("Listar", "ExameFisico");
        }

        public ActionResult Incluir(int codigoexamefisico)
        {
            ViewBag.codigoexameFisicoItem = codigoexamefisico;
            ViewBag.ListarExameFisicoItem = new SelectList(db.ExameFisicoItem, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ExameFisicoItem examefisicoitem)
        {
            if (ModelState.IsValid)
            {
                examefisicoitem.Incluir(examefisicoitem);
                return RedirectToAction("Listar", "ExameFisicoItem", new { codigo = examefisicoitem.CODIGO_EXAMEFIS }); 
            }
            else
                return View(examefisicoitem);
        }

        public ActionResult Editar(int codigo)
        {
            ExameFisicoItem examefisicoitem = db.ExameFisicoItem.Find(codigo);
            ViewBag.ListarExameFisicoItem = new SelectList(db.ExameFisicoItem, "CODIGO", "NOME");
            return View(examefisicoitem);
        }

        [HttpPost]
        public ActionResult Editar(ExameFisicoItem examefisicoitem)
        {
            if (ModelState.IsValid)
            {
                examefisicoitem.Atualizar(examefisicoitem);
                return RedirectToAction("Listar", "ExameFisicoItem", new { codigo = examefisicoitem.CODIGO_EXAMEFIS });
            }
            else
                return View(examefisicoitem);
        }

        public ActionResult Eliminar( int codigo)
        {            
            ExameFisicoItem examefisicoitem = db.ExameFisicoItem.Find(codigo);            
            return View(examefisicoitem);
        }

        [HttpPost]
        public ActionResult Eliminar(ExameFisicoItem examefisicoitem)
        {
            ViewBag.mensagem = "";
            ViewBag.codigoexamefis = examefisicoitem.CODIGO_EXAMEFIS;
            try
            {
                examefisicoitem.Eliminar(examefisicoitem);
                return RedirectToAction("Listar", "ExameFisicoItem", new { codigo = examefisicoitem.CODIGO });
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta exame.  O sistema tem dados que dependem dele.";
                return View();
            }
        }
    }
}
