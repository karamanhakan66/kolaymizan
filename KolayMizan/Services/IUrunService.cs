using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KolayMizan.Models;

namespace KolayMizan.Services
{
    public interface IUrunService
    {
        Task<List<Urun>> GetAllAsync();
        Task<Urun> GetByIdAsync(int id);
        Task<Urun> GetByKodAsync(string urunKodu);
        Task<Urun> GetByBarkodAsync(string barkod);
        Task<bool> CreateAsync(Urun urun);
        Task<bool> UpdateAsync(Urun urun);
        Task<bool> DeleteAsync(int id);
        Task<decimal> GetStokMiktariAsync(int urunId);
        Task<List<Urun>> SearchAsync(string searchTerm);
        Task<List<UrunKategori>> GetAllKategorilerAsync();
        Task<UrunKategori> GetKategoriByIdAsync(int id);
        Task<bool> CreateKategoriAsync(UrunKategori kategori);
        Task<bool> UpdateKategoriAsync(UrunKategori kategori);
        Task<bool> DeleteKategoriAsync(int id);
        Task<bool> StokGirisAsync(StokHareket stokHareket);
        Task<bool> StokCikisAsync(StokHareket stokHareket);
        Task<bool> StokTransferAsync(StokHareket stokHareket);
        Task<List<StokHareket>> GetStokHareketleriByUrunIdAsync(int urunId);
        Task<List<Depo>> GetAllDepolarAsync();
        Task<Depo> GetDepoByIdAsync(int id);
        Task<bool> CreateDepoAsync(Depo depo);
        Task<bool> UpdateDepoAsync(Depo depo);
        Task<bool> DeleteDepoAsync(int id);
    }
} 