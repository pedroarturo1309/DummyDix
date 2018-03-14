using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDix.Models.Views
{
    public class vw_ListaLibro
    {
        public long id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string title { get; set; }
    }
}