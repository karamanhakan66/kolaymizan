# RFC-004: Ürün/Hizmet Kataloğu ve Stok Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının ürün/hizmet kataloğu ve stok yönetimi modülünü tanımlamaktadır. Ürün ve hizmetlerin eklenmesi, düzenlenmesi, kategorize edilmesi ve stok takibi gibi temel özellikleri içermektedir.

## Motivasyon

Ürün ve hizmet bilgilerinin etkin yönetimi ve stok takibi, ön muhasebe programının kritik bileşenlerindendir. İşletmelerin satış ve alım süreçlerinde kullandıkları ürün/hizmet bilgilerini düzenli bir şekilde yönetebilmesi, stok seviyelerini takip edebilmesi ve ürün hareketlerini izleyebilmesi için kapsamlı bir ürün/hizmet kataloğu ve stok yönetim modülü gereklidir.

## Detaylı Tasarım

### Ürün Yönetimi

#### Ürün Ekleme, Düzenleme ve Silme
- Yeni ürün kaydı oluşturma
- Mevcut ürün bilgilerini düzenleme
- Ürün kaydı silme (soft delete)
- Ürün arama ve filtreleme
- Toplu ürün işlemleri (içe/dışa aktarma)

#### Ürün Bilgileri
- Temel bilgiler:
  - Ürün adı
  - Ürün kodu
  - Barkod
  - Açıklama
  - Birim (adet, kg, lt vb.)
  - Alış fiyatı
  - Satış fiyatı
  - KDV oranı
  - Ürün görselleri (birden fazla görsel desteği)
- Stok bilgileri:
  - Minimum stok seviyesi
  - Maksimum stok seviyesi
  - Kritik stok seviyesi
  - Stok takibi yapılsın/yapılmasın seçeneği
- Tedarikçi bilgileri:
  - Varsayılan tedarikçi
  - Tedarikçi ürün kodu
  - Tedarikçi fiyatları
- Varyasyon desteği (renk, boyut vb.)
- Özel notlar ve etiketler

#### Ürün Kategorileri ve Alt Kategoriler
- Kategori ekleme, düzenleme ve silme
- Hiyerarşik kategori yapısı (ana kategori, alt kategori)
- Ürünleri kategorilere atama
- Kategori bazlı raporlama ve filtreleme

#### Ürün Görselleri
- Birden fazla görsel ekleme
- Ana görsel belirleme
- Görsel önizleme
- Toplu görsel yükleme
- Görsel boyutlandırma ve optimize etme

#### Minimum Stok Seviyesi Belirleme
- Ürün bazlı minimum stok seviyesi tanımlama
- Stok seviyesi altına düşen ürünler için bildirim
- Otomatik sipariş önerisi

#### Birim Tanımlama
- Standart birimler (adet, kg, lt, m, m², m³ vb.)
- Özel birim tanımlama
- Birim dönüşümleri (örn. kg -> g, lt -> ml)
- Birim bazlı fiyatlandırma

### Stok Yönetimi

#### Stok Giriş ve Çıkış Takibi
- Stok giriş kaydı (satın alma, iade, sayım düzeltme)
- Stok çıkış kaydı (satış, fire, sayım düzeltme)
- Stok transfer kaydı
- Stok hareket geçmişi
- Lot/Seri numarası takibi
- Son kullanma tarihi takibi

#### Stok Sayım İşlemleri
- Stok sayım listesi oluşturma
- Sayım sonuçlarını girme
- Sayım farkları raporlama
- Otomatik stok düzeltme
- Periyodik sayım planlaması

#### Stok Transferi
- Depolar arası transfer
- Transfer formu oluşturma
- Transfer onay süreci
- Transfer geçmişi

#### Stok Alarm Sistemi
- Düşük stok bildirimleri
- Kritik stok seviyesi uyarıları
- Stok tükenme tahminleri
- E-posta/uygulama içi bildirimler

#### Stok Hareket Raporu
- Tarih aralığına göre stok hareketleri
- Ürün bazlı stok hareketleri
- Depo bazlı stok hareketleri
- Hareket türüne göre filtreleme
- Detaylı hareket açıklamaları

### Hizmet Yönetimi

#### Hizmet Ekleme, Düzenleme ve Silme
- Yeni hizmet kaydı oluşturma
- Mevcut hizmet bilgilerini düzenleme
- Hizmet kaydı silme (soft delete)
- Hizmet arama ve filtreleme
- Toplu hizmet işlemleri

#### Hizmet Bilgileri
- Temel bilgiler:
  - Hizmet adı
  - Hizmet kodu
  - Açıklama
  - Birim (saat, gün, ay vb.)
  - Fiyat
  - KDV oranı
- Özel notlar ve etiketler

#### Hizmet Kategorileri
- Kategori ekleme, düzenleme ve silme
- Hizmetleri kategorilere atama
- Kategori bazlı raporlama

## Teknik Uygulama

### Veritabanı Tabloları

#### Products Tablosu
```
Id (PK)
Name
Code
Barcode
Description
UnitId (FK)
PurchasePrice
SalePrice
VatRate
CategoryId (FK)
MinStockLevel
MaxStockLevel
CriticalStockLevel
TrackStock
DefaultSupplierId (FK)
SupplierProductCode
IsActive
CreatedAt
UpdatedAt
CreatedBy
Notes
```

#### ProductImages Tablosu
```
Id (PK)
ProductId (FK)
ImagePath
IsMain
DisplayOrder
CreatedAt
```

#### ProductVariations Tablosu
```
Id (PK)
ProductId (FK)
VariationName
VariationValue
SKU
Barcode
PurchasePrice
SalePrice
StockQuantity
IsActive
```

#### Units Tablosu
```
Id (PK)
Name
Abbreviation
Description
IsActive
```

#### UnitConversions Tablosu
```
Id (PK)
FromUnitId (FK)
ToUnitId (FK)
ConversionFactor
```

#### Categories Tablosu
```
Id (PK)
Name
Description
ParentCategoryId (FK, self-referencing)
Type (Product/Service)
IsActive
CreatedAt
UpdatedAt
```

#### Services Tablosu
```
Id (PK)
Name
Code
Description
UnitId (FK)
Price
VatRate
CategoryId (FK)
IsActive
CreatedAt
UpdatedAt
CreatedBy
Notes
```

#### Inventory Tablosu
```
Id (PK)
ProductId (FK)
WarehouseId (FK)
Quantity
ReservedQuantity
AvailableQuantity
UpdatedAt
```

#### InventoryTransactions Tablosu
```
Id (PK)
ProductId (FK)
WarehouseId (FK)
TransactionType (Purchase/Sale/Return/Transfer/Adjustment)
Quantity
UnitPrice
ReferenceType (Invoice/Order/Adjustment)
ReferenceId
TransactionDate
Notes
CreatedBy
CreatedAt
```

#### Warehouses Tablosu
```
Id (PK)
Name
Address
IsDefault
IsActive
CreatedAt
UpdatedAt
```

#### StockTransfers Tablosu
```
Id (PK)
TransferNumber
SourceWarehouseId (FK)
DestinationWarehouseId (FK)
TransferDate
Status (Draft/Pending/Completed/Cancelled)
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### StockTransferItems Tablosu
```
Id (PK)
StockTransferId (FK)
ProductId (FK)
Quantity
Notes
```

### İlişkiler

- Bir ürün bir kategoriye ait olabilir
- Bir kategori birden fazla alt kategoriye sahip olabilir
- Bir ürün birden fazla görsele sahip olabilir
- Bir ürün birden fazla varyasyona sahip olabilir
- Bir ürün birden fazla depoda stoklanabilir
- Bir hizmet bir kategoriye ait olabilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Ürün Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir ürün tablosu
   - Hızlı arama
   - Kategori filtresi
   - Stok durumu filtresi
   - Toplu işlem seçenekleri
   - Yeni ürün ekleme butonu

2. **Ürün Detay/Düzenleme Ekranı**
   - Ürün bilgileri formu
   - Sekmeli arayüz (Genel Bilgiler, Stok Bilgileri, Görseller, Varyasyonlar, Tedarikçi Bilgileri)
   - Kaydet/İptal butonları
   - Silme/Pasif yapma seçenekleri

3. **Stok Yönetim Ekranı**
   - Stok seviyesi özeti
   - Depo bazlı stok durumu
   - Kritik stok seviyesindeki ürünler
   - Stok giriş/çıkış/transfer işlemleri

4. **Stok Hareket Ekranı**
   - Filtrelenebilir stok hareket tablosu
   - Tarih aralığı seçimi
   - Ürün/kategori/depo filtreleri
   - Hareket türü filtresi
   - Detaylı hareket görüntüleme

5. **Stok Sayım Ekranı**
   - Sayım listesi oluşturma
   - Barkod okuyucu desteği
   - Sayım sonuçlarını girme
   - Fark raporu görüntüleme
   - Stok düzeltme onayı

6. **Stok Transfer Ekranı**
   - Transfer formu
   - Kaynak ve hedef depo seçimi
   - Ürün ve miktar seçimi
   - Transfer durumu takibi

7. **Hizmet Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir hizmet tablosu
   - Hızlı arama
   - Kategori filtresi
   - Yeni hizmet ekleme butonu

8. **Hizmet Detay/Düzenleme Ekranı**
   - Hizmet bilgileri formu
   - Kaydet/İptal butonları
   - Silme/Pasif yapma seçenekleri

9. **Kategori Yönetim Ekranı**
   - Ürün kategorileri
   - Hizmet kategorileri
   - Kategori ağacı görünümü
   - Kategori ekleme/düzenleme/silme

## Özellikler ve İşlevler

- Ürün/hizmet verilerinin Excel/CSV formatında içe/dışa aktarımı
- Barkod oluşturma ve yazdırma
- Barkod okuyucu entegrasyonu
- Toplu fiyat güncelleme
- Stok maliyeti hesaplama (FIFO, LIFO, Ortalama)
- Düşük stok bildirimleri
- Stok yaşlandırma raporu
- Ürün etiketleme sistemi
- Çoklu birim desteği
- Varyasyon yönetimi

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Stok hesaplama testleri
- Performans testleri (büyük veri setleri ile)
- Barkod okuyucu entegrasyon testleri

## Açık Sorular

1. Seri numarası/lot takibi ilk sürümde yer almalı mı?
2. Üretim modülü ileride eklenecek mi?
3. Çoklu depo yönetimi ilk sürümde ne kadar detaylı olmalı?
4. Ürün varyasyonları nasıl yapılandırılmalı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari 