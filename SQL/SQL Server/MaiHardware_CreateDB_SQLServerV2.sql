-- Eliminar tablas si existen con prefijo consistente
DROP TABLE IF EXISTS mh_histories;
DROP TABLE IF EXISTS mh_invoices;
DROP TABLE IF EXISTS mh_sales;
DROP TABLE IF EXISTS mh_cart_details;
DROP TABLE IF EXISTS mh_temp_carts;
DROP TABLE IF EXISTS mh_products;
DROP TABLE IF EXISTS mh_users;
DROP TABLE IF EXISTS mh_roles;
DROP TABLE IF EXISTS mh_categories;

-- Tabla de roles
CREATE TABLE mh_roles (
    id_role INT IDENTITY(1,1) PRIMARY KEY,
    role_name VARCHAR(20) NOT NULL UNIQUE,
    description VARCHAR(100)
);

-- Tabla de usuarios
CREATE TABLE mh_users (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL UNIQUE,
    id_role INT NOT NULL,
    token_telegram NVARCHAR(200),
    status BIT DEFAULT 1,
    created_at DATETIME2 DEFAULT SYSDATETIME(),
    updated_at DATETIME2,
    updated_by INT,
    FOREIGN KEY (id_role) REFERENCES mh_roles(id_role),
    FOREIGN KEY (updated_by) REFERENCES mh_users(id_user)
);

-- Tabla de categorías
CREATE TABLE mh_categories (
    id_category INT IDENTITY(1,1) PRIMARY KEY,
    category_name NVARCHAR(50) NOT NULL UNIQUE,
    description NVARCHAR(200)
);

-- Tabla de productos
CREATE TABLE mh_products (
    id_product INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(40) NOT NULL,
    reference NVARCHAR(15) UNIQUE,
    description NVARCHAR(MAX) NOT NULL,
    price DECIMAL(19,4) NOT NULL,
    stock INT NOT NULL,
    sizes NVARCHAR(20),
    id_category INT,
    created_at DATETIME2 DEFAULT SYSDATETIME(),
    updated_at DATETIME2,
    updated_by INT,
    FOREIGN KEY (id_category) REFERENCES mh_categories(id_category),
    FOREIGN KEY (updated_by) REFERENCES mh_users(id_user)
);

-- Índices para productos
CREATE INDEX idx_products_reference ON mh_products(reference);
CREATE INDEX idx_products_category ON mh_products(id_category);

-- Carritos temporales
CREATE TABLE mh_temp_carts (
    id_cart INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    created_at DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (id_user) REFERENCES mh_users(id_user) ON DELETE CASCADE
);

-- Detalles del carrito
CREATE TABLE mh_cart_details (
    id_detail INT IDENTITY(1,1) PRIMARY KEY,
    id_cart INT NOT NULL,
    id_product INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    price DECIMAL(19,4) NOT NULL,
    total AS (quantity * price) PERSISTED,
    FOREIGN KEY (id_cart) REFERENCES mh_temp_carts(id_cart) ON DELETE CASCADE,
    FOREIGN KEY (id_product) REFERENCES mh_products(id_product)
);

-- Ventas
CREATE TABLE mh_sales (
    id_sale INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    created_at DATETIME2 DEFAULT SYSDATETIME(),
    total DECIMAL(19,4),
    type_sale VARCHAR(20) NOT NULL CHECK (type_sale IN ('contado', 'cotizado')),
    status VARCHAR(20) DEFAULT 'pending',
    FOREIGN KEY (id_user) REFERENCES mh_users(id_user)
);

-- Facturas (detalle de venta)
CREATE TABLE mh_invoices (
    id_invoice INT IDENTITY(1,1) PRIMARY KEY,
    id_sale INT NOT NULL,
    id_product INT NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL(19,4) NOT NULL,
    total AS (quantity * price) PERSISTED,
    FOREIGN KEY (id_sale) REFERENCES mh_sales(id_sale) ON DELETE CASCADE,
    FOREIGN KEY (id_product) REFERENCES mh_products(id_product)
);

-- Historial de operaciones
CREATE TABLE mh_histories (
    id_history INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    created_at DATETIME2 DEFAULT SYSDATETIME(),
    action_type VARCHAR(50) NOT NULL,
    table_affected VARCHAR(50),
    record_id INT,
    query NVARCHAR(MAX),
    query_results NVARCHAR(MAX),
    FOREIGN KEY (id_user) REFERENCES mh_users(id_user)
) WITH (DATA_COMPRESSION = PAGE);

-- Insertar roles básicos
INSERT INTO mh_roles (role_name, description) VALUES 
('vendedor', 'Usuario con permisos de venta'),
('admin', 'Usuario con permisos administrativos');