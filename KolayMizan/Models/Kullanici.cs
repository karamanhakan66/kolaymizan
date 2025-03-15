using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class Kullanici : BaseEntity
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string SifreHash { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; }

        public string TamAd => $"{Ad} {Soyad}";

        public string Telefon { get; set; }

        public DateTime? SonGirisTarihi { get; set; }

        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }

        public string ProfilResmi { get; set; }

        public bool EmailOnaylandi { get; set; } = false;
        
        public string OnayKodu { get; set; }
        
        public DateTime? OnayKoduSonGecerlilikTarihi { get; set; }
    }
} 