using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class GiderKategori : BaseEntity
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
        public string KategoriAdi { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        public int? UstKategoriId { get; set; }
        public virtual GiderKategori UstKategori { get; set; }

        // İlişkiler
        public virtual ICollection<Gider> Giderler { get; set; }
        public virtual ICollection<GiderKategori> AltKategoriler { get; set; }
    }
} 