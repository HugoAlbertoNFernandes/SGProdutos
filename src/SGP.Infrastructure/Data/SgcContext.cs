using System;
using System.Collections.Generic;
using System.Text;

using SGP.AplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using SGP.Infrastructure.EntityConfig;

namespace SGP.Infrastructure.Data
{
    public class SgcContext : DbContext
    {
        public SgcContext(DbContextOptions<SgcContext> options) :base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            

            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
