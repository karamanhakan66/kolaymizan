# RFC-007: Banka Hesapları Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının banka hesapları yönetimi modülünü tanımlamaktadır. Banka hesaplarının eklenmesi, düzenlenmesi, hesap hareketlerinin takibi ve hesaplar arası transferlerin yönetimi gibi temel özellikleri içermektedir.

## Motivasyon

Banka hesapları yönetimi, ön muhasebe programının önemli bileşenlerinden biridir. İşletmelerin banka hesaplarını etkin bir şekilde yönetebilmesi, hesap hareketlerini takip edebilmesi, nakit akışını kontrol edebilmesi ve finansal durumunu anlık olarak görebilmesi için kapsamlı bir banka hesapları yönetim modülü gereklidir.

## Detaylı Tasarım

### Hesap İşlemleri

#### Banka Hesabı Ekleme, Düzenleme ve Silme
- Yeni banka hesabı tanımlama
- Mevcut hesap bilgilerini düzenleme
- Hesap silme (soft delete)
- Hesap arama ve filtreleme
- Hesap durumunu değiştirme (aktif/pasif)

#### Hesap Detayları
- Temel bilgiler:
  - Banka adı
  - Şube adı ve kodu
  - Hesap numarası
  - IBAN
  - Hesap türü (vadesiz, vadeli, kredi, kredi kartı)
  - Para birimi
  - Açılış bakiyesi ve tarihi
  - Hesap sahibi bilgileri
- Ek bilgiler:
  - Hesap yetkilisi
  - İletişim bilgileri
  - Hesap limiti
  - Açıklama/notlar
  - Etiketler

#### Hesap Bakiyesi Takibi
- Güncel bakiye görüntüleme
- Kullanılabilir bakiye hesaplama
- Bloke tutar takibi
- Bakiye geçmişi
- Bakiye uyarı seviyeleri (minimum bakiye)
- Çoklu para birimi desteği ile bakiye gösterimi

#### Hesap Hareketleri Listeleme
- Tarih aralığına göre hareketler
- Hareket türüne göre filtreleme (giriş, çıkış, transfer)
- Tutar aralığına göre filtreleme
- İlişkili işleme göre filtreleme (fatura, ödeme, tahsilat)
- Açıklamaya göre arama
- Hareket detaylarını görüntüleme

#### Hesaplar Arası Transfer
- İç transfer işlemleri
- Farklı para birimleri arası transfer
- Döviz kuru belirleme
- Transfer tarihi ve açıklaması
- Transfer onay mekanizması
- Transfer geçmişi görüntüleme

### Banka İşlemleri

#### Banka Hareketleri
- Para yatırma işlemi
- Para çekme işlemi
- Otomatik ödeme/tahsilat kaydı
- Banka masrafları kaydı
- Faiz geliri kaydı
- Kredi kartı işlemleri
- Çek/senet işlemleri

#### Banka İşlem Kategorileri
- Standart kategori tanımları
- Özel kategori ekleme
- Kategori bazlı raporlama
- Kategori bazlı bütçe takibi
- Gelir/gider kategorileri

#### Banka Hesap Ekstresi
- Belirli dönem için ekstre oluşturma
- Ekstre yazdırma
- PDF olarak kaydetme
- E-posta ile gönderme
- Ekstre karşılaştırma
- Ekstre içe aktarma

#### Otomatik Banka Mutabakatı
- Banka ekstresi içe aktarma (CSV, OFX, MT940)
- Otomatik eşleştirme
- Eşleşmeyen işlemleri belirleme
- Manuel eşleştirme
- Mutabakat raporu oluşturma
- Periyodik mutabakat kontrolü

### Kredi Kartı Yönetimi

#### Kredi Kartı Hesapları
- Kredi kartı hesabı tanımlama
- Kart limiti ve kullanılabilir limit takibi
- Hesap kesim tarihi ve son ödeme tarihi
- Minimum ödeme tutarı
- Faiz oranı
- Kart sahibi bilgileri

#### Kredi Kartı İşlemleri
- Satış işlemleri
- Taksitli satış işlemleri
- İade işlemleri
- Komisyon takibi
- POS cihazı tanımlama
- Banka komisyon oranları

#### Kredi Kartı Ekstresi
- Dönemsel ekstre görüntüleme
- Taksit planı takibi
- Ödeme planı oluşturma
- Ekstre karşılaştırma
- Ekstre içe aktarma

### Kredi Yönetimi

#### Kredi Hesapları
- Kredi hesabı tanımlama
- Kredi türü (işletme, taşıt, gayrimenkul vb.)
- Kredi tutarı ve para birimi
- Faiz oranı
- Vade ve ödeme planı
- Teminat bilgileri

#### Kredi Taksitleri
- Taksit planı oluşturma
- Taksit ödeme takibi
- Erken ödeme hesaplama
- Gecikme faizi hesaplama
- Kalan anapara takibi
- Ödenen faiz takibi

## Teknik Uygulama

### Veritabanı Tabloları

#### BankAccounts Tablosu
```
Id (PK)
AccountName
BankId (FK)
BranchName
BranchCode
AccountNumber
IBAN
SwiftCode
AccountType (Checking/Savings/CreditCard/Loan)
CurrencyId (FK)
OpeningBalance
CurrentBalance
MinimumBalance
AccountLimit
IsActive
OpeningDate
ContactPerson
ContactPhone
ContactEmail
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### Banks Tablosu
```
Id (PK)
Name
Code
Logo
Country
Website
IsActive
CreatedAt
UpdatedAt
```

#### BankTransactions Tablosu
```
Id (PK)
BankAccountId (FK)
TransactionDate
ValueDate
TransactionType (Deposit/Withdrawal/Transfer/BankFee/Interest)
Amount
RunningBalance
ReferenceNumber
Description
CategoryId (FK)
RelatedEntityType (Invoice/Payment/Transfer)
RelatedEntityId
IsReconciled
ReconciledDate
ReconciledBy
CreatedBy
CreatedAt
UpdatedAt
```

#### BankTransfers Tablosu
```
Id (PK)
TransferNumber
SourceAccountId (FK)
DestinationAccountId (FK)
Amount
SourceCurrencyId (FK)
DestinationCurrencyId (FK)
ExchangeRate
TransferDate
Description
Status (Draft/Completed/Cancelled)
CreatedBy
CreatedAt
UpdatedAt
CompletedBy
CompletedAt
CancelledBy
CancelledAt
CancellationReason
```

#### TransactionCategories Tablosu
```
Id (PK)
Name
Type (Income/Expense/Transfer)
ParentCategoryId (FK, self-referencing)
Description
IsActive
CreatedAt
UpdatedAt
```

#### CreditCards Tablosu
```
Id (PK)
BankAccountId (FK)
CardNumber
CardHolderName
ExpiryMonth
ExpiryYear
CardLimit
StatementDay
DueDay
MinimumPaymentPercentage
InterestRate
IsActive
Notes
CreatedAt
UpdatedAt
```

#### CreditCardTransactions Tablosu
```
Id (PK)
CreditCardId (FK)
TransactionDate
Amount
Description
NumberOfInstallments
CategoryId (FK)
RelatedEntityType
RelatedEntityId
IsReconciled
CreatedBy
CreatedAt
UpdatedAt
```

#### Loans Tablosu
```
Id (PK)
BankAccountId (FK)
LoanNumber
LoanType
Amount
CurrencyId (FK)
InterestRate
InterestType (Fixed/Variable)
StartDate
EndDate
Term
TermUnit (Month/Year)
PaymentFrequency (Monthly/Quarterly/Yearly)
TotalInstallments
RemainingInstallments
NextInstallmentDate
NextInstallmentAmount
TotalPaid
RemainingAmount
Notes
IsActive
CreatedBy
CreatedAt
UpdatedAt
```

#### LoanInstallments Tablosu
```
Id (PK)
LoanId (FK)
InstallmentNumber
DueDate
TotalAmount
PrincipalAmount
InterestAmount
IsPaid
PaidDate
PaidAmount
Notes
CreatedBy
CreatedAt
UpdatedAt
```

#### BankStatements Tablosu
```
Id (PK)
BankAccountId (FK)
StatementDate
StartDate
EndDate
StartBalance
EndBalance
FilePath
ImportedBy
ImportedAt
Notes
```

#### BankStatementEntries Tablosu
```
Id (PK)
BankStatementId (FK)
TransactionDate
ValueDate
Description
Amount
Balance
ReferenceNumber
IsMatched
MatchedTransactionId (FK)
CreatedAt
```

### İlişkiler

- Bir banka birden fazla hesaba sahip olabilir
- Bir hesap birden fazla işleme sahip olabilir
- Bir transfer iki hesap arasında gerçekleşir
- Bir işlem bir kategoriye ait olabilir
- Bir kredi kartı bir banka hesabına bağlıdır
- Bir kredi bir banka hesabına bağlıdır
- Bir kredi birden fazla taksite sahip olabilir
- Bir banka ekstresi bir hesaba ait olabilir
- Bir banka ekstresi birden fazla kayıt içerebilir

## Kullanıcı Arayüzü

### Ekranlar

1. **Banka Hesapları Listesi Ekranı**
   - Filtrelenebilir ve sıralanabilir hesap tablosu
   - Hesap türü filtresi
   - Banka filtresi
   - Para birimi filtresi
   - Durum filtresi (aktif/pasif)
   - Bakiye özeti
   - Yeni hesap ekleme butonu

2. **Hesap Detay/Düzenleme Ekranı**
   - Hesap bilgileri formu
   - Bakiye bilgileri
   - Son işlemler listesi
   - Hesap istatistikleri
   - Kaydet/İptal butonları
   - Silme/Pasif yapma seçenekleri

3. **Hesap Hareketleri Ekranı**
   - Filtrelenebilir işlem tablosu
   - Tarih aralığı seçimi
   - İşlem türü filtresi
   - Tutar aralığı filtresi
   - İşlem detayı görüntüleme
   - Yeni işlem ekleme butonu
   - Dışa aktarma seçenekleri

4. **Hesap Transfer Ekranı**
   - Kaynak hesap seçimi
   - Hedef hesap seçimi
   - Transfer tutarı ve tarihi
   - Döviz kuru (farklı para birimleri için)
   - Transfer açıklaması
   - Kaydet/İptal butonları

5. **Banka İşlemi Ekleme Ekranı**
   - Hesap seçimi
   - İşlem türü seçimi
   - Tutar ve tarih girişi
   - Kategori seçimi
   - İlişkili işlem seçimi
   - İşlem açıklaması
   - Kaydet/İptal butonları

6. **Banka Mutabakat Ekranı**
   - Hesap seçimi
   - Dönem seçimi
   - Ekstre yükleme alanı
   - Otomatik eşleştirme butonu
   - Eşleşmeyen işlemler listesi
   - Manuel eşleştirme alanı
   - Mutabakat raporu oluşturma

7. **Kredi Kartı Yönetim Ekranı**
   - Kredi kartı listesi
   - Kart detayları
   - Limit ve kullanım bilgileri
   - Taksitli işlemler listesi
   - Ekstre görüntüleme
   - Ödeme planı

8. **Kredi Yönetim Ekranı**
   - Kredi listesi
   - Kredi detayları
   - Taksit planı
   - Ödeme geçmişi
   - Kalan borç bilgisi
   - Erken ödeme hesaplama

## Özellikler ve İşlevler

- Banka hesap verilerinin Excel/CSV formatında içe/dışa aktarımı
- Banka ekstresi içe aktarma ve otomatik eşleştirme
- Çoklu para birimi desteği ve döviz kuru yönetimi
- Hesaplar arası transfer ve döviz çevirme
- Tekrarlayan banka işlemleri tanımlama
- Banka hesap mutabakatı
- Kredi kartı ve kredi takibi
- Banka işlem kategorilendirme
- Banka hesap raporları ve analizleri
- Nakit akış projeksiyonu

## Test Planı

- Birim testleri
- Entegrasyon testleri
- Kullanıcı arayüzü testleri
- Bakiye hesaplama testleri
- Döviz çevirme testleri
- Ekstre içe aktarma testleri
- Mutabakat testleri
- Performans testleri

## Açık Sorular

1. Banka API entegrasyonu ilk sürümde yer almalı mı?
2. Otomatik banka mutabakatı için hangi dosya formatları desteklenmeli?
3. Kredi modülü ne kadar detaylı olmalı?
4. Çek/senet modülü ile banka hesapları modülü nasıl entegre edilmeli?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari
- RFC-006: Ödeme ve Tahsilat Yönetimi 