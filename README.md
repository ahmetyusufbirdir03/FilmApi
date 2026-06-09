# FilmApi

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-8.0-blue.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![CQRS](https://img.shields.io/badge/Architecture-CQRS-brightgreen.svg)]()
[![MediatR](https://img.shields.io/badge/Pattern-MediatR-orange.svg)]()

Choose your language / Dil seçiminizi yapın:
- [English](#english)
- [Türkçe](#türkçe)

---

## English

**FilmApi** is a robust and scalable RESTful API built with **.NET 8** and **ASP.NET Core**. It follows the principles of **Onion/Clean Architecture** and implements the **CQRS** (Command Query Responsibility Segregation) pattern utilizing **MediatR**. 

The API provides comprehensive management for movies, user authentication, and authorization using **JWT (JSON Web Tokens)** and **ASP.NET Core Identity**.

### 🚀 Technologies & Libraries

- **Framework:** .NET 8, ASP.NET Core Web API
- **Architecture:** Onion Architecture, CQRS Pattern
- **Database ORM:** Entity Framework Core (SQL Server)
- **Mediator Pattern:** MediatR
- **Identity & Security:** ASP.NET Core Identity, JWT (JSON Web Tokens)
- **Validation:** FluentValidation
- **Object Mapping:** AutoMapper
- **Data Seeding:** Bogus
- **API Documentation:** Swagger / OpenAPI

### 📂 Project Structure (Onion Architecture)

- **Domain:** Contains core entities (`Movie`, `User`, `Role`), Enums, and domain logic. Independent of all other layers.
- **Application:** Contains DTOs, CQRS Features (Commands, Queries, Handlers), Interfaces, Behaviors, and Exceptions.
- **Infrastructure:** Cross-cutting concerns, external services, or utilities.
- **Persistence:** Implementation of DbContext, EF Core Configurations, Migrations, Repositories, and Unit Of Work.
- **WebApi:** The presentation layer. Contains Controllers (`AuthController`, `MovieController`, `UserController`) and API setup.

### 🔑 Key Features

- **User Authentication:** Registration, Login, Token Refresh, Revoke Tokens.
- **Authorization:** Protected endpoints requiring valid JWT tokens.
- **Movie Management:** Full CRUD operations (Create, Read, Update, Delete) for movie records.
- **Validation Pipeline:** Request validation pipeline using MediatR Behaviors and FluentValidation.

### 🛠️ Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/ahmetyusufbirdir03/FilmApi.git
   ```
2. **Configure the Database:**
   - Open `appsettings.json` or `appsettings.Development.json` in the `FilmApi.WebApi` project.
   - Update the `ConnectionStrings` to point to your local SQL Server instance.
3. **Run Migrations:**
   ```bash
   dotnet ef database update --project Infrastructure\FilmApi.Persistence --startup-project WebApi\FilmApi.WebApi
   ```
4. **Run the API:**
   ```bash
   dotnet run --project WebApi\FilmApi.WebApi
   ```
   *Swagger UI will be available at `https://localhost:<port>/swagger`.*

---

## Türkçe

**FilmApi**, **.NET 8** ve **ASP.NET Core** kullanılarak geliştirilmiş, sağlam ve ölçeklenebilir bir RESTful API projesidir. **Onion/Clean Architecture (Soğan Mimarisi)** prensiplerine uygun olarak tasarlanmış olup, **MediatR** kullanılarak **CQRS** (Command Query Responsibility Segregation) deseni uygulanmıştır.

API; filmlerin yönetimi, kullanıcı kimlik doğrulaması (authentication) ve yetkilendirmesi (authorization) işlemleri için **ASP.NET Core Identity** ve **JWT (JSON Web Tokens)** kullanır.

### 🚀 Teknolojiler ve Kütüphaneler

- **Framework:** .NET 8, ASP.NET Core Web API
- **Mimari:** Onion Architecture (Soğan Mimarisi), CQRS Deseni
- **Veritabanı ORM:** Entity Framework Core (SQL Server)
- **Mediator Deseni:** MediatR
- **Kimlik & Güvenlik:** ASP.NET Core Identity, JWT (JSON Web Tokens)
- **Doğrulama (Validation):** FluentValidation
- **Nesne Eşleme (Mapping):** AutoMapper
- **Sahte Veri Üretimi (Seeding):** Bogus
- **API Dokümantasyonu:** Swagger / OpenAPI

### 📂 Proje Yapısı (Onion Architecture)

- **Domain:** Temel varlıkları (`Movie`, `User`, `Role`), Enum'ları ve domain mantığını içerir. Diğer tüm katmanlardan bağımsızdır.
- **Application:** DTO'ları, CQRS özelliklerini (Command, Query, Handler), Arayüzleri (Interfaces), Behavior'ları ve Hata (Exception) sınıflarını barındırır.
- **Infrastructure:** Kesişen ilgiler (cross-cutting concerns), dış servis entegrasyonları.
- **Persistence:** DbContext implementasyonu, EF Core yapılandırmaları, Migration'lar, Repository'ler ve Unit Of Work deseni burada yer alır.
- **WebApi:** Sunum katmanı (Presentation). Controller'ları (`AuthController`, `MovieController`, `UserController`) ve API başlangıç ayarlarını içerir.

### 🔑 Temel Özellikler

- **Kullanıcı İşlemleri:** Kayıt (Register), Giriş (Login), Token Yenileme (Refresh Token) ve Token İptali (Revoke).
- **Yetkilendirme:** Geçerli bir JWT token gerektiren korumalı uç noktalar (endpoints).
- **Film Yönetimi:** Film kayıtları için tam CRUD işlemleri (Oluşturma, Okuma, Güncelleme, Silme).
- **Validasyon Pipeline:** MediatR Behaviors ve FluentValidation kullanılarak merkezi istek (request) doğrulaması.

### 🛠️ Başlangıç

1. **Projeyi Klonlayın:**
   ```bash
   git clone https://github.com/ahmetyusufbirdir03/FilmApi.git
   ```
2. **Veritabanı Ayarlarını Yapılandırın:**
   - `FilmApi.WebApi` projesindeki `appsettings.json` veya `appsettings.Development.json` dosyasını açın.
   - `ConnectionStrings` ayarlarını kendi yerel SQL Server veritabanınıza göre güncelleyin.
3. **Migration'ları Çalıştırın:**
   ```bash
   dotnet ef database update --project Infrastructure\FilmApi.Persistence --startup-project WebApi\FilmApi.WebApi
   ```
4. **Projeyi Başlatın:**
   ```bash
   dotnet run --project WebApi\FilmApi.WebApi
   ```
   *Swagger arayüzüne `https://localhost:<port>/swagger` adresinden erişebilirsiniz.*