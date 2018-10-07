using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MasterDetailReact.Models.DB
{
    public partial class HarjoitustietokantaContext : DbContext
    {
        public HarjoitustietokantaContext()
        {
        }

        public HarjoitustietokantaContext(DbContextOptions<HarjoitustietokantaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetLocation> AssetLocation { get; set; }
        public virtual DbSet<AssetLocations> AssetLocations { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<Henkilot> Henkilot { get; set; }
        public virtual DbSet<HenkilotPaiva2> HenkilotPaiva2 { get; set; }
        public virtual DbSet<Projektit> Projektit { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<Tunnit> Tunnit { get; set; }

        // Unable to generate entity type for table 'dbo.tblTuntiLisays'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.POSTITOIMIPAIKKA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.henkilotDay1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblTuntiLoki'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HENKILOT_temp2'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HENKILOT_temp'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Henkilot_bak'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Lokitaulu'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HenkilotLokitaulu'. Please see the warning messages.


        //OMA POISKOMMENTOINTI ALLA OLEVAT RIVIT

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-MF7GQV4J\\SQLEXANNEVA;Database=Harjoitustietokanta;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetLocation>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<AssetLocations>(entity =>
            {
                entity.Property(e => e.LastSeen).HasColumnType("datetime");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetLocations)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetLocations_Assets");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AssetLocations)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_AssetLocations_Locations");
            });

            modelBuilder.Entity<Assets>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Model).HasMaxLength(500);

                entity.Property(e => e.Type).HasMaxLength(200);
            });

            modelBuilder.Entity<Henkilot>(entity =>
            {
                entity.HasKey(e => e.HenkiloId);

                entity.Property(e => e.Etunimi).HasMaxLength(50);

                entity.Property(e => e.Osoite).HasMaxLength(100);

                entity.Property(e => e.Sukunimi).HasMaxLength(50);
            });

            modelBuilder.Entity<HenkilotPaiva2>(entity =>
            {
                entity.HasKey(e => e.HenkiloId);

                entity.HasIndex(e => e.Etunimi)
                    .HasName("HenkilotPaiva2_Etunimi_ix1");

                entity.HasIndex(e => e.Sukunimi)
                    .HasName("HenkilotPaiva2_Sukunimi_ix1");

                entity.Property(e => e.Etunimi).HasMaxLength(50);

                entity.Property(e => e.Osoite).HasMaxLength(100);

                entity.Property(e => e.Sukunimi).HasMaxLength(50);
            });

            modelBuilder.Entity<Projektit>(entity =>
            {
                entity.HasKey(e => e.ProjektiId);

                entity.HasIndex(e => e.Nimi)
                    .HasName("Projektit_nimi_ix1");

                entity.Property(e => e.Nimi).HasMaxLength(50);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tunnit>(entity =>
            {
                entity.HasKey(e => e.TuntiId);

                entity.HasIndex(e => e.Pvm)
                    .HasName("Tunnit_Pvm_ix1");

                entity.Property(e => e.Pvm).HasColumnType("datetime");

                entity.Property(e => e.Tunnit1)
                    .HasColumnName("Tunnit")
                    .HasColumnType("numeric(15, 7)");
            });
        }
    }
}
