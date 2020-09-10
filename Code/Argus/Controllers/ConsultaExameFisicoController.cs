using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argus.Models;
using System.IO;

namespace Argus.Controllers
{
    public class ConsultaExameFisicoController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(int codigoconsulta, String pesquisa = "")
        {
            ViewBag.CodigoConsulta = codigoconsulta;
            ConsultaExameFisico consultaexamefisico = new ConsultaExameFisico();
            return View(consultaexamefisico.ListarConsultaExameFisico(codigoconsulta));
        }

        public ActionResult Incluir(int codigoconsulta)
        {
            ViewBag.CodigoConsulta = codigoconsulta;
            ViewBag.ListaExameFisico = new SelectList(db.ExameFisico, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ConsultaExameFisico consultaexamefisico)
        {
            if (ModelState.IsValid)
            {
                int codigo = consultaexamefisico.Incluir(consultaexamefisico);
                consultaexamefisico.IncluirConsultaExameItem(consultaexamefisico.CODIGO, consultaexamefisico.CODIGO_EXAMEFIS);
                return RedirectToAction("Listar", "ConsultaExameFisico", new { codigoconsulta = consultaexamefisico.CODIGO_CONSULTA });
            }
            else
                return View(consultaexamefisico);
        }

        public ActionResult Editar(int codigo)
        {
            ConsultaExameFisico consultaexamefisico = db.ConsultaExameFisico.Find(codigo);
            ViewBag.ListaExameFisico = new SelectList(db.ExameFisico, "CODIGO", "NOME");
            return View(consultaexamefisico);
        }

        [HttpPost]
        public ActionResult Editar(ConsultaExameFisico consultaexamefisico)
        {
            if (ModelState.IsValid)
            {
                consultaexamefisico.Atualizar(consultaexamefisico);
                return RedirectToAction("Listar", "ConsultaExameFisico", new { codigoconsulta = consultaexamefisico.CODIGO_CONSULTA });
            }
            else
                return View(consultaexamefisico);

        }

        public ActionResult Eliminar(int codigo)
        {
            ConsultaExameFisico consultaexamefisico = db.ConsultaExameFisico.Find(codigo);
            return View(consultaexamefisico);
        }

        [HttpPost]
        public ActionResult Eliminar(ConsultaExameFisico consultaexamefisico)
        {
            consultaexamefisico.Eliminar(consultaexamefisico);
            return RedirectToAction("Listar", "ConsultaExameFisico", new { codigoconsulta = consultaexamefisico.CODIGO_CONSULTA });
        }
    }
}
