# 📚 Book Store Web Application

A simple and responsive Online Book Store built with ASP.NET Core MVC. This project demonstrates CRUD operations, Entity Framework Core relationships, file uploads, custom middleware, and state management using Cookies, Sessions, and TempData.

---

## 🚀 Features

### 📖 Book Management

* Create, Read, Update, and Delete books.
* Upload book cover images using `IFormFile`.
* Automatic fallback to a default image when no cover is uploaded.
* View detailed information for each book.

### 🏢 Publisher Management

* One-to-Many relationship between Publishers and Books.
* Dynamic Publisher selection through a dropdown list.

### 🎨 Theme Switcher

* Light Mode and Dark Mode support.
* User preference stored in Cookies for 7 days.
* Theme applied automatically across all pages.

### 📚 Reading List Tracker

* Add books to a Reading List.
* Session-based counter displayed in the navigation bar.
* Success notifications using TempData.

### ⚡ Custom Performance Middleware

* Measures request execution time.
* Logs request duration to the Visual Studio Output Window.

Example log:

```text
[BookStore Log] Request to /Books/Index took 18 ms.
```

---

## 🛠️ Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* Razor Views
* Bootstrap 5
* Session State
* Cookies
* TempData
* Middleware

---

## 📂 Database Design

### Publisher

| Field | Type   |
| ----- | ------ |
| Id    | int    |
| Name  | string |

### Book

| Field       | Type    |
| ----------- | ------- |
| Id          | int     |
| Title       | string  |
| Price       | decimal |
| ImageUrl    | string  |
| PublisherId | int     |

### Relationship

```text
Publisher (1) --------> (Many) Books
```

---

## 🖼️ Application Screens

### Home / Books Page

* Bootstrap Card Layout
* Book Cover
* Book Title
* Price
* Publisher Name
* Add to Reading List Button

### Create Book

* Publisher Dropdown
* Image Upload
* Form Validation

### Book Details

* Large Cover Image
* Complete Book Information

---

## 📁 Project Structure

```text
BookStore
│
├── Controllers
│   └── BooksController.cs
│
├── Models
│   ├── Book.cs
│   └── Publisher.cs
│
├── Views
│   ├── Books
│   └── Shared
│
├── wwwroot
│   └── images
│       ├── no-image.png
│       └── uploaded-images
│
├── Data
│
├── Program.cs
└── appsettings.json
```

---

## ⚙️ Installation

### Clone the Repository

```bash
git clone https://github.com/your-username/BookStore.git
```

### Navigate to the Project

```bash
cd BookStore
```

### Configure Database

Update the connection string in:

```json
appsettings.json
```

### Apply Migrations

```powershell
Add-Migration InitialCreate
Update-Database
```

### Run the Application

```bash
dotnet run
```

or simply run the project from Visual Studio.

---

## 📤 Image Upload Configuration

Create the following folder:

```text
wwwroot/images
```

Add a default image:

```text
wwwroot/images/no-image.png
```

Make sure your Create/Edit forms include:

```html
enctype="multipart/form-data"
```

---

## 🧠 State Management

### Cookies

Stores the selected application theme.

### Session

Tracks the Reading List count.

Example:

```text
Reading List: 5
```

### TempData

Displays success messages after actions.

Example:

```text
Book added successfully!
```

---

## 🔧 Custom Middleware

The application includes a custom inline middleware that:

* Intercepts every request.
* Calculates processing time.
* Logs execution details to the Output Window.

This helps monitor application performance during development.

---

## 📌 Assignment Requirements Covered

✅ Entity Framework Core Relationship

✅ CRUD Operations

✅ Image Upload

✅ Bootstrap Cards

✅ Eager Loading with Include()

✅ Custom Middleware

✅ Cookies

✅ Sessions

✅ TempData

✅ Responsive UI

✅ Git & GitHub Integration

---

## 👩‍💻 Author

**Shrouq Ramadan**
