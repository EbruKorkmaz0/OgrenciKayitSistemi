using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ogrencikayitsistemi.Models
{
    public partial class MvcContext : DbContext
    {
        public MvcContext()
            : base("name=MvcContext")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ogrenci> Ogrenci { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
