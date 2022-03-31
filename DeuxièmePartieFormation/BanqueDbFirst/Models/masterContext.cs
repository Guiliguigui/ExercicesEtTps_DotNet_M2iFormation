using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BanqueDbFirst.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prenom");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.ToTable("compte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CoutOperation)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("coutOperation");

                entity.Property(e => e.Solde)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("solde");

                entity.Property(e => e.Taux)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("taux");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompteId).HasColumnName("compte_id");

                entity.Property(e => e.DateOperation)
                    .HasColumnType("datetime")
                    .HasColumnName("date_operation");

                entity.Property(e => e.Montant)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("montant");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
