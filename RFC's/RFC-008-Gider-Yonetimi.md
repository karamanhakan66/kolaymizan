# RFC-008: Gider Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının gider yönetimi modülünü tanımlamaktadır. Giderlerin kaydedilmesi, kategorize edilmesi, takibi ve raporlanması gibi temel özellikleri içermektedir.

## Motivasyon

Gider yönetimi, ön muhasebe programının önemli bileşenlerinden biridir. İşletmelerin giderlerini etkin bir şekilde yönetebilmesi, kategorize edebilmesi, bütçe ile karşılaştırabilmesi ve finansal durumunu doğru analiz edebilmesi için kapsamlı bir gider yönetim modülü gereklidir.

## Detaylı Tasarım

### Gider İşlemleri

#### Gider Ekleme, Düzenleme ve Silme
- Yeni gider kaydı oluşturma
- Mevcut gider bilgilerini düzenleme
- Gider kaydı silme (soft delete)
- Gider arama ve filtreleme
- Toplu gider işlemleri

#### Gider Bilgileri
- Temel bilgiler:
  - Gider adı/açıklaması
  - Gider tutarı
  - Gider tarihi
  - Gider kategorisi
  - Ödeme yöntemi
  - Tedarikçi/satıcı bilgisi
  - Vergi tutarı ve oranı
  - Para birimi
- Ek bilgiler:
  - Belge/fatura numarası
  - Belge tarihi
  - Proje/departman ilişkilendirme
  - Notlar
  - Etiketler
  - Dosya ekleri (fatura, fiş, makbuz vb.)

#### Gider Kategorileri Tanımlama
- Standart gider kategorileri
- Özel kategori ekleme, düzenleme ve silme
- Hiyerarşik kategori yapısı (ana kategori, alt kategori)
- Kategori bazlı raporlama ve filtreleme
- Kategori bazlı bütçe tanımlama

#### Faturalandırılabilir Giderler
- Gideri faturalandırılabilir olarak işaretleme
- Müşteri ile ilişkilendirme
- Kâr marjı ekleme
- Faturalandırma durumu takibi
- Faturalandırılmamış gider raporları
- Gideri faturaya dönüştürme

#### Tekrarlayan Giderler
- Tekrarlayan gider tanımlama
- Tekrarlama sıklığı belirleme (günlük, haftalık, aylık, yıllık)
- Başlangıç ve bitiş tarihi
- Otomatik gider oluşturma
- Tekrarlayan gider durumu takibi
- Tekrarlayan gider düzenleme ve iptal etme

### Gider Takibi

#### Kategori Bazlı Gider Takibi
- Kategori bazlı gider raporları
- Kategori bazlı trend analizi
- Kategori karşılaştırma
- Kategori bazlı bütçe-gerçekleşen karşılaştırması
- Kategori bazlı grafikler ve görseller

#### Gider Onay Süreci
- Gider onay iş akışı tanımlama
- Onay seviyelerini belirleme
- Onay limitleri tanımlama
- Onay bildirimleri
- Onay geçmişi takibi
- Onay bekleyen gider listesi
- Reddedilen gider yönetimi

#### Gider Raporu Oluşturma
- Çalışan bazlı gider raporu
- Tarih aralığına göre gider raporu
- Kategori bazlı gider raporu
- Proje/departman bazlı gider raporu
- Gider raporu onay süreci
- Gider raporu yazdırma ve dışa aktarma

#### Gider Analizi
- Dönemsel gider karşılaştırma
- Kategori bazlı analiz
- Tedarikçi/satıcı bazlı analiz
- Trend analizi ve tahminleme
- Bütçe-gerçekleşen analizi
- Grafikler ve görseller ile zenginleştirilmiş analizler

### Bütçe Yönetimi

#### Bütçe Tanımlama
- Kategori bazlı bütçe oluşturma
- Dönemsel bütçe tanımlama (aylık, üç aylık, yıllık)
- Proje/departman bazlı bütçe
- Bütçe kopyalama ve düzenleme
- Bütçe versiyonlama

#### Bütçe Takibi
- Bütçe-gerçekleşen karşılaştırma
- Bütçe aşım uyarıları
- Bütçe trend analizi
- Bütçe revizyon yönetimi
- Bütçe performans raporları

### Avans ve Masraf Yönetimi

#### Avans İşlemleri
- Avans talebi oluşturma
- Avans onay süreci
- Avans ödeme kaydı
- Avans kapatma
- Avans bakiyesi takibi
- Avans raporları

#### Masraf Yönetimi
- Masraf girişi
- Masraf onayı
- Masrafı avans ile ilişkilendirme
- Masraf geri ödeme işlemleri
- Masraf raporları

## Teknik Uygulama

### Veritabanı Tabloları

#### Expenses Tablosu
```
Id (PK)
ExpenseNumber
Description
Amount
TaxAmount
TaxRate
TotalAmount
ExpenseDate
DueDate
CategoryId (FK)
SupplierId (FK, nullable)
PaymentMethodId (FK)
PaymentStatus (Unpaid/Paid)
CurrencyId (FK)
ExchangeRate
ReferenceNumber
IsBillable
CustomerId (FK, nullable)
ProjectId (FK, nullable)
DepartmentId (FK, nullable)
Status (Draft/Pending/Approved/Rejected)
ApprovedBy
ApprovedAt
RejectedBy
RejectedAt
RejectionReason
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### ExpenseCategories Tablosu
```
Id (PK)
Name
Description
ParentCategoryId (FK, self-referencing)
IsActive
CreatedAt
UpdatedAt
```

#### ExpenseAttachments Tablosu
```
Id (PK)
ExpenseId (FK)
FileName
FilePath
FileSize
FileType
UploadedBy
UploadedAt
```

#### RecurringExpenses Tablosu
```
Id (PK)
Description
Amount
TaxAmount
TaxRate
TotalAmount
CategoryId (FK)
SupplierId (FK, nullable)
PaymentMethodId (FK)
CurrencyId (FK)
ExchangeRate
Frequency (Daily/Weekly/Monthly/Quarterly/Yearly)
StartDate
EndDate
NextDueDate
IsActive
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### ExpenseReports Tablosu
```
Id (PK)
ReportNumber
Title
EmployeeId (FK)
StartDate
EndDate
TotalAmount
Status (Draft/Submitted/Approved/Rejected)
SubmittedAt
ApprovedBy
ApprovedAt
RejectedBy
RejectedAt
RejectionReason
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### ExpenseReportItems Tablosu
```
Id (PK)
ExpenseReportId (FK)
ExpenseId (FK)
Amount
Notes
```

#### Budgets Tablosu
```
Id (PK)
Name
Description
Year
Period (Monthly/Quarterly/Yearly)
Status (Draft/Active/Closed)
Version
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### BudgetItems Tablosu
```
Id (PK)
BudgetId (FK)
CategoryId (FK)
ProjectId (FK, nullable)
DepartmentId (FK, nullable)
Period (1-12 for months, 1-4 for quarters, 1 for yearly)
Amount
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### Advances Tablosu
```
Id (PK)
AdvanceNumber
EmployeeId (FK)
RequestDate
Amount
Purpose
Status (Requested/Approved/Paid/Settled/Rejected)
ApprovedBy
ApprovedAt
PaidAt
SettledAt
RejectedBy
RejectedAt
RejectionReason
RemainingAmount
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### AdvanceSettlements Tablosu
```
Id (PK)
AdvanceId (FK)
ExpenseId (FK, nullable)
Amount
SettlementDate
Notes
CreatedBy
CreatedAt
```

### İlişkiler

- Bir gider bir kategoriye ait olabilir
- Bir kategori birden fazla alt kategoriye sahip olabilir
- Bir gider birden fazla dosya ekine sahip olabilir
- Bir gider bir tedarikçi/satıcı ile ilişkilendirilebilir
- Bir gider bir müşteri ile ilişkilendirilebilir (faturalandırılabilir giderler için)
- Bir gider bir proje/departman ile ilişkilendirilebilir
- Bir gider raporu birden fazla gider içerebilir
- Bir bütçe birden fazla bütçe kalemi içerebilir
- Bir avans birden fazla gider ile ilişkilendirilebilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Gider Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir gider tablosu
   - Tarih aralığı filtresi
   - Kategori filtresi
   - Durum filtresi
   - Ödeme durumu filtresi
   - Tedarikçi/satıcı filtresi
   - Proje/departman filtresi
   - Hızlı arama
   - Toplu işlem seçenekleri
   - Yeni gider ekleme butonu

2. **Gider Ekleme/Düzenleme Ekranı**
   - Gider bilgileri formu
   - Kategori seçimi
   - Tedarikçi/satıcı seçimi
   - Vergi hesaplama
   - Dosya ekleme alanı
   - Kaydet/İptal butonları
   - Onaya gönder butonu

3. **Gider Kategorileri Ekranı**
   - Kategori listesi
   - Kategori ağacı görünümü
   - Kategori ekleme/düzenleme/silme
   - Kategori bazlı gider özeti

4. **Tekrarlayan Giderler Ekranı**
   - Tekrarlayan gider listesi
   - Durum filtresi
   - Sıklık filtresi
   - Tekrarlayan gider ekleme/düzenleme/silme
   - Tekrarlayan gider detayları

5. **Gider Raporu Ekranı**
   - Rapor listesi
   - Rapor oluşturma
   - Gider seçme ve ekleme
   - Rapor özeti
   - Rapor onay durumu
   - Rapor yazdırma ve dışa aktarma

6. **Gider Onay Ekranı**
   - Onay bekleyen giderler listesi
   - Gider detayları görüntüleme
   - Onaylama/reddetme işlemleri
   - Toplu onay seçenekleri
   - Onay geçmişi

7. **Bütçe Yönetim Ekranı**
   - Bütçe listesi
   - Bütçe oluşturma/düzenleme
   - Kategori bazlı bütçe girişi
   - Bütçe-gerçekleşen karşılaştırma
   - Bütçe performans grafikleri

8. **Avans Yönetim Ekranı**
   - Avans listesi
   - Avans talebi oluşturma
   - Avans onaylama
   - Avans kapatma
   - Avans-masraf ilişkilendirme

9. **Gider Analiz Ekranı**
   - Dönemsel gider grafikleri
   - Kategori bazlı dağılım
   - Trend analizi
   - Karşılaştırmalı raporlar
   - Filtreleme ve özelleştirme seçenekleri

## Özellikler ve İşlevler

- Gider verilerinin Excel/CSV formatında içe/dışa aktarımı
- Makbuz/fatura tarama ve otomatik veri çıkarma
- Mobil uygulama ile gider girişi ve makbuz fotoğraflama
- Çoklu para birimi desteği
- Vergi hesaplama ve raporlama
- Gider onay iş akışları
- Bütçe-gerçekleşen karşılaştırma
- Tekrarlayan gider otomasyonu
- Gider tahminleme
- Departman/proje bazlı gider takibi

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- İş akışı testleri
- Vergi hesaplama testleri
- Bütçe hesaplama testleri
- Performans testleri
- Mobil uygulama testleri

## Açık Sorular

1. Gider onay iş akışı ne kadar karmaşık olmalı?
2. Mobil uygulama ile makbuz tarama ve OCR özelliği ilk sürümde yer almalı mı?
3. Bütçe modülü ne kadar detaylı olmalı?
4. Çalışan masraf yönetimi ayrı bir modül olarak mı ele alınmalı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-006: Ödeme ve Tahsilat Yönetimi
- RFC-007: Banka Hesapları Yönetimi 