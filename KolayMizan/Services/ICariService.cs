using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface ICariService
    {
        Task<List<Cari>> GetAllAsync();
        Task<List<Cari>> GetMusterilerAsync();
        Task<List<Cari>> GetTedarikcilerAsync();
        Task<Cari> GetByIdAsync(int id);
        Task<Cari> GetByKodAsync(string cariKodu);
        Task<bool> CreateAsync(Cari cari);
        Task<bool> UpdateAsync(Cari cari);
        Task<bool> DeleteAsync(int id);
        Task<decimal> GetBakiyeAsync(int cariId);
        Task<List<Cari>> SearchAsync(string searchTerm);
        Task<List<CariGrup>> GetAllGruplarAsync();
        Task<CariGrup> GetGrupByIdAsync(int id);
        Task<bool> CreateGrupAsync(CariGrup grup);
        Task<bool> UpdateGrupAsync(CariGrup grup);
        Task<bool> DeleteGrupAsync(int id);
        Task<bool> AddAdresAsync(CariAdres adres);
        Task<bool> UpdateAdresAsync(CariAdres adres);
        Task<bool> DeleteAdresAsync(int id);
        Task<bool> AddIletisimAsync(CariIletisim iletisim);
        Task<bool> UpdateIletisimAsync(CariIletisim iletisim);
        Task<bool> DeleteIletisimAsync(int id);
    }
} 