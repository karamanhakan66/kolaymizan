using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface ITahsilatService
    {
        Task<List<Tahsilat>> GetAllAsync();
        Task<Tahsilat> GetByIdAsync(int id);
        Task<bool> CreateAsync(Tahsilat tahsilat);
        Task<bool> UpdateAsync(Tahsilat tahsilat);
        Task<bool> DeleteAsync(int id);
        Task<List<Tahsilat>> GetByCariIdAsync(int cariId);
        Task<List<Tahsilat>> GetByFaturaIdAsync(int faturaId);
        Task<List<Tahsilat>> GetByTarihAralikAsync(DateTime baslangic, DateTime bitis);
        Task<List<Tahsilat>> GetByTahsilatTipiAsync(TahsilatTip tahsilatTipi);
        Task<decimal> GetToplamTahsilatAsync(DateTime baslangic, DateTime bitis);
        Task<List<Tahsilat>> SearchAsync(string searchTerm);
    }
} 