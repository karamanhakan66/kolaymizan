using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class UrunKategori : BaseEntity
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
        public string KategoriAdi { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Aciklama { get; set; }

        public int? UstKategoriId { get; set; }
        public virtual UrunKategori UstKategori { get; set; }

        // İlişkiler
        public virtual ICollection<Urun> Urunler { get; set; }
        public virtual ICollection<UrunKategori> AltKategoriler { get; set; }
    }
} 