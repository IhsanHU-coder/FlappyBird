# 🐦 FlappyBird — Unity Firebase Leaderboard Project  

Download : [Flappy Bird Game](https://fatihsanstudio.itch.io/flappy-bird)

## 🎮 Deskripsi  
**FlappyBird** adalah game buatan Unity yang terinspirasi dari Flappy Bird, dengan tambahan **online leaderboard** menggunakan **Firebase Realtime Database**.  
Pemain bisa melihat skor mereka tersimpan online dan dibandingkan dengan pemain lain di seluruh dunia.  

---

## 🚀 Fitur Utama  
- 🕹️ Gameplay klasik gaya *Flappy Bird*  
- ☁️ Online Leaderboard dengan Firebase  
- 🧠 Sistem penyimpanan nama pemain  
- 🔄 Auto reconnect jika koneksi terputus  
- 📱 Build Android ready  

---

## 🧩 Teknologi yang Digunakan  
- **Unity** 2022 atau lebih baru  
- **Firebase SDK for Unity** (Authentication & Realtime Database)  
- **C# scripting**

---

## ⚙️ Cara Menjalankan Proyek  

### 1. Clone Repository  
```bash
git clone https://github.com/IhsanHU-coder/FlappyBird.git
```

## 2️⃣ Buka di Unity
- Buka Unity Hub
- Klik Add Project
- Pilih folder FlappyBird hasil clone tadi
- Tunggu Unity memuat semua asset

## 3️⃣ Import Firebase SDK

⚠️ File Firebase tidak disertakan di GitHub (karena >100 MB)
- Download Firebase Unity SDK
- Extract ZIP-nya
- Import ke Unity:
- Buka Assets → Import Package → Custom Package

Pilih file:
- FirebaseAuth.unitypackage
- FirebaseDatabase.unitypackage

## 4️⃣ Tambahkan File Konfigurasi
Dapatkan google-services.json dari Firebase Console
Letakkan di folder:
```Assets/google-services.json```

## 5️⃣ Jalankan Game
- Klik tombol ▶️ (Play) di Unity
- Masukkan nama pemain
- Mainkan game
- Skor otomatis tersimpan ke Firebase Leaderboard

