using Microsoft.EntityFrameworkCore;
using KolayMizan.Models;
using System.Collections.Generic;

namespace KolayMizan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Kullanıcı yönetimi için DbSet'ler
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }

        // Müşteri/Tedarikçi yönetimi için DbSet'ler
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<CariGrup> CariGruplari { get; set; }
        public DbSet<CariAdres> CariAdresler { get; set; }
        public DbSet<CariIletisim> CariIletisimler { get; set; }

        // Ürün/Stok yönetimi için DbSet'ler
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunKategori> UrunKategoriler { get; set; }
        public DbSet<StokHareket> StokHareketler { get; set; }
        public DbSet<Depo> Depolar { get; set; }

        // Fatura yönetimi için DbSet'ler
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaKalem> FaturaKalemler { get; set; }

        // Ödeme/Tahsilat yönetimi için DbSet'ler
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<Tahsilat> Tahsilatlar { get; set; }

        // Banka hesabı yönetimi için DbSet'ler
        public DbSet<BankaHesap> BankaHesaplar { get; set; }
        public DbSet<BankaHareket> BankaHareketler { get; set; }

        // Gider yönetimi için DbSet'ler
        public DbSet<Gider> Giderler { get; set; }
        public DbSet<GiderKategori> GiderKategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri ve kısıtlamaları burada tanımlayacağız
            
            // Kullanıcı - Rol ilişkisi
            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Rol)
                .WithMany(r => r.Kullanicilar)
                .HasForeignKey(k => k.RolId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Cari - CariGrup ilişkisi
            modelBuilder.Entity<Cari>()
                .HasOne(c => c.CariGrup)
                .WithMany(g => g.Cariler)
                .HasForeignKey(c => c.CariGrupId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
                
            // Cari - CariAdres ilişkisi
            modelBuilder.Entity<CariAdres>()
                .HasOne(a => a.Cari)
                .WithMany(c => c.Adresler)
                .HasForeignKey(a => a.CariId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Cari - CariIletisim ilişkisi
            modelBuilder.Entity<CariIletisim>()
                .HasOne(i => i.Cari)
                .WithMany(c => c.IletisimBilgileri)
                .HasForeignKey(i => i.CariId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Urun - UrunKategori ilişkisi
            modelBuilder.Entity<Urun>()
                .HasOne(u => u.UrunKategori)
                .WithMany(k => k.Urunler)
                .HasForeignKey(u => u.UrunKategoriId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
                
            // UrunKategori - UstKategori ilişkisi
            modelBuilder.Entity<UrunKategori>()
                .HasOne(k => k.UstKategori)
                .WithMany(k => k.AltKategoriler)
                .HasForeignKey(k => k.UstKategoriId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // StokHareket - Urun ilişkisi
            modelBuilder.Entity<StokHareket>()
                .HasOne(s => s.Urun)
                .WithMany(u => u.StokHareketleri)
                .HasForeignKey(s => s.UrunId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // StokHareket - Depo ilişkisi
            modelBuilder.Entity<StokHareket>()
                .HasOne(s => s.Depo)
                .WithMany(d => d.StokHareketleri)
                .HasForeignKey(s => s.DepoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // StokHareket - HedefDepo ilişkisi
            modelBuilder.Entity<StokHareket>()
                .HasOne(s => s.HedefDepo)
                .WithMany(d => d.HedefStokHareketleri)
                .HasForeignKey(s => s.HedefDepoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // StokHareket - Cari ilişkisi
            modelBuilder.Entity<StokHareket>()
                .HasOne(s => s.Cari)
                .WithMany()
                .HasForeignKey(s => s.CariId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // StokHareket - Fatura ilişkisi
            modelBuilder.Entity<StokHareket>()
                .HasOne(s => s.Fatura)
                .WithMany(f => f.StokHareketleri)
                .HasForeignKey(s => s.FaturaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Fatura - Cari ilişkisi
            modelBuilder.Entity<Fatura>()
                .HasOne(f => f.Cari)
                .WithMany(c => c.Faturalar)
                .HasForeignKey(f => f.CariId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // FaturaKalem - Fatura ilişkisi
            modelBuilder.Entity<FaturaKalem>()
                .HasOne(k => k.Fatura)
                .WithMany(f => f.FaturaKalemleri)
                .HasForeignKey(k => k.FaturaId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // FaturaKalem - Urun ilişkisi
            modelBuilder.Entity<FaturaKalem>()
                .HasOne(k => k.Urun)
                .WithMany(u => u.FaturaKalemleri)
                .HasForeignKey(k => k.UrunId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Odeme - Cari ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Cari)
                .WithMany(c => c.Odemeler)
                .HasForeignKey(o => o.CariId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Odeme - Fatura ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Fatura)
                .WithMany(f => f.Odemeler)
                .HasForeignKey(o => o.FaturaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Odeme - BankaHesap ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.BankaHesap)
                .WithMany(b => b.Odemeler)
                .HasForeignKey(o => o.BankaHesapId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Tahsilat - Cari ilişkisi
            modelBuilder.Entity<Tahsilat>()
                .HasOne(t => t.Cari)
                .WithMany(c => c.Tahsilatlar)
                .HasForeignKey(t => t.CariId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Tahsilat - Fatura ilişkisi
            modelBuilder.Entity<Tahsilat>()
                .HasOne(t => t.Fatura)
                .WithMany(f => f.Tahsilatlar)
                .HasForeignKey(t => t.FaturaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Tahsilat - BankaHesap ilişkisi
            modelBuilder.Entity<Tahsilat>()
                .HasOne(t => t.BankaHesap)
                .WithMany(b => b.Tahsilatlar)
                .HasForeignKey(t => t.BankaHesapId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // BankaHareket - BankaHesap ilişkisi
            modelBuilder.Entity<BankaHareket>()
                .HasOne(h => h.BankaHesap)
                .WithMany(b => b.BankaHareketleri)
                .HasForeignKey(h => h.BankaHesapId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // BankaHareket - HedefHesap ilişkisi
            modelBuilder.Entity<BankaHareket>()
                .HasOne(h => h.HedefHesap)
                .WithMany()
                .HasForeignKey(h => h.HedefHesapId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // BankaHareket - Cari ilişkisi
            modelBuilder.Entity<BankaHareket>()
                .HasOne(h => h.Cari)
                .WithMany()
                .HasForeignKey(h => h.CariId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // BankaHareket - Odeme ilişkisi
            modelBuilder.Entity<BankaHareket>()
                .HasOne(h => h.Odeme)
                .WithMany()
                .HasForeignKey(h => h.OdemeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // BankaHareket - Tahsilat ilişkisi
            modelBuilder.Entity<BankaHareket>()
                .HasOne(h => h.Tahsilat)
                .WithMany()
                .HasForeignKey(h => h.TahsilatId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Gider - GiderKategori ilişkisi
            modelBuilder.Entity<Gider>()
                .HasOne(g => g.GiderKategori)
                .WithMany(k => k.Giderler)
                .HasForeignKey(g => g.GiderKategoriId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
                
            // Gider - Cari ilişkisi
            modelBuilder.Entity<Gider>()
                .HasOne(g => g.Cari)
                .WithMany()
                .HasForeignKey(g => g.CariId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Gider - Odeme ilişkisi
            modelBuilder.Entity<Gider>()
                .HasOne(g => g.Odeme)
                .WithMany()
                .HasForeignKey(g => g.OdemeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // GiderKategori - UstKategori ilişkisi
            modelBuilder.Entity<GiderKategori>()
                .HasOne(k => k.UstKategori)
                .WithMany(k => k.AltKategoriler)
                .HasForeignKey(k => k.UstKategoriId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Null olabilecek string alanları için varsayılan değer atama
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && property.IsNullable == false)
                    {
                        property.SetDefaultValue("");
                    }
                }
            }
        }
    }
} 