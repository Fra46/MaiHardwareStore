--DROP DATABASE IF EXISTS MaiHardware_StoreDB;
--CREATE DATABASE MaiHardware_StoreDB;

DROP TABLE IF EXISTS config;
DROP TABLE IF EXISTS sale_detail;
DROP TABLE IF EXISTS sale;
DROP TABLE IF EXISTS quotations;
DROP TABLE IF EXISTS quotation_details;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS admins;
DROP TABLE IF EXISTS employees;
DROP TABLE IF EXISTS clients;
DROP TABLE IF EXISTS users;

CREATE TABLE users (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(20) NOT NULL,
    last_name NVARCHAR(30) NOT NULL,
    phone_number NVARCHAR(20),
    email NVARCHAR(100) NOT NULL
);

CREATE TABLE clients (
    id_client INT IDENTITY(1,1) PRIMARY KEY,
    registration_date DATETIME DEFAULT GETDATE(),
    status NVARCHAR(15),
    id_users INT FOREIGN KEY REFERENCES users(id_user)
);

CREATE TABLE employees (
    id_employees INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(20) NOT NULL,
    password NVARCHAR(MAX) NOT NULL CHECK(LEN(password) >= 8),
    id_users INT FOREIGN KEY REFERENCES users(id_user)
);

CREATE TABLE admins (
    id_admin INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(20) NOT NULL,
    password NVARCHAR(MAX) NOT NULL CHECK(LEN(password) >= 8),
    post NVARCHAR(MAX) NOT NULL,
    salary DECIMAL(10,2) NOT NULL,
    id_users INT FOREIGN KEY REFERENCES users(id_user)
);

CREATE TABLE product (
    id_product INT IDENTITY(1,1) PRIMARY KEY,
    code NVARCHAR(15) UNIQUE,
    name NVARCHAR(50) NOT NULL,
    category NVARCHAR(15) NOT NULL,
    description NVARCHAR(MAX),
    sale_price DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL
);

CREATE TABLE quotation (
    id_quotation INT IDENTITY(1,1) PRIMARY KEY,
    date DATETIME DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    id_client INT FOREIGN KEY REFERENCES clients(id_client)
);

CREATE TABLE quotation_detail (
    id_quotation_detail INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    id_quotation INT FOREIGN KEY REFERENCES quotation(id_quotation),
    id_product INT FOREIGN KEY REFERENCES product(id_product)
);

CREATE TABLE sale (
    id_sale INT IDENTITY(1,1) PRIMARY KEY,
    date DATETIME DEFAULT GETDATE() NOT NULL,
    payment_method NVARCHAR(50) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    id_client INT FOREIGN KEY REFERENCES clients(id_client),
    id_employees INT FOREIGN KEY REFERENCES employees(id_employees)
);

CREATE TABLE sale_detail (
    id_sale_detail INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    id_sale INT FOREIGN KEY REFERENCES sale(id_sale),
    id_product INT FOREIGN KEY REFERENCES product(id_product)
);

CREATE TABLE config (
    id_config INT IDENTITY(1,1) PRIMARY KEY,
    store_name NVARCHAR(30) NOT NULL DEFAULT 'MaiHardware Store',
    igv DECIMAL(4,2) NOT NULL DEFAULT 0.18,
    default_printer NVARCHAR(50)
);
