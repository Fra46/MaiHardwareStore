-- Eliminar tablas si existen
DROP TABLE IF EXISTS histories;
DROP TABLE IF EXISTS invoices;
DROP TABLE IF EXISTS sales;
DROP TABLE IF EXISTS cart_details;
DROP TABLE IF EXISTS temp_carts;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS users;

-- Tabla de usuarios
CREATE TABLE users (
	id_user INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE,
	rol VARCHAR(20) NOT NULL CHECK (rol IN ('vendedor', 'admin')),
	token_telegram VARCHAR(200),
	status BIT DEFAULT 1
);

-- Tabla de productos
CREATE TABLE products (
	id_product INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(40) NOT NULL,
	reference VARCHAR(15) UNIQUE,
	description TEXT NOT NULL,
	price DECIMAL(10,2) NOT NULL,
	stock INT NOT NULL,
	sizes VARCHAR(20),
	category VARCHAR(50),
	date_sign DATETIME DEFAULT GETDATE()
);

-- Carritos temporales
CREATE TABLE temp_carts (
	id_cart INT IDENTITY(1,1) PRIMARY KEY,
	id_user INT NOT NULL,
	date_cart DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE
);

-- Detalles del carrito
CREATE TABLE cart_details (
	id_detail INT IDENTITY(1,1) PRIMARY KEY,
	id_cart INT NOT NULL,
	id_product INT NOT NULL,
	quantity INT NOT NULL,
	price DECIMAL(10,2) NOT NULL,
	total AS (quantity * price) PERSISTED,
	FOREIGN KEY (id_cart) REFERENCES temp_carts(id_cart) ON DELETE CASCADE,
	FOREIGN KEY (id_product) REFERENCES products(id_product)
);

-- Ventas
CREATE TABLE sales (
	id_sale INT IDENTITY(1,1) PRIMARY KEY,
	id_user INT NOT NULL,
	date_sale DATETIME DEFAULT GETDATE(),
	total DECIMAL(10,2),
	type_sale VARCHAR(20) NOT NULL CHECK (type_sale IN ('contado', 'cotizado')),
	FOREIGN KEY (id_user) REFERENCES users(id_user)
);

-- Facturas (detalle de venta)
CREATE TABLE invoices (
	id_invoice INT IDENTITY(1,1) PRIMARY KEY,
	id_sale INT NOT NULL,
	id_product INT NOT NULL,
	quantity INT NOT NULL,
	price DECIMAL(10,2) NOT NULL,
	total AS (quantity * price) PERSISTED,
	FOREIGN KEY (id_sale) REFERENCES sales(id_sale) ON DELETE CASCADE,
	FOREIGN KEY (id_product) REFERENCES products(id_product)
);

-- Historial de operaciones
CREATE TABLE histories (
	id_history INT IDENTITY(1,1) PRIMARY KEY,
	id_user INT NOT NULL,
	date_time DATETIME DEFAULT GETDATE(),
	query TEXT,
	query_results TEXT,
	FOREIGN KEY (id_user) REFERENCES users(id_user)
);
