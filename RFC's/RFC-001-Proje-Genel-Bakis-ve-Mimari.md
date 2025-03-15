# RFC-001: Proje Genel Bakış ve Mimari

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının genel bakışını, hedeflerini, teknoloji seçimlerini ve mimari yapısını tanımlamaktadır. Belge, projenin temel yapı taşlarını ve geliştirme prensiplerini ortaya koymaktadır.

## Motivasyon

Küçük ve orta ölçekli işletmelerin ön muhasebe ihtiyaçlarını karşılayacak, kullanımı kolay, modern ve açık kaynaklı bir çözüm sunmak. Mevcut ticari çözümler genellikle pahalı ve karmaşık olduğundan, daha erişilebilir bir alternatif oluşturmak amaçlanmaktadır.

## Hedef Kullanıcılar

- Küçük ve orta ölçekli işletmeler
- Serbest çalışan girişimciler
- Temel muhasebe takibi yapmak isteyen bireysel kullanıcılar

## Teknoloji Stack'i

- **Backend:** .NET Core MVC (en son kararlı sürüm)
- **ORM:** Entity Framework Core
- **Veritabanı:** MySQL
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap 5 / Tailwind CSS
- **Kimlik Doğrulama:** ASP.NET Core Identity
- **Raporlama:** RDLC veya yerel PDF oluşturma kütüphaneleri

## Mimari Yapı

### Katmanlı Mimari

Uygulama, aşağıdaki katmanlardan oluşacaktır:

1. **Sunum Katmanı (Presentation Layer)**
   - MVC Controllers
   - Views
   - ViewModels
   - JavaScript/AJAX işlemleri

2. **İş Katmanı (Business Layer)**
   - Services
   - Business Logic
   - Validation

3. **Veri Erişim Katmanı (Data Access Layer)**
   - Repositories
   - Entity Framework Context
   - Database Migrations

4. **Domain Katmanı**
   - Entities
   - Enums
   - Constants

### Veritabanı Şeması (Temel Tablolar)

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

## Güvenlik Gereksinimleri

- Güvenli kimlik doğrulama
- HTTPS desteği
- SQL injection koruması
- CSRF koruması
- XSS koruması
- Giriş denemesi sınırlaması
- İşlem logları tutma
- Yetkilendirme kontrolleri

## Performans Gereksinimleri

- Hızlı sayfa yükleme süreleri
- Veritabanı sorgu optimizasyonu
- Sayfalama desteği
- Lazy loading
- Caching mekanizmaları

## Geliştirme Prensipleri

- SOLID prensipleri
- DRY (Don't Repeat Yourself)
- Test-driven development yaklaşımı
- Kod kalitesi ve standartları
- Düzenli code review
- Versiyon kontrolü (Git)

## Proje Yol Haritası

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

## Gelecek Geliştirmeler (v2)

- E-fatura entegrasyonu
- Mobil uygulama
- Çoklu dil desteği
- API desteği
- İleri düzey analitik
- Takvim ve hatırlatıcı özellikleri
- SMS bildirim entegrasyonu
- QR kod desteği
- Döviz kurları entegrasyonu

## Karar Gerekçesi

.NET Core MVC ve Entity Framework Core, kurumsal uygulamalar için güçlü, güvenli ve ölçeklenebilir bir platform sunmaktadır. MySQL veritabanı, açık kaynak olması ve yaygın kullanımı nedeniyle tercih edilmiştir. Modern frontend teknolojileri ile kullanıcı dostu bir arayüz sağlanacaktır.

## Alternatifler

- Node.js + Express + MongoDB
- Django + PostgreSQL
- Laravel + MySQL

Bu alternatifler değerlendirilmiş, ancak ekip uzmanlığı ve hedef kullanıcı kitlesi göz önüne alınarak .NET Core ekosistemi tercih edilmiştir.

## Açık Sorular

1. Çoklu dil desteği ilk sürümde yer almalı mı?
2. Mobil uygulama geliştirme önceliği ne olmalı?
3. Bulut depolama entegrasyonu eklenecek mi?

## Referanslar

- PRD.md
- FEATURES.md 