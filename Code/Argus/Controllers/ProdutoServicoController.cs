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
    public class ProdutoServicoController : Controller
    {
        //
        // GET: /ProdutoServico/

        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            ProdutoServico produtoservico = new ProdutoServico();
            return View(produtoservico.ListarProdutoServico(pesquisa));
        }

        public ActionResult Relatorio(String pesquisa = "")
        {
            ProdutoServico produtoservico = new ProdutoServico();
            return View(produtoservico.RelatorioProdutoServico(pesquisa));
        }

        public ActionResult Incluir()
        {
            ViewBag.ListarProdutoServico = new SelectList(db.ProdutoServico, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ProdutoServico produtoservico)
        {
            if (ModelState.IsValid)
            {
                produtoservico.Incluir(produtoservico);
                return RedirectToAction("Listar");
            }
            else
                return View(produtoservico);
        }

        public ActionResult Editar(int codigo)
        {
            ProdutoServico produtoservico = db.ProdutoServico.Find(codigo);
            ViewBag.ListarProdutoServico = new SelectList(db.ProdutoServico, "CODIGO", "NOME");
            return View(produtoservico);
        }

        [HttpPost]
        public ActionResult Editar(ProdutoServico produtoservico)
        {
            if (ModelState.IsValid)
            {
                produtoservico.Atualizar(produtoservico);
                return RedirectToAction("Listar");
            }
            else
                return View(produtoservico);
        }

        public ActionResult Eliminar(int codigo)
        {
            ProdutoServico produtoservico = db.ProdutoServico.Find(codigo);
            return View(produtoservico);
        }

        [HttpPost]
        public ActionResult Eliminar(ProdutoServico produtoservico)
        {
            ViewBag.mensagem = "";
            try
            {
                produtoservico.Eliminar(produtoservico);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta produto/serviço.  O sistema tem dados que dependem dele.";
                return View();
            }
        }      

    }
}
