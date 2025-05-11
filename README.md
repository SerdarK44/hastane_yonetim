# 🏥 Hastane Yönetim Sistemi (WPF - Veri Yapıları)

Bu proje, bağlı liste, yığın, kuyruk ve ikili arama ağacı gibi veri yapılarını kullanarak oluşturulmuş bir WPF tabanlı hastane yönetim sistemidir. Modern arayüzü ve modüler yapısı ile hasta kayıt, muayene takibi, acil yönetimi ve raporlama işlemlerini destekler.

---

## 👤 Geliştirici

- **Ad:** Serdar Külek   
- **Teknolojiler:** C#, WPF, .NET 8.0, XAML

---

## 📌 Öne Çıkan Özellikler

- ✅ Hasta ekleme (Bağlı Liste)
- 🩺 Muayene ekleme (Stack)
- 📂 Muayene geçmişi
- 🚨 Acil hasta yönetimi (3 ayrı kuyruk: Kritik, Orta, Hafif)
- 🔍 TC ile hasta arama (BST)
- 📊 İstatistik ekranı
- 📄 Raporlama ve TXT dışa aktarma
- 🔐 Admin girişi

---

## 🔐 Giriş Bilgileri

- **Kullanıcı Adı:** `admin`  
- **Şifre:** `1234`  

Giriş ekranından bu bilgilerle sisteme erişim sağlanır.

---

## 🧠 Kullanılan Veri Yapıları

| Modül               | Veri Yapısı          |
|---------------------|-----------------------|
| Hasta Kayıt         | Linked List           |
| Muayene Geçmişi     | Stack (Yığın)         |
| Acil Hasta Sırası   | Queue (3 adet)        |
| TC ile Arama        | Binary Search Tree    |

---

## 📁 Proje Yapısı

├── App.xaml
├── MainWindow.xaml
├── Pages/
│ ├── Giris.xaml
│ ├── HastaEklePage.xaml
│ ├── MuayeneEklePage.xaml
│ ├── GecmisPage.xaml
│ ├── AcilHastaPage.xaml
│ ├── TcAramaPage.xaml
│ ├── RaporPage.xaml
│ └── HakkindaPage.xaml
├── Models/
│ ├── Hasta.cs
│ ├── Muayene.cs
│ ├── AcilHasta.cs
├── DataStructures/
│ ├── HastaLinkedList.cs
│ ├── MuayeneVeri.cs
│ ├── AcilVeri.cs
│ └── HastaAgaci.cs


---

## 🚀 Kurulum

```bash
git clone https://github.com/SerdarK44/hastane_yonetim.git
cd hastane_yonetim
```
Visual Studio ile aç.

Derle (Build > Rebuild) ve çalıştır.

📄 Raporlama Özelliği
TC ile hasta aranır

Tüm muayene geçmişi çekilir

TXT formatında dışa aktarılır

📌 Gereksinimler
Visual Studio 2022+

.NET 6.0 veya 8.0

Windows 10/11
