using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class Rol : BaseEntity
    {
        [Required(ErrorMessage = "Rol adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Rol adı en fazla 50 karakter olabilir.")]
        public string RolAdi { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // Yetki bilgileri
        public bool KullaniciYonetimi { get; set; } = false;
        public bool CariYonetimi { get; set; } = false;
        public bool UrunYonetimi { get; set; } = false;
        public bool StokYonetimi { get; set; } = false;
        public bool FaturaYonetimi { get; set; } = false;
        public bool OdemeYonetimi { get; set; } = false;
        public bool TahsilatYonetimi { get; set; } = false;
        public bool BankaYonetimi { get; set; } = false;
        public bool GiderYonetimi { get; set; } = false;
        public bool RaporlamaYonetimi { get; set; } = false;
        public bool AyarlarYonetimi { get; set; } = false;

        // İlişkiler
        public virtual ICollection<Kullanici> Kullanicilar { get; set; }
    }
} 