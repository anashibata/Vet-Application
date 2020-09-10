using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argus.Models;
using System.IO;

namespace Argus.Controllers
{
    [Authorize]
    public class VeterinarioController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "") 
        {            
            Veterinario veterinario = new Veterinario();
            return View(veterinario.ListaVeterinarios(pesquisa));            
        }

        public ActionResult Incluir()
        {
            ViewBag.ListaPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            return View();
        }
        
        [HttpPost]
        public ActionResult Incluir(Veterinario Veterinario)
        {
            if (ModelState.IsValid)
            {
                Veterinario.Incluir(Veterinario);
                return RedirectToAction("Listar");
            }
            else
                return View(Veterinario);
        }
                
        public ActionResult Editar(int codigo)
        {
            Veterinario Veterinario = db.Veterinario.Find(codigo);
            ViewBag.ListaPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            return View(Veterinario);
        }

        [HttpPost]
        public ActionResult Editar(Veterinario Veterinario)
        {
            if (ModelState.IsValid)
            {
                Veterinario.Atualizar(Veterinario);
                return RedirectToAction("Listar");
            }
            else
                return View(Veterinario);
        }

        public ActionResult Eliminar(int codigo)
        {
            Veterinario Veterinario = db.Veterinario.Find(codigo);
            return View(Veterinario);
        }

        [HttpPost] 
        public ActionResult Eliminar(Veterinario Veterinario)
        {
            ViewBag.mensagem = "";
            try
            {
                Veterinario.Eliminar(Veterinario);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar este veterinário.  O sistema tem dados que dependem dele.";
                return View();
            }
        }        
    }

}
