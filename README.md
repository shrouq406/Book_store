# 📚 Book Store Web Application

A modern and responsive Online Book Store built with ASP.NET Core MVC. The application allows users to browse books, manage publishers, upload book covers, maintain a reading list, and securely access features through authentication and authorization.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- User Registration
- User Login & Logout
- ASP.NET Core Identity Integration
- Cookie-based Authentication
- Protected Pages for Authorized Users

### 📖 Book Management
- Create, Read, Update, and Delete books
- Upload book cover images using IFormFile
- Automatic fallback to a default image
- View detailed information for each book
- Eager Loading using Include()

### 🏢 Publisher Management
- Full CRUD Operations
- One-to-Many Relationship between Publishers and Books
- Dynamic Publisher Dropdown Lists

### 📚 Reading List
- Add books to a reading list
- Session-based counter
- Success messages using TempData

### 🎨 Theme Switcher
- Light Mode & Dark Mode
- Theme stored in Cookies
- Automatically applied across pages

### ⚡ Custom Middleware
- Measures request execution time
- Logs request duration to Visual Studio Output Window

---

## 🛠️ Technologies Used

- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap 5
- Session
- Cookies
- TempData
- Middleware
- Git & GitHub

---

## 📂 Database Design

### Publisher
| Field | Type |
|---------|---------|
| Id | int |
| Name | string |

### Book
| Field | Type |
|---------|---------|
| Id | int |
| Title | string |
| Price | decimal |
| ImageUrl | string |
| PublisherId | int |

### ApplicationUser
| Field | Type |
|---------|---------|
| Id | string |
| UserName | string |
| Email | string |

### Relationship

Publisher (1) ───────► (Many) Books

---

## ✅ Assignment Requirements Covered

- Entity Framework Core Relationship
- CRUD Operations
- Authentication & Authorization
- ASP.NET Core Identity
- Image Upload
- Bootstrap UI
- Eager Loading
- Custom Middleware
- Cookies
- Sessions
- TempData
- Responsive Design
- Git & GitHub Integration

---

## 👩‍💻 Author

Shrouq Ramadan
