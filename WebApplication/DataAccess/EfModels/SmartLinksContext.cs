using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.DataAccess.EfModels
{
    public partial class SmartLinksContext : DbContext
    {
        public SmartLinksContext()
        {
        }

        public SmartLinksContext(DbContextOptions<SmartLinksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatByUrl> StatByUrl { get; set; }
        public virtual DbSet<TShorcuts> TShorcuts { get; set; }
        public virtual DbSet<TStats> TStats { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\MTI;Initial Catalog=SmartLink;Trusted_Connection=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatByUrl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StatByUrl");

                entity.Property(e => e.Hit).HasColumnName("hit");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasColumnName("sessionId")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(250);
            });

          
            modelBuilder.Entity<TShorcuts>(entity =>
            {
                entity.ToTable("T_Shorcuts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasColumnName("sessionId")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TStats>(entity =>
            {
                entity.ToTable("T_Stats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUrl).HasColumnName("idUrl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
