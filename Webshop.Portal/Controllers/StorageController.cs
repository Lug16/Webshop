using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webshop.Portal.Controllers
{
    public class StorageController : Controller
    {
        // GET: Storage
        public ActionResult Change(string storageKey)
        {
            MvcApplication.ChangeUnitOfWork(storageKey);
            return RedirectToAction("Index", "Home");
        }
    }
}