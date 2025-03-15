using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class CariGrup : BaseEntity
    {
        [Required(ErrorMessage = "Grup adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Grup adı en fazla 50 karakter olabilir.")]
        public string GrupAdi { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        // İlişkiler
        public virtual ICollection<Cari> Cariler { get; set; }
    }
} 