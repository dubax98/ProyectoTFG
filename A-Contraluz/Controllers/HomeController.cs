using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace A_Contraluz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Lienzo()
        {
            ViewBag.Message = "Acabados en lienzo";
            return View();
        }

        public ActionResult Cromalux()
        {
            ViewBag.Message = "Acabados en cromalux";
            return View();
        }

        public ActionResult Capatext()
        {
            ViewBag.Message = "Acabados en capatext";
            return View();
        }
        public ActionResult Bodas()
        {
            ViewBag.Message = "Bodas";
            return View();
        }

        public ActionResult Comuniones()
        {
            ViewBag.Message = "Comuniones";
            return View();
        }

        public ActionResult Bebes()
        {
            ViewBag.Message = "Bebes";
            return View();
        }

        public ActionResult Familiares()
        {
            ViewBag.Message = "Familiares";
            return View();
        }

        public ActionResult Festivos()
        {
            ViewBag.Message = "Festivos";
            return View();
        }

        public ActionResult LaboratorioImagen()
        {
            ViewBag.Messsage = "Laboratorio de imagen";
            return View();
        }

        public ActionResult RevFotografico()
        {
            ViewBag.Messsage = "Revelado fotográfico";
            return View();
        }

        public ActionResult AlbumDigital()
        {
            ViewBag.Messsage = "Álbum digital";
            return View();
        }

        public ActionResult ImpDigColor()
        {
            ViewBag.Message = "Impresión digital a color";
            return View();
        }

        public ActionResult ImpDigBlanco()
        {
            ViewBag.Message = "Impresión digital en blanco y negro";
            return View();
        }

        public ActionResult TarVisita()
        {
            ViewBag.Message = "Tarjetas de visita";
            return View();
        }

        public ActionResult CartasPresentacion()
        {
            ViewBag.Message = "Cartas de presentación";
            return View();
        }

        public ActionResult Packagin()
        {
            ViewBag.Message = "Packagin";
            return View();
        }

        public ActionResult Calendarios()
        {
            ViewBag.Message = "Calendario";
            return View();
        }

        public ActionResult InvitacionBoda()
        {
            ViewBag.Message = "Invitaciones de bodas";
            return View();
        }

        public ActionResult Embarazos()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }

        public ActionResult SiteMaps()
        {
            ViewBag.Message = "Mapa del sitio";
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