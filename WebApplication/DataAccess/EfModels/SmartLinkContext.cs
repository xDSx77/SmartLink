using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.DataAccess.EfModels
{
    public partial class SmartLinkContext : DbContext
    {
        public SmartLinkContext()
        {
        }

        public SmartLinkContext(DbContextOptions<SmartLinkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatByUrl> StatByUrl { get; set; }
        public virtual DbSet<TShortcuts> TShortcuts { get; set; }
        public virtual DbSet<TStats> TStats { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PC-DE-ALLAN-POR\\MTI;Database=SmartLink;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatByUrl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StatByUrl");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TShortcuts>(entity =>
            {
                entity.ToTable("T_Shortcuts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TStats>(entity =>
            {
                entity.ToTable("T_Stats");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUrl).HasColumnName("idUrl");

                entity.HasOne(d => d.IdUrlNavigation)
                    .WithMany(p => p.TStats)
                    .HasForeignKey(d => d.IdUrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Stats_T_Shortcuts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
