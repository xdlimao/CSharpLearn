using EFProject2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject2.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            builder.ToTable("Category");
            //Chave Primária
            builder.HasKey(x => x.Id);
            //Definindo um campo Identity
            builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(); // <- IDENTITY(1, 1)
            //Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            //Propriedades
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            //Índices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();
        }
    }
}
