# Kolay Mizan Proje Geliştirme Kuralları

Bu belge, Kolay Mizan ön muhasebe programının geliştirme sürecinde uyulması gereken kuralları ve standartları tanımlamaktadır.

## Kod Yazım Standartları

### Genel Kurallar

- Tüm kod Türkçe yazılmalıdır (değişken, metot, sınıf isimleri vb.).
- Kod yazımında PascalCase (sınıflar, metotlar) ve camelCase (değişkenler) kullanılmalıdır.
- Tüm kod dosyaları UTF-8 formatında kaydedilmelidir.
- Satır sonları CRLF (Windows) formatında olmalıdır.
- Her satır 120 karakteri geçmemelidir.
- Girintiler için 4 boşluk kullanılmalıdır (tab değil).

### Sınıf ve Metot İsimlendirme

- Sınıf isimleri PascalCase ile yazılmalı ve isim olmalıdır (örn. `MüşteriYönetici`).
- Metot isimleri PascalCase ile yazılmalı ve fiil içermelidir (örn. `MüşteriEkle`).
- Interface isimleri "I" harfi ile başlamalıdır (örn. `IMüşteriServisi`).
- Değişken isimleri camelCase ile yazılmalıdır (örn. `müşteriAdı`).
- Sabitler tamamen büyük harflerle ve alt çizgi ile yazılmalıdır (örn. `MAKSIMUM_STOK_MIKTARI`).

### Yorum Yazımı

- Tüm sınıflar, metotlar ve karmaşık kod blokları için açıklayıcı yorumlar eklenmelidir.
- Yorum satırları Türkçe yazılmalıdır.
- XML belgeleme yorumları kullanılmalıdır (örn. `/// <summary>...</summary>`).
- TODO yorumları için standart format kullanılmalıdır: `// TODO: yapılacak iş açıklaması`.

## Mimari Kurallar

### Katmanlı Mimari

Proje aşağıdaki katmanlardan oluşmalıdır:

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

### Bağımlılık Enjeksiyonu

- Tüm servisler ve repository'ler için interface'ler tanımlanmalıdır.
- Bağımlılıklar constructor injection ile sağlanmalıdır.
- Startup.cs dosyasında tüm bağımlılıklar kayıt edilmelidir.

### SOLID Prensipleri

- Single Responsibility Principle: Her sınıf tek bir sorumluluğa sahip olmalıdır.
- Open/Closed Principle: Sınıflar genişletmeye açık, değiştirmeye kapalı olmalıdır.
- Liskov Substitution Principle: Alt sınıflar, üst sınıfların yerine geçebilmelidir.
- Interface Segregation Principle: İstemciler kullanmadıkları interface'lere bağımlı olmamalıdır.
- Dependency Inversion Principle: Üst seviye modüller alt seviye modüllere bağımlı olmamalıdır.

## Veritabanı Kuralları

### Tablo İsimlendirme

- Tablo isimleri çoğul olmalıdır (örn. `Müşteriler`, `Ürünler`).
- İlişki tabloları için her iki tablonun tekil isimleri kullanılmalıdır (örn. `MüşteriÜrün`).
- Tablo isimleri PascalCase ile yazılmalıdır.

### Sütun İsimlendirme

- Primary key sütunu `Id` olarak isimlendirilmelidir.
- Foreign key sütunları `TabloAdıId` formatında olmalıdır (örn. `MüşteriId`).
- Boolean sütunlar "Is", "Has" veya "Can" ile başlamalıdır (örn. `IsAktif`).
- Tarih sütunları için "Date", "At" veya "On" son eki kullanılmalıdır (örn. `OluşturulmaDate`).

### Veritabanı İşlemleri

- Tüm veritabanı işlemleri transaction içinde yapılmalıdır.
- Büyük veri kümeleri için sayfalama kullanılmalıdır.
- Kritik veritabanı işlemleri için loglama yapılmalıdır.
- Veritabanı bağlantıları kullanıldıktan sonra kapatılmalıdır.

## Test Kuralları

### Birim Testleri

- Her servis ve repository için birim testleri yazılmalıdır.
- Test isimleri `[MetotAdı]_[Senaryo]_[BeklenenSonuç]` formatında olmalıdır.
- Her test için en az bir assertion kullanılmalıdır.
- Testler birbirinden bağımsız olmalıdır.
- Mock framework olarak Moq kullanılmalıdır.

### Entegrasyon Testleri

- Kritik iş akışları için entegrasyon testleri yazılmalıdır.
- Test veritabanı olarak in-memory database kullanılmalıdır.
- Her test öncesi veritabanı temizlenmelidir.

### UI Testleri

- Kritik kullanıcı arayüzü işlemleri için UI testleri yazılmalıdır.
- Selenium WebDriver kullanılmalıdır.
- Page Object Model (POM) deseni uygulanmalıdır.

## Git Kuralları

### Dallanma Stratejisi

- Ana dallar: `main`, `develop`
- Özellik dalları: `feature/özellik-adı`
- Hata düzeltme dalları: `bugfix/hata-açıklaması`
- Sürüm dalları: `release/v1.0.0`
- Acil düzeltme dalları: `hotfix/düzeltme-açıklaması`

### Commit Mesajları

- Commit mesajları Türkçe yazılmalıdır.
- Commit mesajları şu formatta olmalıdır: `[Modül]: Yapılan değişiklik açıklaması`
- Örnek: `[Müşteri Yönetimi]: Müşteri silme işlemi eklendi`

### Pull Request Kuralları

- Her pull request en az bir reviewer tarafından incelenmelidir.
- Pull request açıklaması detaylı olmalıdır.
- Tüm testler başarılı olmalıdır.
- Kod kalite kontrolleri geçilmelidir.

## Dağıtım Kuralları

### Sürüm Numaralandırma

- Semantic Versioning (SemVer) kullanılmalıdır: `MAJOR.MINOR.PATCH`
- MAJOR: Geriye uyumlu olmayan API değişiklikleri
- MINOR: Geriye uyumlu yeni özellikler
- PATCH: Geriye uyumlu hata düzeltmeleri

### Dağıtım Süreci

- Her sürüm için release notes hazırlanmalıdır.
- Dağıtım öncesi smoke testleri yapılmalıdır.
- Dağıtım sonrası doğrulama testleri yapılmalıdır.
- Sorun durumunda geri alma planı hazır olmalıdır.

## Güvenlik Kuralları

- Hassas veriler şifrelenmelidir.
- SQL injection, XSS ve CSRF korumaları uygulanmalıdır.
- Kullanıcı girişleri doğrulanmalıdır.
- Yetkilendirme kontrolleri her işlemde yapılmalıdır.
- Güvenlik güncellemeleri düzenli olarak uygulanmalıdır.

## Performans Kuralları

- Veritabanı sorguları optimize edilmelidir.
- N+1 sorgu problemi önlenmelidir.
- Büyük listeler için sayfalama kullanılmalıdır.
- Önbellek mekanizmaları uygulanmalıdır.
- Statik içerikler için CDN kullanılmalıdır.

## Dokümantasyon Kuralları

- Tüm API'ler için Swagger dokümantasyonu hazırlanmalıdır.
- Karmaşık iş akışları için akış diyagramları oluşturulmalıdır.
- Veritabanı şeması için ER diyagramı güncel tutulmalıdır.
- Kurulum ve yapılandırma adımları detaylı olarak belgelenmelidir.
- Kullanıcı kılavuzu hazırlanmalıdır.

## Kod İnceleme Kontrol Listesi

- Kod yazım standartlarına uygunluk
- SOLID prensiplerine uygunluk
- Tekrar eden kod olmaması (DRY prensibi)
- Uygun hata yönetimi
- Yeterli test kapsamı
- Güvenlik açıkları
- Performans sorunları
- Dokümantasyon yeterliliği

Bu kurallar, Kolay Mizan projesinin kaliteli, sürdürülebilir ve güvenli bir şekilde geliştirilmesini sağlamak için oluşturulmuştur. Tüm geliştiricilerin bu kurallara uyması beklenmektedir. 