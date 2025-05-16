INSERT INTO usuarios (username, password, tipo, first_name, last_name, phone_number, email, post, salary)
VALUES 
('admin', 'admin123', 'admin', 'Juan', 'Pérez', '999888777', 'admin@correo.com', 'Gerente', 5000.00),
('empleado1', 'emp12345', 'empleado', 'Ana', 'García', '988877766', 'empleado1@correo.com', NULL, NULL),
('cliente1', NULL, 'cliente', 'Carlos', 'López', NULL, NULL, NULL, NULL);

INSERT INTO clients (registration_date, status, id_usuario)
VALUES (GETDATE(), 'activo', 3);

INSERT INTO product (code, name, category, description, sale_price, stock)
VALUES 
('P001', 'Martillo', 'Herramientas', 'Martillo de acero', 25.50, 100),
('P002', 'Destornillador', 'Herramientas', 'Destornillador plano', 10.00, 200),
('P003', 'Taladro', 'Eléctricos', 'Taladro eléctrico 500W', 120.00, 50);

INSERT INTO quotation (date, total, id_client)
VALUES (GETDATE(), 55.50, 1);

INSERT INTO quotation_detail (quantity, unit_price, id_quotation, id_product)
VALUES 
(2, 25.50, 1, 1),
(1, 4.50, 1, 2);

INSERT INTO sale (date, payment_method, total, id_client, id_usuario)
VALUES (GETDATE(), 'Efectivo', 145.50, 1, 2);

INSERT INTO sale_detail (quantity, unit_price, id_sale, id_product)
VALUES 
(1, 120.00, 1, 3),
(1, 25.50, 1, 1);

INSERT INTO config (store_name, igv, default_printer)
VALUES ('MaiHardware Store', 0.18, 'HP-LaserJet-123');
