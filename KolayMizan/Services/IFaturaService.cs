using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface IFaturaService
    {
        Task<List<Fatura>> GetAllAsync();
        Task<List<Fatura>> GetSatisFaturalariAsync();
        Task<List<Fatura>> GetAlisFaturalariAsync();
        Task<Fatura> GetByIdAsync(int id);
        Task<Fatura> GetByNoAsync(string faturaNo);
        Task<bool> CreateAsync(Fatura fatura, List<FaturaKalem> kalemler);
        Task<bool> UpdateAsync(Fatura fatura, List<FaturaKalem> kalemler);
        Task<bool> DeleteAsync(int id);
        Task<bool> OdemeEkleAsync(int faturaId, Odeme odeme);
        Task<bool> TahsilatEkleAsync(int faturaId, Tahsilat tahsilat);
        Task<List<Fatura>> GetByCariIdAsync(int cariId);
        Task<List<Fatura>> GetVadesiGelenlerAsync();
        Task<List<Fatura>> GetOdenmeyenlerAsync();
        Task<List<Fatura>> SearchAsync(string searchTerm);
        Task<List<FaturaKalem>> GetFaturaKalemlerByFaturaIdAsync(int faturaId);
    }
} 