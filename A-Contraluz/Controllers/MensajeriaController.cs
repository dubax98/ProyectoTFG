using A_Contraluz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace A_Contraluz.Controllers
{
    public class MensajeriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Mensajeria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mensajeria(string tSolicitante, string tAsunto, string tMensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(tSolicitante);
                mail.Subject = tAsunto;
                mail.Body = tMensaje;
                mail.To.Add("usuarioJuanxxiii@gmail.com");
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";

                // Configuracion del SMTP
                // Puerto que utiliza Gmail para sus servicios
                SmtpServer.Port = 587;

                // Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential(tSolicitante, "Usuario2522");

                SmtpServer.EnableSsl = true;

                // Envio del mail
                SmtpServer.Send(mail);

                ViewBag.Mensaje = "Mensaje enviado correctamente";

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }    
}