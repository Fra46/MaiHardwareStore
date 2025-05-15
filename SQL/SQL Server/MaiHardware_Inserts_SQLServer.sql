-- Insertar usuarios
INSERT INTO users (name, email, rol, token_telegram, status)
VALUES 
('Carlos Gomez', 'carlos@ferreteria.com', 'admin', NULL, 1),
('Laura Perez', 'laura@ferreteria.com', 'vendedor', NULL, 1);

-- Insertar productos
INSERT INTO products (name, reference, description, price, stock, sizes, category)
VALUES 
('Martillo acero', 'H001', 'Martillo con mango de goma antideslizante', 25000.00, 20, 'M', 'herramientas'),
('Destornillador estrella', 'D002', 'Destornillador de precision con punta magnetica', 12000.00, 35, 'S', 'herramientas'),
('Cinta metrica 5m', 'C003', 'Cinta retractil con seguro', 9000.00, 50, NULL, 'medicion');

-- Crear carrito temporal para Laura
INSERT INTO temp_carts (id_user)
VALUES (2); -- id_user = 2 corresponde a Laura Perez

-- Insertar productos al carrito
INSERT INTO cart_details (id_cart, id_product, quantity, price)
VALUES 
(1, 1, 2, 25000.00),  -- 2 martillos
(1, 3, 1, 9000.00);   -- 1 cinta metrica

-- Registrar una venta tipo contado
INSERT INTO sales (id_user, date_sale, total, type_sale)
VALUES 
(2, GETDATE(), 59000.00, 'contado'); -- Laura vendio productos por un total de 59000.00

-- Registrar detalle de venta en invoices
INSERT INTO invoices (id_sale, id_product, quantity, price)
VALUES 
(1, 1, 2, 25000.00),  -- 2 martillos
(1, 3, 1, 9000.00);   -- 1 cinta metrica

-- Historial de comandos o acciones del bot
INSERT INTO histories (id_user, query, query_results)
VALUES 
(2, 'consultar stock martillo', 'Martillo acero - Stock: 20'),
(1, 'agregar producto', 'Producto Destornillador estrella agregado correctamente');
