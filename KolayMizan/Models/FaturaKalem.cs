using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class FaturaKalem : BaseEntity
    {
        public int SiraNo { get; set; }

        [Required(ErrorMessage = "Miktar zorunludur.")]
        public decimal Miktar { get; set; }

        public decimal BirimFiyat { get; set; } = 0;
        public decimal IndirimOrani { get; set; } = 0;
        public decimal IndirimTutari { get; set; } = 0;
        public decimal KDVOrani { get; set; } = 18;
        public decimal KDVTutari { get; set; } = 0;
        public decimal AraToplam { get; set; } = 0;
        public decimal GenelToplam { get; set; } = 0;

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // İlişkiler
        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
    }
} 