using System;

namespace KolayMizan.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellemeTarihi { get; set; }
        public string? OlusturanKullanici { get; set; }
        public string? GuncelleyenKullanici { get; set; }
        public bool Aktif { get; set; } = true;
        public bool Silindi { get; set; } = false;
    }
} 