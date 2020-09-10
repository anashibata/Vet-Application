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
    public class PessoaController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            Pessoa pessoa = new Pessoa();
            return View(pessoa.ListarPessoa(pesquisa));
        }

   

        public ActionResult Incluir()
        {
            ViewBag.ListarCidade = new SelectList(db.Cidade, "CODIGO", "NOME");
            ViewBag.DataCadastro = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.Incluir(pessoa);


                return RedirectToAction("Listar");
            }
            else
                return View(pessoa);
        }
       

        public ActionResult Editar(int codigo)
        {
            Pessoa pessoa = db.Pessoa.Find(codigo);
            ViewBag.ListarCidade = new SelectList(db.Cidade, "CODIGO", "NOME");
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.Atualizar(pessoa);
                return RedirectToAction("Listar");
            }
            else
                return View(pessoa);
        }

        public ActionResult Eliminar(int codigo)
        {
            Pessoa pessoa = db.Pessoa.Find(codigo);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Eliminar(Pessoa pessoa)
        {
            ViewBag.mensagem = "";
            try
            {
                pessoa.Eliminar(pessoa);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta pessoa.  O sistema tem dados que dependem dela.";
                return View();
            }
        }


        

    }
}
