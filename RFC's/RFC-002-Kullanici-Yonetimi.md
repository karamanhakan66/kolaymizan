# RFC-002: Kullanıcı Yönetimi

## Özet

Bu RFC, Kolay Mizan ön muhasebe programının kullanıcı yönetimi modülünü tanımlamaktadır. Kullanıcı kaydı, kimlik doğrulama, yetkilendirme ve kullanıcı profil yönetimi gibi temel özellikleri içermektedir.

## Motivasyon

Güvenli ve esnek bir kullanıcı yönetim sistemi, ön muhasebe programının temel yapı taşlarından biridir. Farklı yetki seviyelerine sahip kullanıcıların sisteme güvenli erişimi ve işlem yapabilmesi için kapsamlı bir kullanıcı yönetim modülü gereklidir.

## Detaylı Tasarım

### Temel Kullanıcı İşlemleri

#### Kullanıcı Kaydı ve E-posta Doğrulama
- Kullanıcı adı, e-posta, şifre ve temel bilgiler ile kayıt
- E-posta doğrulama süreci
- Kayıt formunda CAPTCHA koruması
- İlk kayıt sonrası varsayılan rol atama

#### Kullanıcı Girişi ve Oturum Yönetimi
- E-posta/kullanıcı adı ve şifre ile giriş
- Oturum süre yönetimi
- "Beni hatırla" seçeneği
- Çoklu cihaz oturum yönetimi
- Oturum güvenliği (IP kontrolü, şüpheli giriş tespiti)

#### Şifre Sıfırlama ve Değiştirme
- E-posta üzerinden şifre sıfırlama
- Güvenli şifre değiştirme mekanizması
- Şifre politikası uygulama (minimum uzunluk, karmaşıklık)
- Şifre geçmişi kontrolü

### Yetkilendirme

#### Rol Tabanlı Yetkilendirme Sistemi
- Önceden tanımlanmış roller:
  - **Yönetici (Admin)**: Tüm sistem üzerinde tam yetki
  - **Muhasebeci**: Finansal işlemler üzerinde yetki
  - **Görüntüleyici**: Sadece görüntüleme yetkisi
- Rol atama ve değiştirme
- Rol bazlı menü ve sayfa erişimi

#### Özel İzin Tanımlama
- Granüler izin sistemi
- Belirli modüller için özel izinler tanımlama
- İzin grupları oluşturma
- Kullanıcı bazlı özel izin atamaları

#### Kullanıcı Eylemleri için Detaylı Aktivite Günlüğü
- Kullanıcı giriş/çıkış kayıtları
- Kritik işlem logları (silme, güncelleme, yetki değişikliği)
- Log filtreleme ve arama
- Log raporları oluşturma

### Kullanıcı Profil Yönetimi

- Profil bilgilerini güncelleme
- Profil fotoğrafı yükleme
- İletişim bilgilerini yönetme
- Bildirim tercihlerini ayarlama
- İki faktörlü kimlik doğrulama (2FA) desteği (gelecek sürüm)

## Teknik Uygulama

### Veritabanı Tabloları

#### Users Tablosu
```
Id (PK)
UserName
Email
PasswordHash
PhoneNumber
FirstName
LastName
ProfilePicture
IsActive
CreatedAt
UpdatedAt
LastLoginAt
```

#### Roles Tablosu
```
Id (PK)
Name
Description
CreatedAt
UpdatedAt
```

#### UserRoles Tablosu
```
Id (PK)
UserId (FK)
RoleId (FK)
AssignedAt
AssignedBy
```

#### Permissions Tablosu
```
Id (PK)
Name
Description
Module
Action
```

#### RolePermissions Tablosu
```
Id (PK)
RoleId (FK)
PermissionId (FK)
```

#### UserPermissions Tablosu
```
Id (PK)
UserId (FK)
PermissionId (FK)
Granted
```

#### UserActivityLogs Tablosu
```
Id (PK)
UserId (FK)
Action
Description
IPAddress
UserAgent
CreatedAt
```

### Teknoloji ve Kütüphaneler

- ASP.NET Core Identity
- JWT (JSON Web Tokens) kimlik doğrulama
- SendGrid veya SMTP e-posta gönderimi
- reCAPTCHA entegrasyonu

## Kullanıcı Arayüzü

### Ekranlar

1. **Giriş Ekranı**
   - Kullanıcı adı/e-posta ve şifre alanları
   - "Beni hatırla" seçeneği
   - Şifremi unuttum bağlantısı

2. **Kayıt Ekranı**
   - Temel kullanıcı bilgileri formu
   - CAPTCHA doğrulama
   - Kullanım şartları onayı

3. **Şifre Sıfırlama Ekranı**
   - E-posta giriş formu
   - Yeni şifre belirleme formu

4. **Kullanıcı Profil Ekranı**
   - Kişisel bilgiler
   - Şifre değiştirme
   - Profil fotoğrafı yönetimi

5. **Kullanıcı Yönetim Ekranı (Admin)**
   - Kullanıcı listesi
   - Kullanıcı ekleme/düzenleme/silme
   - Rol atama
   - İzin yönetimi

6. **Aktivite Günlüğü Ekranı**
   - Filtrelenebilir log listesi
   - Detaylı log görüntüleme

## Güvenlik Önlemleri

- Şifrelerin hash'lenerek saklanması
- Brute force saldırılarına karşı giriş denemesi sınırlaması
- CSRF token kullanımı
- XSS koruması
- Hassas verilerin şifrelenmesi
- Güvenli oturum yönetimi
- IP bazlı şüpheli aktivite tespiti

## Test Planı

- Birim testleri (Unit Tests)
- Entegrasyon testleri
- Güvenlik testleri (penetrasyon testi)
- Kullanıcı arayüzü testleri
- Performans testleri

## Açık Sorular

1. İki faktörlü kimlik doğrulama (2FA) ilk sürümde yer almalı mı?
2. Sosyal medya hesapları ile giriş (OAuth) desteklenmeli mi?
3. Kullanıcı hesap kilitleme politikası nasıl olmalı?

## Referanslar

- PRD.md
- FEATURES.md
- RFC-001: Proje Genel Bakış ve Mimari 