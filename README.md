# Netflix CRUD API

A simple Netflix CRUD REST API built using **ASP.NET Core Web API, C#, ADO.NET, MySQL, and a 3-tier architecture**.

## 📌 Project Overview

This project demonstrates how to build a backend REST API for managing Netflix movie and TV show data.

The project follows a 3-tier architecture:

```text
Controller
    ↓
DAL
    ↓
MySQL Database
```

DTOs are used to transfer data between the API and data access layer.

## 🛠️ Technologies Used

* C#
* ASP.NET Core Web API
* .NET 10
* ADO.NET
* MySQL
* Swagger / OpenAPI
* Dependency Injection
* Git & GitHub

## 📂 Project Structure

```text
Netflix
│
├── Netflix.API
│   ├── Controllers
│   │   └── NetflixController.cs
│   └── Program.cs
│
├── Netflix.DAL
│   ├── DatabaseConnection.cs
│   └── NetflixDAL.cs
│
├── Netflix.DTO
│   └── NetflixDTO.cs
│
├── Netflix.slnx
└── README.md
```

## 🔄 CRUD Operations

| Method | Endpoint       | Description             |
| ------ | -------------- | ----------------------- |
| GET    | `/api/Netflix` | Get all Netflix records |
| POST   | `/api/Netflix` | Create a new record     |
| PUT    | `/api/Netflix` | Update a record         |
| DELETE | `/api/Netflix` | Delete a record         |

## 🧩 Architecture

### API Layer

The `Netflix.API` project contains the controller and handles HTTP requests.

```text
HTTP Request
     ↓
NetflixController
```

### DAL Layer

The `Netflix.DAL` project handles database operations using ADO.NET.

```text
NetflixController
       ↓
   NetflixDAL
       ↓
 MySqlConnection
       ↓
    MySQL
```

### DTO Layer

The `Netflix.DTO` project contains `NetflixDTO`, which represents the Netflix data transferred between layers.

## 🗄️ Database

The API connects to a MySQL database named:

```text
netflix
```

The main table is:

```text
netflix
```

Example columns:

```text
show_id
type
title
director
cast
country
date_added
release_year
rating
duration
listed_in
description
```

## ⚙️ Setup and Installation

### 1. Clone the repository

```bash
git clone https://github.com/Pravalikairumalla/Netflix-CRUD-API.git
```

### 2. Open the project

```bash
cd Netflix-CRUD-API
```

### 3. Configure MySQL

Create a MySQL database named:

```sql
CREATE DATABASE netflix;
```

Create the required `netflix` table and import your Netflix dataset.

### 4. Configure the connection string

Update the connection string in `DatabaseConnection.cs` with your local MySQL credentials.

**Do not commit real database passwords to GitHub.**

### 5. Build the project

```bash
dotnet build
```

### 6. Run the API

```bash
dotnet run
```

### 7. Test using Swagger

Open the Swagger URL shown in the terminal after running the application.

You can test:

* GET
* POST
* PUT
* DELETE

## 📮 Example POST Request

```json
{
  "show_Id": "s10001",
  "type": "Movie",
  "title": "Example Movie",
  "director": "Example Director",
  "cast": "Example Actor",
  "country": "India",
  "date_Added": "2026-08-18",
  "release_Year": 2026,
  "rating": "PG",
  "duration": "120 min",
  "listed_In": "Drama",
  "description": "Example Netflix movie"
}
```

## 🔐 Dependency Injection

The project uses ASP.NET Core Dependency Injection:

```csharp
builder.Services.AddScoped<DatabaseConnection>();
builder.Services.AddScoped<NetflixDAL>();
```

The controller receives `NetflixDAL` through constructor injection.

## 📚 What I Learned

Through this project, I practiced:

* ASP.NET Core Web API
* REST API development
* CRUD operations
* Controllers
* DTOs
* Data Access Layer
* ADO.NET
* MySQL database connectivity
* SQL queries
* Parameterized queries
* Dependency Injection
* Swagger API testing
* Git and GitHub
* 3-tier architecture

## 👩‍💻 Author

**Pravalika Irumalla**

GitHub: https://github.com/Pravalikairumalla
