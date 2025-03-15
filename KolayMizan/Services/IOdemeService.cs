using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface IOdemeService
    {
        Task<List<Odeme>> GetAllAsync();
        Task<Odeme> GetByIdAsync(int id);
        Task<bool> CreateAsync(Odeme odeme);
        Task<bool> UpdateAsync(Odeme odeme);
        Task<bool> DeleteAsync(int id);
        Task<List<Odeme>> GetByCariIdAsync(int cariId);
        Task<List<Odeme>> GetByFaturaIdAsync(int faturaId);
        Task<List<Odeme>> GetByTarihAralikAsync(DateTime baslangic, DateTime bitis);
        Task<List<Odeme>> GetByOdemeTipiAsync(OdemeTip odemeTipi);
        Task<decimal> GetToplamOdemeAsync(DateTime baslangic, DateTime bitis);
        Task<List<Odeme>> SearchAsync(string searchTerm);
    }
} 