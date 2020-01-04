using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.DAL.Context
{
    class WorkContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<CommentaireEmp> CommentaireEmps{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=tcp:mg-sql-server.database.windows.net,1433;Initial Catalog=vnext;Persist Security Info=False;User ID=ad-min;Password=Vnext#14;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentaireEmp>().HasKey(sc => new { sc.IdEmployee, sc.IdCommentaire });
        }
    }
}
