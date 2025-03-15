# RFC-011: Mobil Uygulama ve API

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının mobil uygulama ve API bileşenlerini tanımlamaktadır. Mobil cihazlar üzerinden erişim, API entegrasyonu ve üçüncü taraf yazılımlarla veri alışverişi gibi temel özellikleri içermektedir.

## Motivasyon

Modern iş dünyasında mobilite ve sistem entegrasyonu kritik öneme sahiptir. Kullanıcıların hareket halindeyken temel işlemleri gerçekleştirebilmesi ve Kolay Mizan'ın diğer iş yazılımlarıyla entegre çalışabilmesi için güçlü bir mobil uygulama ve API altyapısı gereklidir.

## Detaylı Tasarım

### Mobil Uygulama

#### Desteklenen Platformlar
- iOS (iPhone ve iPad)
- Android (Telefon ve Tablet)
- Progressive Web App (PWA) desteği
- Minimum desteklenen sürümler
- Cihaz uyumluluk gereksinimleri

#### Kullanıcı Arayüzü ve Deneyimi
- Platform tasarım ilkelerine uygun arayüz
- Responsive tasarım
- Koyu/açık tema desteği
- Offline çalışma modu
- Dokunmatik ekran optimizasyonu
- Gesture (hareket) desteği

#### Temel İşlevler

##### Dashboard ve Özet Görünümü
- Finansal durum özeti
- Kritik göstergeler (KPI'lar)
- Vadesi yaklaşan alacak/borçlar
- Stok durumu
- Günlük satış/tahsilat özeti
- Özelleştirilebilir widget'lar

##### Müşteri/Tedarikçi Yönetimi
- Müşteri/tedarikçi listesi görüntüleme
- Detaylı bilgi erişimi
- Yeni müşteri/tedarikçi ekleme
- İletişim bilgilerine hızlı erişim
- Arama ve filtreleme
- Cari hesap bakiyesi görüntüleme

##### Fatura İşlemleri
- Fatura listesi görüntüleme
- Fatura detaylarını inceleme
- Hızlı fatura oluşturma
- Fatura durumu güncelleme
- Fatura onaylama
- PDF olarak kaydetme ve paylaşma

##### Tahsilat ve Ödeme
- Tahsilat/ödeme kaydetme
- Tahsilat/ödeme listesi görüntüleme
- Vadesi geçmiş ödemeleri görüntüleme
- Ödeme hatırlatıcıları
- Hızlı tahsilat girişi
- Çek/senet takibi

##### Ürün ve Stok
- Ürün listesi görüntüleme
- Stok durumu kontrolü
- Barkod tarama ile ürün bulma
- Hızlı fiyat kontrolü
- Stok hareketi girişi
- Düşük stok bildirimleri

##### Raporlar
- Temel finansal raporlar
- Grafik ve tablolar
- Rapor paylaşımı
- Özelleştirilebilir rapor parametreleri
- Rapor favorileri
- Offline rapor görüntüleme

#### Bildirim Sistemi
- Push bildirimleri
- Bildirim merkezi
- Bildirim tercihleri
- Kritik durum uyarıları
- Görev hatırlatıcıları
- Bildirim geçmişi

#### Senkronizasyon
- Otomatik veri senkronizasyonu
- Manuel senkronizasyon seçeneği
- Offline veri depolama
- Çatışma çözümleme
- Senkronizasyon durumu göstergeleri
- Veri kullanımı optimizasyonu

#### Güvenlik Özellikleri
- Biyometrik kimlik doğrulama (parmak izi, yüz tanıma)
- PIN/şifre koruması
- Oturum zaman aşımı
- Uzaktan erişim kontrolü
- Cihaz bazlı yetkilendirme
- Şifreli veri depolama

### API Sistemi

#### API Mimarisi
- RESTful API tasarımı
- JSON veri formatı
- OAuth 2.0 kimlik doğrulama
- Rate limiting
- Versiyonlama
- Hata işleme ve durum kodları

#### Endpoint Kategorileri

##### Kimlik Doğrulama ve Yetkilendirme
- Kullanıcı girişi
- Token yenileme
- Kullanıcı bilgileri
- İzin kontrolü
- Şifre sıfırlama
- API anahtarı yönetimi

##### Müşteri/Tedarikçi API'leri
- Müşteri/tedarikçi listeleme
- Detay görüntüleme
- Ekleme/güncelleme/silme
- Cari hesap bilgileri
- İletişim bilgileri
- Filtreleme ve arama

##### Fatura API'leri
- Fatura listeleme
- Fatura detayları
- Fatura oluşturma
- Fatura güncelleme
- Fatura silme/iptal etme
- Fatura durumu güncelleme

##### Ödeme/Tahsilat API'leri
- Ödeme/tahsilat listeleme
- Ödeme/tahsilat kaydetme
- Ödeme/tahsilat güncelleme
- Ödeme/tahsilat silme
- Fatura-ödeme ilişkilendirme
- Bakiye sorgulama

##### Ürün/Stok API'leri
- Ürün listeleme
- Ürün detayları
- Ürün ekleme/güncelleme/silme
- Stok durumu sorgulama
- Stok hareketi kaydetme
- Fiyat bilgisi sorgulama

##### Rapor API'leri
- Rapor parametreleri alma
- Rapor oluşturma
- Rapor verisi alma
- Özet bilgiler
- İstatistikler
- Dashboard verileri

#### Webhook Desteği
- Olay bazlı bildirimler
- Webhook yapılandırma
- Webhook güvenliği
- Yeniden deneme mekanizması
- Webhook loglama
- Test araçları

#### Entegrasyon Senaryoları
- E-ticaret platformları
- Banka ve ödeme sistemleri
- CRM sistemleri
- ERP sistemleri
- E-fatura sistemleri
- Muhasebe yazılımları

#### API Dokümantasyonu
- Interaktif API dokümantasyonu (Swagger/OpenAPI)
- Kod örnekleri
- Kullanım senaryoları
- Hata kodları ve açıklamaları
- Sürüm geçmişi
- Test ortamı

#### API Yönetimi
- Kullanım istatistikleri
- Rate limiting yapılandırması
- API anahtarı yönetimi
- Erişim kontrolü
- Kullanım kotaları
- Performans izleme

## Teknik Uygulama

### Mobil Uygulama Teknolojileri

#### Geliştirme Yaklaşımı
- Cross-platform geliştirme (React Native, Flutter)
- Native geliştirme (Swift, Kotlin)
- Hibrit yaklaşım
- Kod paylaşımı stratejisi
- Performans optimizasyonu
- Bakım ve güncelleme stratejisi

#### Veri Depolama
- SQLite veritabanı
- Secure storage
- Önbellek mekanizması
- Veri sıkıştırma
- Veri şifreleme
- Veri yedekleme

#### Ağ İletişimi
- HTTP/HTTPS protokolleri
- WebSocket desteği
- Bağlantı durumu yönetimi
- Retry mekanizması
- Veri kullanımı optimizasyonu
- Sıkıştırma

### API Teknolojileri

#### Backend Teknolojileri
- .NET Core API
- Entity Framework Core
- Identity Server
- API Gateway
- Caching mekanizması
- Loglama ve izleme

#### Güvenlik Önlemleri
- SSL/TLS şifreleme
- API anahtarı doğrulama
- JWT token kullanımı
- CORS yapılandırması
- Input validasyonu
- SQL injection koruması

### Veritabanı Tabloları

#### ApiKeys Tablosu
```
Id (PK)
UserId (FK)
ApiKey
Name
Description
Permissions
IsActive
ExpiryDate
CreatedAt
UpdatedAt
LastUsedAt
```

#### ApiLogs Tablosu
```
Id (PK)
ApiKeyId (FK)
Endpoint
Method
RequestData
ResponseCode
ResponseTime
IpAddress
UserAgent
CreatedAt
```

#### MobileDevices Tablosu
```
Id (PK)
UserId (FK)
DeviceId
DeviceType
DeviceName
Platform
OsVersion
AppVersion
PushToken
LastSyncAt
IsActive
RegisteredAt
LastActivityAt
```

#### SyncLogs Tablosu
```
Id (PK)
UserId (FK)
DeviceId (FK)
SyncType
StartedAt
CompletedAt
Status
ItemsSynced
ErrorMessage
```

#### Webhooks Tablosu
```
Id (PK)
UserId (FK)
Name
Url
Secret
Events
IsActive
FailureCount
LastTriggeredAt
CreatedAt
UpdatedAt
```

#### WebhookLogs Tablosu
```
Id (PK)
WebhookId (FK)
Event
Payload
ResponseCode
ResponseBody
ExecutionTime
Status
CreatedAt
```

### İlişkiler

- Bir kullanıcı birden fazla API anahtarına sahip olabilir
- Bir API anahtarı birden fazla API log kaydına sahip olabilir
- Bir kullanıcı birden fazla mobil cihaz kaydına sahip olabilir
- Bir mobil cihaz birden fazla senkronizasyon log kaydına sahip olabilir
- Bir kullanıcı birden fazla webhook yapılandırmasına sahip olabilir
- Bir webhook birden fazla webhook log kaydına sahip olabilir

## Kullanıcı Arayüzü

### Mobil Uygulama Ekranları

1. **Giriş ve Kimlik Doğrulama Ekranları**
   - Giriş ekranı
   - Şifre sıfırlama
   - Biyometrik kimlik doğrulama
   - PIN oluşturma/giriş

2. **Ana Dashboard Ekranı**
   - Finansal özet
   - Kritik göstergeler
   - Hızlı erişim butonları
   - Bildirimler
   - Aktivite akışı

3. **Müşteri/Tedarikçi Ekranları**
   - Liste görünümü
   - Detay görünümü
   - Arama ve filtreleme
   - Cari hesap bakiyesi
   - İletişim seçenekleri

4. **Fatura Ekranları**
   - Fatura listesi
   - Fatura detayı
   - Fatura oluşturma
   - Fatura durumu güncelleme
   - Fatura paylaşımı

5. **Tahsilat/Ödeme Ekranları**
   - Tahsilat/ödeme listesi
   - Tahsilat/ödeme kaydetme
   - Vade takibi
   - Çek/senet takibi
   - Banka hesap durumu

6. **Ürün/Stok Ekranları**
   - Ürün listesi
   - Ürün detayı
   - Stok durumu
   - Barkod tarama
   - Stok hareketi

7. **Rapor Ekranları**
   - Rapor listesi
   - Rapor parametreleri
   - Rapor görüntüleme
   - Grafik ve tablolar
   - Rapor paylaşımı

8. **Ayarlar Ekranı**
   - Kullanıcı profili
   - Bildirim ayarları
   - Senkronizasyon ayarları
   - Güvenlik ayarları
   - Uygulama tercihleri

### API Yönetim Ekranları

1. **API Anahtarı Yönetim Ekranı**
   - API anahtarı listesi
   - API anahtarı oluşturma
   - İzin yapılandırması
   - Kullanım istatistikleri
   - Geçerlilik süresi yönetimi

2. **Webhook Yapılandırma Ekranı**
   - Webhook listesi
   - Webhook oluşturma/düzenleme
   - Olay seçimi
   - Test aracı
   - Log görüntüleme

3. **API Kullanım İstatistikleri Ekranı**
   - Endpoint bazlı kullanım
   - Zaman bazlı grafikler
   - Hata oranları
   - Performans metrikleri
   - Kullanım raporları

4. **API Dokümantasyon Ekranı**
   - Interaktif API referansı
   - Endpoint açıklamaları
   - Request/response örnekleri
   - Kod parçacıkları
   - Test konsolu

## Özellikler ve İşlevler

- Offline çalışma modu
- Biyometrik kimlik doğrulama
- Push bildirimleri
- Barkod/QR kod tarama
- Dosya paylaşımı
- Kamera entegrasyonu (belge tarama)
- Konum bazlı özellikler
- Çoklu dil desteği
- Erişilebilirlik özellikleri
- Otomatik güncelleme
- API kullanım analitikleri
- Webhook test aracı
- API dokümantasyonu
- Entegrasyon örnekleri
- Sandbox ortamı

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Performans testleri
- Güvenlik testleri
- Çapraz platform testleri
- Çapraz cihaz testleri
- Bağlantı testleri (offline, zayıf bağlantı)
- Yük testleri (API)
- Penetrasyon testleri

## Açık Sorular

1. Mobil uygulama için native mi yoksa cross-platform bir yaklaşım mı tercih edilmeli?
2. API kullanımı için ücretlendirme modeli olmalı mı?
3. Üçüncü taraf entegrasyonlar için marketplace yaklaşımı düşünülmeli mi?
4. Offline çalışma modu ne kadar kapsamlı olmalı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-010: Dashboard ve Kullanıcı Arayüzü 