using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext: DbContext
    { 
 
        public RepositoryContext(DbContextOptions options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Emprestimo>().HasKey(e => e.Id);
            modelBuilder.Entity<Models.Jogo>().HasKey(e => e.Id);
            modelBuilder.Entity<Models.Amigo>().HasKey(e => e.Id);
            modelBuilder.Entity<Models.Usuario>().HasKey(e => e.Id);

            modelBuilder.Entity<Models.Emprestimo>()
            .HasIndex(p => new { p.Amigo, p.Jogo })
            .IsUnique(true);
        }

        public DbSet<Models.Emprestimo> Emprestimo { get; set; }
        public DbSet<Models.Jogo> Jogo { get; set; }

        public DbSet<Models.Amigo> Amigo { get; set; }

        public DbSet<Models.Usuario> Usuario { get; set; }


    }
}
