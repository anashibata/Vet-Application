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
    [Authorize]
    public class TemperamentoController : Controller
    {
        private Contexto db = new Contexto();
        //
        // GET: /MotivoBaixa/

        public ActionResult Listar(String pesquisa = "")
        {
            Temperamento temperamento = new Temperamento();
            return View(temperamento.ListarTemperamento(pesquisa));
        }


        public ActionResult Incluir()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Temperamento temperamento)
        {
            if (ModelState.IsValid)
            {
                temperamento.Incluir(temperamento);


                return RedirectToAction("Listar");
            }
            else
                return View(temperamento);
        }


        public ActionResult Editar(int codigo)
        {
            Temperamento temperamento = db.Temperamento.Find(codigo);
            ViewBag.ListarTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            return View(temperamento);
        }

        [HttpPost]
        public ActionResult Editar(Temperamento temperamento)
        {
            if (ModelState.IsValid)
            {
                temperamento.Atualizar(temperamento);
                return RedirectToAction("Listar");
            }
            else
                return View(temperamento);
        }

       
        public ActionResult Eliminar(int codigo)
        {
            Temperamento temperamento = db.Temperamento.Find(codigo);
            return View(temperamento);
        }

        [HttpPost]
        public ActionResult Eliminar(Temperamento temperamento)
        {
            ViewBag.mensagem = "";
            try
            {
                temperamento.Eliminar(temperamento);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar este item.  O sistema tem dados que dependem dele.";
                return View();
            }
        }
                
    }



}
