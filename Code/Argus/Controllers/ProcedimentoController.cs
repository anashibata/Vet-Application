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
    [Authorize]
    public class ProcedimentoController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            Procedimento procedimento = new Procedimento();
            return View(procedimento.ListaProcedimentos(pesquisa));
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Procedimento procedimento, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {                
                procedimento.Incluir(procedimento);
                return RedirectToAction("Listar");
            }
            else
                return View(procedimento);
        }

        public ActionResult Editar(int codigo)
        {
            Procedimento procedimento = db.Procedimento.Find(codigo);
            return View(procedimento);
        }

        [HttpPost]
        public ActionResult Editar(Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                procedimento.Atualizar(procedimento);
                return RedirectToAction("Listar");
            }
            else
                return View(procedimento);
        }

        public ActionResult Eliminar(int codigo)
        {
            Procedimento procedimento = db.Procedimento.Find(codigo);
            return View(procedimento);
        }

        [HttpPost]
        public ActionResult Eliminar(Procedimento procedimento)
        {
            procedimento.Eliminar(procedimento);
            return RedirectToAction("Listar");
        }

        public ActionResult Imprimir(int codigo=0, int codigoanimal=0)
        {
            ViewBag.ListaAnimal = new SelectList(db.Animal, "CODIGO", "NOME");
            Procedimento procedimento = db.Procedimento.Find(codigo);
            if (codigoanimal != 0)
            {
                Animal animal = db.Animal.Find(codigoanimal);
                ViewBag.CodigoAnimal = animal.CODIGO.ToString();
                ViewBag.NomeAnimal = animal.NOME;
                ViewBag.DataNascimento = animal.DT_NASCIMENTO.ToString();
                ViewBag.NomeCliente = animal.Cliente.Pessoa.NOME;
                if (animal.Veterinario != null) { 
                    ViewBag.NomeVeterinario = animal.Veterinario.Pessoa.NOME;
                    ViewBag.CRMV = animal.Veterinario.CRMV;
                } 
                else { 
                    ViewBag.NomeVeterinario = "";
                    ViewBag.CRMV = "";
                }
                
                ViewBag.EnderecoCliente = animal.Cliente.Pessoa.ENDERECO;
                ViewBag.DataHora = DateTime.Now.ToString();
            }
            return View(procedimento);
        }

        public ActionResult ImprimirProc(int codigo = 0, int codigoanimal = 0)
        {
            Procedimento procedimento = db.Procedimento.Find(codigo);

            Animal animal = db.Animal.Find(codigoanimal);
            ViewBag.NomeAnimal = animal.NOME;
            ViewBag.DataNascimento = animal.DT_NASCIMENTO.ToString();
            ViewBag.NomeCliente = animal.Cliente.Pessoa.NOME;
            if (animal.Veterinario != null)
            {
                ViewBag.NomeVeterinario = animal.Veterinario.Pessoa.NOME;
                ViewBag.CRMV = animal.Veterinario.CRMV;
            }
            else
            {
                ViewBag.NomeVeterinario = "";
                ViewBag.CRMV = "";
            }
            ViewBag.EnderecoCliente = animal.Cliente.Pessoa.ENDERECO;
            ViewBag.DataHora = DateTime.Now.ToString();
            return View(procedimento);
        }
    }
}
