using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface IBankaService
    {
        Task<List<BankaHesap>> GetAllHesaplarAsync();
        Task<BankaHesap> GetHesapByIdAsync(int id);
        Task<bool> CreateHesapAsync(BankaHesap hesap);
        Task<bool> UpdateHesapAsync(BankaHesap hesap);
        Task<bool> DeleteHesapAsync(int id);
        Task<decimal> GetHesapBakiyeAsync(int hesapId);
        Task<List<BankaHesap>> SearchHesaplarAsync(string searchTerm);
        Task<List<BankaHareket>> GetAllHareketlerAsync();
        Task<List<BankaHareket>> GetHareketlerByHesapIdAsync(int hesapId);
        Task<BankaHareket> GetHareketByIdAsync(int id);
        Task<bool> CreateHareketAsync(BankaHareket hareket);
        Task<bool> UpdateHareketAsync(BankaHareket hareket);
        Task<bool> DeleteHareketAsync(int id);
        Task<bool> ParaTransferAsync(int kaynakHesapId, int hedefHesapId, decimal tutar, string aciklama);
        Task<List<BankaHareket>> GetHareketlerByTarihAralikAsync(DateTime baslangic, DateTime bitis);
        Task<decimal> GetToplamGirisAsync(int hesapId, DateTime baslangic, DateTime bitis);
        Task<decimal> GetToplamCikisAsync(int hesapId, DateTime baslangic, DateTime bitis);
    }
} 