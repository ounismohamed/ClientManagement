using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppData.Models.ModelConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
       

        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.Nom)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.Prenom)
              .HasMaxLength(30)
              .IsRequired();

            builder.Property(prop => prop.Sexe)
              .IsRequired();

            builder.Property(prop => prop.Adresse)
             .HasMaxLength(50)
             .IsRequired();


            builder.Property(prop => prop.Telephone)
              .HasMaxLength(12)
              .IsRequired();

            builder.Property(prop => prop.Etat_Civil)
              .HasMaxLength(10)
              .IsRequired();

            builder.Property(prop => prop.Carte_Credit)
              .IsRequired();

            builder.Property(prop => prop.Carte_Fidelite)
              .IsRequired();

            builder.Property(prop => prop.Age)
              .IsRequired();
        }
    }
}
