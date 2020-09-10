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
    public class ClienteController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            ViewBag.ListarCliente = new SelectList(db.Cliente, "CODIGO", "CODIGO_PESSOA");
            ViewBag.ListarTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            ViewBag.ListarPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            Cliente cliente = new Cliente();
            return View(cliente.ListarCliente(pesquisa));
        }

        public ActionResult Relatorio(String pesquisa = "")
        {
            ViewBag.ListarCliente = new SelectList(db.Cliente, "CODIGO", "CODIGO_PESSOA");
            ViewBag.ListarTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            ViewBag.ListarPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            Cliente cliente = new Cliente();
            return View(cliente.ListarCliente(pesquisa));
        }

        public ActionResult Incluir()
        {
            ViewBag.ListarCliente = new SelectList(db.Cliente, "CODIGO", "CODIGO_PESSOA");
            ViewBag.ListarTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            ViewBag.ListarPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Incluir(cliente);
                return RedirectToAction("Listar");
            }
            else
                return View(cliente);
        }

    public ActionResult Editar(int codigo)
        {
            db.Cliente.Find(codigo);
            Cliente cliente = db.Cliente.Find(codigo);
            ViewBag.ListarCliente = new SelectList(db.Cliente, "CODIGO", "CODIGO_PESSOA");
            ViewBag.ListarTemperamento = new SelectList(db.Temperamento, "CODIGO", "NOME");
            ViewBag.ListarPessoa = new SelectList(db.Pessoa, "CODIGO", "NOME");
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Atualizar(cliente);
                return RedirectToAction("Listar");
            }
            else
                return View(cliente);
        }

        public ActionResult Eliminar(int codigo)
        {
            Cliente cliente = db.Cliente.Find(codigo);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            ViewBag.mensagem = "";
            try
            {
                cliente.Eliminar(cliente);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar este cliente. Ele possui informações no sistema que dependem dele.";
                return View();
            }
        }
    }
}
