using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolayMizan.Migrations
{
    /// <inheritdoc />
    public partial class IlkMigrasyon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankaHesaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    BankaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    SubeAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    SubeKodu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    HesapNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: ""),
                    IBAN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: ""),
                    HesapTipi = table.Column<int>(type: "int", nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Bakiye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHesaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CariGruplari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariGruplari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepoKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    DepoAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    VarsayilanDepo = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiderKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UstKategoriId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiderKategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiderKategoriler_GiderKategoriler_UstKategoriId",
                        column: x => x.UstKategoriId,
                        principalTable: "GiderKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    KullaniciYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    CariYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    UrunYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    StokYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    FaturaYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    OdemeYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    TahsilatYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    BankaYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    GiderYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    RaporlamaYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    AyarlarYonetimi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrunKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UstKategoriId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunKategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunKategoriler_UrunKategoriler_UstKategoriId",
                        column: x => x.UstKategoriId,
                        principalTable: "UrunKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cariler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    CariAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    CariTipi = table.Column<int>(type: "int", nullable: false),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, defaultValue: ""),
                    VergiDairesi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    VergiNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, defaultValue: ""),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    WebSitesi = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Bakiye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskLimiti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CariGrupId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cariler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cariler_CariGruplari_CariGrupId",
                        column: x => x.CariGrupId,
                        principalTable: "CariGruplari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    SifreHash = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    SonGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    ProfilResmi = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    EmailOnaylandi = table.Column<bool>(type: "bit", nullable: false),
                    OnayKodu = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    OnayKoduSonGecerlilikTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    UrunAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    UrunTipi = table.Column<int>(type: "int", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    AlisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDVOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumStokMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokBirimi = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    UrunResmi = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    UrunKategoriId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_UrunKategoriler_UrunKategoriId",
                        column: x => x.UrunKategoriId,
                        principalTable: "UrunKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CariAdresler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    AdresTipi = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    Ilce = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Il = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    PostaKodu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    Ulke = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariAdresler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariAdresler_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariIletisimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IletisimAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    IletisimTipi = table.Column<int>(type: "int", nullable: false),
                    Deger = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariIletisimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariIletisimler_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaTipi = table.Column<int>(type: "int", nullable: false),
                    SeriNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    SiraNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    AraToplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndirimTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDVTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenelToplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Odendi = table.Column<bool>(type: "bit", nullable: false),
                    OdenenTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KalanTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturalar_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaturaKalemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiraNo = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndirimOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndirimTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDVOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDVTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AraToplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenelToplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    FaturaId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaKalemler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaKalemler_Faturalar_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaKalemler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdemeTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeTipi = table.Column<int>(type: "int", nullable: false),
                    BelgeNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: true),
                    BankaHesapId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odemeler_BankaHesaplar_BankaHesapId",
                        column: x => x.BankaHesapId,
                        principalTable: "BankaHesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Odemeler_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Odemeler_Faturalar_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StokHareketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HareketTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HareketTipi = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    ReferansNo = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    BelgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    HedefDepoId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    FaturaId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokHareketler_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StokHareketler_Depolar_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StokHareketler_Depolar_HedefDepoId",
                        column: x => x.HedefDepoId,
                        principalTable: "Depolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StokHareketler_Faturalar_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StokHareketler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tahsilatlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TahsilatTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TahsilatTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TahsilatTipi = table.Column<int>(type: "int", nullable: false),
                    BelgeNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: true),
                    BankaHesapId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tahsilatlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tahsilatlar_BankaHesaplar_BankaHesapId",
                        column: x => x.BankaHesapId,
                        principalTable: "BankaHesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tahsilatlar_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tahsilatlar_Faturalar_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Giderler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiderTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDVOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDVTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BelgeNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    Odendi = table.Column<bool>(type: "bit", nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GiderKategoriId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    OdemeId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giderler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giderler_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Giderler_GiderKategoriler_GiderKategoriId",
                        column: x => x.GiderKategoriId,
                        principalTable: "GiderKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Giderler_Odemeler_OdemeId",
                        column: x => x.OdemeId,
                        principalTable: "Odemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankaHareketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HareketTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HareketTipi = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BelgeNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    BankaHesapId = table.Column<int>(type: "int", nullable: false),
                    HedefHesapId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    OdemeId = table.Column<int>(type: "int", nullable: true),
                    TahsilatId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    GuncelleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHareketler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankaHareketler_BankaHesaplar_BankaHesapId",
                        column: x => x.BankaHesapId,
                        principalTable: "BankaHesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankaHareketler_BankaHesaplar_HedefHesapId",
                        column: x => x.HedefHesapId,
                        principalTable: "BankaHesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankaHareketler_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankaHareketler_Odemeler_OdemeId",
                        column: x => x.OdemeId,
                        principalTable: "Odemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankaHareketler_Tahsilatlar_TahsilatId",
                        column: x => x.TahsilatId,
                        principalTable: "Tahsilatlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareketler_BankaHesapId",
                table: "BankaHareketler",
                column: "BankaHesapId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareketler_CariId",
                table: "BankaHareketler",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareketler_HedefHesapId",
                table: "BankaHareketler",
                column: "HedefHesapId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareketler_OdemeId",
                table: "BankaHareketler",
                column: "OdemeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareketler_TahsilatId",
                table: "BankaHareketler",
                column: "TahsilatId");

            migrationBuilder.CreateIndex(
                name: "IX_CariAdresler_CariId",
                table: "CariAdresler",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariIletisimler_CariId",
                table: "CariIletisimler",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Cariler_CariGrupId",
                table: "Cariler",
                column: "CariGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalemler_FaturaId",
                table: "FaturaKalemler",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalemler_UrunId",
                table: "FaturaKalemler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturalar_CariId",
                table: "Faturalar",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_GiderKategoriler_UstKategoriId",
                table: "GiderKategoriler",
                column: "UstKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Giderler_CariId",
                table: "Giderler",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Giderler_GiderKategoriId",
                table: "Giderler",
                column: "GiderKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Giderler_OdemeId",
                table: "Giderler",
                column: "OdemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_RolId",
                table: "Kullanicilar",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_BankaHesapId",
                table: "Odemeler",
                column: "BankaHesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_CariId",
                table: "Odemeler",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_FaturaId",
                table: "Odemeler",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketler_CariId",
                table: "StokHareketler",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketler_DepoId",
                table: "StokHareketler",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketler_FaturaId",
                table: "StokHareketler",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketler_HedefDepoId",
                table: "StokHareketler",
                column: "HedefDepoId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketler_UrunId",
                table: "StokHareketler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Tahsilatlar_BankaHesapId",
                table: "Tahsilatlar",
                column: "BankaHesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Tahsilatlar_CariId",
                table: "Tahsilatlar",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Tahsilatlar_FaturaId",
                table: "Tahsilatlar",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunKategoriler_UstKategoriId",
                table: "UrunKategoriler",
                column: "UstKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_UrunKategoriId",
                table: "Urunler",
                column: "UrunKategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankaHareketler");

            migrationBuilder.DropTable(
                name: "CariAdresler");

            migrationBuilder.DropTable(
                name: "CariIletisimler");

            migrationBuilder.DropTable(
                name: "FaturaKalemler");

            migrationBuilder.DropTable(
                name: "Giderler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "StokHareketler");

            migrationBuilder.DropTable(
                name: "Tahsilatlar");

            migrationBuilder.DropTable(
                name: "GiderKategoriler");

            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Depolar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "BankaHesaplar");

            migrationBuilder.DropTable(
                name: "Faturalar");

            migrationBuilder.DropTable(
                name: "UrunKategoriler");

            migrationBuilder.DropTable(
                name: "Cariler");

            migrationBuilder.DropTable(
                name: "CariGruplari");
        }
    }
}
