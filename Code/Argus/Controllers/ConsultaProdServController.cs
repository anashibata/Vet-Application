using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argus.Models;
using System.IO;

namespace Argus.Controllers
{
    public class ConsultaProdServController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(int codigoconsulta, String pesquisa = "")
        {
            ViewBag.CodigoConsulta = codigoconsulta;
            ConsultaProdServ consultaprodserv = new ConsultaProdServ();
            return View(consultaprodserv.ListaConsultas(codigoconsulta));            
        }

        public ActionResult Relatorio(String pesquisa = "")
        {
            ConsultaProdServ consultaprodserv = new ConsultaProdServ();
            return View(consultaprodserv.Relatorio());
        }

        public ActionResult Incluir(int codigoconsulta)
        {
            ViewBag.CodigoConsulta = codigoconsulta;
            ViewBag.ListaProdServ = new SelectList(db.ProdutoServico, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ConsultaProdServ consultaprodserv)
        {
            if (ModelState.IsValid)
            {
                consultaprodserv.Incluir(consultaprodserv);
                return RedirectToAction("Listar", "ConsultaProdServ", new { codigoconsulta = consultaprodserv.CODIGO_CONSULTA });
            }
            else
                return View(consultaprodserv);
        }

        public ActionResult Editar(int codigo)
        {
            ConsultaProdServ consultaprodserv = db.ConsultaProdServ.Find(codigo);
            ViewBag.ListaProdServ = new SelectList(db.ProdutoServico, "CODIGO", "NOME");
            return View(consultaprodserv);
        }

        [HttpPost]
        public ActionResult Editar(ConsultaProdServ consultaprodserv)
        {
            if (ModelState.IsValid)
            {
                consultaprodserv.Atualizar(consultaprodserv);
                return RedirectToAction("Listar", "ConsultaProdServ", new { codigoconsulta = consultaprodserv.CODIGO_CONSULTA });
            }
            else
                return View(consultaprodserv);

        }

        public ActionResult Eliminar(int codigo)
        {
            ConsultaProdServ consultaprodserv = db.ConsultaProdServ.Find(codigo);
            return View(consultaprodserv);
        }

        [HttpPost]
        public ActionResult Eliminar(ConsultaProdServ consultaprodserv)
        {
            consultaprodserv.Eliminar(consultaprodserv);
            return RedirectToAction("Listar", "ConsultaProdServ", new { codigoconsulta = consultaprodserv.CODIGO_CONSULTA });
        }

    }
}
