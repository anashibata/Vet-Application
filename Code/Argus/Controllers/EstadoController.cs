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
    public class EstadoController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            Estado estado = new Estado();
            return View(estado.ListarEstado(pesquisa));
        }

       
        public ActionResult Incluir()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Estado estado)
        {
            if (ModelState.IsValid)
            {
                estado.Incluir(estado);

                return RedirectToAction("Listar");
            }
            else
                return View(estado);
        }
      
        public ActionResult Editar(int codigo)
        {
            Estado estado = db.Estado.Find(codigo);
          
            return View(estado);
        }

        [HttpPost]
        public ActionResult Editar(Estado estado)
        {
            if (ModelState.IsValid)
            {
                estado.Atualizar(estado);
                return RedirectToAction("Listar");
            }
            else
                return View(estado);
        }

        public ActionResult Eliminar(int codigo)
        {
            Estado estado = db.Estado.Find(codigo);
            return View(estado);
        }

        [HttpPost]
        public ActionResult Eliminar(Estado estado)
        {
            ViewBag.mensagem = "";
            try
            {
                estado.Eliminar(estado);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta estado. Ele possui informações no sistema que dependem dele.";
                return View();
            }
        }

       }
}
