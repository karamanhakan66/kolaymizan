using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface IKullaniciService
    {
        Task<List<Kullanici>> GetAllAsync();
        Task<Kullanici> GetByIdAsync(int id);
        Task<Kullanici> GetByKullaniciAdiAsync(string kullaniciAdi);
        Task<Kullanici> GetByEmailAsync(string email);
        Task<bool> CreateAsync(Kullanici kullanici, string sifre);
        Task<bool> UpdateAsync(Kullanici kullanici);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangePasswordAsync(int id, string eskiSifre, string yeniSifre);
        Task<bool> ValidatePasswordAsync(string kullaniciAdi, string sifre);
        Task<bool> EmailOnaylaAsync(string email, string onayKodu);
        Task<bool> SifreSifirlamaBaslatAsync(string email);
        Task<bool> SifreSifirlamaOnaylaAsync(string email, string onayKodu, string yeniSifre);
    }
} 