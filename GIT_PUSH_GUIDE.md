# Panduan Push Project PinjemIn ke Git

## Persiapan Awal

### 1. Install Git (jika belum)
Download dari: https://git-scm.com/download/win

### 2. Konfigurasi Git (satu kali saja)
```bash
git config --global user.name "Nama Anda"
git config --global user.email "email@anda.com"
```

## Cara Push ke GitHub/GitLab

### Langkah 1: Inisialisasi Git Repository
Buka Terminal/PowerShell di folder project:
```bash
cd "E:\DATA ARNAN\FP PL\PinjemIn"
git init
```

### Langkah 2: Tambahkan Semua File
```bash
git add .
```

### Langkah 3: Commit Pertama
```bash
git commit -m "Initial commit: PinjemIn Desktop App"
```

### Langkah 4: Buat Repository di GitHub/GitLab

**Untuk GitHub:**
1. Buka https://github.com
2. Klik tombol "+" → New repository
3. Isi nama: `pinjemin-desktop`
4. Jangan centang "Initialize with README" (sudah ada di local)
5. Klik "Create repository"

**Untuk GitLab:**
1. Buka https://gitlab.com
2. Klik "New project" → "Create blank project"
3. Isi nama: `pinjemin-desktop`
4. Visibility: Private atau Public
5. Jangan centang "Initialize with README"
6. Klik "Create project"

### Langkah 5: Link Repository Remote
```bash
# Untuk GitHub
git remote add origin https://github.com/username/pinjemin-desktop.git

# Atau untuk GitLab
git remote add origin https://gitlab.com/username/pinjemin-desktop.git
```

Ganti `username` dengan username GitHub/GitLab Anda.

### Langkah 6: Push ke Remote
```bash
git branch -M main
git push -u origin main
```

Masukkan username dan password/token saat diminta.

## Cara Push Update Selanjutnya

Setelah mengubah code:
```bash
# 1. Lihat perubahan
git status

# 2. Tambahkan file yang diubah
git add .

# 3. Commit dengan pesan
git commit -m "Deskripsi perubahan"

# 4. Push ke remote
git push
```

## Tips Penting

### Jangan Push File Sensitif
- File `.gitignore` sudah dibuat untuk mencegah push file build dan cache
- Jangan pernah push file berisi password, API key, atau token

### Pesan Commit yang Baik
```bash
# ✅ Baik
git commit -m "Tambah validasi email di LoginForm"
git commit -m "Perbaiki bug di ItemService.SearchItems"
git commit -m "Update UI Dashboard dengan warna baru"

# ❌ Buruk
git commit -m "update"
git commit -m "fix"
git commit -m "asdfgh"
```

### Menggunakan Token untuk GitHub (Recommended)
GitHub tidak lagi mendukung password. Gunakan Personal Access Token:

1. Buka GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Generate new token
3. Pilih scope: `repo` (full control)
4. Copy token yang dihasilkan
5. Saat push, gunakan token sebagai password

### Branches (Opsional)
```bash
# Buat branch baru untuk fitur
git checkout -b feature/supabase-integration

# Pindah branch
git checkout main

# Merge branch
git merge feature/supabase-integration
```

## Troubleshooting

### Error: "remote origin already exists"
```bash
git remote remove origin
git remote add origin https://github.com/username/pinjemin-desktop.git
```

### Error: "failed to push some refs"
```bash
git pull origin main --rebase
git push origin main
```

### Melihat Status
```bash
git status          # Lihat file yang berubah
git log             # Lihat history commit
git remote -v       # Lihat remote repository
```

### Membatalkan Perubahan
```bash
git restore namafile.cs          # Batalkan perubahan 1 file
git restore .                    # Batalkan semua perubahan
git reset --hard HEAD           # Reset ke commit terakhir (HATI-HATI!)
```

## Clone Project di Komputer Lain

```bash
# Clone dari remote
git clone https://github.com/username/pinjemin-desktop.git

# Masuk ke folder
cd pinjemin-desktop

# Build project
dotnet build

# Jalankan
dotnet run
```

## Struktur Commit yang Disarankan

```
Initial commit: PinjemIn Desktop App
│
├── Add: Supabase integration
├── Update: Dashboard UI improvements
├── Fix: Bug in rental calculation
├── Refactor: Service layer architecture
└── Docs: Update README with setup instructions
```

---

**Catatan:** Setelah push berhasil, project Anda akan tersedia di repository online dan bisa diakses dari mana saja!