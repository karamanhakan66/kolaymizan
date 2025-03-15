# Ön Muhasebe Programı - Ürün Gereksinim Dokümanı (PRD)

## 1. Giriş

Bu doküman, .NET Core MVC ve Entity Framework Core kullanılarak geliştirilecek, MySQL veritabanı üzerinde çalışacak bir ön muhasebe programının temel gereksinimlerini ve özelliklerini tanımlamaktadır. Proje, modern ve kullanıcı dostu bir arayüz sunarak küçük ve orta ölçekli işletmelerin muhasebe ihtiyaçlarını karşılamayı hedeflemektedir.

## 2. Proje Hedefleri

- Kolay kullanılabilir ve modern bir arayüze sahip ön muhasebe yazılımı geliştirmek
- Portfolyo projesi olarak kullanılabilecek nitelikte bir uygulama oluşturmak
- İşletmelerin temel muhasebe işlemlerini karşılayacak fonksiyonlar sunmak
- Açık kaynak olarak paylaşılarak ücretsiz erişim sağlamak

## 3. Hedef Kullanıcılar

- Küçük ve orta ölçekli işletmeler
- Serbest çalışan girişimciler
- Temel muhasebe takibi yapmak isteyen bireysel kullanıcılar

## 4. Teknoloji Stack'i

- **Backend:** .NET Core MVC (en son kararlı sürüm)
- **ORM:** Entity Framework Core
- **Veritabanı:** MySQL
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap 5 / Tailwind CSS
- **Kimlik Doğrulama:** ASP.NET Core Identity
- **Raporlama:** RDLC veya yerel PDF oluşturma kütüphaneleri

## 5. Temel Özellikler

### 5.1 Kullanıcı Yönetimi
- Kullanıcı kayıt ve giriş işlemleri
- Rol tabanlı yetkilendirme (Admin, Muhasebeci, Görüntüleyici vb.)
- Şifre sıfırlama ve kullanıcı profil yönetimi

### 5.2 Müşteri/Tedarikçi Yönetimi
- Müşteri ve tedarikçi ekleme, düzenleme, silme
- Detaylı müşteri/tedarikçi bilgileri (ad, vergi no, adres, iletişim bilgileri vb.)
- Müşteri/tedarikçi kategorilendirme
- Cari hesap görüntüleme

### 5.3 Ürün/Hizmet Kataloğu
- Ürün ve hizmet tanımlama
- Stok yönetimi ve takibi
- Barkod desteği
- Kategori ve alt kategori yapısı
- Birim fiyat ve KDV oranları yönetimi

### 5.4 Fatura Yönetimi
- Satış faturası oluşturma
- Alış faturası oluşturma
- Proforma fatura oluşturma
- Fatura şablonları
- PDF olarak fatura çıktısı alma ve e-posta ile gönderme
- Ödenmemiş/kısmi ödenmiş/ödenmiş fatura takibi

### 5.5 Ödeme ve Tahsilat Yönetimi
- Tahsilat kaydı oluşturma
- Ödeme kaydı oluşturma
- Farklı ödeme yöntemleri (nakit, banka, kredi kartı)
- Vade takibi
- Alacak/borç durumu görüntüleme

### 5.6 Banka Hesapları Yönetimi
- Banka hesabı tanımlama ve yönetme
- Banka hesap hareketleri takibi
- Hesaplar arası transfer

### 5.7 Gider Yönetimi
- Gider kategorileri tanımlama
- Gider kaydı oluşturma ve takibi
- Fatura ile gider ilişkilendirme

### 5.8 Raporlama
- Gelir-gider raporu
- Kar/zarar analizi
- Müşteri/tedarikçi bazlı raporlar
- Vadesi geçmiş alacaklar raporu
- Stok durum raporu
- Dönemsel satış raporları
- Özelleştirilebilir rapor formatları

### 5.9 Dashboard
- Genel bakış sayfası
- Önemli finansal göstergeler
- Grafik ve tablolarla veri görselleştirme
- Vadesi yaklaşan ödemeler uyarısı
- Stok azalma uyarıları
- Son işlemler özeti

## 6. Veritabanı Şeması (Temel Tablolar)

- Users
- Roles
- UserRoles
- Customers
- Suppliers
- Products
- Categories
- Services
- Invoices
- InvoiceItems
- Payments
- Expenses
- ExpenseCategories
- BankAccounts
- BankTransactions
- Settings

## 7. Kullanıcı Arayüzü Gereksinimleri

- Responsive tasarım (mobil, tablet ve masaüstü uyumlu)
- Modern ve temiz arayüz
- Kolay navigasyon
- Dashboard widget'ları
- Tema seçenekleri (açık/koyu mod)
- Kullanıcı dostu formlar
- Gelişmiş arama ve filtreleme özellikleri
- Toplu işlem yapabilme yeteneği

## 8. Güvenlik Gereksinimleri

- Güvenli kimlik doğrulama
- HTTPS desteği
- SQL injection koruması
- CSRF koruması
- XSS koruması
- Giriş denemesi sınırlaması
- İşlem logları tutma
- Yetkilendirme kontrolleri

## 9. Performans Gereksinimleri

- Hızlı sayfa yükleme süreleri
- Veritabanı sorgu optimizasyonu
- Sayfalama desteği
- Lazy loading
- Caching mekanizmaları

## 10. Gelecek Geliştirmeler (v2)

- E-fatura entegrasyonu
- Mobil uygulama
- Çoklu dil desteği
- API desteği
- İleri düzey analitik
- Takvim ve hatırlatıcı özellikleri
- SMS bildirim entegrasyonu
- QR kod desteği
- Döviz kurları entegrasyonu

## 11. Örnek Ekran Tasarımları

Aşağıdaki ekranlar modern ve temiz bir tasarım anlayışıyla oluşturulmalıdır:

1. Giriş/Kayıt Ekranı
2. Dashboard
3. Müşteri Listesi
4. Müşteri Detay/Düzenleme
5. Fatura Oluşturma
6. Fatura Görüntüleme
7. Ürün/Hizmet Yönetimi
8. Ödeme/Tahsilat Girişi
9. Rapor Ekranları
10. Ayarlar

## 12. Ürün Yol Haritası

### Faz 1 (Temel Sürüm)
- Kullanıcı yönetimi
- Müşteri/tedarikçi yönetimi
- Ürün kataloğu
- Temel fatura işlemleri
- Basit raporlar

### Faz 2 (Geliştirme)
- Gelişmiş fatura özellikleri
- Stok yönetimi
- Banka hesapları
- Gelişmiş raporlar
- Dashboard geliştirmeleri

### Faz 3 (Tamamlama)
- Tam raporlama sistemi
- Gelişmiş dashboard
- Toplu işlem özellikleri
- PDF çıktı ve e-posta entegrasyonu
- Son kullanıcı testleri ve hata düzeltmeleri

## 13. Geliştirme ve Test

- Test-driven development yaklaşımı
- Birim testleri
- Entegrasyon testleri
- Kullanıcı kabul testleri
- Güvenlik testleri

## 14. Proje Çıktıları

- Kaynak kodu (GitHub'da açık kaynak olarak)
- Kurulum ve kullanım dokümanları
- API referans dokümanı (ileride eklenecek özellik için)
- Demo site
