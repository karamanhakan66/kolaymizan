using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum HesapTip
    {
        Vadesiz = 1,
        Vadeli = 2,
        KrediKarti = 3,
        Kredi = 4,
        Diger = 5
    }

    public class BankaHesap : BaseEntity
    {
        [Required(ErrorMessage = "Hesap adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Hesap adı en fazla 50 karakter olabilir.")]
        public string HesapAdi { get; set; }

        [Required(ErrorMessage = "Banka adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Banka adı en fazla 50 karakter olabilir.")]
        public string BankaAdi { get; set; }

        [StringLength(50, ErrorMessage = "Şube adı en fazla 50 karakter olabilir.")]
        public string SubeAdi { get; set; }

        [StringLength(10, ErrorMessage = "Şube kodu en fazla 10 karakter olabilir.")]
        public string SubeKodu { get; set; }

        [StringLength(30, ErrorMessage = "Hesap numarası en fazla 30 karakter olabilir.")]
        public string HesapNo { get; set; }

        [StringLength(30, ErrorMessage = "IBAN en fazla 30 karakter olabilir.")]
        public string IBAN { get; set; }

        public HesapTip HesapTipi { get; set; } = HesapTip.Vadesiz;

        public string ParaBirimi { get; set; } = "TL";
        public decimal Bakiye { get; set; } = 0;

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // İlişkiler
        public virtual ICollection<BankaHareket> BankaHareketleri { get; set; }
        public virtual ICollection<Odeme> Odemeler { get; set; }
        public virtual ICollection<Tahsilat> Tahsilatlar { get; set; }
    }
} 