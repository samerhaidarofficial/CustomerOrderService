# 🧩 CustomerOrderService (.NET 8 Clean Architecture)

![.NET](https://img.shields.io/badge/.NET-8.0-blue?style=flat-square)
![EF Core](https://img.shields.io/badge/EntityFrameworkCore-InMemory-green?style=flat-square)
![Architecture](https://img.shields.io/badge/Pattern-Clean%20Architecture-orange?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-lightgrey?style=flat-square)

A lightweight **.NET 8 Web API** implementing **Clean Architecture** with **Entity Framework Core (In-Memory DB)**.  
It demonstrates user registration, order management, logging, and unit testing designed for clarity, modularity, and best practices.

---

## 🚀 Features

- 👤 **User Management**
  - Register users with validation
- 📦 **Order Management**
  - Create and retrieve orders linked to registered users
  - Auto-calculate total order price
- 🧠 **Clean Architecture**
  - Separation of concerns across API, Business, Entities, and DB Layers
- 🧰 **EF Core In-Memory Database**
  - Simple, fast, and ideal for demos or testing
- 🧾 **Logging**
  - Centralized audit and error logging service
- 🧪 **Unit Tests**
  - xUnit tests covering core business logic

---
## ⚙️ Tech Stack

| Layer | Technology |
|-------|-------------|
| **Framework** | .NET 8 |
| **Database** | EF Core (In-Memory) |
| **Architecture** | Clean Architecture |
| **Testing** | xUnit |
| **Logging** | Microsoft.Extensions.Logging |
---

🧩 Running the Project
#### 1️⃣ Clone the repository
bash <br>
git clone https://github.com/samerhaidarofficial/CustomerOrderService.git <br>
cd CustomerOrderService
#### 2️⃣ Open in Visual Studio 2022
Open CustomerOrderService.sln <br>

Set CustomerOrderService as the startup project <br>

Press F5 to run

#### 3️⃣ Test the API
Use the URL [baseurl:{port}//swagger](https://localhost:7262/swagger/index.html)


#### 🧰 Future Enhancements
🔐 JWT-based authentication & login <br>
🧱 Replace In-Memory DB with SQLite or SQL Serve <br>
🧪 Integration testing <br>
🐳 Docker support <br>

#### 👨‍💻 Author
Samer Haidar  <br>
Technical Team Lead

#### 📜 License
This project is licensed under the MIT License.
