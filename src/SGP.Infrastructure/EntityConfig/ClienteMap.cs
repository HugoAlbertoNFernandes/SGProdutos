using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.EntityConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(a => a.ClienteId);

            builder
                .Property(f => f.ClienteId)
                .ValueGeneratedOnAdd();


            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Email)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Senha)
               .HasColumnType("varchar(150)")
               .IsRequired();
        }
    }
}
