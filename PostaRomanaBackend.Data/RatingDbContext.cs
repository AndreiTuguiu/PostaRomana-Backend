using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;

#nullable disable

namespace RatingSystem.Data
{
    public partial class RatingDbContext : DbContext
    {
        public RatingDbContext(DbContextOptions<RatingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Limit).HasColumnType("money");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
