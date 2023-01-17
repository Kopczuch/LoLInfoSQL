using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoLInfoSQL.Shared.Models
{
    public partial class lolinfoContext : DbContext
    {
        public lolinfoContext()
        {
        }

        public lolinfoContext(DbContextOptions<lolinfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bohaterowie> Bohaterowies { get; set; } = null!;
        public virtual DbSet<DaneLogowanium> DaneLogowania { get; set; } = null!;
        public virtual DbSet<Druzyny> Druzynies { get; set; } = null!;
        public virtual DbSet<Gracze> Graczes { get; set; } = null!;
        public virtual DbSet<GraczeZawodowi> GraczeZawodowis { get; set; } = null!;
        public virtual DbSet<Gry> Gries { get; set; } = null!;
        public virtual DbSet<KomponentyPrzedmiotow> KomponentyPrzedmiotows { get; set; } = null!;
        public virtual DbSet<Przedmioty> Przedmioties { get; set; } = null!;
        public virtual DbSet<Turnieje> Turniejes { get; set; } = null!;
        public virtual DbSet<ZakupionePrzedmioty> ZakupionePrzedmioties { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=lolinfodb_root;database=lolinfo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bohaterowie>(entity =>
            {
                entity.HasKey(e => e.Nazwa)
                    .HasName("PRIMARY");

                entity.ToTable("bohaterowie");

                entity.HasIndex(e => e.Nazwa, "bohaterowie__idx");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(20)
                    .HasColumnName("nazwa");

                entity.Property(e => e.Atak).HasColumnName("atak");

                entity.Property(e => e.Klasa)
                    .HasMaxLength(20)
                    .HasColumnName("klasa");

                entity.Property(e => e.KrotkiOpis)
                    .HasMaxLength(500)
                    .HasColumnName("krotki_opis");

                entity.Property(e => e.Magia).HasColumnName("magia");

                entity.Property(e => e.Obraz)
                    .HasColumnType("text")
                    .HasColumnName("obraz");

                entity.Property(e => e.Obrona).HasColumnName("obrona");

                entity.Property(e => e.Trudnosc).HasColumnName("trudnosc");

                entity.Property(e => e.Tytuł)
                    .HasMaxLength(30)
                    .HasColumnName("tytuł");

                entity.HasMany(d => d.Bohaters)
                    .WithMany(p => p.Kontras)
                    .UsingEntity<Dictionary<string, object>>(
                        "Kontry",
                        l => l.HasOne<Bohaterowie>().WithMany().HasForeignKey("Bohater").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("kontry_bohaterowie_fk"),
                        r => r.HasOne<Bohaterowie>().WithMany().HasForeignKey("Kontra").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("kontry_bohaterowie_fkv1"),
                        j =>
                        {
                            j.HasKey("Bohater", "Kontra").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("kontry");

                            j.HasIndex(new[] { "Kontra" }, "kontry_bohaterowie_fkv1");

                            j.IndexerProperty<string>("Bohater").HasMaxLength(20).HasColumnName("bohater");

                            j.IndexerProperty<string>("Kontra").HasMaxLength(20).HasColumnName("kontra");
                        });

                entity.HasMany(d => d.Kontras)
                    .WithMany(p => p.Bohaters)
                    .UsingEntity<Dictionary<string, object>>(
                        "Kontry",
                        l => l.HasOne<Bohaterowie>().WithMany().HasForeignKey("Kontra").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("kontry_bohaterowie_fkv1"),
                        r => r.HasOne<Bohaterowie>().WithMany().HasForeignKey("Bohater").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("kontry_bohaterowie_fk"),
                        j =>
                        {
                            j.HasKey("Bohater", "Kontra").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("kontry");

                            j.HasIndex(new[] { "Kontra" }, "kontry_bohaterowie_fkv1");

                            j.IndexerProperty<string>("Bohater").HasMaxLength(20).HasColumnName("bohater");

                            j.IndexerProperty<string>("Kontra").HasMaxLength(20).HasColumnName("kontra");
                        });
            });

            modelBuilder.Entity<DaneLogowanium>(entity =>
            {
                entity.HasKey(e => e.Nick)
                    .HasName("PRIMARY");

                entity.ToTable("dane_logowania");

                entity.Property(e => e.Nick)
                    .HasMaxLength(20)
                    .HasColumnName("nick");

                entity.Property(e => e.DataOstatniegoZalogowania)
                    .HasColumnType("datetime")
                    .HasColumnName("data_ostatniego_zalogowania");

                entity.Property(e => e.Haslo)
                    .HasMaxLength(100)
                    .HasColumnName("haslo");

                entity.HasOne(d => d.NickNavigation)
                    .WithOne(p => p.DaneLogowanium)
                    .HasForeignKey<DaneLogowanium>(d => d.Nick)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dane_logowania_gracze_fk");
            });

            modelBuilder.Entity<Druzyny>(entity =>
            {
                entity.HasKey(e => e.IdDruzyny)
                    .HasName("PRIMARY");

                entity.ToTable("druzyny");

                entity.Property(e => e.IdDruzyny)
                    .HasMaxLength(6)
                    .HasColumnName("id_druzyny");

                entity.Property(e => e.Liga)
                    .HasMaxLength(20)
                    .HasColumnName("liga");

                entity.Property(e => e.Logo)
                    .HasColumnType("text")
                    .HasColumnName("logo");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");

                entity.Property(e => e.Opis)
                    .HasColumnType("text")
                    .HasColumnName("opis");

                entity.Property(e => e.ZdjecieZawodnikow)
                    .HasColumnType("text")
                    .HasColumnName("zdjecie_zawodnikow");
            });

            modelBuilder.Entity<Gracze>(entity =>
            {
                entity.HasKey(e => e.Nick)
                    .HasName("PRIMARY");

                entity.ToTable("gracze");

                entity.HasIndex(e => e.UlubionyBohater, "bohaterowienazwareg_fk");

                entity.Property(e => e.Nick)
                    .HasMaxLength(20)
                    .HasColumnName("nick");

                entity.Property(e => e.Dywizja)
                    .HasMaxLength(15)
                    .HasColumnName("dywizja");

                entity.Property(e => e.Poziom).HasColumnName("poziom");

                entity.Property(e => e.UlubionyBohater)
                    .HasMaxLength(20)
                    .HasColumnName("ulubiony_bohater");

                entity.HasOne(d => d.UlubionyBohaterNavigation)
                    .WithMany(p => p.Graczes)
                    .HasForeignKey(d => d.UlubionyBohater)
                    .HasConstraintName("bohaterowienazwareg_fk");

                entity.HasMany(d => d.GryIdMeczus)
                    .WithMany(p => p.GraczeNicks)
                    .UsingEntity<Dictionary<string, object>>(
                        "GraczeGry",
                        l => l.HasOne<Gry>().WithMany().HasForeignKey("GryIdMeczu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gragracz_fk"),
                        r => r.HasOne<Gracze>().WithMany().HasForeignKey("GraczeNick").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gracznick_fk"),
                        j =>
                        {
                            j.HasKey("GraczeNick", "GryIdMeczu").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("gracze_gry");

                            j.HasIndex(new[] { "GryIdMeczu" }, "gragracz_fk");

                            j.IndexerProperty<string>("GraczeNick").HasMaxLength(20).HasColumnName("gracze_nick");

                            j.IndexerProperty<long>("GryIdMeczu").HasColumnName("gry_id_meczu");
                        });
            });

            modelBuilder.Entity<GraczeZawodowi>(entity =>
            {
                entity.HasKey(e => e.Nick)
                    .HasName("PRIMARY");

                entity.ToTable("gracze_zawodowi");

                entity.HasIndex(e => e.UlubionyBohater, "bohaterowienazwapro_fk");

                entity.HasIndex(e => e.IdDruzyny, "druzynyidpro_fk");

                entity.HasIndex(e => e.Nick, "gracze_zawodowi__idx");

                entity.Property(e => e.Nick)
                    .HasMaxLength(20)
                    .HasColumnName("nick");

                entity.Property(e => e.DataUrodzin)
                    .HasColumnType("datetime")
                    .HasColumnName("data_urodzin");

                entity.Property(e => e.IdDruzyny)
                    .HasMaxLength(6)
                    .HasColumnName("id_druzyny");

                entity.Property(e => e.ImieINazwisko)
                    .HasMaxLength(50)
                    .HasColumnName("imie_i_nazwisko");

                entity.Property(e => e.Kraj)
                    .HasMaxLength(30)
                    .HasColumnName("kraj");

                entity.Property(e => e.Rezydencja)
                    .HasMaxLength(20)
                    .HasColumnName("rezydencja");

                entity.Property(e => e.Rola)
                    .HasMaxLength(9)
                    .HasColumnName("rola");

                entity.Property(e => e.UlubionyBohater)
                    .HasMaxLength(20)
                    .HasColumnName("ulubiony_bohater");

                entity.Property(e => e.Zdjecie)
                    .HasColumnType("text")
                    .HasColumnName("zdjecie");

                entity.HasOne(d => d.IdDruzynyNavigation)
                    .WithMany(p => p.GraczeZawodowis)
                    .HasForeignKey(d => d.IdDruzyny)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("druzynyidpro_fk");

                entity.HasOne(d => d.UlubionyBohaterNavigation)
                    .WithMany(p => p.GraczeZawodowis)
                    .HasForeignKey(d => d.UlubionyBohater)
                    .HasConstraintName("bohaterowienazwapro_fk");

                entity.HasMany(d => d.GryIdMeczus)
                    .WithMany(p => p.GraczeZawodowiNicks)
                    .UsingEntity<Dictionary<string, object>>(
                        "GraczezawodowiGry",
                        l => l.HasOne<Gry>().WithMany().HasForeignKey("GryIdMeczu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gragraczzawodowy_fk"),
                        r => r.HasOne<GraczeZawodowi>().WithMany().HasForeignKey("GraczeZawodowiNick").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("graczzawodowynick_fk"),
                        j =>
                        {
                            j.HasKey("GraczeZawodowiNick", "GryIdMeczu").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("graczezawodowi_gry");

                            j.HasIndex(new[] { "GryIdMeczu" }, "gragraczzawodowy_fk");

                            j.IndexerProperty<string>("GraczeZawodowiNick").HasMaxLength(20).HasColumnName("gracze_zawodowi_nick");

                            j.IndexerProperty<long>("GryIdMeczu").HasColumnName("gry_id_meczu");
                        });
            });

            modelBuilder.Entity<Gry>(entity =>
            {
                entity.HasKey(e => e.IdMeczu)
                    .HasName("PRIMARY");

                entity.ToTable("gry");

                entity.HasIndex(e => e.BohaterowieNazwa, "gry__idx")
                    .IsUnique();

                entity.Property(e => e.IdMeczu).HasColumnName("id_meczu");

                entity.Property(e => e.Asysty).HasColumnName("asysty");

                entity.Property(e => e.BohaterowieNazwa)
                    .HasMaxLength(20)
                    .HasColumnName("bohaterowie_nazwa");

                entity.Property(e => e.Creep_score)
                    
                    .HasColumnName("creep_score");

                entity.Property(e => e.CzasGry)
                    .HasColumnType("timespan")
                    .HasColumnName("czas_gry");

                entity.Property(e => e.Rezultat)
                    .HasMaxLength(4)
                    .HasColumnName("rezultat");

                entity.Property(e => e.Smierci).HasColumnName("smierci");

                entity.Property(e => e.Strona)
                    .HasMaxLength(4)
                    .HasColumnName("strona");

                entity.Property(e => e.Zabojstwa).HasColumnName("zabojstwa");

                entity.Property(e => e.ZabojstwaDruzyny).HasColumnName("zabojstwa_druzyny");

                entity.Property(e => e.ZadaneObrazenia)
                    //.HasPrecision(6, 3)
                    .HasColumnName("zadane_obrazenia");

                entity.Property(e => e.ZdobyteZloto).HasColumnName("zdobyte_zloto");

                entity.Property(e => e.ZgonyDruzyny).HasColumnName("zgony_druzyny");

                entity.HasOne(d => d.BohaterowieNazwaNavigation)
                    .WithOne(p => p.Gry)
                    .HasForeignKey<Gry>(d => d.BohaterowieNazwa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gry_bohaterowie_fk");

                entity.HasMany(d => d.IdZakupionegoPrzedmiotus)
                    .WithMany(p => p.IdMeczus)
                    .UsingEntity<Dictionary<string, object>>(
                        "GryZakupioneprzedmioty",
                        l => l.HasOne<ZakupionePrzedmioty>().WithMany().HasForeignKey("IdZakupionegoPrzedmiotu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("zakupprzedmid_fk"),
                        r => r.HasOne<Gry>().WithMany().HasForeignKey("IdMeczu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("graidmeczu_fk"),
                        j =>
                        {
                            j.HasKey("IdMeczu", "IdZakupionegoPrzedmiotu").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("gry_zakupioneprzedmioty");

                            j.HasIndex(new[] { "IdZakupionegoPrzedmiotu" }, "zakupprzedmid_fk");

                            j.IndexerProperty<long>("IdMeczu").HasColumnName("id_meczu");

                            j.IndexerProperty<long>("IdZakupionegoPrzedmiotu").HasColumnName("id_zakupionego_przedmiotu");
                        });
            });

            modelBuilder.Entity<KomponentyPrzedmiotow>(entity =>
            {
                entity.ToTable("komponenty_przedmiotow");

                entity.HasIndex(e => new { e.IdPrzed, e.IdKomponentu }, "komponenty_przedmiotow__idx");

                entity.HasIndex(e => e.IdKomponentu, "przedmiotyid2_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdKomponentu).HasColumnName("id_komponentu");

                entity.Property(e => e.IdPrzed).HasColumnName("id_przed");

                entity.HasOne(d => d.IdKomponentuNavigation)
                    .WithMany(p => p.KomponentyPrzedmiotowIdKomponentuNavigations)
                    .HasForeignKey(d => d.IdKomponentu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("przedmiotyid2_fk");

                entity.HasOne(d => d.IdPrzedNavigation)
                    .WithMany(p => p.KomponentyPrzedmiotowIdPrzedNavigations)
                    .HasForeignKey(d => d.IdPrzed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("przedmiotyid1_fk");
            });

            modelBuilder.Entity<Przedmioty>(entity =>
            {
                entity.HasKey(e => e.IdPrzed)
                    .HasName("PRIMARY");

                entity.ToTable("przedmioty");

                entity.HasIndex(e => e.IdPrzed, "przedmioty__idx");

                entity.Property(e => e.IdPrzed)
                    .ValueGeneratedNever()
                    .HasColumnName("id_przed");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Ikona)
                    .HasColumnType("text")
                    .HasColumnName("ikona");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(100)
                    .HasColumnName("nazwa")
                    .IsFixedLength();

                entity.Property(e => e.Statystyki).HasColumnName("statystyki");

                entity.Property(e => e.WartoscSprzedazy).HasColumnName("wartosc_sprzedazy");
            });

            modelBuilder.Entity<Turnieje>(entity =>
            {
                entity.HasKey(e => new { e.NazwaTurnieju, e.DruzynyIdDruzyny })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("turnieje");

                entity.HasIndex(e => e.DruzynyIdDruzyny, "druzynyidtur_fk");

                entity.Property(e => e.NazwaTurnieju)
                    .HasMaxLength(70)
                    .HasColumnName("nazwa_turnieju");

                entity.Property(e => e.DruzynyIdDruzyny)
                    .HasMaxLength(6)
                    .HasColumnName("druzyny_id_druzyny");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Nagroda)
                    .HasPrecision(10, 5)
                    .HasColumnName("nagroda");

                entity.Property(e => e.OstatniWynik)
                    .HasMaxLength(10)
                    .HasColumnName("ostatni_wynik");

                entity.Property(e => e.Rodzaj)
                    .HasMaxLength(8)
                    .HasColumnName("rodzaj");

                entity.Property(e => e.ZajeteMiejsce).HasColumnName("zajete_miejsce");

                entity.HasOne(d => d.DruzynyIdDruzynyNavigation)
                    .WithMany(p => p.Turniejes)
                    .HasForeignKey(d => d.DruzynyIdDruzyny)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("druzynyidtur_fk");
            });

            modelBuilder.Entity<ZakupionePrzedmioty>(entity =>
            {
                entity.ToTable("zakupione_przedmioty");

                entity.HasIndex(e => e.IdPrzed, "zakupione_przedmioty__idx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPrzed).HasColumnName("id_przed");

                entity.HasOne(d => d.IdPrzedNavigation)
                    .WithOne(p => p.ZakupionePrzedmioty)
                    .HasForeignKey<ZakupionePrzedmioty>(d => d.IdPrzed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("przedmiotyid3_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
