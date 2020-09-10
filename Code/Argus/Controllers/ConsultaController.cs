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
    public class ConsultaController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Listar(String pesquisa = "")
        {
            Consulta consulta = new Consulta();
            return View(consulta.ListaConsultas(pesquisa));
        }


        public ActionResult ListarConsultasEncerradas(String pesquisa = "")
        {
            Consulta consulta = new Consulta();
            return View(consulta.ListaConsultasEncerrados(pesquisa));
        }



        public ActionResult Relatorio(String pesquisa = "")
        {
            Consulta consulta = new Consulta();
            return View(consulta.ListaConsultas(pesquisa));
        }

        
        public ActionResult ListarConsulta(int codigo)
        {
            return RedirectToAction("Listar", "ConsultaImagem", new { codigo = codigo });
        }

        public ActionResult Incluir()
        {            
            ViewBag.DataConsulta = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            ViewBag.DataAtlStatus = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            CriarListasView();            
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CodigoConsulta = consulta.Incluir(consulta);
                ViewBag.DataConsulta = consulta.DTHR_CONSULTA.ToString();
                CriarListasView();
                return RedirectToAction("Listar");
            }
            else
                return View(consulta);
        }

        public ActionResult Editar(int codigo)
        {
            Consulta consulta = db.Consulta.Find(codigo);
            ViewBag.CodigoConsulta = consulta.CODIGO;
            CriarListasView();          
            return View(consulta);
        }

        [HttpPost]
        public ActionResult Editar(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                consulta.Atualizar(consulta);
                return RedirectToAction("Listar");
            }
            else
                return View(consulta);
        }

        public ActionResult Eliminar(int codigo)
        {
            Consulta consulta = db.Consulta.Find(codigo);
            return View(consulta);
        }

        [HttpPost]
        public ActionResult Eliminar(Consulta consulta)
        {
            ViewBag.mensagem = "";
            try
            {
                consulta.Eliminar(consulta);
                return RedirectToAction("Listar");
            }
            catch
            {
                ViewBag.mensagem = "Não foi possível eliminar esta consulta. Verifique se ela possuir produtos/serviços";
                return View();
            }
        }

        private void CriarListasView() {
            ViewBag.ListaCliente = new SelectList(db.Cliente, "CODIGO", "Pessoa.NOME");
            ViewBag.ListaAnimal = new SelectList(db.Animal, "CODIGO", "NOME");
            ViewBag.ListaVeterinario = new SelectList(db.Veterinario, "CODIGO", "Pessoa.NOME");
            ViewBag.ListaTpVisita = new SelectList(db.TipoVisita, "CODIGO", "NOME");
            ViewBag.ListaStatus = new SelectList(db.ConsultaStatus, "CODIGO", "NOME");            
        }

        public ActionResult ListarProdutosServicos(int codigoconsulta)
        {
            return RedirectToAction("Listar", "ConsultaProdServ", new { codigoconsulta = codigoconsulta });
        }

        
    }
}
