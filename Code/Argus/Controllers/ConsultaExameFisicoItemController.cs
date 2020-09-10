using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argus.Models;
using System.IO;
using System.Web.Helpers;

namespace Argus.Controllers
{
    public class ConsultaExameFisicoItemController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(int codigo, int codigoconsulta, String pesquisa = "")
        {
            ViewBag.CodigoConsulta = codigoconsulta.ToString() ;
            ConsultaExameFisicoItem consultaexamefisicoitem = new ConsultaExameFisicoItem();
            return View(consultaexamefisicoitem.ListarConsultaExameFisicoItem(codigo));
        }        

        [HttpPost]
        public ActionResult Listar(int[] CODIGO_CONEXAFIS, int[] CODIGO_EXAMEFISITEM, String[] RESULTADO, int codigocon)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i <= CODIGO_CONEXAFIS.Count()-1; i++)
                {
                    ConsultaExameFisicoItem consultaexamefisicoitem = new ConsultaExameFisicoItem();
                    consultaexamefisicoitem.CODIGO_CONEXAFIS = CODIGO_CONEXAFIS[i];
                    consultaexamefisicoitem.CODIGO_EXAMEFISITEM = CODIGO_EXAMEFISITEM[i];
                    consultaexamefisicoitem.RESULTADO = RESULTADO[i];
                    consultaexamefisicoitem.Atualizar(consultaexamefisicoitem);
                }
                return RedirectToAction("Listar", "ConsultaExameFisico", new { codigoconsulta = codigocon });
            }           
            else
                return View();

        }

    }
}
