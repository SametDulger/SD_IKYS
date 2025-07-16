# SD IKYS - İnsan Kaynakları Yönetim Sistemi

## ⚠️ Geliştirme Aşamasında

**Bu proje aktif geliştirme aşamasındadır ve henüz production ortamı için hazır değildir.**

### Önemli Notlar

- **Geliştirme Durumu**: Proje şu anda beta aşamasındadır
- **Eksik Özellikler**: Bazı modüller henüz tamamlanmamış olabilir
- **Hata Riski**: Geliştirme sürecinde beklenmeyen hatalar oluşabilir
- **API Değişiklikleri**: API endpoint'leri geliştirme sürecinde değişebilir
- **Veritabanı Şeması**: Migration'lar güncellenebilir

### Öneriler

- Sadece geliştirme ve test ortamlarında kullanın
- Production verilerinizi bu sistemle test etmeyin
- Düzenli olarak güncellemeleri kontrol edin
- Sorun yaşarsanız GitHub Issues üzerinden bildirin

---

## Genel Bakış

SD IKYS, modern kurumsal ihtiyaçlar için geliştirilmiş kapsamlı bir İnsan Kaynakları Yönetim Sistemidir. SOLID prensiplerine uygun, çok katmanlı mimari ile tasarlanmış bu sistem, personel yönetiminden performans değerlendirmesine kadar tüm HR süreçlerini dijitalleştirir.

### Temel Avantajlar

- **Çok Katmanlı Mimari**: SOLID prensiplerine uygun, sürdürülebilir kod yapısı
- **RESTful API**: Modern web standartlarına uygun API tasarımı
- **Responsive UI**: Bootstrap ile mobil uyumlu arayüz
- **Otomatik Migration**: Veritabanı şeması otomatik güncelleme
- **Swagger Desteği**: API dokümantasyonu ve test arayüzü

## Özellikler

### Personel Yönetimi
- Personel kayıt ve profil yönetimi
- TCKN bazlı benzersiz kimlik doğrulama
- Departman ve pozisyon yönetimi
- Yöneticilik hiyerarşisi
- Aktif/pasif personel durumu
- Departmana göre filtreleme

### İzin Yönetimi
- İzin talebi oluşturma ve takip
- Onaylama/reddetme süreci
- İzin türü kategorileri (Yıllık, Hastalık, Ücretsiz)
- Bekleyen izinler listesi
- Personele göre izin geçmişi
- Onay notları ve tarih takibi

### Performans Değerlendirme
- Çok kriterli performans değerlendirmesi
- Değerlendirici atama sistemi
- Dönemsel değerlendirme (Q1, Q2, Q3, Q4, Yıllık)
- Yüksek performanslı personel tespiti
- Güçlü yönler ve gelişim alanları
- Detaylı raporlama

### Eğitim Yönetimi
- Eğitim programı oluşturma
- Eğitim türü kategorileri (İç, Dış, Online)
- Eğitmen ve konum yönetimi
- Katılımcı kapasitesi kontrolü
- Aktif, tamamlanan, yaklaşan eğitimler
- Eğitmene göre filtreleme

### Eğitim Katılımcıları
- Katılımcı kayıt sistemi
- Eğitim puanlama ve sertifika
- Katılım durumu takibi
- Eğitim tamamlanma tarihi
- Personele göre eğitim geçmişi

### Kullanıcı ve Rol Yönetimi
- Kullanıcı hesap yönetimi
- Rol tabanlı yetkilendirme
- Giriş/çıkış işlemleri
- Aktif/pasif kullanıcı durumu
- Güvenli oturum yönetimi

## Mimari

```
SD_IKYS/
├── SD_IKYS.Core/           # Domain Layer
│   ├── Entities/           # Domain Models
│   ├── DTOs/              # Data Transfer Objects
│   └── Interfaces/        # Repository & Service Contracts
├── SD_IKYS.Data/          # Data Access Layer
│   ├── Repositories/      # Repository Implementations
│   ├── Migrations/        # Database Migrations
│   └── ApplicationDbContext.cs
├── SD_IKYS.Business/      # Business Logic Layer
│   ├── Services/          # Business Services
│   └── Interfaces/        # Service Contracts
├── SD_IKYS.API/           # API Layer
│   └── Controllers/       # REST API Controllers
└── SD_IKYS.Web/           # Presentation Layer
    ├── Controllers/       # MVC Controllers
    ├── Views/            # Razor Views
    ├── Models/           # View Models
    └── Services/         # API Communication
```

### Veri Akışı

```
Web UI → API Layer → Business Layer → Core Layer → Data Layer → Database
   ↑                                                               ↓
   └────────────────────── Response Flow ←─────────────────────────┘
```

## Teknolojiler

### Backend
- **.NET 9.0** - Modern .NET platformu
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core 9.0.7** - ORM ve veritabanı erişimi
- **SQL Server** - İlişkisel veritabanı
- **Swagger/OpenAPI 9.0.3** - API dokümantasyonu

### Frontend
- **ASP.NET Core MVC** - Web framework
- **Razor Views** - View engine
- **Bootstrap 5.3.3** - CSS framework
- **jQuery 3.7.1** - JavaScript library
- **Font Awesome 6.0.0** - Icon library

### Diğer
- **CORS** - Cross-origin resource sharing
- **Session Management** - Kullanıcı oturum yönetimi
- **Dependency Injection** - IoC container
- **Repository Pattern** - Veri erişim deseni
- **Unit of Work** - Transaction yönetimi

## Kurulum

### Gereksinimler

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [VS Code](https://code.visualstudio.com/)

### Adım 1: Projeyi İndirin

```bash
git clone https://github.com/SametDulger/SD_IKYS.git
cd SD_IKYS
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın

`SD_IKYS.API/appsettings.json` dosyasını düzenleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SD_IKYS;Trusted_Connection=true;TrustServerCertificate=True;"
  }
}
```

### Adım 3: Migration Oluşturun ve Veritabanını Güncelleyin

```bash
cd SD_IKYS.API

# İlk migration oluşturun (eğer yoksa)
dotnet ef migrations add InitialCreate

# Veritabanını güncelleyin
dotnet ef database update
```

### Adım 4: Projeyi Çalıştırın

**API Projesi:**
```bash
cd SD_IKYS.API
dotnet run
```
API varsayılan olarak `http://localhost:5214` adresinde çalışır.

**Web Projesi:**
```bash
cd SD_IKYS.Web
dotnet run
```
Web arayüzü varsayılan olarak `http://localhost:5283` adresinde çalışır.

## Kullanım

### İlk Giriş

1. Web arayüzüne gidin: `http://localhost:5283`
2. **Roller** menüsünden yeni rol oluşturun
3. **Kullanıcılar** menüsünden ilk kullanıcıyı oluşturun
4. Oluşturduğunuz kullanıcı ile giriş yapın

### Ana Dashboard

Dashboard'da şu bilgiler görüntülenir:
- Toplam ve aktif personel sayısı
- Bekleyen izin talepleri
- Aktif eğitimler
- Son performans değerlendirmeleri

### Hızlı İşlemler

Dashboard'dan hızlıca erişebileceğiniz işlemler:
- Yeni personel ekleme
- İzin talebi oluşturma
- Performans değerlendirmesi
- Yeni eğitim oluşturma

## API Dokümantasyonu

### Swagger UI

API dokümantasyonuna erişmek için:
```
http://localhost:5214/swagger
```

### Temel Endpoint'ler

| Modül | Endpoint | Açıklama |
|-------|----------|----------|
| Personel | `GET /api/employees` | Tüm personeli listele |
| İzin | `GET /api/leaverequests` | İzin taleplerini listele |
| Performans | `GET /api/performanceevaluations` | Değerlendirmeleri listele |
| Eğitim | `GET /api/trainings` | Eğitimleri listele |
| Kullanıcı | `GET /api/users` | Kullanıcıları listele |

### Örnek API Kullanımı

```bash
# Personel listesi
curl -X GET "http://localhost:5214/api/employees"

# Yeni personel ekleme
curl -X POST "http://localhost:5214/api/employees" \
  -H "Content-Type: application/json" \
  -d '{"firstName":"Ahmet","lastName":"Yılmaz","tckn":"12345678901"}'
```

## Geliştirme

### Proje Yapısı

```bash
# Solution'ı açın
dotnet sln SD_IKYS.sln

# Tüm projeleri derleyin
dotnet build
```

### Migration İşlemleri

#### İlk Migration Oluşturma
```bash
cd SD_IKYS.API
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Yeni Migration Oluşturma
```bash
cd SD_IKYS.API
dotnet ef migrations add MigrationName
dotnet ef database update
```

#### Migration'ları Listeleme
```bash
cd SD_IKYS.API
dotnet ef migrations list
```

#### Migration'ları Geri Alma
```bash
cd SD_IKYS.API
dotnet ef database update PreviousMigrationName
```

#### Migration'ları Silme
```bash
cd SD_IKYS.API
dotnet ef migrations remove
```

#### Veritabanını Sıfırlama
```bash
cd SD_IKYS.API
dotnet ef database drop --force
dotnet ef database update
```

### Kod Standartları

- **C# Coding Conventions** - Microsoft standartları
- **SOLID Principles** - Temiz kod prensipleri
- **Repository Pattern** - Veri erişim deseni
- **Dependency Injection** - Bağımlılık enjeksiyonu

## Katkı

1. Bu repository'yi fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

### Katkı Öncesi Kontrol Listesi

- [ ] Kod standartlarına uygunluk
- [ ] API dokümantasyonunun güncellenmesi
- [ ] README dosyasının güncellenmesi
- [ ] Geliştirme aşamasındaki özelliklerin belirtilmesi
- [ ] Bilinen hataların dokümante edilmesi

## Bilinen Sorunlar ve Sınırlamalar

### Mevcut Durum
- **Kullanıcı Arayüzü**: Bazı sayfalar henüz responsive tasarıma tam uyumlu değil
- **Performans**: Büyük veri setlerinde performans optimizasyonu gerekli
- **Güvenlik**: Ek güvenlik katmanları eklenmesi planlanıyor
- **Raporlama**: Detaylı raporlama modülü geliştirme aşamasında
- **Bildirimler**: Email/SMS bildirim sistemi henüz entegre edilmedi

### Gelecek Güncellemeler
- [ ] Gelişmiş arama ve filtreleme özellikleri
- [ ] Dashboard widget'ları ve grafikler
- [ ] Excel/PDF export fonksiyonları
- [ ] Çoklu dil desteği
- [ ] Mobil uygulama desteği
- [ ] Webhook entegrasyonları

---

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

