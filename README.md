# EFCore Learning Project

This repository contains a collection of projects and exercises for learning **Entity Framework Core (EF Core)** in C#.  
The goal is to practice and understand the main features of EF Core by building small examples and testing functionality step by step.

---

## 📂 Project Structure

- **EFCore.Console**  
  A console application for running EF Core queries and testing features.

- **EFCore.Data**  
  Contains the data access layer (DbContext, migrations, database setup).

- **EFCore.Domain**  
  Contains domain models (entities, relationships, configurations).

---

## 🚀 Features Explored

This repo demonstrates and experiments with different EF Core features, such as:

- Setting up DbContext and configuring models
- Querying data with LINQ
- Relationships (one-to-one, one-to-many, many-to-many)
- Migrations and database updates
- New EF Core 7 features:
  - `ExecuteUpdate`
  - `ExecuteDelete`
- Basic repository pattern

---

## 🛠️ Requirements

- [.NET 6/7 SDK](https://dotnet.microsoft.com/download)
- EF Core tools:
  ```bash
  dotnet tool install --global dotnet-ef
  ```
---

## ▶️ Running the Project

1. Clone the repo:
   ```bash
   git clone https://github.com/your-username/EFCore.git
   cd EFCore
   ```
2. Navigate to the console project:
   ``` bash
   cd EFCore.Console
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
## 🔮 Next Steps

Planned learning topics:

- Advanced LINQ queries

- Concurrency handling

- Transactions

- Performance optimizations

- Unit testing with EF Core (in-memory provider)
