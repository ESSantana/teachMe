﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachMe.Core.Dominio;

namespace TeachMe.Repository.Mapeamento
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("cargo");

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.Usuarios);

            builder.Property(x => x.Id)
                .HasColumnName("CARGO_ID");

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100);

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO");
        }
    }
}
