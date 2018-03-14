using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaDix.Models.Views
{
    public class vw_ultimasventas
    {
        [Key]
        public long id { get; set; }
        public string title { get; set; }
    }
}