using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum UrunTip
    {
        Urun = 1,
        Hizmet = 2
    }

    public class Urun : BaseEntity
    {
        [Required(ErrorMessage = "Ürün kodu zorunludur.")]
        [StringLength(20, ErrorMessage = "Ürün kodu en fazla 20 karakter olabilir.")]
        public string UrunKodu { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
        public string UrunAdi { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Aciklama { get; set; }

        public UrunTip UrunTipi { get; set; } = UrunTip.Urun;

        [StringLength(20, ErrorMessage = "Barkod en fazla 20 karakter olabilir.")]
        public string Barkod { get; set; }

        public decimal AlisFiyati { get; set; } = 0;
        public decimal SatisFiyati { get; set; } = 0;
        public decimal KDVOrani { get; set; } = 18;

        public decimal StokMiktari { get; set; } = 0;
        public decimal MinimumStokMiktari { get; set; } = 0;
        public string StokBirimi { get; set; } = "Adet";

        public string UrunResmi { get; set; }

        public int? UrunKategoriId { get; set; }
        public virtual UrunKategori UrunKategori { get; set; }

        // İlişkiler
        public virtual ICollection<StokHareket> StokHareketleri { get; set; }
        public virtual ICollection<FaturaKalem> FaturaKalemleri { get; set; }
    }
} 