using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.EntityConfig
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(a => a.CategoriaId);

            builder
                .Property(a => a.CategoriaId)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Descricao)
               .HasColumnType("varchar(200)")
               .IsRequired();

        }

    }
}
