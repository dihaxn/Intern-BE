# 🚀 .NET 8 Web API Development Journey

Welcome to my full-stack .NET 8 Web API learning repository!  
This repo documents everything I've learned and implemented – from environment setup, API development, database integration, security, to documentation and logging.  

🛠️ Tech Stack:  
`.NET 8`, `C#`, `ASP.NET Core`, `SQL Server`, `Entity Framework Core`, `Swagger`, `WSO2`, `log4net`

---

## ✅ .NET Fundamentals & Environment Setup

| Topic | Description | Status |
|-------|-------------|--------|
| 💾 Install .NET 8 SDK & Runtime | Installed and configured for API projects | ✅ Done |
| 🧰 Set up IDE (VS/VS Code) | Configured VS Code for Web API projects | ✅ Done |
| 🔧 .NET CLI Commands | Used CLI to scaffold and run projects | ✅ Done |
| 💻 C# Syntax & Types | Practiced with basic class and data types | ✅ Done |
| 🌐 Hello World API | Created and tested first API via Postman | ✅ Done |
| 📂 ASP.NET Core Structure | Explored Program.cs, Controllers, Models | ✅ Done |

---

## 🔄 ASP.NET Core Web API Basics

| Topic | Description | Status |
|-------|-------------|--------|
| 🧭 Controllers & Routing | Built RESTful API with routing | ✅ Done |
| 📩 CRUD Endpoints | Implemented GET, POST, PUT, DELETE | ✅ Done |
| 🧱 Middleware | Added custom logging & global error handling | ✅ Done |
| 🔌 Dependency Injection | Injected services via built-in DI container | ✅ Done |
| 🆎 API Versioning | Built support for v1 and v2 endpoints | ✅ Done |

---

## 🗃️ Database Integration with SQL Server

| Topic | Description | Status |
|-------|-------------|--------|
| 🛢️ Install SQL Server & SSMS | Installed locally and tested connection | ✅ Done |
| 🔗 Database Project Setup | Added connection string in appsettings.json | ✅ Done |
| ⚙️ EF Core Basics | Practiced both Code-First & DB-First approaches | ✅ Done |
| 📘 DbContext Config | Registered DbContext in DI container | ✅ Done |
| 🛠️ CRUD with EF Core | Built DB-layer CRUD with Repository pattern | ✅ Done |
| 🧱 Migrations | Created/updated DB schema with migrations | ✅ Done |

---

## 🔐 Authentication & Security with WSO2

| Topic | Description | Status |
|-------|-------------|--------|
| 🔑 OAuth2 & JWT | Tested and decoded tokens via jwt.io | ✅ Done |
| ⚙️ WSO2 Identity Server | Installed and configured with SPs | ✅ Done |
| 🔐 Client Apps & Scopes | Registered clients and assigned scopes | ✅ Done |
| 🛡️ Secure APIs (JWT) | Validated JWT in middleware | ✅ Done |
| 👥 Role-based Auth | Implemented role-based endpoint protection | ✅ Done |

---

## 🌍 Advanced REST API Design

| Topic | Description | Status |
|-------|-------------|--------|
| ✅ REST Best Practices | Followed naming conventions and design patterns | ✅ Done |
| 🧾 HTTP Status Codes | Returned proper codes for all scenarios | ✅ Done |
| 📊 Pagination & Filtering | Enabled skip/take, filters, and sorts | ✅ Done |
| 🔗 HATEOAS | Added hypermedia links in responses | ✅ Done |
| 🚨 Error Strategy | Unified global error responses | ✅ Done |

---

## 📘 API Documentation with Swagger

| Topic | Description | Status |
|-------|-------------|--------|
| 🔧 Install Swashbuckle | Integrated and explored Swagger UI | ✅ Done |
| ✍️ XML Comments | Annotated controllers for API docs | ✅ Done |
| 🎨 Customize UI | Personalized Swagger with metadata | ✅ Done |
| 📄 OpenAPI 3.0.1 | Generated and validated spec (JSON/YAML) | ✅ Done |
| 📦 SDK Generation | Generated client SDKs using NSwag | ✅ Done |

---

## 📋 Logging with log4net

| Topic | Description | Status |
|-------|-------------|--------|
| 📝 Intro to log4net | Learned logging structure and config | ✅ Done |
| ⚙️ Configure in .NET 8 | Setup logging via code and config | ✅ Done |
| 📁 Log Files & Formats | Wrote to file, formatted logs | ✅ Done |
| 🧭 Logging Levels | Used Debug, Info, Warn, Error properly | ✅ Done |
| 💡 Best Practices | Avoided PII, added correlation IDs | ✅ Done |

---

## 📌 Summary

This repository is a **complete end-to-end implementation** of an enterprise-grade ASP.NET Core Web API project. It includes:

- ✅ Real-world architecture
- 🔐 Secure authentication
- 🛢️ Robust database handling
- 📊 Well-documented APIs
- 📦 Scalable logging practices

---

## 📎 How to Run

1. Clone the repo  
2. Ensure [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) is installed  
3. Open with **VS Code** or **Visual Studio**  
4. Update `appsettings.json` with your DB config  
5. Run the API using:

```bash
dotnet run
