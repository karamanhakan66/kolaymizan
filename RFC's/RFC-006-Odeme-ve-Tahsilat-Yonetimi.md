# RFC-006: Ödeme ve Tahsilat Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının ödeme ve tahsilat yönetimi modülünü tanımlamaktadır. Müşterilerden tahsilat ve tedarikçilere ödeme işlemlerinin kaydedilmesi, takibi ve raporlanması gibi temel özellikleri içermektedir.

## Motivasyon

Ödeme ve tahsilat yönetimi, ön muhasebe programının kritik bileşenlerinden biridir. İşletmelerin nakit akışını etkin bir şekilde yönetebilmesi, alacak ve borçlarını takip edebilmesi ve finansal durumunu anlık olarak görebilmesi için kapsamlı bir ödeme ve tahsilat yönetim modülü gereklidir.

## Detaylı Tasarım

### Tahsilat İşlemleri

#### Müşterilerden Tahsilat Kaydetme
- Müşteri seçimi
- Tahsilat tutarı girişi
- Tahsilat tarihi belirleme
- Tahsilat yöntemi seçimi (nakit, banka, kredi kartı, çek/senet)
- Tahsilatı faturalarla ilişkilendirme
- Kısmi tahsilat desteği
- Tahsilat açıklaması girişi
- Tahsilat makbuzu oluşturma

#### Kısmi Tahsilat Desteği
- Bir faturanın kısmi ödemesini kaydetme
- Birden fazla faturaya dağıtılabilen tahsilat
- Otomatik veya manuel dağıtım seçeneği
- Kalan bakiye takibi
- Ödeme planına göre tahsilat takibi

#### Farklı Ödeme Yöntemleri
- Nakit tahsilat
- Banka havalesi/EFT
- Kredi kartı ödemesi
- Çek ile tahsilat
- Senet ile tahsilat
- Dijital ödeme yöntemleri (gelecek sürüm)
- Ödeme yöntemine özel bilgi alanları

#### Çek ve Senet Takibi
- Çek/senet bilgilerini kaydetme (no, vade, banka, şube)
- Çek/senet durumu takibi (Beklemede, Tahsil Edildi, Karşılıksız)
- Çek/senet vade takibi
- Ciro işlemleri
- Bankaya tahsile gönderme
- Karşılıksız çek işlemleri
- Çek/senet raporları

#### Tahsilat Makbuzu Oluşturma
- Profesyonel tasarımlı makbuz şablonları
- Otomatik makbuz numarası oluşturma
- Makbuz yazdırma
- E-posta ile gönderme
- PDF olarak kaydetme
- Makbuz geçmişi görüntüleme

### Ödeme İşlemleri

#### Tedarikçilere Ödeme Kaydetme
- Tedarikçi seçimi
- Ödeme tutarı girişi
- Ödeme tarihi belirleme
- Ödeme yöntemi seçimi (nakit, banka, kredi kartı, çek/senet)
- Ödemeyi faturalarla ilişkilendirme
- Kısmi ödeme desteği
- Ödeme açıklaması girişi
- Ödeme makbuzu oluşturma

#### Kısmi Ödeme Desteği
- Bir faturanın kısmi ödemesini kaydetme
- Birden fazla faturaya dağıtılabilen ödeme
- Otomatik veya manuel dağıtım seçeneği
- Kalan bakiye takibi
- Ödeme planına göre ödeme takibi

#### Farklı Ödeme Yöntemleri
- Nakit ödeme
- Banka havalesi/EFT
- Kredi kartı ödemesi
- Çek ile ödeme
- Senet ile ödeme
- Otomatik ödeme talimatları
- Ödeme yöntemine özel bilgi alanları

#### Ödeme Makbuzu Oluşturma
- Profesyonel tasarımlı makbuz şablonları
- Otomatik makbuz numarası oluşturma
- Makbuz yazdırma
- E-posta ile gönderme
- PDF olarak kaydetme
- Makbuz geçmişi görüntüleme

#### Periyodik Ödeme Planları
- Tekrarlayan ödemeleri tanımlama
- Ödeme sıklığı belirleme (haftalık, aylık, üç aylık, yıllık)
- Otomatik ödeme hatırlatıcıları
- Ödeme planı raporları
- Ödeme planı revizyonu

### Vade Takibi

#### Vadesi Gelen Alacaklar Bildirimi
- Vadesi yaklaşan alacaklar listesi
- Vadesi geçmiş alacaklar listesi
- Vade bazlı filtreleme (bugün, bu hafta, bu ay)
- Müşteri bazlı vade takibi
- Otomatik e-posta bildirimleri
- Dashboard üzerinde vade özeti

#### Vadesi Gelen Borçlar Bildirimi
- Vadesi yaklaşan borçlar listesi
- Vadesi geçmiş borçlar listesi
- Vade bazlı filtreleme (bugün, bu hafta, bu ay)
- Tedarikçi bazlı vade takibi
- Otomatik e-posta bildirimleri
- Dashboard üzerinde vade özeti

#### Vade Takvimi Görüntüleme
- Takvim formatında vade görünümü
- Alacak ve borçları aynı takvimde gösterme
- Tarih aralığı filtreleme
- Müşteri/tedarikçi filtreleme
- Tutar bazlı filtreleme
- Takvim üzerinden detaylı bilgiye erişim

#### Erken Ödeme/Tahsilat Yönetimi
- Erken ödeme indirimi tanımlama
- Erken tahsilat indirimi uygulama
- Vade farkı hesaplama
- Geç ödeme faizi hesaplama
- İndirim ve faiz oranlarını yapılandırma

### Avans Yönetimi

#### Müşteri Avansları
- Müşteriden avans tahsilatı kaydetme
- Avansı faturalarla ilişkilendirme
- Avans bakiyesi takibi
- Avans raporları
- Kullanılmayan avansların iadesi

#### Tedarikçi Avansları
- Tedarikçiye avans ödemesi kaydetme
- Avansı faturalarla ilişkilendirme
- Avans bakiyesi takibi
- Avans raporları
- Kullanılmayan avansların iadesi

### Mahsup İşlemleri

- Alacak ve borçları mahsuplaştırma
- Aynı müşteri/tedarikçi için cari hesap mahsubu
- Farklı müşteri/tedarikçiler arası mahsup
- Mahsup fişi oluşturma
- Mahsup geçmişi görüntüleme

## Teknik Uygulama

### Veritabanı Tabloları

#### Payments Tablosu
```
Id (PK)
PaymentNumber
PaymentType (Receipt/Payment)
PaymentDate
EntityId (FK, Customer/Supplier)
EntityType (Customer/Supplier)
Amount
PaymentMethodId (FK)
ReferenceNumber
BankAccountId (FK, nullable)
CurrencyId (FK)
ExchangeRate
Notes
Status (Draft/Completed/Cancelled)
CreatedBy
CreatedAt
UpdatedAt
CancelledBy
CancelledAt
CancellationReason
```

#### PaymentAllocations Tablosu
```
Id (PK)
PaymentId (FK)
InvoiceId (FK)
Amount
Notes
CreatedBy
CreatedAt
```

#### PaymentMethods Tablosu
```
Id (PK)
Name
Description
IsActive
RequiresBankAccount
RequiresReference
```

#### Cheques Tablosu
```
Id (PK)
ChequeNumber
PaymentId (FK, nullable)
BankName
BranchName
AccountNumber
DrawerName
IssueDate
DueDate
Amount
Status (Pending/Deposited/Cleared/Bounced/Endorsed)
EndorsedTo
EndorsedAt
DepositedAt
ClearedAt
BouncedAt
BounceReason
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### Promissory Tablosu
```
Id (PK)
PromissoryNumber
PaymentId (FK, nullable)
IssuerName
IssueDate
DueDate
Amount
Status (Pending/Deposited/Cleared/Bounced/Endorsed)
EndorsedTo
EndorsedAt
DepositedAt
ClearedAt
BouncedAt
BounceReason
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### RecurringPayments Tablosu
```
Id (PK)
EntityId (FK, Customer/Supplier)
EntityType (Customer/Supplier)
PaymentMethodId (FK)
Amount
StartDate
EndDate
Frequency (Weekly/Monthly/Quarterly/Yearly)
DayOfMonth
MonthOfYear
IsActive
LastRunDate
NextRunDate
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### PaymentReminders Tablosu
```
Id (PK)
EntityId (FK, Customer/Supplier)
EntityType (Customer/Supplier)
InvoiceId (FK, nullable)
ReminderDate
ReminderType (Email/SMS/System)
Status (Pending/Sent/Failed)
SentAt
Notes
CreatedBy
CreatedAt
```

#### Advances Tablosu
```
Id (PK)
AdvanceNumber
EntityId (FK, Customer/Supplier)
EntityType (Customer/Supplier)
PaymentId (FK)
Amount
RemainingAmount
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### AdvanceAllocations Tablosu
```
Id (PK)
AdvanceId (FK)
InvoiceId (FK)
Amount
AllocationDate
Notes
CreatedBy
CreatedAt
```

### İlişkiler

- Bir ödeme/tahsilat birden fazla faturaya dağıtılabilir
- Bir ödeme/tahsilat bir ödeme yöntemine sahiptir
- Bir çek/senet bir ödeme/tahsilat ile ilişkilendirilebilir
- Bir avans bir ödeme/tahsilat ile oluşturulur
- Bir avans birden fazla faturaya dağıtılabilir
- Tekrarlayan ödemeler birden fazla ödeme kaydı oluşturabilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Tahsilat Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir tahsilat tablosu
   - Tarih aralığı filtresi
   - Müşteri filtresi
   - Ödeme yöntemi filtresi
   - Durum filtresi
   - Hızlı arama
   - Yeni tahsilat ekleme butonu

2. **Tahsilat Ekleme/Düzenleme Ekranı**
   - Müşteri seçimi
   - Tahsilat bilgileri (tarih, tutar, yöntem)
   - Ödeme yöntemine göre değişen alanlar
   - Fatura seçimi ve dağıtım
   - Tahsilat açıklaması
   - Kaydet/İptal butonları

3. **Ödeme Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir ödeme tablosu
   - Tarih aralığı filtresi
   - Tedarikçi filtresi
   - Ödeme yöntemi filtresi
   - Durum filtresi
   - Hızlı arama
   - Yeni ödeme ekleme butonu

4. **Ödeme Ekleme/Düzenleme Ekranı**
   - Tedarikçi seçimi
   - Ödeme bilgileri (tarih, tutar, yöntem)
   - Ödeme yöntemine göre değişen alanlar
   - Fatura seçimi ve dağıtım
   - Ödeme açıklaması
   - Kaydet/İptal butonları

5. **Çek/Senet Yönetim Ekranı**
   - Çek/senet listesi
   - Durum filtreleme
   - Vade takibi
   - Çek/senet işlemleri (tahsil, ciro, karşılıksız)
   - Çek/senet detay görüntüleme

6. **Vade Takvimi Ekranı**
   - Takvim görünümü
   - Alacak/borç renk kodlaması
   - Tarih aralığı seçimi
   - Detay görüntüleme
   - Filtreleme seçenekleri

7. **Avans Yönetim Ekranı**
   - Avans listesi
   - Müşteri/tedarikçi filtresi
   - Kullanılan/kalan avans tutarları
   - Avans kullanım detayları
   - Yeni avans ekleme butonu

8. **Mahsup İşlemleri Ekranı**
   - Mahsup edilecek alacak/borç seçimi
   - Mahsup tutarı belirleme
   - Mahsup açıklaması
   - Mahsup fişi oluşturma

## Özellikler ve İşlevler

- Ödeme/tahsilat verilerinin Excel/CSV formatında içe/dışa aktarımı
- Toplu ödeme/tahsilat işlemleri
- Otomatik ödeme/tahsilat eşleştirme
- Banka hesapları ile entegrasyon
- Çek/senet vade takibi ve hatırlatıcılar
- Vadesi geçmiş alacak/borç bildirimleri
- Ödeme planı oluşturma ve takibi
- Makbuz yazdırma ve e-posta gönderimi
- Avans yönetimi ve takibi
- Mahsup işlemleri

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Ödeme dağıtım hesaplama testleri
- Vade hesaplama testleri
- Performans testleri
- Yazdırma ve PDF oluşturma testleri
- E-posta gönderim testleri

## Açık Sorular

1. Çek/senet modülü ne kadar detaylı olmalı?
2. Otomatik ödeme hatırlatıcıları hangi kanallar üzerinden gönderilmeli?
3. Kredi kartı entegrasyonu ilk sürümde yer almalı mı?
4. Avans yönetimi ayrı bir modül olarak mı, yoksa ödeme/tahsilat modülünün bir parçası olarak mı ele alınmalı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-003: Müşteri/Tedarikçi Yönetimi
- RFC-005: Fatura Yönetimi 