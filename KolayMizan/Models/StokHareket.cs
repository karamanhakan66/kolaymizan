using System;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum StokHareketTip
    {
        Giris = 1,
        Cikis = 2,
        Transfer = 3,
        Sayim = 4
    }

    public class StokHareket : BaseEntity
    {
        [Required(ErrorMessage = "Hareket tarihi zorunludur.")]
        public DateTime HareketTarihi { get; set; } = DateTime.Now;

        public StokHareketTip HareketTipi { get; set; }

        [Required(ErrorMessage = "Miktar zorunludur.")]
        public decimal Miktar { get; set; }

        public decimal BirimFiyat { get; set; } = 0;
        public decimal ToplamTutar { get; set; } = 0;

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        public string ReferansNo { get; set; }
        public string BelgeNo { get; set; }

        // İlişkiler
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        public int? DepoId { get; set; }
        public virtual Depo Depo { get; set; }

        public int? HedefDepoId { get; set; }
        public virtual Depo HedefDepo { get; set; }

        public int? CariId { get; set; }
        public virtual Cari Cari { get; set; }

        public int? FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
} 