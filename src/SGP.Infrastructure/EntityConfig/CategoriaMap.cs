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
            //builder.HasKey(ca => ca.CategoriaID);

            builder
                .Property(f => f.CategoriaId).ValueGeneratedOnAdd();

            builder.Property(e => e.Descricao)
               .HasColumnType("varchar(200)");

        }

    }
}
