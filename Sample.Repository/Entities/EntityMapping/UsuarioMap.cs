﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachMe.Core.Entities;
using TeachMe.Repository.Context;

namespace TeachMe.Repository.Entities.EntityMapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public readonly DbOptions _dbOptions;

        public UsuarioMap(DbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("USUARIO_ID");

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(80);

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO");

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(x => x.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(255);

            builder.Property(x => x.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(11);

            builder.Property(x => x.Escolaridade)
                .HasColumnName("ESCOLARIDADE")
                .HasMaxLength(100);

            builder.Property(x => x.NuDocumento)
                .HasColumnName("NU_DOCUMENTO")
                .HasMaxLength(11);

            builder.Property(x => x.TipoDocumento)
                .HasColumnName("TIPO_DOCUMENTO")
                .HasMaxLength(3);
        }
    }
}