using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KolayMizan.Models
{
    public class Kullanici : BaseEntity
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir.")]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string SifreHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; } = string.Empty;

        public string TamAd => $"{Ad} {Soyad}";

        public string Telefon { get; set; } = string.Empty;

        public DateTime? SonGirisTarihi { get; set; }

        public int RolId { get; set; }
        public virtual Rol Rol { get; set; } = null!;

        public string ProfilResmi { get; set; } = string.Empty;

        public bool EmailOnaylandi { get; set; } = false;
        
        public string OnayKodu { get; set; } = string.Empty;
        
        public DateTime? OnayKoduSonGecerlilikTarihi { get; set; }
    }
} 