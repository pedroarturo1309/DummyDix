using PruebaDix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaDix.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using(var db = new dbPubs())
            {
                var result = db.vw_AutoresMasVenden.OrderByDescending(x => x.cantidad).ToList();
                return View(result);
            }
        }
    }
}