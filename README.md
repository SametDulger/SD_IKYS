# SD IKYS - İnsan Kaynakları Yönetim Sistemi

Bu proje, modern .NET 9.0 teknolojileri kullanılarak geliştirilmiş kapsamlı bir İnsan Kaynakları Yönetim Sistemidir.

## 🚀 Özellikler

### 👥 Kullanıcı Yönetimi
- Kullanıcı kayıt ve giriş sistemi
- Rol tabanlı yetkilendirme (Admin, Manager, Employee, HR)
- Kullanıcı profil yönetimi

### 👨‍💼 Personel Yönetimi
- Personel kayıt ve bilgi yönetimi
- Departman ve pozisyon takibi
- Maaş bilgileri
- Hiyerarşik yapı (Yönetici-Çalışan ilişkisi)

### 📅 İzin Yönetimi
- İzin talep sistemi
- Onay süreçleri
- İzin geçmişi takibi
- Farklı izin türleri

### 📊 Performans Değerlendirme
- Çalışan performans değerlendirmeleri
- Kriter bazlı puanlama
- Hedef belirleme ve takip
- Raporlama

### 🎓 Eğitim Yönetimi
- Eğitim programları
- Katılımcı yönetimi
- Sertifika takibi
- Eğitim sonuçları

## 🏗️ Mimari

Proje Clean Architecture prensiplerine uygun olarak geliştirilmiştir:

```
SD_IKYS/
├── SD_IKYS.Core/          # Domain entities, interfaces, DTOs
├── SD_IKYS.Data/          # Data access layer, repositories
├── SD_IKYS.Business/      # Business logic, services
├── SD_IKYS.API/           # REST API
└── SD_IKYS.Web/           # Web UI (MVC)
```

### Teknolojiler

- **Backend**: .NET 9.0, Entity Framework Core
- **Database**: SQL Server
- **API**: ASP.NET Core Web API
- **Frontend**: ASP.NET Core MVC, Bootstrap 5
- **Authentication**: Session-based
- **Architecture**: Clean Architecture, Repository Pattern

## 🛠️ Kurulum

### Gereksinimler

- .NET 9.0 SDK
- SQL Server (Express veya üzeri)
- Visual Studio 2022 veya VS Code

### Adımlar

1. **Repository'yi klonlayın**
   ```bash
   git clone https://github.com/your-username/SD_IKYS.git
   cd SD_IKYS
   ```

2. **Veritabanı bağlantısını yapılandırın**
   
   `SD_IKYS.API/appsettings.json` ve `SD_IKYS.Web/appsettings.json` dosyalarında connection string'i güncelleyin:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=SD_IKYS_DB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
   }
   ```

3. **Migration'ları çalıştırın**
   ```bash
   cd SD_IKYS.API
   dotnet ef database update
   ```

4. **Projeyi çalıştırın**
   
   **API için:**
   ```bash
   dotnet run --project SD_IKYS.API
   ```
   
   **Web UI için:**
   ```bash
   dotnet run --project SD_IKYS.Web
   ```

## 🔐 Varsayılan Kullanıcılar

Sistem ilk çalıştırıldığında aşağıdaki kullanıcılar otomatik olarak oluşturulur:

| Kullanıcı Adı | Şifre | Rol | Açıklama |
|---------------|-------|-----|----------|
| admin | 123456 | Admin | Sistem yöneticisi |
| manager | 123456 | Manager | Yönetici |
| employee | 123456 | Employee | Çalışan |

## 📋 API Endpoints

### Kullanıcılar
- `GET /api/users` - Tüm kullanıcıları listele
- `GET /api/users/{id}` - Kullanıcı detayı
- `POST /api/users` - Yeni kullanıcı oluştur
- `PUT /api/users/{id}` - Kullanıcı güncelle
- `DELETE /api/users/{id}` - Kullanıcı sil
- `POST /api/users/login` - Giriş yap

### Roller
- `GET /api/roles` - Tüm rolleri listele
- `GET /api/roles/{id}` - Rol detayı
- `POST /api/roles` - Yeni rol oluştur
- `PUT /api/roles/{id}` - Rol güncelle
- `DELETE /api/roles/{id}` - Rol sil

### Çalışanlar
- `GET /api/employees` - Tüm çalışanları listele
- `GET /api/employees/{id}` - Çalışan detayı
- `POST /api/employees` - Yeni çalışan oluştur
- `PUT /api/employees/{id}` - Çalışan güncelle
- `DELETE /api/employees/{id}` - Çalışan sil

### İzin Talepleri
- `GET /api/leaverequests` - Tüm izin taleplerini listele
- `GET /api/leaverequests/{id}` - İzin talebi detayı
- `POST /api/leaverequests` - Yeni izin talebi oluştur
- `PUT /api/leaverequests/{id}` - İzin talebi güncelle
- `DELETE /api/leaverequests/{id}` - İzin talebi sil

### Performans Değerlendirmeleri
- `GET /api/performanceevaluations` - Tüm değerlendirmeleri listele
- `GET /api/performanceevaluations/{id}` - Değerlendirme detayı
- `POST /api/performanceevaluations` - Yeni değerlendirme oluştur
- `PUT /api/performanceevaluations/{id}` - Değerlendirme güncelle
- `DELETE /api/performanceevaluations/{id}` - Değerlendirme sil

### Eğitimler
- `GET /api/trainings` - Tüm eğitimleri listele
- `GET /api/trainings/{id}` - Eğitim detayı
- `POST /api/trainings` - Yeni eğitim oluştur
- `PUT /api/trainings/{id}` - Eğitim güncelle
- `DELETE /api/trainings/{id}` - Eğitim sil

### Eğitim Katılımcıları
- `GET /api/trainingparticipants` - Tüm katılımcıları listele
- `GET /api/trainingparticipants/{id}` - Katılımcı detayı
- `POST /api/trainingparticipants` - Yeni katılımcı ekle
- `PUT /api/trainingparticipants/{id}` - Katılımcı güncelle
- `DELETE /api/trainingparticipants/{id}` - Katılımcı sil

## 🎨 Web Arayüzü

Web arayüzü aşağıdaki özellikleri içerir:

- **Responsive Design**: Bootstrap 5 ile mobil uyumlu
- **Modern UI**: Font Awesome ikonları
- **Kullanıcı Dostu**: Kolay navigasyon
- **Session Yönetimi**: Güvenli oturum yönetimi
- **Form Validasyonu**: Client-side ve server-side validasyon

## 🔧 Geliştirme

### Yeni Entity Ekleme

1. `SD_IKYS.Core/Entities/` klasöründe entity oluşturun
2. `SD_IKYS.Core/DTOs/` klasöründe DTO'ları oluşturun
3. `SD_IKYS.Core/Interfaces/` klasöründe repository interface'i oluşturun
4. `SD_IKYS.Data/Repositories/` klasöründe repository implementasyonu oluşturun
5. `SD_IKYS.Business/Interfaces/` klasöründe service interface'i oluşturun
6. `SD_IKYS.Business/Services/` klasöründe service implementasyonu oluşturun
7. `SD_IKYS.API/Controllers/` klasöründe API controller oluşturun
8. `SD_IKYS.Web/Controllers/` klasöründe MVC controller oluşturun
9. `SD_IKYS.Web/Models/` klasöründe ViewModel'leri oluşturun
10. `SD_IKYS.Web/Views/` klasöründe view'ları oluşturun

### Migration Oluşturma

```bash
cd SD_IKYS.API
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 🧪 Test

Proje şu anda test projeleri içermemektedir. Gelecek sürümlerde unit test ve integration test projeleri eklenecektir.

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit yapın (`git commit -m 'Add some AmazingFeature'`)
4. Push yapın (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📞 İletişim

Proje hakkında sorularınız için issue açabilir veya pull request gönderebilirsiniz.

## 🔄 Sürüm Geçmişi

### v1.0.0 (2025-01-16)
- İlk sürüm
- Temel CRUD işlemleri
- Kullanıcı yönetimi
- Personel yönetimi
- İzin yönetimi
- Performans değerlendirme
- Eğitim yönetimi
- Web arayüzü
- REST API

## 🚧 Bilinen Sorunlar

- Unit testler henüz yazılmamış
- Logging sistemi henüz implement edilmemiş
- Caching mekanizması henüz eklenmemiş
- Role-based authorization henüz tam implement edilmemiş

## 🔮 Gelecek Planları

- [x] JWT Authentication
- [x] Şifre hash'leme
- [ ] Unit testler
- [ ] Integration testler
- [ ] Logging sistemi
- [ ] Caching mekanizması
- [ ] Role-based authorization
- [ ] Email bildirimleri
- [ ] Raporlama sistemi
- [ ] Dashboard
- [ ] Mobile app
- [ ] Docker support
- [ ] CI/CD pipeline

