using PruebaDix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaDix.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index(string title)
        {
            using(var db = new dbPubs())
            {
                if(string.IsNullOrWhiteSpace(title))
                    return View(db.titles.ToList());
                else
                    return View(db.titles.Where(x => x.title1.Contains(title)).ToList());
            }

        }

        public ActionResult ListaLibros()
        {
            using (var db = new dbPubs())
            {
                return View(db.vw_ListaLibro.ToList());
            }
        }

        public ActionResult UltimasVentas()
        {
            return View();
        }
    }
}