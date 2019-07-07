using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using A_Contraluz.Models;

namespace A_Contraluz.Controllers
{
    public class CarritoComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarritoCompras
        public ActionResult Index()
        {
            return View(db.CarritoCompras.ToList());
        }

        // GET: CarritoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritoCompra carritoCompra = db.CarritoCompras.Find(id);
            if (carritoCompra == null)
            {
                return HttpNotFound();
            }
            return View(carritoCompra);
        }

        // GET: CarritoCompras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritoCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarritoCompraId,Categoria,Modelo,Descripcion,Precio,Cantidad")] CarritoCompra carritoCompra)
        {
            if (ModelState.IsValid)
            {
                db.CarritoCompras.Add(carritoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carritoCompra);
        }

        // GET: CarritoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritoCompra carritoCompra = db.CarritoCompras.Find(id);
            if (carritoCompra == null)
            {
                return HttpNotFound();
            }
            return View(carritoCompra);
        }

        // POST: CarritoCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarritoCompraId,Categoria,Modelo,Descripcion,Precio,Cantidad")] CarritoCompra carritoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carritoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carritoCompra);
        }

        // GET: CarritoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritoCompra carritoCompra = db.CarritoCompras.Find(id);
            if (carritoCompra == null)
            {
                return HttpNotFound();
            }
            return View(carritoCompra);
        }

        // POST: CarritoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarritoCompra carritoCompra = db.CarritoCompras.Find(id);
            db.CarritoCompras.Remove(carritoCompra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ListadoFiltroProductos(string BuscaDescripcion, string BuscaCategoria, string BuscaArticulos, string BuscaTalla, int? precio)
        {
            var ProductosFiltro = from al in db.CarritoCompras select al;

            if (!string.IsNullOrEmpty(BuscaDescripcion))
            {
                ProductosFiltro = db.CarritoCompras.Where(x => x.Descripcion.Contains(BuscaDescripcion));
            }

            if (!string.IsNullOrEmpty(BuscaCategoria))
            {
                ProductosFiltro = db.CarritoCompras.Where(x => x.Categoria.Contains(BuscaCategoria));
            }

            var listaArticulos = new List<string>();
            string[] listaArticulosFiltro = { "Marcos", "Figuritas", "Camisetas", "Tazas" };
            listaArticulos = listaArticulosFiltro.ToList();
            ViewBag.BuscaArticulos = new SelectList(listaArticulos);
            if (!string.IsNullOrEmpty(BuscaArticulos))
            {
                ProductosFiltro = db.CarritoCompras.Where(x => x.Categoria == BuscaArticulos);
            }

            var listaTallaFiltro = from ar in db.CarritoCompras select ar.Modelo;
            listaArticulos = listaTallaFiltro.ToList();
            ViewBag.BuscaTalla = new SelectList(listaArticulos);
            if (!string.IsNullOrEmpty(BuscaTalla))
            {
                ProductosFiltro = db.CarritoCompras.Where(x => x.Modelo == BuscaTalla);
            }

            var listaArticulosPrecio = new List<int>();
            int[] listaPrecioFiltro = { 0, 20, 50, 100, 200, 500 };
            listaArticulosPrecio = listaPrecioFiltro.ToList();
            ViewBag.precio = new SelectList(listaArticulosPrecio);
            if (precio != null)
            {
                if (precio >= 0)
                {
                    ProductosFiltro = db.CarritoCompras.Where(x => x.Precio >= precio);
                }
                else if (precio >= 20)
                {
                    ProductosFiltro = db.CarritoCompras.Where(x => x.Precio >= precio);
                }
                else if (precio >= 50)
                {
                    ProductosFiltro = db.CarritoCompras.Where(x => x.Precio >= precio);
                }
                else if (precio >= 100)
                {
                    ProductosFiltro = db.CarritoCompras.Where(x => x.Precio >= precio);
                }
                else if (precio >= 200)
                {
                    ProductosFiltro = db.CarritoCompras.Where(x => x.Precio >= precio);
                }
                else if (precio >= 500)
                {
                    ProductosFiltro = db.CarritoCompras.Where(x => x.Precio >= precio);
                }
            }

            return View(ProductosFiltro);
        }

        public ActionResult ListadoCarritoCompra(int? id)
        {
            List<CarritoCompra> ListaProductos = new List<CarritoCompra>();
            if (Session["compra"] == null)
            {
                ListaProductos = Session["compra"] as List<CarritoCompra>;
                ListaProductos.Add(db.CarritoCompras.Where(x => x.CarritoCompraId == id).First());
                Session["compra"] = ListaProductos;
            }
            else
            {
                ListaProductos = Session["compra"] as List<CarritoCompra>;
                ListaProductos.Add(db.CarritoCompras.Where(x => x.CarritoCompraId == id).First());
                Session["compra"] = ListaProductos;
            }

            return View(ListaProductos);
        }

        public FileResult PedidosExcel()
        {
            List<CarritoCompra> listaPedidos = new List<CarritoCompra>();
            listaPedidos = db.CarritoCompras.ToList();

            var stream = new MemoryStream();
            var serializar = new XmlSerializer(typeof(List<CarritoCompra>));

            serializar.Serialize(stream, listaPedidos);
            stream.Position = 0;

            return File(stream, "application/vnd.ms-excel", "GanaciaMensual.xls");
        }

        public ActionResult Formulario(string nombre, string email, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(email);
                mail.Subject = "Compra realizada";
                mail.Body = "Hola " + nombre + ", Su compra virtual llegará en 24 horas. Pase un buen día.";
                mail.To.Add(email);
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";

                // Configuracion del SMTP
                // Puerto que utiliza Gmail para sus servicios
                SmtpServer.Port = 587;

                // Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);

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
