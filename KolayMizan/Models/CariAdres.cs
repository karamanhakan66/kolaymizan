using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum AdresTip
    {
        Merkez = 1,
        Fatura = 2,
        Sevkiyat = 3,
        Diger = 4
    }

    public class CariAdres : BaseEntity
    {
        [Required(ErrorMessage = "Adres adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Adres adı en fazla 50 karakter olabilir.")]
        public string AdresAdi { get; set; }

        public AdresTip AdresTipi { get; set; } = AdresTip.Merkez;

        [Required(ErrorMessage = "Adres zorunludur.")]
        [StringLength(250, ErrorMessage = "Adres en fazla 250 karakter olabilir.")]
        public string Adres { get; set; }

        [StringLength(50, ErrorMessage = "İlçe en fazla 50 karakter olabilir.")]
        public string Ilce { get; set; }

        [StringLength(50, ErrorMessage = "İl en fazla 50 karakter olabilir.")]
        public string Il { get; set; }

        [StringLength(10, ErrorMessage = "Posta kodu en fazla 10 karakter olabilir.")]
        public string PostaKodu { get; set; }

        [StringLength(50, ErrorMessage = "Ülke en fazla 50 karakter olabilir.")]
        public string Ulke { get; set; } = "Türkiye";

        // İlişkiler
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
    }
} 