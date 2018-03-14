namespace PruebaDix.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class author
    {
        public author()
        {
            titleauthors = new HashSet<titleauthor>();
        }

        [Key]
        [StringLength(11), Display(Name = "Actor ID")]
        public string au_id { get; set; }

        [Required]
        [StringLength(40), Display(Name = "Apellido")]
        public string au_lname { get; set; }

        [Required]
        [StringLength(20), Display(Name = "Nombre")]
        public string au_fname { get; set; }

        [Required]
        [StringLength(12), Display(Name = "Telefono")]
        public string phone { get; set; }

        [StringLength(40), Display(Name = "Direccion")]
        public string address { get; set; }

        [StringLength(20), Display(Name = "Ciudad")]
        public string city { get; set; }

        [StringLength(2), Display(Name = "Estado")]
        public string state { get; set; }

        [StringLength(5), Display(Name = "Codigo ZIP")]
        public string zip { get; set; }

        public bool contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<titleauthor> titleauthors { get; set; }
    }
}
