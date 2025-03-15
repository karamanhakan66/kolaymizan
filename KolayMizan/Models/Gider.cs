using System;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class Gider : BaseEntity
    {
        [Required(ErrorMessage = "Gider tarihi zorunludur.")]
        public DateTime GiderTarihi { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Gider tutarı zorunludur.")]
        public decimal Tutar { get; set; }

        public decimal KDVOrani { get; set; } = 18;
        public decimal KDVTutari { get; set; } = 0;
        public decimal ToplamTutar { get; set; } = 0;

        [StringLength(20, ErrorMessage = "Belge numarası en fazla 20 karakter olabilir.")]
        public string BelgeNo { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        public bool Odendi { get; set; } = false;
        public DateTime? OdemeTarihi { get; set; }

        // İlişkiler
        public int? GiderKategoriId { get; set; }
        public virtual GiderKategori GiderKategori { get; set; }

        public int? CariId { get; set; }
        public virtual Cari Cari { get; set; }

        public int? OdemeId { get; set; }
        public virtual Odeme Odeme { get; set; }
    }
} 