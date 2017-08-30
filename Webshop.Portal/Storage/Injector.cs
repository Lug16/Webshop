using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Kernel;
using Webshop.Repository.EntityFramework;
using Webshop.Repository.MemoryStorage;

namespace Webshop.Portal.Storage
{
    public class Injector
    {
        public Dictionary<string, IUnitOfWork> ContextDictionary { get; set; }

        public Injector(Model model, TempDataDictionary tempData)
        {
            var dictionary = new Dictionary<string, IUnitOfWork>();

            dictionary.Add("Database", new Repository.EntityFramework.UnitOfWork(model));
            dictionary.Add("Memory", new Repository.MemoryStorage.UnitOfWork(tempData));

            ContextDictionary = dictionary;
        }
    }
}