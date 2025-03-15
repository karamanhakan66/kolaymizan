# RFC-003: Müşteri/Tedarikçi Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının müşteri ve tedarikçi yönetimi modülünü tanımlamaktadır. Müşteri ve tedarikçilerin eklenmesi, düzenlenmesi, silinmesi ve kategorize edilmesi gibi temel özellikleri içermektedir.

## Motivasyon

Müşteri ve tedarikçi bilgilerinin etkin yönetimi, ön muhasebe programının temel işlevlerinden biridir. İşletmelerin müşteri ve tedarikçi ilişkilerini düzenli bir şekilde takip edebilmesi, cari hesapları izleyebilmesi ve geçmiş işlemlere kolayca erişebilmesi için kapsamlı bir müşteri/tedarikçi yönetim modülü gereklidir.

## Detaylı Tasarım

### Müşteri Yönetimi

#### Müşteri Ekleme, Düzenleme ve Silme
- Yeni müşteri kaydı oluşturma
- Mevcut müşteri bilgilerini düzenleme
- Müşteri kaydı silme (soft delete)
- Müşteri arama ve filtreleme
- Toplu müşteri işlemleri (içe/dışa aktarma)

#### Müşteri Bilgileri
- Temel bilgiler:
  - Ad/Unvan
  - Vergi Dairesi ve Vergi Numarası/TC Kimlik No
  - Adres bilgileri (birden fazla adres desteği)
  - Telefon numaraları (birden fazla numara desteği)
  - E-posta adresleri
  - Web sitesi
- İletişim kişileri:
  - Ad-soyad
  - Pozisyon
  - Telefon
  - E-posta
- Özel notlar ve etiketler
- Müşteri özel fiyatlandırma bilgileri
- Ödeme ve teslimat şartları

#### Müşteri Kategorileri
- Kategori ekleme, düzenleme ve silme
- Hiyerarşik kategori yapısı
- Müşterileri kategorilere atama
- Kategori bazlı raporlama

#### Müşteri Cari Hesap Görüntüleme
- Cari hesap bakiyesi
- Borç/alacak durumu
- Vade bilgileri
- Ödeme geçmişi
- Açık faturalar
- Tahsilat bilgileri

#### Müşteri Bazlı İşlem Geçmişi
- Satış faturaları listesi
- Tahsilat kayıtları
- İade işlemleri
- Teklif ve siparişler
- Zaman çizelgesi görünümü
- İşlem detaylarına hızlı erişim

### Tedarikçi Yönetimi

#### Tedarikçi Ekleme, Düzenleme ve Silme
- Yeni tedarikçi kaydı oluşturma
- Mevcut tedarikçi bilgilerini düzenleme
- Tedarikçi kaydı silme (soft delete)
- Tedarikçi arama ve filtreleme
- Toplu tedarikçi işlemleri (içe/dışa aktarma)

#### Tedarikçi Bilgileri
- Temel bilgiler:
  - Ad/Unvan
  - Vergi Dairesi ve Vergi Numarası/TC Kimlik No
  - Adres bilgileri (birden fazla adres desteği)
  - Telefon numaraları (birden fazla numara desteği)
  - E-posta adresleri
  - Web sitesi
- İletişim kişileri:
  - Ad-soyad
  - Pozisyon
  - Telefon
  - E-posta
- Özel notlar ve etiketler
- Ürün/hizmet bilgileri
- Ödeme ve teslimat şartları

#### Tedarikçi Kategorileri
- Kategori ekleme, düzenleme ve silme
- Hiyerarşik kategori yapısı
- Tedarikçileri kategorilere atama
- Kategori bazlı raporlama

#### Tedarikçi Cari Hesap Görüntüleme
- Cari hesap bakiyesi
- Borç/alacak durumu
- Vade bilgileri
- Ödeme geçmişi
- Açık faturalar
- Ödeme bilgileri

#### Tedarikçi Bazlı İşlem Geçmişi
- Alış faturaları listesi
- Ödeme kayıtları
- İade işlemleri
- Siparişler
- Zaman çizelgesi görünümü
- İşlem detaylarına hızlı erişim

## Teknik Uygulama

### Veritabanı Tabloları

#### Customers Tablosu
```
Id (PK)
Name
TaxOffice
TaxNumber
IdentityNumber
CustomerType (Individual/Corporate)
Phone
Email
Website
Address
City
Country
PostalCode
DefaultPaymentTerms
DefaultCurrency
CustomerCategoryId (FK)
IsActive
CreatedAt
UpdatedAt
CreatedBy
Notes
```

#### CustomerContacts Tablosu
```
Id (PK)
CustomerId (FK)
FirstName
LastName
Position
Phone
Email
IsPrimary
CreatedAt
UpdatedAt
```

#### CustomerAddresses Tablosu
```
Id (PK)
CustomerId (FK)
AddressType (Billing/Shipping/Other)
AddressLine1
AddressLine2
City
State
Country
PostalCode
IsPrimary
```

#### CustomerCategories Tablosu
```
Id (PK)
Name
Description
ParentCategoryId (FK, self-referencing)
CreatedAt
UpdatedAt
```

#### Suppliers Tablosu
```
Id (PK)
Name
TaxOffice
TaxNumber
IdentityNumber
SupplierType (Individual/Corporate)
Phone
Email
Website
Address
City
Country
PostalCode
DefaultPaymentTerms
DefaultCurrency
SupplierCategoryId (FK)
IsActive
CreatedAt
UpdatedAt
CreatedBy
Notes
```

#### SupplierContacts Tablosu
```
Id (PK)
SupplierId (FK)
FirstName
LastName
Position
Phone
Email
IsPrimary
CreatedAt
UpdatedAt
```

#### SupplierAddresses Tablosu
```
Id (PK)
SupplierId (FK)
AddressType (Billing/Shipping/Other)
AddressLine1
AddressLine2
City
State
Country
PostalCode
IsPrimary
```

#### SupplierCategories Tablosu
```
Id (PK)
Name
Description
ParentCategoryId (FK, self-referencing)
CreatedAt
UpdatedAt
```

### İlişkiler

- Bir müşteri/tedarikçi birden fazla adrese sahip olabilir
- Bir müşteri/tedarikçi birden fazla iletişim kişisine sahip olabilir
- Bir müşteri/tedarikçi bir kategoriye ait olabilir
- Kategoriler hiyerarşik olarak yapılandırılabilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Müşteri Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir müşteri tablosu
   - Hızlı arama
   - Toplu işlem seçenekleri
   - Kategori filtresi
   - Yeni müşteri ekleme butonu

2. **Müşteri Detay/Düzenleme Ekranı**
   - Müşteri bilgileri formu
   - Sekmeli arayüz (Genel Bilgiler, İletişim Kişileri, Adresler, Cari Hesap, İşlem Geçmişi)
   - Kaydet/İptal butonları
   - Silme/Pasif yapma seçenekleri

3. **Müşteri Cari Hesap Ekranı**
   - Cari hesap özeti
   - Borç/alacak durumu
   - İşlem listesi
   - Tarih aralığı filtresi
   - Dışa aktarma seçenekleri

4. **Tedarikçi Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir tedarikçi tablosu
   - Hızlı arama
   - Toplu işlem seçenekleri
   - Kategori filtresi
   - Yeni tedarikçi ekleme butonu

5. **Tedarikçi Detay/Düzenleme Ekranı**
   - Tedarikçi bilgileri formu
   - Sekmeli arayüz (Genel Bilgiler, İletişim Kişileri, Adresler, Cari Hesap, İşlem Geçmişi)
   - Kaydet/İptal butonları
   - Silme/Pasif yapma seçenekleri

6. **Tedarikçi Cari Hesap Ekranı**
   - Cari hesap özeti
   - Borç/alacak durumu
   - İşlem listesi
   - Tarih aralığı filtresi
   - Dışa aktarma seçenekleri

7. **Kategori Yönetim Ekranı**
   - Müşteri kategorileri
   - Tedarikçi kategorileri
   - Kategori ağacı görünümü
   - Kategori ekleme/düzenleme/silme

## Özellikler ve İşlevler

- Müşteri/tedarikçi verilerinin Excel/CSV formatında içe/dışa aktarımı
- Müşteri/tedarikçi etiketleme sistemi
- Otomatik vergi numarası doğrulama
- Müşteri/tedarikçi birleştirme (duplicate yönetimi)
- Toplu e-posta gönderimi
- Müşteri/tedarikçi risk değerlendirmesi
- Hatırlatıcı ve notlar
- Doküman ekleme (sözleşme, fatura vb.)

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Veri doğrulama testleri
- Performans testleri (büyük veri setleri ile)

## Açık Sorular

1. Müşteri ve tedarikçi modülleri tamamen ayrı mı olmalı, yoksa ortak bir "İş Ortakları" modülü altında mı birleştirilmeli?
2. Müşteri/tedarikçi kredi limiti ve risk değerlendirmesi nasıl yapılandırılmalı?
3. Müşteri/tedarikçi portalı ileride eklenecek mi?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari 