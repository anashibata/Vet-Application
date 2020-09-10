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
    public class EmailController : Controller
    {

        public ActionResult Enviar()
        {
            return View();         
        }

        [HttpPost]
        public ActionResult Enviar(string email, string assunto, string mensagem)
        {
            if ((email == "") || (mensagem == "") )
            {
                ViewBag.aviso = "O preenchimento do email e mensagem são obrigatórios para o envio do email.";
                return View();
            }
            else
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.From = "argussistema@gmail.com";
                WebMail.UserName = "argussistema@gmail.com";
                WebMail.Password = "137956mozao";

                WebMail.Send(email, assunto, mensagem);
                return Redirect("Enviar");
            }
        }

    }
}

