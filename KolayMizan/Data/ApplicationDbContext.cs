using Microsoft.EntityFrameworkCore;
using KolayMizan.Models;

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
        }
    }
} 