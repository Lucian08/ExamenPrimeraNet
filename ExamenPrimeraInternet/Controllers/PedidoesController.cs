using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenPrimeraInternet.Models;

namespace ExamenPrimeraInternet.Controllers
{
    [Authorize]
    public class PedidoesController : Controller
    {
        private ExamenPrimeraNetEntities db = new ExamenPrimeraNetEntities();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Cliente).Include(p => p.Producto);
            return View(pedido.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre");
            ViewBag.IdProducto = new SelectList(db.Producto, "Id", "Nombre");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCliente,IdProducto,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre", pedido.IdCliente);
            ViewBag.IdProducto = new SelectList(db.Producto, "Id", "Nombre", pedido.IdProducto);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre", pedido.IdCliente);
            ViewBag.IdProducto = new SelectList(db.Producto, "Id", "Nombre", pedido.IdProducto);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCliente,IdProducto,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre", pedido.IdCliente);
            ViewBag.IdProducto = new SelectList(db.Producto, "Id", "Nombre", pedido.IdProducto);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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
    }
}
