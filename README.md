# Tech Fix - Inventory Management System
A service-oriented application for managing inventory, quotations, and user roles, built with C#, ASP.NET, and CSS, with SQL Server as the database.
# About the Project
This Inventory Management System is a web application designed to streamline inventory tracking, user management, and quotation processing with separate interfaces and permissions for each user role. Built with a service-oriented architecture, this system offers Managers, Accountants, and Suppliers specific capabilities tailored to their roles, with a secure login to access each interface.
# Features
### Manager Features
* User Management: Add, edit, delete, and search for users.
* Quotation Management: View quotations and request quotations, with the ability to approve or reject quotations and request quotations.
### Accountant Features
* Inventory Management: Add, edit, and delete inventory items.
* Quotation Requests: Request quotations when inventory levels are low.
### Supplier Features
* Quotation Response: Add pricing and discounts to approved quotations.<br><br>
##### All users must log in with their username and password to access role-specific interfaces.
# Technologies Used
* Frontend: ASP.NET, CSS
* Backend: C#
* Database: SQL Server (using SQL Server Management Studio)
* Architecture: Service-Oriented Architecture (SOA)
# Installation
##### 1 Set Up SQL Server:
* Open SQL Server Management Studio and create a new database (e.g., InventoryDB).
* Import the provided SQL file to set up the required tables and initial data.
##### 2 Configure Database Connection:
* In Visual Studio, navigate to the database connection file (e.g., appsettings.json or relevant config file) and enter your SQL Server connection details.
##### 3 Run the Application:
* Open the project in Visual Studio and start debugging to launch the application.
# Usage
#### 1 Login:
* All users (Manager, Accountant, Supplier) log in with unique credentials.
#### 2 Role-Specific Interfaces:
* Manager: Access user management and quotation approval functions.
* Accountant: Manage inventory and initiate new quotation requests.
* Supplier: Respond to quotations with pricing and discount information.
