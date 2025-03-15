# RFC-005: Fatura Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının fatura yönetimi modülünü tanımlamaktadır. Satış, alış, proforma ve iade faturalarının oluşturulması, düzenlenmesi, takibi ve raporlanması gibi temel özellikleri içermektedir.

## Motivasyon

Fatura yönetimi, ön muhasebe programının en kritik bileşenlerinden biridir. İşletmelerin satış ve alım süreçlerinde oluşturdukları faturaları düzenli bir şekilde yönetebilmesi, takip edebilmesi ve yasal gereksinimlere uygun şekilde düzenleyebilmesi için kapsamlı bir fatura yönetim modülü gereklidir.

## Detaylı Tasarım

### Fatura İşlemleri

#### Satış Faturası Oluşturma
- Müşteri seçimi
- Ürün/hizmet seçimi ve miktar girişi
- Fiyat ve iskonto belirleme
- KDV ve diğer vergi hesaplamaları
- Fatura tarihi ve vade tarihi belirleme
- Ödeme şartları ve ödeme yöntemi seçimi
- Fatura numarası otomatik oluşturma
- Fatura notları ve açıklamaları
- Fatura kaydetme ve onaylama

#### Alış Faturası Oluşturma
- Tedarikçi seçimi
- Ürün/hizmet seçimi ve miktar girişi
- Fiyat ve iskonto girişi
- KDV ve diğer vergi hesaplamaları
- Fatura tarihi ve vade tarihi belirleme
- Ödeme şartları ve ödeme yöntemi seçimi
- Fatura numarası girişi
- Fatura notları ve açıklamaları
- Fatura kaydetme ve onaylama

#### Proforma Fatura Oluşturma
- Müşteri seçimi
- Ürün/hizmet seçimi ve miktar girişi
- Fiyat ve iskonto belirleme
- KDV ve diğer vergi hesaplamaları
- Geçerlilik süresi belirleme
- Proforma fatura numarası otomatik oluşturma
- Notlar ve açıklamalar
- Proforma faturayı satış faturasına dönüştürme

#### İade Faturası Oluşturma
- İlgili satış/alış faturasını seçme
- İade edilecek ürünleri ve miktarları belirleme
- İade nedeni girişi
- KDV ve diğer vergi hesaplamaları
- İade faturası numarası otomatik oluşturma
- Notlar ve açıklamalar
- İade faturası kaydetme ve onaylama

#### Fatura Düzenleme ve İptal Etme
- Onaylanmamış faturaları düzenleme
- Fatura iptal etme (iptal nedeni girişi)
- İptal edilen faturanın yerine yeni fatura oluşturma
- Fatura durumunu güncelleme (Taslak, Onaylandı, İptal Edildi)

#### Fatura Kopyalama ve Tekrarlama
- Mevcut faturadan yeni fatura oluşturma
- Periyodik fatura tanımlama (aylık, üç aylık, yıllık)
- Otomatik fatura oluşturma planlaması
- Toplu fatura oluşturma

### Fatura Özellikleri

#### Fatura Numarası Otomatik Oluşturma
- Özelleştirilebilir fatura numarası formatı
- Yıl, ay, gün, seri ve sıra numarası kombinasyonları
- Farklı fatura türleri için farklı format tanımlama
- Otomatik sıra numarası artırma

#### Çoklu Vergi Oranı Desteği
- Farklı KDV oranları tanımlama
- Ürün/hizmet bazlı vergi oranı belirleme
- Tevkifat uygulaması
- ÖTV ve diğer vergi türleri desteği
- Vergi muafiyeti tanımlama

#### İskonto ve Ek Ücret Ekleme
- Fatura geneline iskonto uygulama
- Kalem bazlı iskonto uygulama
- Tutar veya yüzde olarak iskonto tanımlama
- Nakliye, sigorta gibi ek ücretler ekleme
- İskonto ve ek ücretlere vergi uygulama

#### Ödeme Şartları ve Vadeler
- Standart ödeme şartları tanımlama (peşin, 30 gün, 60 gün vb.)
- Özel vade tarihi belirleme
- Taksitli ödeme planı oluşturma
- Vade farkı hesaplama
- Erken ödeme iskontosu tanımlama

#### Döviz Desteği
- Çoklu para birimi desteği
- Güncel döviz kuru entegrasyonu
- Dövizli fatura oluşturma
- Döviz kuru farkı hesaplama
- Raporlarda döviz bazlı gösterim

#### Tahsilat ve Ödeme Durumu İzleme
- Fatura ödeme durumu takibi (Ödenmedi, Kısmen Ödendi, Ödendi)
- Vadesi geçmiş fatura bildirimleri
- Tahsilat ve ödeme kayıtları ile ilişkilendirme
- Ödeme geçmişi görüntüleme
- Tahsilat/ödeme planı oluşturma

#### Fatura Notları ve Şartları
- Standart fatura notları tanımlama
- Fatura bazlı özel notlar ekleme
- Teslimat şartları belirleme
- Yasal uyarı metinleri
- Müşteri/tedarikçi özel notları

### Fatura Çıktıları

#### PDF Formatında Fatura Oluşturma
- Profesyonel tasarımlı fatura şablonları
- Firma logosu ve bilgileri
- Yasal gereksinimlere uygun format
- Barkod/QR kod desteği
- Çoklu dil desteği

#### Fatura E-posta ile Gönderme
- Otomatik e-posta şablonları
- Faturayı PDF olarak ekleme
- Toplu fatura gönderimi
- E-posta gönderim durumu takibi
- Gönderim geçmişi

#### Özelleştirilebilir Fatura Şablonları
- Birden fazla fatura şablonu tanımlama
- Şablon tasarım editörü
- Şablon öğelerini özelleştirme
- Müşteri/tedarikçi gruplarına özel şablonlar
- Farklı dillerde şablonlar

#### Toplu Fatura Yazdırma
- Seçilen faturaları toplu yazdırma
- Yazdırma önizleme
- Yazdırma seçenekleri (kağıt boyutu, yönlendirme)
- Yazdırma geçmişi
- Farklı formatlarda dışa aktarma (PDF, Excel)

## Teknik Uygulama

### Veritabanı Tabloları

#### Invoices Tablosu
```
Id (PK)
InvoiceNumber
InvoiceType (Sale/Purchase/Proforma/Return)
InvoiceStatus (Draft/Approved/Cancelled)
CustomerId/SupplierId (FK)
CustomerType (Customer/Supplier)
IssueDate
DueDate
CurrencyId (FK)
ExchangeRate
SubTotal
DiscountType (Percentage/Amount)
DiscountValue
DiscountAmount
TaxAmount
TotalAmount
PaidAmount
RemainingAmount
PaymentStatus (Unpaid/PartiallyPaid/Paid)
PaymentTermId (FK)
PaymentMethodId (FK)
Notes
InternalNotes
IsRecurring
RecurringCycleId (FK)
RelatedInvoiceId (FK)
CreatedBy
CreatedAt
UpdatedAt
ApprovedBy
ApprovedAt
CancelledBy
CancelledAt
CancellationReason
```

#### InvoiceItems Tablosu
```
Id (PK)
InvoiceId (FK)
ItemType (Product/Service)
ProductId/ServiceId (FK)
Description
Quantity
UnitId (FK)
UnitPrice
DiscountType (Percentage/Amount)
DiscountValue
DiscountAmount
TaxRate
TaxAmount
TotalAmount
Notes
DisplayOrder
```

#### InvoicePayments Tablosu
```
Id (PK)
InvoiceId (FK)
PaymentId (FK)
Amount
PaymentDate
Notes
CreatedBy
CreatedAt
```

#### InvoiceTaxes Tablosu
```
Id (PK)
InvoiceId (FK)
InvoiceItemId (FK, nullable)
TaxTypeId (FK)
TaxRate
TaxableAmount
TaxAmount
```

#### PaymentTerms Tablosu
```
Id (PK)
Name
Days
Description
IsActive
```

#### PaymentMethods Tablosu
```
Id (PK)
Name
Description
IsActive
```

#### RecurringCycles Tablosu
```
Id (PK)
Name
DayFrequency
MonthFrequency
Description
IsActive
```

#### InvoiceAttachments Tablosu
```
Id (PK)
InvoiceId (FK)
FileName
FilePath
FileSize
FileType
UploadedBy
UploadedAt
```

#### InvoiceTemplates Tablosu
```
Id (PK)
Name
Description
TemplateContent
IsDefault
LanguageCode
CreatedBy
CreatedAt
UpdatedAt
```

### İlişkiler

- Bir fatura bir müşteri/tedarikçiye ait olabilir
- Bir fatura birden fazla fatura kalemine sahip olabilir
- Bir fatura birden fazla ödeme ile ilişkilendirilebilir
- Bir fatura birden fazla vergi kaydına sahip olabilir
- Bir fatura birden fazla ek dosyaya sahip olabilir
- Bir fatura başka bir fatura ile ilişkilendirilebilir (iade, proforma-satış)

## Kullanıcı Arayüzü

### Ekranlar

1. **Fatura Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir fatura tablosu
   - Fatura türü filtresi (Satış, Alış, Proforma, İade)
   - Fatura durumu filtresi (Taslak, Onaylandı, İptal Edildi)
   - Ödeme durumu filtresi (Ödenmedi, Kısmen Ödendi, Ödendi)
   - Tarih aralığı filtresi
   - Müşteri/tedarikçi filtresi
   - Hızlı arama
   - Toplu işlem seçenekleri
   - Yeni fatura oluşturma butonu

2. **Fatura Oluşturma/Düzenleme Ekranı**
   - Müşteri/tedarikçi seçimi
   - Fatura bilgileri (tarih, vade, para birimi)
   - Ürün/hizmet seçimi ve miktar girişi
   - Otomatik vergi ve toplam hesaplama
   - İskonto ve ek ücret ekleme
   - Notlar ve şartlar
   - Kaydet/Onaylama/İptal butonları

3. **Fatura Detay Ekranı**
   - Fatura bilgileri görüntüleme
   - Fatura kalemleri listesi
   - Ödeme bilgileri ve geçmişi
   - İlişkili faturalar
   - Fatura durumu ve işlem geçmişi
   - Fatura yazdırma, e-posta gönderme, PDF oluşturma butonları
   - Fatura düzenleme/iptal etme butonları

4. **Proforma Fatura Ekranı**
   - Proforma fatura oluşturma
   - Geçerlilik süresi belirleme
   - Proforma faturayı satış faturasına dönüştürme

5. **İade Faturası Ekranı**
   - İlgili satış/alış faturasını seçme
   - İade edilecek ürünleri ve miktarları belirleme
   - İade nedeni girişi

6. **Toplu Fatura İşlemleri Ekranı**
   - Toplu fatura oluşturma
   - Toplu fatura yazdırma
   - Toplu e-posta gönderimi

7. **Fatura Şablonu Yönetim Ekranı**
   - Şablon listesi
   - Şablon düzenleme
   - Şablon önizleme
   - Varsayılan şablon belirleme

## Özellikler ve İşlevler

- Fatura verilerinin Excel/CSV formatında içe/dışa aktarımı
- Fatura arama ve filtreleme
- Fatura onay süreci
- Otomatik stok güncelleme (satış/alış faturası onaylandığında)
- Fatura kopyalama ve tekrarlama
- E-posta entegrasyonu
- Çoklu dil desteği
- Çoklu para birimi desteği
- Yasal gereksinimlere uygun fatura formatları
- Fatura istatistikleri ve raporları

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Vergi hesaplama testleri
- Performans testleri
- Yazdırma ve PDF oluşturma testleri
- E-posta gönderim testleri

## Açık Sorular

1. E-fatura entegrasyonu ilk sürümde yer almalı mı?
2. Fatura onay süreci nasıl yapılandırılmalı?
3. Tekrarlayan faturalar için ne kadar detaylı bir yapılandırma sunulmalı?
4. Farklı ülkelerin fatura formatları desteklenmeli mi?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-003: Müşteri/Tedarikçi Yönetimi
- RFC-004: Ürün/Hizmet Kataloğu ve Stok Yönetimi 