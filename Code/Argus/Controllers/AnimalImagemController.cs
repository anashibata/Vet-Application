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
    public class AnimalImagemController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(int codigo, String pesquisa = "")
        {
            ViewBag.CodigoAnimal = codigo;
            AnimalImagem animal = new AnimalImagem();
            return View(animal.ListaAnimaisImagem(codigo));
        }

        public ActionResult ListarAnimais()
        {
            return RedirectToAction("Listar", "Animal");   
        }

        public ActionResult Incluir(int codigoanimal)
        {
            ViewBag.CodigoAnimal = codigoanimal;
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(AnimalImagem animal, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);
                animal.NOME_FOTO = fileName;                 
            }

            if (ModelState.IsValid)
            {
                animal.DTHR_ATUALIZACAO = DateTime.Now;
                animal.Incluir(animal);
                return RedirectToAction("Listar", "AnimalImagem", new { codigo = animal.CODIGO_ANIMAL });   
            }
            else
                return View(animal);   
        }

        public ActionResult Editar(int codigo)
        {
            AnimalImagem animal = db.AnimalImagem.Find(codigo);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Editar(AnimalImagem animal, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);
                animal.NOME_FOTO = fileName;
            }

            if (ModelState.IsValid)
            {                
                animal.DTHR_ATUALIZACAO = DateTime.Now;
                animal.Atualizar(animal);
                return RedirectToAction("Listar", "AnimalImagem", new { codigo = animal.CODIGO_ANIMAL });   
            }
            else
                return View(animal);

        }

        public ActionResult Eliminar(int codigo)
        {
            AnimalImagem animal = db.AnimalImagem.Find(codigo);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Eliminar(AnimalImagem animal)
        {
            animal.Eliminar(animal);
            return RedirectToAction("Listar", "AnimalImagem", new { codigo = animal.CODIGO_ANIMAL });   
        }       
    }
}
