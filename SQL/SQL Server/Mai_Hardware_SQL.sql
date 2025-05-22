-- Eliminar tablas en orden correcto
DROP TABLE IF EXISTS config;
DROP TABLE IF EXISTS sale_detail;
DROP TABLE IF EXISTS sale;
DROP TABLE IF EXISTS quotation_detail;
DROP TABLE IF EXISTS quotation;
DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS clients;
DROP TABLE IF EXISTS users;

-- Tabla de usuarios (solo admins y empleados)
CREATE TABLE users (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(20) NOT NULL UNIQUE,
    password NVARCHAR(MAX) NOT NULL CHECK(LEN(password) >= 8),
    tipo NVARCHAR(20) NOT NULL, -- 'admin', 'empleado'
    first_name NVARCHAR(20) NOT NULL,
    last_name NVARCHAR(30) NOT NULL,
    phone_number NVARCHAR(20),
    email NVARCHAR(100) NOT NULL,
    post NVARCHAR(50),         -- Solo para admin
    salary DECIMAL(10,2)       -- Solo para admin
);

-- Tabla de clientes (sin usuario ni contrasena)
CREATE TABLE clients (
    id_client INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(20) NOT NULL,
    last_name NVARCHAR(30) NOT NULL,
    phone_number NVARCHAR(20),
    email NVARCHAR(100),
    registration_date DATETIME DEFAULT GETDATE(),
    status NVARCHAR(15)
);

-- Tabla de productos
CREATE TABLE product (
    id_product INT IDENTITY(1,1) PRIMARY KEY,
    code NVARCHAR(15) UNIQUE,
    name NVARCHAR(50) NOT NULL,
    category NVARCHAR(15) NOT NULL,
    description NVARCHAR(MAX),
    sale_price DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL
);

-- Tabla de cotizaciones
CREATE TABLE quotation (
    id_quotation INT IDENTITY(1,1) PRIMARY KEY,
    date DATETIME DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    id_client INT FOREIGN KEY REFERENCES clients(id_client)
);

-- Detalle de cotizaciones
CREATE TABLE quotation_detail (
    id_quotation_detail INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    id_quotation INT FOREIGN KEY REFERENCES quotation(id_quotation),
    id_product INT FOREIGN KEY REFERENCES product(id_product)
);

-- Tabla de ventas
CREATE TABLE sale (
    id_sale INT IDENTITY(1,1) PRIMARY KEY,
    date DATETIME DEFAULT GETDATE() NOT NULL,
    payment_method NVARCHAR(50) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    id_client INT FOREIGN KEY REFERENCES clients(id_client),
    id_user INT FOREIGN KEY REFERENCES users(id_user) -- empleado/admin que realizo la venta
);

-- Detalle de ventas
CREATE TABLE sale_detail (
    id_sale_detail INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    id_sale INT FOREIGN KEY REFERENCES sale(id_sale),
    id_product INT FOREIGN KEY REFERENCES product(id_product)
);

-- Configuracion de la tienda
CREATE TABLE config (
    id_config INT IDENTITY(1,1) PRIMARY KEY,
    store_name NVARCHAR(30) NOT NULL DEFAULT 'MaiHardware Store',
    igv DECIMAL(4,2) NOT NULL DEFAULT 0.18,
    default_printer NVARCHAR(50)
);

-- =========================
-- INDICES RECOMENDADOS
-- =========================
CREATE INDEX idx_clients_email ON clients(email);
CREATE INDEX idx_sale_id_client ON sale(id_client);
CREATE INDEX idx_sale_id_user ON sale(id_user);
CREATE INDEX idx_quotation_id_client ON quotation(id_client);
CREATE INDEX idx_quotation_detail_id_quotation ON quotation_detail(id_quotation);
CREATE INDEX idx_quotation_detail_id_product ON quotation_detail(id_product);
CREATE INDEX idx_sale_detail_id_sale ON sale_detail(id_sale);
CREATE INDEX idx_sale_detail_id_product ON sale_detail(id_product);

-- =========================
-- DATOS DE PRUEBA
-- =========================

-- Usuarios: admin y empleado
INSERT INTO users (username, password, tipo, first_name, last_name, phone_number, email, post, salary)
VALUES 
('admin', 'admin1234', 'admin', 'Juan', 'P�rez', '999888777', 'admin@correo.com', 'Gerente', 5000.00),
('empleado1', 'emp12345', 'empleado', 'Ana', 'Garc�a', '988877766', 'empleado1@correo.com', NULL, NULL);

-- Clientes
INSERT INTO clients (first_name, last_name, phone_number, email, registration_date, status)
VALUES 
('Carlos', 'L�pez', '977766655', 'cliente1@correo.com', GETDATE(), 'activo'),
('Mar�a', 'S�nchez', '966655544', 'cliente2@correo.com', GETDATE(), 'activo');

-- Productos
INSERT INTO product (code, name, category, description, sale_price, stock)
VALUES 
('P001', 'Martillo', 'Herramientas', 'Martillo de acero', 25.50, 100),
('P002', 'Destornillador', 'Herramientas', 'Destornillador plano', 10.00, 200),
('P003', 'Taladro', 'El�ctricos', 'Taladro el�ctrico 500W', 120.00, 50);

-- Cotizaci�n para cliente1
INSERT INTO quotation (date, total, id_client)
VALUES (GETDATE(), 55.50, 1);

-- Detalle de cotizaci�n
INSERT INTO quotation_detail (quantity, unit_price, id_quotation, id_product)
VALUES 
(2, 25.50, 1, 1), -- 2 Martillos
(1, 4.50, 1, 2);  -- 1 Destornillador

-- Venta realizada por empleado1 al cliente1
INSERT INTO sale (date, payment_method, total, id_client, id_user)
VALUES (GETDATE(), 'Efectivo', 145.50, 1, 2);

-- Detalle de venta
INSERT INTO sale_detail (quantity, unit_price, id_sale, id_product)
VALUES 
(1, 120.00, 1, 3), -- 1 Taladro
(1, 25.50, 1, 1);  -- 1 Martillo

-- Configuraci�n de la tienda
INSERT INTO config (store_name, igv, default_printer)
VALUES ('MaiHardware Store', 0.18, 'HP-LaserJet-123');
