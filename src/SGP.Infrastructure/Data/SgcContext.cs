using Microsoft.EntityFrameworkCore;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.Data
{
    public class SgcContext : DbContext
    {
        public SgcContext(DbContextOptions<SgcContext> options) :base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");

            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
