using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum CariTip
    {
        Musteri = 1,
        Tedarikci = 2,
        MusteriVeTedarikci = 3
    }

    public class Cari : BaseEntity
    {
        [Required(ErrorMessage = "Cari kodu zorunludur.")]
        [StringLength(20, ErrorMessage = "Cari kodu en fazla 20 karakter olabilir.")]
        public string CariKodu { get; set; }

        [Required(ErrorMessage = "Cari adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Cari adı en fazla 100 karakter olabilir.")]
        public string CariAdi { get; set; }

        public CariTip CariTipi { get; set; } = CariTip.Musteri;

        [StringLength(11, ErrorMessage = "TC Kimlik No en fazla 11 karakter olabilir.")]
        public string TcKimlikNo { get; set; }

        [StringLength(10, ErrorMessage = "Vergi dairesi en fazla 10 karakter olabilir.")]
        public string VergiDairesi { get; set; }

        [StringLength(11, ErrorMessage = "Vergi numarası en fazla 11 karakter olabilir.")]
        public string VergiNo { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }
        public string WebSitesi { get; set; }

        public decimal Bakiye { get; set; } = 0;
        public decimal RiskLimiti { get; set; } = 0;

        public int? CariGrupId { get; set; }
        public virtual CariGrup CariGrup { get; set; }

        // İlişkiler
        public virtual ICollection<CariAdres> Adresler { get; set; }
        public virtual ICollection<CariIletisim> IletisimBilgileri { get; set; }
        public virtual ICollection<Fatura> Faturalar { get; set; }
        public virtual ICollection<Odeme> Odemeler { get; set; }
        public virtual ICollection<Tahsilat> Tahsilatlar { get; set; }
    }
} 