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
    public class ExameFisicoController : Controller
    {
        //
        // GET: /ExameFisico/

        
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            ExameFisico examefisico = new ExameFisico();
            return View(examefisico.ListarExameFisico(pesquisa));
        }

        public ActionResult ExameFisicoItem(int codigo)
        {
            return RedirectToAction("Listar", "ExameFisicoItem", new { codigo = codigo });
        }

        public ActionResult Incluir()
        {
            ViewBag.ListarExameFisico = new SelectList(db.ExameFisico, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ExameFisico examefisico)
        {
            if (ModelState.IsValid)
            {
                examefisico.Incluir(examefisico);

                
                return RedirectToAction("Listar");
            }
            else
                return View(examefisico);
        }

        public ActionResult Editar(int codigo)
        {
            ExameFisico examefisico = db.ExameFisico.Find(codigo);
            ViewBag.ListarExameFisico = new SelectList(db.ExameFisico, "CODIGO", "NOME");
            return View(examefisico);
        }

        [HttpPost]
        public ActionResult Editar(ExameFisico examefisico)
        {
            if (ModelState.IsValid)
            {
                examefisico.Atualizar(examefisico);
                return RedirectToAction("Listar");
            }
            else
                return View(examefisico);
        }

        public ActionResult Eliminar(int codigo)
        {
            ExameFisico examefisico = db.ExameFisico.Find(codigo);
            return View(examefisico);
        }

        [HttpPost]
        public ActionResult Eliminar(ExameFisico examefisico)
        {
            ViewBag.mensagem = "";
            try
            {
                examefisico.Eliminar(examefisico);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar este exame. O sistema tem dados que dependem dele.";
                return View();
            }
        }
    }
}
