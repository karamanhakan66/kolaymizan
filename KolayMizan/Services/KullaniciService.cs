using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KolayMizan.Data;
using KolayMizan.Models;
using Microsoft.EntityFrameworkCore;

namespace KolayMizan.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly ApplicationDbContext _context;

        public KullaniciService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kullanici>> GetAllAsync()
        {
            return await _context.Kullanicilar
                .Include(k => k.Rol)
                .Where(k => !k.Silindi)
                .ToListAsync();
        }

        public async Task<Kullanici> GetByIdAsync(int id)
        {
            return await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.Id == id && !k.Silindi);
        }

        public async Task<Kullanici> GetByKullaniciAdiAsync(string kullaniciAdi)
        {
            return await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.KullaniciAdi == kullaniciAdi && !k.Silindi);
        }

        public async Task<Kullanici> GetByEmailAsync(string email)
        {
            return await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.Email == email && !k.Silindi);
        }

        public async Task<bool> CreateAsync(Kullanici kullanici, string sifre)
        {
            if (await _context.Kullanicilar.AnyAsync(k => k.KullaniciAdi == kullanici.KullaniciAdi))
                return false;

            if (await _context.Kullanicilar.AnyAsync(k => k.Email == kullanici.Email))
                return false;

            kullanici.SifreHash = HashPassword(sifre);
            kullanici.OlusturmaTarihi = DateTime.Now;
            kullanici.OnayKodu = GenerateRandomCode();
            kullanici.OnayKoduSonGecerlilikTarihi = DateTime.Now.AddDays(1);

            await _context.Kullanicilar.AddAsync(kullanici);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Kullanici kullanici)
        {
            var existingKullanici = await _context.Kullanicilar.FindAsync(kullanici.Id);
            if (existingKullanici == null || existingKullanici.Silindi)
                return false;

            // Kullanıcı adı değiştirilmek isteniyorsa ve yeni kullanıcı adı başka bir kullanıcı tarafından kullanılıyorsa
            if (existingKullanici.KullaniciAdi != kullanici.KullaniciAdi &&
                await _context.Kullanicilar.AnyAsync(k => k.KullaniciAdi == kullanici.KullaniciAdi && k.Id != kullanici.Id))
                return false;

            // Email değiştirilmek isteniyorsa ve yeni email başka bir kullanıcı tarafından kullanılıyorsa
            if (existingKullanici.Email != kullanici.Email &&
                await _context.Kullanicilar.AnyAsync(k => k.Email == kullanici.Email && k.Id != kullanici.Id))
                return false;

            existingKullanici.KullaniciAdi = kullanici.KullaniciAdi;
            existingKullanici.Email = kullanici.Email;
            existingKullanici.Ad = kullanici.Ad;
            existingKullanici.Soyad = kullanici.Soyad;
            existingKullanici.Telefon = kullanici.Telefon;
            existingKullanici.RolId = kullanici.RolId;
            existingKullanici.ProfilResmi = kullanici.ProfilResmi;
            existingKullanici.Aktif = kullanici.Aktif;
            existingKullanici.GuncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
                return false;

            kullanici.Silindi = true;
            kullanici.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePasswordAsync(int id, string eskiSifre, string yeniSifre)
        {
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null || kullanici.Silindi)
                return false;

            if (!VerifyPassword(eskiSifre, kullanici.SifreHash))
                return false;

            kullanici.SifreHash = HashPassword(yeniSifre);
            kullanici.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidatePasswordAsync(string kullaniciAdi, string sifre)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.KullaniciAdi == kullaniciAdi && !k.Silindi && k.Aktif);

            if (kullanici == null)
                return false;

            bool isValid = VerifyPassword(sifre, kullanici.SifreHash);
            if (isValid)
            {
                kullanici.SonGirisTarihi = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return isValid;
        }

        public async Task<bool> EmailOnaylaAsync(string email, string onayKodu)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == email && !k.Silindi);

            if (kullanici == null || kullanici.EmailOnaylandi)
                return false;

            if (kullanici.OnayKodu != onayKodu || 
                kullanici.OnayKoduSonGecerlilikTarihi < DateTime.Now)
                return false;

            kullanici.EmailOnaylandi = true;
            kullanici.OnayKodu = null;
            kullanici.OnayKoduSonGecerlilikTarihi = null;
            kullanici.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SifreSifirlamaBaslatAsync(string email)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == email && !k.Silindi);

            if (kullanici == null)
                return false;

            kullanici.OnayKodu = GenerateRandomCode();
            kullanici.OnayKoduSonGecerlilikTarihi = DateTime.Now.AddHours(1);
            kullanici.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SifreSifirlamaOnaylaAsync(string email, string onayKodu, string yeniSifre)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == email && !k.Silindi);

            if (kullanici == null)
                return false;

            if (kullanici.OnayKodu != onayKodu || 
                kullanici.OnayKoduSonGecerlilikTarihi < DateTime.Now)
                return false;

            kullanici.SifreHash = HashPassword(yeniSifre);
            kullanici.OnayKodu = null;
            kullanici.OnayKoduSonGecerlilikTarihi = null;
            kullanici.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        private string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
} 