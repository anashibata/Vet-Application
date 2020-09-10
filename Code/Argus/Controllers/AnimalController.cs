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
    public class AnimalController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "") 
        {            
            Animal animal = new Animal();
            return View(animal.ListaAnimais(pesquisa));            
        }

        public ActionResult ListarAnimal(int codigo)
        {            
            return RedirectToAction("Listar", "AnimalImagem", new { codigo = codigo });            
        }

        public ActionResult Incluir()
        {            
            ViewBag.ListaPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            ViewBag.ListaCliente = new SelectList(db.Cliente, "CODIGO", "Pessoa.NOME");
            ViewBag.ListaVeterinario = new SelectList(db.Veterinario, "CODIGO_PESSOA", "Pessoa.NOME"); 
            ViewBag.ListaTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            ViewBag.ListaCor = new SelectList(db.Cor, "CODIGO", "NOME");
            ViewBag.ListaEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View();
        }
        
        [HttpPost]
        public ActionResult Incluir(Animal animal,HttpPostedFileBase file)
        {
           
            if (ModelState.IsValid)
            {
                //Util.UpLoadImagem(file);
                if (file != null && file.ContentLength > 0)
                {   var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    file.SaveAs(path);
                    animal.CAMINHO_FOTO = fileName;
                }                
                animal.Incluir(animal);

                return RedirectToAction("Listar");
            }
            else
                return View(animal);
        }
                
        public ActionResult Editar(int codigo)
        {
            Animal animal = db.Animal.Find(codigo);
            ViewBag.ListaPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            ViewBag.ListaCliente = new SelectList(db.Cliente, "CODIGO", "Pessoa.NOME");
            ViewBag.ListaVeterinario = new SelectList(db.Veterinario, "CODIGO", "Pessoa.NOME");
            ViewBag.ListaTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            ViewBag.ListaCor = new SelectList(db.Cor, "CODIGO", "NOME");
            ViewBag.ListaEspecie = new SelectList(db.Especie, "CODIGO", "NOME");
            return View(animal);
        }

        [HttpPost]
        public ActionResult Editar(Animal animal, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    file.SaveAs(path);
                    animal.CAMINHO_FOTO = fileName;
                }
                animal.Atualizar(animal);
                return RedirectToAction("Listar");
            }
            else
                return View(animal);
        }

        public ActionResult Eliminar(int codigo)
        {
            Animal animal = db.Animal.Find(codigo);
            return View(animal);
        }

        [HttpPost] 
        public ActionResult Eliminar(Animal animal)
        {
            ViewBag.mensagem = "";
            try
            {
                animal.Eliminar(animal);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar este animal. Ele possui informações no sistema que dependem dele.";
                return View();
            }
        }


        [HttpPost]
        public ActionResult GravaIma(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }      

    }
}
