using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.EntityConfig
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(a => a.ProdutoId);

            builder
                .Property(f => f.ProdutoId)
                .ValueGeneratedOnAdd();

            


            builder.Property(e => e.Preco)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

        }
    }
}
