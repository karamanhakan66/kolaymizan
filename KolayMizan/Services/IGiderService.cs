using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface IGiderService
    {
        Task<List<Gider>> GetAllAsync();
        Task<Gider> GetByIdAsync(int id);
        Task<bool> CreateAsync(Gider gider);
        Task<bool> UpdateAsync(Gider gider);
        Task<bool> DeleteAsync(int id);
        Task<List<Gider>> GetByKategoriIdAsync(int kategoriId);
        Task<List<Gider>> GetByCariIdAsync(int cariId);
        Task<List<Gider>> GetByTarihAralikAsync(DateTime baslangic, DateTime bitis);
        Task<List<Gider>> GetOdenmeyenlerAsync();
        Task<decimal> GetToplamGiderAsync(DateTime baslangic, DateTime bitis);
        Task<List<Gider>> SearchAsync(string searchTerm);
        Task<List<GiderKategori>> GetAllKategorilerAsync();
        Task<GiderKategori> GetKategoriByIdAsync(int id);
        Task<bool> CreateKategoriAsync(GiderKategori kategori);
        Task<bool> UpdateKategoriAsync(GiderKategori kategori);
        Task<bool> DeleteKategoriAsync(int id);
        Task<bool> OdemeEkleAsync(int giderId, Odeme odeme);
    }
} 