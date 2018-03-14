using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaDix.Models.Views
{
    public class vw_AutoresMasVenden
    {
        [Key]
        public long id { get; set; }
        public string au_fname { get; set; }
        public string au_lname { get; set; }
        public int cantidad { get; set; }
    }
}