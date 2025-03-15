# Ön Muhasebe Programı - Özellikler (FEATURES.md)

Bu belge, .NET Core MVC ve Entity Framework Core kullanılarak geliştirilecek ön muhasebe programının özelliklerini detaylı olarak tanımlamaktadır.

## Kullanıcı Yönetimi

### Temel Kullanıcı İşlemleri
- ✅ Kullanıcı kaydı ve e-posta doğrulama
- ✅ Kullanıcı girişi ve oturum yönetimi
- ✅ Şifre sıfırlama ve değiştirme

### Yetkilendirme
- ✅ Rol tabanlı yetkilendirme sistemi
- ✅ Önceden tanımlanmış roller (Yönetici, Muhasebeci, Görüntüleyici)
- ✅ Özel izin tanımlama
- ✅ Kullanıcı eylemleri için detaylı aktivite günlüğü

## Müşteri/Tedarikçi Yönetimi

### Müşteri Yönetimi
- ✅ Müşteri ekleme, düzenleme ve silme
- ✅ Müşteri bilgileri (Ad, Vergi No, Adres, Telefon, E-posta)
- ✅ Müşteri kategorileri
- ✅ Müşteri cari hesap görüntüleme
- ✅ Müşteri bazlı işlem geçmişi

### Tedarikçi Yönetimi
- ✅ Tedarikçi ekleme, düzenleme ve silme
- ✅ Tedarikçi bilgileri (Ad, Vergi No, Adres, Telefon, E-posta)
- ✅ Tedarikçi kategorileri
- ✅ Tedarikçi cari hesap görüntüleme
- ✅ Tedarikçi bazlı işlem geçmişi

## Ürün/Hizmet Kataloğu

### Ürün Yönetimi
- ✅ Ürün ekleme, düzenleme ve silme
- ✅ Ürün bilgileri (Ad, Kod, Barkod, Fiyat, KDV oranı)
- ✅ Ürün kategorileri ve alt kategoriler
- ✅ Ürün görselleri
- ✅ Minimum stok seviyesi belirleme
- ✅ Birim tanımlama (adet, kg, lt vb.)

### Stok Yönetimi
- ✅ Stok giriş ve çıkış takibi
- ✅ Stok sayım işlemleri
- ✅ Stok transferi
- ✅ Stok alarm sistemi (düşük stok bildirimi)
- ✅ Stok hareket raporu

### Hizmet Yönetimi
- ✅ Hizmet ekleme, düzenleme ve silme
- ✅ Hizmet bilgileri (Ad, Kod, Fiyat, KDV oranı)
- ✅ Hizmet kategorileri

## Fatura Yönetimi

### Fatura İşlemleri
- ✅ Satış faturası oluşturma
- ✅ Alış faturası oluşturma
- ✅ Proforma fatura oluşturma
- ✅ İade faturası oluşturma
- ✅ Fatura düzenleme ve iptal etme
- ✅ Fatura kopyalama ve tekrarlama

### Fatura Özellikleri
- ✅ Fatura numarası otomatik oluşturma
- ✅ Çoklu vergi oranı desteği
- ✅ İskonto ve ek ücret ekleme
- ✅ Ödeme şartları ve vadeler
- ✅ Döviz desteği
- ✅ Tahsilat ve ödeme durumu izleme
- ✅ Fatura notları ve şartları

### Fatura Çıktıları
- ✅ PDF formatında fatura oluşturma
- ✅ Fatura e-posta ile gönderme
- ✅ Özelleştirilebilir fatura şablonları
- ✅ Toplu fatura yazdırma

## Ödeme ve Tahsilat Yönetimi

### Tahsilat İşlemleri
- ✅ Müşterilerden tahsilat kaydetme
- ✅ Kısmi tahsilat desteği
- ✅ Farklı ödeme yöntemleri (Nakit, Kredi Kartı, EFT/Havale)
- ✅ Çek ve senet takibi
- ✅ Tahsilat makbuzu oluşturma

### Ödeme İşlemleri
- ✅ Tedarikçilere ödeme kaydetme
- ✅ Kısmi ödeme desteği
- ✅ Farklı ödeme yöntemleri (Nakit, Kredi Kartı, EFT/Havale)
- ✅ Ödeme makbuzu oluşturma
- ✅ Periyodik ödeme planları

### Vade Takibi
- ✅ Vadesi gelen alacaklar bildirimi
- ✅ Vadesi gelen borçlar bildirimi
- ✅ Vade takvimi görüntüleme
- ✅ Erken ödeme/tahsilat yönetimi

## Banka Hesapları Yönetimi

### Hesap İşlemleri
- ✅ Banka hesabı ekleme, düzenleme ve silme
- ✅ Hesap detayları (Banka, Şube, IBAN, Hesap No)
- ✅ Hesap bakiyesi takibi
- ✅ Hesap hareketleri listeleme
- ✅ Hesaplar arası transfer

### Banka İşlemleri
- ✅ Banka hareketleri (yatırma, çekme)
- ✅ Banka işlem kategorileri
- ✅ Banka hesap ekstresi
- ✅ Otomatik banka mutabakatı

## Gider Yönetimi

### Gider İşlemleri
- ✅ Gider ekleme, düzenleme ve silme
- ✅ Gider kategorileri tanımlama
- ✅ Gider bilgileri (Tutar, Tarih, Açıklama, Kategori)
- ✅ Faturalandırılabilir giderler
- ✅ Tekrarlayan giderler

### Gider Takibi
- ✅ Kategori bazlı gider takibi
- ✅ Gider onay süreci
- ✅ Gider raporu oluşturma
- ✅ Gider analizi

## Raporlama Sistemi

### Finansal Raporlar
- ✅ Gelir-gider raporu
- ✅ Kar/zarar analizi
- ✅ Nakit akış raporu
- ✅ Aylık/yıllık satış raporu
- ✅ KDV raporu
- ✅ Tahsilat/ödeme raporu

### Müşteri/Tedarikçi Raporları
- ✅ Müşteri bazlı satış raporu
- ✅ Tedarikçi bazlı alım raporu
- ✅ Müşteri/tedarikçi mutabakat raporu
- ✅ Vadesi geçmiş alacaklar raporu
- ✅ Vadesi geçmiş borçlar raporu

### Stok Raporları
- ✅ Stok durum raporu
- ✅ En çok/en az satılan ürünler
- ✅ Stok hareket raporu
- ✅ Stok değer raporu

### Rapor Özellikleri
- ✅ Excel ve PDF formatında dışa aktarma
- ✅ Grafikler ve görseller ile zenginleştirilmiş raporlar
- ✅ Özelleştirilebilir rapor şablonları
- ✅ Otomatik rapor planlama ve gönderme

## Dashboard

### Genel Bakış
- ✅ Günlük gelir-gider özeti
- ✅ Açık faturalar ve toplam tutar
- ✅ Vadesi yaklaşan alacak ve borçlar
- ✅ Kasa ve banka hesap bakiyeleri
- ✅ Stoğu azalan ürünler

### Görselleştirme
- ✅ Aylık gelir-gider grafiği
- ✅ En çok satılan ürünler grafiği
- ✅ Müşteri bazlı satış grafiği
- ✅ Kategori bazlı satış grafiği
- ✅ Yıllık trend analizi

### Kişiselleştirme
- ✅ Özelleştirilebilir widget'lar
- ✅ Widget boyutlandırma ve yerleştirme
- ✅ Kişiye özel dashboard konfigürasyonu
- ✅ Hızlı erişim menüsü

## Sistem Yönetimi

### Yapılandırma
- ✅ Şirket bilgileri ayarları
- ✅ Para birimi ve vergi ayarları
- ✅ Fatura numaralandırma formatı
- ✅ E-posta şablonları
- ✅ Bildirim ayarları

### Güvenlik
- ✅ Rol ve izin yönetimi
- ✅ Kullanıcı işlem günlüğü
- ✅ Oturum yönetimi
- ✅ Yedekleme ve geri yükleme
- ✅ Veri silme ve anonimleştirme

### Entegrasyonlar
- ✅ E-posta entegrasyonu
- ✅ Barkod okuyucu desteği
- ✅ Döviz kuru API entegrasyonu
- ✅ Yedekleme hizmetleri ile entegrasyon
- ✅ Webhook desteği (gelecek sürümde)

## Ek Özellikler

### Kullanıcı Deneyimi
- ✅ Koyu/açık tema seçeneği
- ✅ Mobil uyumlu arayüz
- ✅ Kısayol tuşları
- ✅ Sürükle-bırak işlemleri
- ✅ Gelişmiş arama ve filtreleme

### Performans
- ✅ Önbellek mekanizmaları
- ✅ Toplu işlem yapabilme
- ✅ Veritabanı optimizasyonu
- ✅ Asenkron işlemler
- ✅ Sayfalama ve lazy loading

### İletişim
- ✅ Dahili mesajlaşma sistemi
- ✅ Hatırlatıcılar ve bildirimler
- ✅ Görev atama ve takibi
- ✅ Ekip üyeleri arasında not paylaşımı

## Gelecek Sürüm Özellikleri

### V2 Planı
- 🔄 E-fatura entegrasyonu
- 🔄 Mobil uygulama
- 🔄 Çoklu dil desteği
- 🔄 API desteği
- 🔄 Gelişmiş analitik
- 🔄 Takvim ve hatırlatıcı özellikleri
- 🔄 SMS bildirim entegrasyonu
- 🔄 QR kod desteği
- 🔄 E-arşiv fatura desteği
- 🔄 Çoklu şube yönetimi
