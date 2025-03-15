using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public enum IletisimTip
    {
        Telefon = 1,
        Cep = 2,
        Faks = 3,
        Email = 4,
        Diger = 5
    }

    public class CariIletisim : BaseEntity
    {
        [Required(ErrorMessage = "İletişim adı zorunludur.")]
        [StringLength(50, ErrorMessage = "İletişim adı en fazla 50 karakter olabilir.")]
        public string IletisimAdi { get; set; }

        public IletisimTip IletisimTipi { get; set; }

        [Required(ErrorMessage = "İletişim değeri zorunludur.")]
        [StringLength(100, ErrorMessage = "İletişim değeri en fazla 100 karakter olabilir.")]
        public string Deger { get; set; }

        // İlişkiler
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
    }
} 