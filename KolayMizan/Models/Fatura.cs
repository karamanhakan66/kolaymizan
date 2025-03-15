using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum FaturaTip
    {
        Satis = 1,
        Alis = 2,
        SatisIade = 3,
        AlisIade = 4
    }

    public class Fatura : BaseEntity
    {
        [Required(ErrorMessage = "Fatura numarası zorunludur.")]
        [StringLength(20, ErrorMessage = "Fatura numarası en fazla 20 karakter olabilir.")]
        public string FaturaNo { get; set; }

        [Required(ErrorMessage = "Fatura tarihi zorunludur.")]
        public DateTime FaturaTarihi { get; set; } = DateTime.Now;

        public FaturaTip FaturaTipi { get; set; }

        [StringLength(20, ErrorMessage = "Seri numarası en fazla 20 karakter olabilir.")]
        public string SeriNo { get; set; }

        [StringLength(20, ErrorMessage = "Sıra numarası en fazla 20 karakter olabilir.")]
        public string SiraNo { get; set; }

        public decimal AraToplam { get; set; } = 0;
        public decimal IndirimTutari { get; set; } = 0;
        public decimal KDVTutari { get; set; } = 0;
        public decimal GenelToplam { get; set; } = 0;

        public DateTime? VadeTarihi { get; set; }
        public bool Odendi { get; set; } = false;
        public decimal OdenenTutar { get; set; } = 0;
        public decimal KalanTutar { get; set; } = 0;

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // İlişkiler
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }

        public virtual ICollection<FaturaKalem> FaturaKalemleri { get; set; }
        public virtual ICollection<StokHareket> StokHareketleri { get; set; }
        public virtual ICollection<Odeme> Odemeler { get; set; }
        public virtual ICollection<Tahsilat> Tahsilatlar { get; set; }
    }
} 