using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class Depo : BaseEntity
    {
        [Required(ErrorMessage = "Depo kodu zorunludur.")]
        [StringLength(20, ErrorMessage = "Depo kodu en fazla 20 karakter olabilir.")]
        public string DepoKodu { get; set; }

        [Required(ErrorMessage = "Depo adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Depo adı en fazla 50 karakter olabilir.")]
        public string DepoAdi { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        [StringLength(250, ErrorMessage = "Adres en fazla 250 karakter olabilir.")]
        public string Adres { get; set; }

        public bool VarsayilanDepo { get; set; } = false;

        // İlişkiler
        public virtual ICollection<StokHareket> StokHareketleri { get; set; }
        public virtual ICollection<StokHareket> HedefStokHareketleri { get; set; }
    }
} 