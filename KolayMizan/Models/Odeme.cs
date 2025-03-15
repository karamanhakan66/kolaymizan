using System;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum OdemeTip
    {
        Nakit = 1,
        BankaTransferi = 2,
        KrediKarti = 3,
        Cek = 4,
        Senet = 5,
        Diger = 6
    }

    public class Odeme : BaseEntity
    {
        [Required(ErrorMessage = "Ödeme tarihi zorunludur.")]
        public DateTime OdemeTarihi { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Ödeme tutarı zorunludur.")]
        public decimal OdemeTutari { get; set; }

        public OdemeTip OdemeTipi { get; set; }

        [StringLength(20, ErrorMessage = "Belge numarası en fazla 20 karakter olabilir.")]
        public string BelgeNo { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // İlişkiler
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }

        public int? FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }

        public int? BankaHesapId { get; set; }
        public virtual BankaHesap BankaHesap { get; set; }
    }
} 