# RFC-010: Dashboard ve Kullanıcı Arayüzü

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının dashboard ve kullanıcı arayüzü tasarımını tanımlamaktadır. Genel bakış paneli, görselleştirme araçları, kişiselleştirme seçenekleri ve kullanıcı deneyimi özellikleri gibi temel bileşenleri içermektedir.

## Motivasyon

Etkili bir dashboard ve kullanıcı dostu bir arayüz, ön muhasebe programının başarısı için kritik öneme sahiptir. Kullanıcıların finansal verileri hızlı bir şekilde analiz edebilmesi, önemli göstergeleri takip edebilmesi ve programı verimli bir şekilde kullanabilmesi için sezgisel, modern ve kişiselleştirilebilir bir arayüz gereklidir.

## Detaylı Tasarım

### Genel Bakış

#### Günlük Gelir-Gider Özeti
- Günlük gelir ve gider toplamları
- Gelir-gider karşılaştırma grafiği
- Gelir-gider kategorileri dağılımı
- Günlük nakit akışı
- Önceki günlerle karşılaştırma
- Hedeflerle karşılaştırma

#### Açık Faturalar ve Toplam Tutar
- Ödenmemiş satış faturaları listesi
- Ödenmemiş alış faturaları listesi
- Toplam alacak tutarı
- Toplam borç tutarı
- Vadeye göre gruplandırma
- Kritik vadesi yaklaşan faturalar vurgusu

#### Vadesi Yaklaşan Alacak ve Borçlar
- Bugün vadesi gelen ödemeler
- Bu hafta vadesi gelecek ödemeler
- Vadesi geçmiş ödemeler
- Öncelik sıralaması
- Ödeme/tahsilat durumu takibi
- Hızlı işlem butonları

#### Kasa ve Banka Hesap Bakiyeleri
- Kasa mevcut bakiyesi
- Banka hesapları bakiyeleri
- Toplam likit varlıklar
- Hesap hareketleri özeti
- Bakiye değişim trendi
- Kritik bakiye uyarıları

#### Stoğu Azalan Ürünler
- Minimum stok seviyesinin altındaki ürünler
- Stok tükenme tahminleri
- Sipariş önerileri
- Stok durumu grafiği
- Hızlı sipariş oluşturma
- Stok alarm seviyeleri

### Görselleştirme

#### Aylık Gelir-Gider Grafiği
- Aylık gelir-gider karşılaştırma grafiği
- Kümülatif gelir-gider trendi
- Kategori bazlı gelir-gider dağılımı
- Ay içi günlük dağılım
- Önceki aylarla karşılaştırma
- Tahmin çizgileri

#### En Çok Satılan Ürünler Grafiği
- En çok satılan ürünler sıralaması
- Satış adedi ve tutarı karşılaştırması
- Ürün kategorisi bazlı dağılım
- Satış trendi
- Stok durumu ile ilişkilendirme
- Karlılık analizi

#### Müşteri Bazlı Satış Grafiği
- En çok satış yapılan müşteriler
- Müşteri segmentasyonu
- Müşteri bazlı satış trendi
- Tahsilat performansı
- Müşteri sadakat analizi
- Potansiyel müşteri fırsatları

#### Kategori Bazlı Satış Grafiği
- Ürün kategorisi bazlı satış dağılımı
- Kategori performans karşılaştırması
- Kategori bazlı büyüme analizi
- Sezonluk kategori performansı
- Kategori bazlı karlılık analizi
- Stok-satış ilişkisi

#### Yıllık Trend Analizi
- Yıllık satış trendi
- Aylık karşılaştırmalar
- Mevsimsellik analizi
- Büyüme oranları
- Yıllık hedeflerle karşılaştırma
- Tahmin modelleri

### Kişiselleştirme

#### Özelleştirilebilir Widget'lar
- Hazır widget kütüphanesi
- Widget ekleme/kaldırma
- Widget içeriğini özelleştirme
- Veri kaynağı seçimi
- Görselleştirme türü seçimi
- Yenileme sıklığı ayarları

#### Widget Boyutlandırma ve Yerleştirme
- Sürükle-bırak yerleştirme
- Boyut değiştirme
- Otomatik düzenleme
- Izgara (grid) sistemi
- Katman yönetimi
- Yerleşim şablonları

#### Kişiye Özel Dashboard Konfigürasyonu
- Birden fazla dashboard oluşturma
- Dashboard şablonları
- Rol bazlı varsayılan dashboardlar
- Dashboard paylaşımı
- Dashboard yedekleme ve geri yükleme
- Dashboard sıfırlama

#### Hızlı Erişim Menüsü
- Sık kullanılan işlemler
- Kişiselleştirilebilir kısayollar
- Son kullanılan öğeler
- Favori raporlar
- Hatırlatıcılar
- Bildirimler

### Kullanıcı Deneyimi

#### Koyu/Açık Tema Seçeneği
- Açık tema
- Koyu tema
- Otomatik tema değişimi
- Özel renk şemaları
- Kontrast ayarları
- Yazı tipi seçenekleri

#### Mobil Uyumlu Arayüz
- Responsive tasarım
- Mobil cihazlara özel görünüm
- Dokunmatik ekran optimizasyonu
- Offline çalışma modu
- Mobil bildirimler
- Düşük bant genişliği modu

#### Kısayol Tuşları
- Temel işlemler için kısayollar
- Özelleştirilebilir kısayollar
- Kısayol rehberi
- Kısayol çakışma yönetimi
- Kısayol grupları
- Bağlam duyarlı kısayollar

#### Sürükle-Bırak İşlemleri
- Dosya yükleme
- Öğe taşıma
- Liste sıralama
- Kategori atama
- Toplu işlem
- Etkileşimli formlar

### Bildirim ve Uyarı Sistemi

#### Bildirim Merkezi
- Tüm bildirimlerin listesi
- Bildirim kategorileri
- Okundu/okunmadı durumu
- Bildirim filtreleme
- Bildirim arşivleme
- Bildirim arama

#### Uyarı Türleri
- Sistem uyarıları
- Finansal uyarılar
- Stok uyarıları
- Vade uyarıları
- Görev uyarıları
- Özel uyarılar

#### Bildirim Tercihleri
- Bildirim alma tercihleri
- Bildirim kanalları (uygulama içi, e-posta, SMS)
- Bildirim sıklığı
- Sessiz saatler
- Bildirim önceliği
- Bildirim gruplandırma

#### Aksiyon Alınabilir Bildirimler
- Doğrudan işlem yapılabilen bildirimler
- Hızlı yanıt seçenekleri
- İşlem onaylama
- Detay görüntüleme
- İlgili sayfaya yönlendirme
- Toplu işlem seçenekleri

### Yardım ve Destek Sistemi

#### Bağlama Duyarlı Yardım
- Sayfa/işlem bazlı yardım içeriği
- İpuçları ve öneriler
- Adım adım rehberler
- Video eğitimler
- Sık sorulan sorular
- Örnek senaryolar

#### Etkileşimli Rehberler
- İlk kullanım turu
- Özellik tanıtımları
- İşlem rehberleri
- Etkileşimli öğreticiler
- İlerleme takibi
- Özelleştirilebilir içerik

#### Destek Talebi Oluşturma
- Uygulama içi destek talebi
- Ekran görüntüsü ekleme
- Sistem bilgisi paylaşma
- Talep durumu takibi
- Geçmiş talepler
- Bilgi tabanı entegrasyonu

#### Kullanıcı Geri Bildirimi
- Özellik önerileri
- Hata bildirimleri
- Memnuniyet anketleri
- Beta test programı
- Kullanım istatistikleri
- Topluluk forumu

## Teknik Uygulama

### Frontend Mimarisi

#### Teknoloji Stack'i
- React/Angular/Vue.js
- TypeScript
- Tailwind CSS/Bootstrap
- Redux/Vuex/NgRx
- GraphQL/REST API
- PWA (Progressive Web App)

#### Komponent Mimarisi
- Atomic Design yaklaşımı
- Yeniden kullanılabilir komponentler
- Tema ve stil sistemi
- Responsive grid sistemi
- Lazy loading
- Code splitting

#### State Yönetimi
- Merkezi state yönetimi
- Önbellek stratejisi
- Oturum yönetimi
- Form state yönetimi
- Veri senkronizasyonu
- Offline state yönetimi

### Veritabanı Tabloları

#### Dashboards Tablosu
```
Id (PK)
UserId (FK)
Name
Description
IsDefault
Layout
CreatedAt
UpdatedAt
```

#### DashboardWidgets Tablosu
```
Id (PK)
DashboardId (FK)
WidgetType
Title
DataSource
Settings
Position
Size
RefreshInterval
IsActive
CreatedAt
UpdatedAt
```

#### WidgetTypes Tablosu
```
Id (PK)
Name
Description
Category
DefaultSettings
ThumbnailUrl
IsActive
```

#### UserPreferences Tablosu
```
Id (PK)
UserId (FK)
Theme (Light/Dark/System)
Language
DateFormat
TimeFormat
NumberFormat
CurrencyFormat
StartPage
NotificationSettings
ShortcutSettings
CreatedAt
UpdatedAt
```

#### Notifications Tablosu
```
Id (PK)
UserId (FK)
Type
Title
Message
Link
IsRead
Priority (Low/Medium/High)
CreatedAt
ExpiresAt
```

#### UserGuides Tablosu
```
Id (PK)
Title
Description
Content
Category
PageUrl
Order
IsActive
CreatedAt
UpdatedAt
```

#### UserFeedback Tablosu
```
Id (PK)
UserId (FK)
Type (Suggestion/Bug/Feedback)
Title
Description
Status (New/InProgress/Resolved/Rejected)
Rating
CreatedAt
UpdatedAt
ResolvedAt
```

### İlişkiler

- Bir kullanıcı birden fazla dashboard'a sahip olabilir
- Bir dashboard birden fazla widget içerebilir
- Bir widget bir widget türüne sahiptir
- Bir kullanıcı bir tercih kaydına sahiptir
- Bir kullanıcı birden fazla bildirime sahip olabilir
- Bir kullanıcı birden fazla geri bildirim gönderebilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Ana Dashboard Ekranı**
   - Özelleştirilebilir widget'lar
   - Özet finansal göstergeler
   - Hızlı işlem butonları
   - Bildirim merkezi
   - Arama çubuğu
   - Ana menü

2. **Dashboard Yönetim Ekranı**
   - Dashboard listesi
   - Dashboard oluşturma/düzenleme
   - Widget ekleme/kaldırma
   - Yerleşim düzenleme
   - Tema seçimi
   - Paylaşım seçenekleri

3. **Kullanıcı Profil Ekranı**
   - Profil bilgileri
   - Tercihler
   - Bildirim ayarları
   - Kısayol ayarları
   - Tema seçimi
   - Dil seçimi

4. **Yardım ve Destek Ekranı**
   - Yardım içeriği
   - Video eğitimler
   - Sık sorulan sorular
   - Destek talebi oluşturma
   - Geri bildirim formu
   - Sürüm bilgileri

5. **Bildirim Merkezi Ekranı**
   - Bildirim listesi
   - Bildirim filtreleme
   - Bildirim detayları
   - Toplu işlemler
   - Bildirim ayarları
   - Arşiv

6. **Arama Sonuçları Ekranı**
   - Kategori bazlı sonuçlar
   - Filtreleme seçenekleri
   - Önizleme
   - Hızlı işlemler
   - İlgili öğeler
   - Arama geçmişi

## Özellikler ve İşlevler

- Gerçek zamanlı veri güncelleme
- Drag-and-drop arayüz düzenleme
- Çoklu dil desteği
- Erişilebilirlik özellikleri (WCAG uyumlu)
- Performans optimizasyonu
- Offline çalışma modu
- Veri görselleştirme araçları
- Etkileşimli grafikler
- Tema desteği
- Mobil uyumluluk
- Kısayol tuşları
- Kullanım analitikleri

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Kullanılabilirlik testleri
- Performans testleri
- Çapraz tarayıcı testleri
- Mobil uyumluluk testleri
- Erişilebilirlik testleri
- A/B testleri
- Kullanıcı kabul testleri

## Açık Sorular

1. Hangi frontend framework'ü kullanılmalı?
2. Dashboard'lar için ne kadar esneklik ve özelleştirme sunulmalı?
3. Mobil deneyim için ayrı bir uygulama mı geliştirilmeli, yoksa responsive web uygulaması yeterli mi?
4. Offline çalışma modu ne kadar kapsamlı olmalı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-009: Raporlama Sistemi 