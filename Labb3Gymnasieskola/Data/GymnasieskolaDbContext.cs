using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Labb3Gymnasieskola.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3Gymnasieskola.Data
{
    public partial class GymnasieskolaDbContext : DbContext
    {
        public GymnasieskolaDbContext()
        {
        }

        public GymnasieskolaDbContext(DbContextOptions<GymnasieskolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBetyg> TblBetyg { get; set; }
        public virtual DbSet<TblElev> TblElev { get; set; }
        public virtual DbSet<TblKurs> TblKurs { get; set; }
        public virtual DbSet<TblPersonal> TblPersonal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source = DESKTOP-O8V61A2;Initial Catalog=Gymnasieskola;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBetyg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblBetyg");

                entity.Property(e => e.Betyg).HasMaxLength(50);

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.HasOne(d => d.Elev)
                    .WithMany()
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK_tblBetyg_tblElev");

                entity.HasOne(d => d.Kurs)
                    .WithMany()
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK_tblBetyg_tblKurs");

                entity.HasOne(d => d.Lärare)
                    .WithMany()
                    .HasForeignKey(d => d.LärareId)
                    .HasConstraintName("FK_tblBetyg_Lärare");
            });

            modelBuilder.Entity<TblElev>(entity =>
            {
                entity.HasKey(e => e.ElevId);

                entity.ToTable("tblElev");

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Klass).HasMaxLength(50);

                entity.Property(e => e.Personnummer).HasMaxLength(50);
            });

            modelBuilder.Entity<TblKurs>(entity =>
            {
                entity.HasKey(e => e.KursId);

                entity.ToTable("tblKurs");

                entity.Property(e => e.KursNamn).HasMaxLength(50);

                entity.HasOne(d => d.Lärare)
                    .WithMany(p => p.TblKurs)
                    .HasForeignKey(d => d.LärareId)
                    .HasConstraintName("FK_tblKurs_Personal");
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.PersonalId)
                    .HasName("PK_Lärare");

                entity.ToTable("tblPersonal");

                entity.Property(e => e.Befattning).HasMaxLength(50);

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Förnamn).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
