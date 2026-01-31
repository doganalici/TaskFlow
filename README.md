# 🗂️ TaskFlow – Console Task Manager (C#)

**TaskFlow**, C# öğrenme sürecinde geliştirilmiş,  
**katmanlı mimari** ve **Repository Pattern** kullanan bir **Console To-Do uygulamasıdır**.

Amaç; gerçek hayatta kullanılan mimari yaklaşımları küçük ama sağlam bir proje üzerinde öğrenmek ve uygulamaktır.

---

## 🚀 Özellikler

- ✅ Task ekleme
- 📋 Task listeleme
- ✏️ Task güncelleme
  - Başlık güncelleme
  - Tamamlandı / Devam Ediyor durumu
- 🗑️ Task silme
- 💾 Dosyaya yazma (JSON)
- 🔁 InMemory & File Repository desteği
- 🧱 Katmanlı mimari

---

## 🧠 Kullanılan Yapılar & Kavramlar

- **C# (.NET)**
- **Console Application**
- **Katmanlı Mimari**
- **Repository Pattern**
- **Service Layer**
- **Dependency Injection (Constructor Injection)**
- **JSON File Storage**
- **SOLID’e uygun yapı**

---

## 📂 Proje Yapısı

TaskFlow<br>
│<br>
├── TaskFlow.Entities<br>
│ └── TaskItem.cs<br>
│<br>
├── TaskFlow.DataAccess<br>
│ ├── Interfaces<br>
│ │ └── ITaskRepository.cs<br>
│ └── Repositories<br>
│ ├── InMemoryTaskRepository.cs<br>
│ └── FileTaskRepository.cs<br>
│<br>
├── TaskFlow.Business<br>
│ └── Services<br>
│ └── TaskService.cs<br>
│<br>
└── TaskFlow.ConsoleUI<br>
└── Program.cs<br>

---

🧪 Repository Yapısı

Uygulama, farklı veri kaynaklarıyla çalışabilecek şekilde tasarlanmıştır.

🔹 InMemoryTaskRepository

* Verileri RAM üzerinde tutar

* Test ve geliştirme amaçlı

🔹 FileTaskRepository

* Verileri JSON dosyasına yazar

* Kalıcı veri saklama sağlar

 Repository değiştirerek uygulama davranışı bozulmadan çalışmaya devam eder.


---

🎯 Projenin Amacı

Bu proje, C# öğrenme sürecinde:

* Katmanlı mimariyi kavramak

* Repository Pattern’i uygulamak

* Dosya tabanlı veri yönetimini öğrenmek

* MVC / Web projelere geçiş için sağlam bir temel oluşturmak

amacıyla geliştirilmiştir.
