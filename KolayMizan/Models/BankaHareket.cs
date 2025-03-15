using System;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum BankaHareketTip
    {
        Giris = 1,
        Cikis = 2,
        Virman = 3
    }

    public class BankaHareket : BaseEntity
    {
        [Required(ErrorMessage = "Hareket tarihi zorunludur.")]
        public DateTime HareketTarihi { get; set; } = DateTime.Now;

        public BankaHareketTip HareketTipi { get; set; }

        [Required(ErrorMessage = "Tutar zorunludur.")]
        public decimal Tutar { get; set; }

        [StringLength(20, ErrorMessage = "Belge numarası en fazla 20 karakter olabilir.")]
        public string BelgeNo { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // İlişkiler
        public int BankaHesapId { get; set; }
        public virtual BankaHesap BankaHesap { get; set; }

        public int? HedefHesapId { get; set; }
        public virtual BankaHesap HedefHesap { get; set; }

        public int? CariId { get; set; }
        public virtual Cari Cari { get; set; }

        public int? OdemeId { get; set; }
        public virtual Odeme Odeme { get; set; }

        public int? TahsilatId { get; set; }
        public virtual Tahsilat Tahsilat { get; set; }
    }
} 