namespace PruebaDix.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PruebaDix.Models.Views;

    public partial class dbPubs : DbContext
    {
        public dbPubs()
            : base("name=dbPubs")
        {
        }

        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<pub_info> pub_info { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<store> stores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<titleauthor> titleauthors { get; set; }
        public virtual DbSet<title> titles { get; set; }
        public virtual DbSet<discount> discounts { get; set; }
        public virtual DbSet<roysched> royscheds { get; set; }

        /* Vistas */
        public virtual DbSet<vw_AutoresMasVenden> vw_AutoresMasVenden { get; set; }
        public virtual DbSet<vw_ListaLibro> vw_ListaLibro { get; set; }
        public virtual DbSet<vw_ultimasventas> vw_ultimasventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<author>()
                .Property(e => e.au_id)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.au_lname)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.au_fname)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .HasMany(e => e.titleauthors)
                .WithRequired(e => e.author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.emp_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.minit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.lname)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.job_desc)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pub_info>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<pub_info>()
                .Property(e => e.pr_info)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.pub_name)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.publisher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<publisher>()
                .HasOptional(e => e.pub_info)
                .WithRequired(e => e.publisher);

            modelBuilder.Entity<sale>()
                .Property(e => e.stor_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.ord_num)
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.payterms)
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.title_id)
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .Property(e => e.stor_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .Property(e => e.stor_name)
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .Property(e => e.stor_address)
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .Property(e => e.zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<store>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<titleauthor>()
                .Property(e => e.au_id)
                .IsUnicode(false);

            modelBuilder.Entity<titleauthor>()
                .Property(e => e.title_id)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.title_id)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.title1)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<title>()
                .Property(e => e.advance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<title>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<title>()
                .HasMany(e => e.titleauthors)
                .WithRequired(e => e.title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<title>()
                .HasOptional(e => e.roysched)
                .WithRequired(e => e.title);

            modelBuilder.Entity<discount>()
                .Property(e => e.discounttype)
                .IsUnicode(false);

            modelBuilder.Entity<discount>()
                .Property(e => e.stor_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<discount>()
                .Property(e => e.discount1)
                .HasPrecision(4, 2);

            modelBuilder.Entity<roysched>()
                .Property(e => e.title_id)
                .IsUnicode(false);
        }
    }
}
