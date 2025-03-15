using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KolayMizan.Models;
using KolayMizan.Services;

namespace KolayMizan.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(string kullaniciAdi, string sifre, bool beniHatirla = false)
        {
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                ViewBag.Hata = "Kullanıcı adı ve şifre zorunludur.";
                return View();
            }

            var gecerli = await _kullaniciService.ValidatePasswordAsync(kullaniciAdi, sifre);
            if (!gecerli)
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }

            var kullanici = await _kullaniciService.GetByKullaniciAdiAsync(kullaniciAdi);
            if (kullanici == null || !kullanici.Aktif)
            {
                ViewBag.Hata = "Kullanıcı hesabı aktif değil.";
                return View();
            }

            // Oturum açma işlemleri burada yapılacak
            // Şimdilik basit bir yönlendirme yapıyoruz
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kayit(Kullanici kullanici, string sifre, string sifreTekrar)
        {
            if (string.IsNullOrEmpty(sifre) || sifre != sifreTekrar)
            {
                ViewBag.Hata = "Şifreler eşleşmiyor.";
                return View(kullanici);
            }

            var basarili = await _kullaniciService.CreateAsync(kullanici, sifre);
            if (!basarili)
            {
                ViewBag.Hata = "Kullanıcı oluşturulurken bir hata oluştu. Kullanıcı adı veya e-posta adresi zaten kullanılıyor olabilir.";
                return View(kullanici);
            }

            // E-posta onayı için bilgilendirme mesajı
            ViewBag.Basarili = "Kullanıcı kaydınız başarıyla oluşturuldu. E-posta adresinize gönderilen onay kodunu kullanarak hesabınızı aktifleştirebilirsiniz.";
            return View("Giris");
        }

        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Hata = "E-posta adresi zorunludur.";
                return View();
            }

            var basarili = await _kullaniciService.SifreSifirlamaBaslatAsync(email);
            if (!basarili)
            {
                ViewBag.Hata = "Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı.";
                return View();
            }

            ViewBag.Basarili = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.";
            return View();
        }

        [HttpGet]
        public IActionResult SifreSifirla(string email, string kod)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(kod))
            {
                return RedirectToAction("Giris");
            }

            ViewBag.Email = email;
            ViewBag.Kod = kod;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifreSifirla(string email, string kod, string yeniSifre, string yeniSifreTekrar)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(kod))
            {
                return RedirectToAction("Giris");
            }

            if (string.IsNullOrEmpty(yeniSifre) || yeniSifre != yeniSifreTekrar)
            {
                ViewBag.Email = email;
                ViewBag.Kod = kod;
                ViewBag.Hata = "Şifreler eşleşmiyor.";
                return View();
            }

            var basarili = await _kullaniciService.SifreSifirlamaOnaylaAsync(email, kod, yeniSifre);
            if (!basarili)
            {
                ViewBag.Email = email;
                ViewBag.Kod = kod;
                ViewBag.Hata = "Şifre sıfırlama işlemi başarısız oldu. Kod geçersiz veya süresi dolmuş olabilir.";
                return View();
            }

            ViewBag.Basarili = "Şifreniz başarıyla değiştirildi. Yeni şifreniz ile giriş yapabilirsiniz.";
            return View("Giris");
        }

        [HttpGet]
        public IActionResult EmailOnayla(string email, string kod)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(kod))
            {
                return RedirectToAction("Giris");
            }

            ViewBag.Email = email;
            ViewBag.Kod = kod;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailOnayla(string email, string kod)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(kod))
            {
                return RedirectToAction("Giris");
            }

            var basarili = await _kullaniciService.EmailOnaylaAsync(email, kod);
            if (!basarili)
            {
                ViewBag.Email = email;
                ViewBag.Kod = kod;
                ViewBag.Hata = "E-posta onaylama işlemi başarısız oldu. Kod geçersiz veya süresi dolmuş olabilir.";
                return View();
            }

            ViewBag.Basarili = "E-posta adresiniz başarıyla onaylandı. Giriş yapabilirsiniz.";
            return View("Giris");
        }

        [HttpGet]
        public IActionResult Cikis()
        {
            // Oturum kapatma işlemleri burada yapılacak
            return RedirectToAction("Giris");
        }
    }
} 