# RFC-009: Raporlama Sistemi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının raporlama sistemini tanımlamaktadır. Finansal raporlar, müşteri/tedarikçi raporları, stok raporları ve özelleştirilebilir raporlar gibi temel özellikleri içermektedir.

## Motivasyon

Raporlama sistemi, ön muhasebe programının en kritik bileşenlerinden biridir. İşletmelerin finansal durumlarını analiz edebilmeleri, karar verme süreçlerini destekleyecek verilere erişebilmeleri ve yasal gereksinimleri karşılayabilmeleri için kapsamlı bir raporlama sistemi gereklidir.

## Detaylı Tasarım

### Finansal Raporlar

#### Gelir-Gider Raporu
- Belirli bir dönem için gelir ve giderlerin karşılaştırması
- Kategori bazlı gelir-gider dağılımı
- Aylık, üç aylık, yıllık karşılaştırmalar
- Grafik ve tablo formatında gösterim
- Trend analizi
- Bütçe ile karşılaştırma

#### Kar/Zarar Analizi
- Belirli bir dönem için kar/zarar hesaplaması
- Ürün/hizmet bazlı karlılık analizi
- Müşteri bazlı karlılık analizi
- Proje bazlı karlılık analizi
- Brüt kar ve net kar hesaplamaları
- Kar marjı analizi
- Dönemsel karşılaştırmalar

#### Nakit Akış Raporu
- Belirli bir dönem için nakit giriş ve çıkışları
- Nakit akış kategorileri (işletme, yatırım, finansman)
- Günlük, haftalık, aylık nakit akış projeksiyonu
- Nakit pozisyonu analizi
- Nakit dönüşüm döngüsü
- Likidite oranları

#### Aylık/Yıllık Satış Raporu
- Aylık ve yıllık satış performansı
- Ürün/hizmet bazlı satış analizi
- Müşteri bazlı satış analizi
- Bölge/sektör bazlı satış analizi
- Satış trendi ve büyüme oranları
- Satış hedefleri ile karşılaştırma
- Mevsimsellik analizi

#### KDV Raporu
- Dönemsel KDV hesaplaması
- Hesaplanan ve indirilecek KDV detayları
- KDV beyanname hazırlığı
- KDV özet ve detay raporları
- KDV iade takibi
- Vergi dairesi bazlı raporlama

#### Tahsilat/Ödeme Raporu
- Belirli bir dönem için tahsilat ve ödemeler
- Tahsilat/ödeme yöntemine göre dağılım
- Vadesi gelen, vadesi geçmiş tahsilat/ödemeler
- Tahsilat/ödeme performans analizi
- Nakit akışı projeksiyonu
- Çek/senet vade analizi

### Müşteri/Tedarikçi Raporları

#### Müşteri Bazlı Satış Raporu
- Müşteri bazlı satış performansı
- Müşteri segmentasyonu
- En çok satış yapılan müşteriler
- Müşteri satın alma davranışları
- Müşteri bazlı ürün/hizmet dağılımı
- Müşteri karlılık analizi
- Müşteri sadakat analizi

#### Tedarikçi Bazlı Alım Raporu
- Tedarikçi bazlı alım performansı
- Tedarikçi segmentasyonu
- En çok alım yapılan tedarikçiler
- Tedarikçi bazlı ürün dağılımı
- Tedarikçi fiyat analizi
- Tedarikçi teslimat performansı
- Tedarikçi kalite analizi

#### Müşteri/Tedarikçi Mutabakat Raporu
- Müşteri cari hesap mutabakatı
- Tedarikçi cari hesap mutabakatı
- Açık kalemler listesi
- Mutabakat mektupları
- Mutabakat durumu takibi
- Mutabakat farkları analizi

#### Vadesi Geçmiş Alacaklar Raporu
- Vadesi geçmiş alacakların listesi
- Vade aşım süresine göre gruplandırma (30, 60, 90, 90+ gün)
- Müşteri bazlı vade aşımı analizi
- Tahsilat riski değerlendirmesi
- Tahsilat takip planı
- Alacak yaşlandırma analizi

#### Vadesi Geçmiş Borçlar Raporu
- Vadesi geçmiş borçların listesi
- Vade aşım süresine göre gruplandırma (30, 60, 90, 90+ gün)
- Tedarikçi bazlı vade aşımı analizi
- Ödeme planlaması
- Borç yaşlandırma analizi
- Nakit akışı etkisi

### Stok Raporları

#### Stok Durum Raporu
- Güncel stok seviyesi
- Ürün bazlı stok durumu
- Depo bazlı stok durumu
- Minimum stok seviyesi altındaki ürünler
- Maksimum stok seviyesi üzerindeki ürünler
- Stok değeri hesaplaması
- Stok devir hızı

#### En Çok/En Az Satılan Ürünler
- En çok satılan ürünlerin listesi
- En az satılan ürünlerin listesi
- Satış trendi analizi
- Ürün performans değerlendirmesi
- Sezonluk satış analizi
- Ürün yaşam döngüsü analizi

#### Stok Hareket Raporu
- Belirli bir dönem için stok hareketleri
- Ürün bazlı stok giriş-çıkışları
- Hareket türüne göre filtreleme (alım, satış, transfer, fire)
- Depo bazlı stok hareketleri
- Lot/seri numarası bazlı takip
- Stok hareket geçmişi

#### Stok Değer Raporu
- Stok değeri hesaplaması (FIFO, LIFO, Ortalama)
- Ürün kategorisi bazlı stok değeri
- Depo bazlı stok değeri
- Stok değer değişim analizi
- Stok değerleme yöntemleri karşılaştırması
- Envanter değerleme raporu

### Rapor Özellikleri

#### Excel ve PDF Formatında Dışa Aktarma
- Excel formatında rapor dışa aktarma
- PDF formatında rapor dışa aktarma
- CSV formatında veri dışa aktarma
- Toplu rapor dışa aktarma
- Otomatik dosya adlandırma
- Şifreli dosya oluşturma

#### Grafikler ve Görseller ile Zenginleştirilmiş Raporlar
- Çubuk, çizgi, pasta grafikleri
- Isı haritaları
- Trend çizgileri
- Karşılaştırmalı grafikler
- Etkileşimli grafikler
- Gösterge panelleri (dashboard)
- Veri görselleştirme seçenekleri

#### Özelleştirilebilir Rapor Şablonları
- Standart rapor şablonları
- Özel rapor şablonları oluşturma
- Şablon düzenleme ve kaydetme
- Şablon paylaşımı
- Şablon kategorileri
- Şablon önizleme

#### Otomatik Rapor Planlama ve Gönderme
- Periyodik rapor planlaması (günlük, haftalık, aylık)
- Otomatik rapor oluşturma
- E-posta ile rapor gönderimi
- Rapor gönderim listesi oluşturma
- Rapor gönderim geçmişi
- Rapor gönderim durumu takibi

### Özelleştirilebilir Raporlar

#### Rapor Oluşturucu
- Sürükle-bırak rapor tasarımı
- Alan seçimi ve düzenleme
- Filtreleme ve sıralama seçenekleri
- Hesaplama alanları ekleme
- Gruplama ve alt toplam seçenekleri
- Koşullu biçimlendirme
- Rapor kaydetme ve paylaşma

#### Veri Analiz Araçları
- Pivot tablo benzeri analiz araçları
- Çapraz tablo raporları
- Detaya inme (drill-down) özellikleri
- Veri filtreleme ve segmentasyon
- Trend analizi ve tahminleme
- İstatistiksel analiz araçları
- Karşılaştırmalı analiz

#### Özel Sorgular
- SQL benzeri sorgu oluşturma
- Sorgu şablonları
- Parametre tanımlama
- Sorgu kaydetme ve paylaşma
- Sorgu zamanlama
- Sorgu performans optimizasyonu

## Teknik Uygulama

### Raporlama Mimarisi

#### Rapor Motoru
- Rapor oluşturma ve işleme
- Veri kaynağı bağlantıları
- Rapor şablonları yönetimi
- Rapor önbelleği
- Rapor işleme kuyruğu
- Asenkron rapor oluşturma

#### Veri Erişim Katmanı
- Veritabanı sorgulama
- Veri dönüşümleri
- Veri önbelleği
- Veri güvenliği
- Performans optimizasyonu
- Çoklu veri kaynağı desteği

#### Görselleştirme Kütüphaneleri
- Grafik ve görsel oluşturma
- Etkileşimli görselleştirmeler
- Mobil uyumlu görselleştirmeler
- Tema ve stil desteği
- Özelleştirilebilir görsel bileşenler
- Dışa aktarma seçenekleri

### Veritabanı Tabloları

#### Reports Tablosu
```
Id (PK)
Name
Description
ReportType
TemplateId (FK)
Parameters
LastRunAt
CreatedBy
CreatedAt
UpdatedAt
```

#### ReportTemplates Tablosu
```
Id (PK)
Name
Description
Category
Content
IsSystem
IsActive
CreatedBy
CreatedAt
UpdatedAt
```

#### ReportSchedules Tablosu
```
Id (PK)
ReportId (FK)
Name
Frequency (Daily/Weekly/Monthly/Quarterly/Yearly)
DayOfWeek
DayOfMonth
MonthOfYear
StartTime
NextRunAt
LastRunAt
IsActive
CreatedBy
CreatedAt
UpdatedAt
```

#### ReportRecipients Tablosu
```
Id (PK)
ScheduleId (FK)
UserId (FK, nullable)
Email
Name
IsActive
CreatedAt
UpdatedAt
```

#### ReportExecutions Tablosu
```
Id (PK)
ReportId (FK)
ScheduleId (FK, nullable)
ExecutedBy
StartedAt
CompletedAt
Status (Pending/Running/Completed/Failed)
Parameters
OutputFormat
OutputPath
ErrorMessage
```

#### ReportCategories Tablosu
```
Id (PK)
Name
Description
ParentCategoryId (FK, self-referencing)
DisplayOrder
IsActive
CreatedAt
UpdatedAt
```

#### UserReportPreferences Tablosu
```
Id (PK)
UserId (FK)
ReportId (FK)
DefaultParameters
DefaultFormat
IsFavorite
LastViewedAt
CreatedAt
UpdatedAt
```

### İlişkiler

- Bir rapor bir şablona sahip olabilir
- Bir rapor birden fazla zamanlama içerebilir
- Bir zamanlama birden fazla alıcıya sahip olabilir
- Bir rapor birden fazla çalıştırma kaydına sahip olabilir
- Bir kategori birden fazla alt kategoriye sahip olabilir
- Bir kullanıcı birden fazla rapor tercihi tanımlayabilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Rapor Merkezi Ekranı**
   - Rapor kategorileri
   - Sık kullanılan raporlar
   - Son çalıştırılan raporlar
   - Rapor arama
   - Rapor favorileri
   - Özel raporlar

2. **Rapor Çalıştırma Ekranı**
   - Rapor parametreleri
   - Tarih aralığı seçimi
   - Filtre seçenekleri
   - Çıktı formatı seçimi
   - Önizleme seçeneği
   - Çalıştır butonu

3. **Rapor Görüntüleme Ekranı**
   - Rapor başlığı ve açıklaması
   - Rapor parametreleri özeti
   - Rapor içeriği (tablo, grafik)
   - Dışa aktarma seçenekleri
   - Yazdırma seçeneği
   - Paylaşma seçeneği

4. **Rapor Tasarım Ekranı**
   - Veri kaynağı seçimi
   - Alan seçimi ve düzenleme
   - Filtreleme ve sıralama
   - Gruplama ve hesaplama
   - Görsel tasarım
   - Önizleme ve test

5. **Rapor Zamanlama Ekranı**
   - Zamanlama sıklığı seçimi
   - Çalıştırma zamanı belirleme
   - Alıcı listesi oluşturma
   - E-posta şablonu düzenleme
   - Çıktı formatı seçimi
   - Zamanlama durumu takibi

6. **Rapor Yönetim Ekranı**
   - Rapor listesi
   - Şablon yönetimi
   - Kategori yönetimi
   - Zamanlama yönetimi
   - Çalıştırma geçmişi
   - Kullanım istatistikleri

## Özellikler ve İşlevler

- Çoklu dil desteği
- Çoklu para birimi desteği
- Mobil uyumlu raporlar
- Etkileşimli grafikler ve görseller
- Detaya inme (drill-down) özellikleri
- Koşullu biçimlendirme
- Rapor aboneliği ve bildirimler
- Rapor paylaşımı ve işbirliği
- Rapor versiyonlama
- Rapor arşivleme ve geçmiş erişimi

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Rapor doğruluk testleri
- Performans testleri
- Yük testleri
- Güvenlik testleri
- Çapraz platform testleri

## Açık Sorular

1. Raporlama motoru olarak açık kaynak bir çözüm mü kullanılmalı, yoksa özel bir motor mu geliştirilmeli?
2. Büyük veri setleri için performans optimizasyonu nasıl sağlanmalı?
3. Mobil cihazlarda rapor görüntüleme için özel bir yaklaşım gerekli mi?
4. İleri düzey analitik özellikler (tahminleme, makine öğrenmesi) ilk sürümde yer almalı mı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-003: Müşteri/Tedarikçi Yönetimi
- RFC-004: Ürün/Hizmet Kataloğu ve Stok Yönetimi
- RFC-005: Fatura Yönetimi
- RFC-006: Ödeme ve Tahsilat Yönetimi
- RFC-007: Banka Hesapları Yönetimi
- RFC-008: Gider Yönetimi 