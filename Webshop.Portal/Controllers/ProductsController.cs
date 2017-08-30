using System.Linq;
using System.Net;
using System.Web.Mvc;
using Webshop.Entities;
using Webshop.Kernel;
using Webshop.Portal.Models;

namespace Webshop.Portal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork db;

        public ProductsController()
        {
            this.db = MvcApplication.CurrentUnitOfWork;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = db.ProductsRepository.GetAll();

            var list = products.ToList().Select(r => r.Map()).ToList();

            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsRepository.GetByKey(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product.Map());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategoriesRepository.GetAll(), "ProductCategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCategoryId,Number,Name,Price")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                db.ProductsRepository.Add(product.Map());
                db.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryId = new SelectList(db.ProductCategoriesRepository.GetAll(), "ProductCategoryId", "Name", product.ProductCategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsRepository.GetByKey(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategoriesRepository.GetAll(), "ProductCategoryId", "Name", product.ProductCategoryId);
            return View(product.Map());
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCategoryId,Number,Name,Price,CreationDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.ProductsRepository.Update(product);
                db.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategoriesRepository.GetAll(), "ProductCategoryId", "Name", product.ProductCategoryId);
            return View(product.Map());
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsRepository.GetByKey(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product.Map());
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.ProductsRepository.Remove(id);
            db.Complete();
            return RedirectToAction("Index");
        }
    }
}
