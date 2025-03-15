using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolayMizan.Data;
using KolayMizan.Models;
using Microsoft.EntityFrameworkCore;

namespace KolayMizan.Services
{
    public class CariService : ICariService
    {
        private readonly ApplicationDbContext _context;

        public CariService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cari>> GetAllAsync()
        {
            return await _context.Cariler
                .Include(c => c.CariGrup)
                .Where(c => !c.Silindi)
                .ToListAsync();
        }

        public async Task<List<Cari>> GetMusterilerAsync()
        {
            return await _context.Cariler
                .Include(c => c.CariGrup)
                .Where(c => !c.Silindi && (c.CariTipi == CariTip.Musteri || c.CariTipi == CariTip.MusteriVeTedarikci))
                .ToListAsync();
        }

        public async Task<List<Cari>> GetTedarikcilerAsync()
        {
            return await _context.Cariler
                .Include(c => c.CariGrup)
                .Where(c => !c.Silindi && (c.CariTipi == CariTip.Tedarikci || c.CariTipi == CariTip.MusteriVeTedarikci))
                .ToListAsync();
        }

        public async Task<Cari> GetByIdAsync(int id)
        {
            return await _context.Cariler
                .Include(c => c.CariGrup)
                .Include(c => c.Adresler)
                .Include(c => c.IletisimBilgileri)
                .FirstOrDefaultAsync(c => c.Id == id && !c.Silindi);
        }

        public async Task<Cari> GetByKodAsync(string cariKodu)
        {
            return await _context.Cariler
                .Include(c => c.CariGrup)
                .Include(c => c.Adresler)
                .Include(c => c.IletisimBilgileri)
                .FirstOrDefaultAsync(c => c.CariKodu == cariKodu && !c.Silindi);
        }

        public async Task<bool> CreateAsync(Cari cari)
        {
            if (await _context.Cariler.AnyAsync(c => c.CariKodu == cari.CariKodu))
                return false;

            cari.OlusturmaTarihi = DateTime.Now;
            await _context.Cariler.AddAsync(cari);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Cari cari)
        {
            var existingCari = await _context.Cariler.FindAsync(cari.Id);
            if (existingCari == null || existingCari.Silindi)
                return false;

            // Cari kodu değiştirilmek isteniyorsa ve yeni cari kodu başka bir cari tarafından kullanılıyorsa
            if (existingCari.CariKodu != cari.CariKodu &&
                await _context.Cariler.AnyAsync(c => c.CariKodu == cari.CariKodu && c.Id != cari.Id))
                return false;

            existingCari.CariKodu = cari.CariKodu;
            existingCari.CariAdi = cari.CariAdi;
            existingCari.CariTipi = cari.CariTipi;
            existingCari.TcKimlikNo = cari.TcKimlikNo;
            existingCari.VergiDairesi = cari.VergiDairesi;
            existingCari.VergiNo = cari.VergiNo;
            existingCari.Telefon = cari.Telefon;
            existingCari.Email = cari.Email;
            existingCari.WebSitesi = cari.WebSitesi;
            existingCari.RiskLimiti = cari.RiskLimiti;
            existingCari.CariGrupId = cari.CariGrupId;
            existingCari.Aktif = cari.Aktif;
            existingCari.GuncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cari = await _context.Cariler.FindAsync(id);
            if (cari == null)
                return false;

            cari.Silindi = true;
            cari.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetBakiyeAsync(int cariId)
        {
            var cari = await _context.Cariler.FindAsync(cariId);
            if (cari == null || cari.Silindi)
                return 0;

            return cari.Bakiye;
        }

        public async Task<List<Cari>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync();

            return await _context.Cariler
                .Include(c => c.CariGrup)
                .Where(c => !c.Silindi && (
                    c.CariKodu.Contains(searchTerm) ||
                    c.CariAdi.Contains(searchTerm) ||
                    c.VergiNo.Contains(searchTerm) ||
                    c.Telefon.Contains(searchTerm) ||
                    c.Email.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<List<CariGrup>> GetAllGruplarAsync()
        {
            return await _context.CariGruplari
                .Where(g => !g.Silindi)
                .ToListAsync();
        }

        public async Task<CariGrup> GetGrupByIdAsync(int id)
        {
            return await _context.CariGruplari
                .Include(g => g.Cariler)
                .FirstOrDefaultAsync(g => g.Id == id && !g.Silindi);
        }

        public async Task<bool> CreateGrupAsync(CariGrup grup)
        {
            if (await _context.CariGruplari.AnyAsync(g => g.GrupAdi == grup.GrupAdi))
                return false;

            grup.OlusturmaTarihi = DateTime.Now;
            await _context.CariGruplari.AddAsync(grup);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateGrupAsync(CariGrup grup)
        {
            var existingGrup = await _context.CariGruplari.FindAsync(grup.Id);
            if (existingGrup == null || existingGrup.Silindi)
                return false;

            // Grup adı değiştirilmek isteniyorsa ve yeni grup adı başka bir grup tarafından kullanılıyorsa
            if (existingGrup.GrupAdi != grup.GrupAdi &&
                await _context.CariGruplari.AnyAsync(g => g.GrupAdi == grup.GrupAdi && g.Id != grup.Id))
                return false;

            existingGrup.GrupAdi = grup.GrupAdi;
            existingGrup.Aciklama = grup.Aciklama;
            existingGrup.Aktif = grup.Aktif;
            existingGrup.GuncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGrupAsync(int id)
        {
            var grup = await _context.CariGruplari.FindAsync(id);
            if (grup == null)
                return false;

            // Gruba bağlı cariler varsa silme işlemi yapılmamalı
            if (await _context.Cariler.AnyAsync(c => c.CariGrupId == id && !c.Silindi))
                return false;

            grup.Silindi = true;
            grup.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddAdresAsync(CariAdres adres)
        {
            var cari = await _context.Cariler.FindAsync(adres.CariId);
            if (cari == null || cari.Silindi)
                return false;

            adres.OlusturmaTarihi = DateTime.Now;
            await _context.CariAdresler.AddAsync(adres);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAdresAsync(CariAdres adres)
        {
            var existingAdres = await _context.CariAdresler.FindAsync(adres.Id);
            if (existingAdres == null || existingAdres.Silindi)
                return false;

            existingAdres.AdresAdi = adres.AdresAdi;
            existingAdres.AdresTipi = adres.AdresTipi;
            existingAdres.Adres = adres.Adres;
            existingAdres.Ilce = adres.Ilce;
            existingAdres.Il = adres.Il;
            existingAdres.PostaKodu = adres.PostaKodu;
            existingAdres.Ulke = adres.Ulke;
            existingAdres.Aktif = adres.Aktif;
            existingAdres.GuncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdresAsync(int id)
        {
            var adres = await _context.CariAdresler.FindAsync(id);
            if (adres == null)
                return false;

            adres.Silindi = true;
            adres.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddIletisimAsync(CariIletisim iletisim)
        {
            var cari = await _context.Cariler.FindAsync(iletisim.CariId);
            if (cari == null || cari.Silindi)
                return false;

            iletisim.OlusturmaTarihi = DateTime.Now;
            await _context.CariIletisimler.AddAsync(iletisim);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateIletisimAsync(CariIletisim iletisim)
        {
            var existingIletisim = await _context.CariIletisimler.FindAsync(iletisim.Id);
            if (existingIletisim == null || existingIletisim.Silindi)
                return false;

            existingIletisim.IletisimAdi = iletisim.IletisimAdi;
            existingIletisim.IletisimTipi = iletisim.IletisimTipi;
            existingIletisim.Deger = iletisim.Deger;
            existingIletisim.Aktif = iletisim.Aktif;
            existingIletisim.GuncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIletisimAsync(int id)
        {
            var iletisim = await _context.CariIletisimler.FindAsync(id);
            if (iletisim == null)
                return false;

            iletisim.Silindi = true;
            iletisim.GuncellemeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 