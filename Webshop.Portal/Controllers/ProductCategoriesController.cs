using System.Net;
using System.Web.Mvc;
using Webshop.Entities;
using Webshop.Kernel;

namespace Webshop.Portal.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private IUnitOfWork db;

        public ProductCategoriesController()
        {
            this.db = MvcApplication.CurrentUnitOfWork;
        }
        // GET: ProductCategories
        public ActionResult Index()
        {
            return View(db.ProductCategoriesRepository.GetAll());
        }

        // GET: ProductCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategoriesRepository.GetByKey(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCategoryId,Name")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategoriesRepository.Add(productCategory);
                db.Complete();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategoriesRepository.GetByKey(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryId,Name")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategoriesRepository.Update(productCategory);
                db.Complete();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategoriesRepository.GetByKey(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.ProductCategoriesRepository.Remove(id    );
            db.Complete();
            return RedirectToAction("Index");
        }
    }
}
