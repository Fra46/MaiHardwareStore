-- =========================
-- INSERTS PARA MAIHARDWARE STORE
-- =========================

-- USUARIOS (10 registros adicionales)
INSERT INTO users (username, password, tipo, first_name, last_name, phone_number, email, post, salary)
VALUES 
('empleado2', 'emp12345', 'empleado', 'Luis', 'Martínez', '955544433', 'luis.martinez@correo.com', NULL, NULL),
('empleado3', 'emp12345', 'empleado', 'Carmen', 'Rodríguez', '944433322', 'carmen.rodriguez@correo.com', NULL, NULL),
('empleado4', 'emp12345', 'empleado', 'Diego', 'Fernández', '933322211', 'diego.fernandez@correo.com', NULL, NULL),
('admin2', 'admin1234', 'admin', 'Patricia', 'González', '922211100', 'patricia.gonzalez@correo.com', 'Supervisor', 4500.00),
('empleado5', 'emp12345', 'empleado', 'Roberto', 'Jiménez', '911100999', 'roberto.jimenez@correo.com', NULL, NULL),
('empleado6', 'emp12345', 'empleado', 'Sofia', 'Morales', '900999888', 'sofia.morales@correo.com', NULL, NULL),
('empleado7', 'emp12345', 'empleado', 'Miguel', 'Castro', '899888777', 'miguel.castro@correo.com', NULL, NULL),
('admin3', 'admin1234', 'admin', 'Elena', 'Vargas', '888777666', 'elena.vargas@correo.com', 'Jefe de Ventas', 4800.00),
('empleado8', 'emp12345', 'empleado', 'Fernando', 'Ruiz', '877666555', 'fernando.ruiz@correo.com', NULL, NULL),
('empleado9', 'emp12345', 'empleado', 'Gabriela', 'Herrera', '866555444', 'gabriela.herrera@correo.com', NULL, NULL);

-- CLIENTES (15 registros adicionales con relación a usuarios)
INSERT INTO clients (first_name, last_name, phone_number, email, registration_date, status, id_user)
VALUES 
('Pedro', 'Ramírez', '755544433', 'pedro.ramirez@email.com', GETDATE(), 'activo', 2),
('Laura', 'Torres', '744433322', 'laura.torres@email.com', GETDATE(), 'activo', 3),
('Jorge', 'Mendoza', '733322211', 'jorge.mendoza@email.com', GETDATE(), 'activo', 4),
('Rosa', 'Aguilar', '722211100', 'rosa.aguilar@email.com', GETDATE(), 'activo', 2),
('Andrés', 'Vega', '711100999', 'andres.vega@email.com', GETDATE(), 'activo', 5),
('Claudia', 'Ramos', '700999888', 'claudia.ramos@email.com', GETDATE(), 'activo', 6),
('Ricardo', 'Flores', '699888777', 'ricardo.flores@email.com', GETDATE(), 'activo', 7),
('Mónica', 'Guerrero', '688777666', 'monica.guerrero@email.com', GETDATE(), 'activo', 8),
('Antonio', 'Cruz', '677666555', 'antonio.cruz@email.com', GETDATE(), 'activo', 9),
('Isabel', 'Ortega', '666555444', 'isabel.ortega@email.com', GETDATE(), 'activo', 10),
('Raúl', 'Navarro', '655444333', 'raul.navarro@email.com', GETDATE(), 'activo', 11),
('Beatriz', 'Silva', '644333222', 'beatriz.silva@email.com', GETDATE(), 'activo', 3),
('Esteban', 'Peña', '633222111', 'esteban.pena@email.com', GETDATE(), 'inactivo', 4),
('Alejandra', 'Molina', '622111000', 'alejandra.molina@email.com', GETDATE(), 'activo', 5),
('Guillermo', 'Campos', '611000999', 'guillermo.campos@email.com', GETDATE(), 'activo', 6);

-- PRODUCTOS (20 registros adicionales)
INSERT INTO product (code, name, category, description, sale_price, stock)
VALUES 
('P024', 'Llave Inglesa 12"', 'Herramientas', 'Llave ajustable 12 pulgadas', 35.00, 75),
('P025', 'Sierra Manual', 'Herramientas', 'Sierra de mano para madera', 28.50, 60),
('P026', 'Alicate Universal', 'Herramientas', 'Alicate universal 8 pulgadas', 18.00, 90),
('P027', 'Taladro Inalámbrico', 'Eléctricos', 'Taladro a batería 18V', 180.00, 30),
('P028', 'Amoladora Angular', 'Eléctricos', 'Amoladora 4.5" 850W', 95.00, 40),
('P029', 'Nivel de Burbuja', 'Herramientas', 'Nivel de aluminio 60cm', 22.00, 80),
('P030', 'Cinta Métrica 5m', 'Herramientas', 'Flexómetro 5 metros', 12.50, 150),
('P031', 'Soldadora Eléctrica', 'Eléctricos', 'Soldadora 200A', 350.00, 15),
('P032', 'Juego Llaves Mixtas', 'Herramientas', 'Set 12 llaves combinadas', 45.00, 50),
('P033', 'Compresor Aire', 'Eléctricos', 'Compresor 50L 2HP', 280.00, 20),
('P034', 'Escalera Aluminio', 'Herramientas', 'Escalera tijera 6 pasos', 120.00, 25),
('P035', 'Pistola Calor', 'Eléctricos', 'Pistola de calor 2000W', 75.00, 35),
('P036', 'Cincel Plano', 'Herramientas', 'Cincel para concreto', 15.00, 100),
('P037', 'Motobomba Agua', 'Eléctricos', 'Bomba centrífuga 1HP', 220.00, 18),
('P038', 'Prensa Tornillo', 'Herramientas', 'Prensa de banco 4"', 85.00, 30),
('P039', 'Generador Eléctrico', 'Eléctricos', 'Generador 3000W', 450.00, 12),
('P040', 'Kit Brocas HSS', 'Herramientas', 'Set 19 brocas HSS', 32.00, 65),
('P041', 'Soplete Butano', 'Herramientas', 'Soplete con regulador', 40.00, 45),
('P042', 'Multímetro Digital', 'Eléctricos', 'Tester digital básico', 55.00, 40),
('P043', 'Carretilla Obra', 'Herramientas', 'Carretilla 90L capacidad', 110.00, 22);

-- COTIZACIONES (12 registros)
INSERT INTO quotation (date, total, id_client)
VALUES 
(GETDATE(), 180.50, 3),
(GETDATE(), 95.00, 4),
(GETDATE(), 245.50, 5),
(GETDATE(), 67.00, 6),
(GETDATE(), 350.00, 7),
(GETDATE(), 158.50, 8),
(GETDATE(), 290.00, 9),
(GETDATE(), 125.50, 10),
(GETDATE(), 420.00, 11),
(GETDATE(), 78.50, 12),
(GETDATE(), 195.00, 13),
(GETDATE(), 310.50, 14);

-- DETALLE DE COTIZACIONES (múltiples productos por cotización)
INSERT INTO quotation_detail (quantity, unit_price, id_quotation, id_product)
VALUES 
-- Cotización 2 (cliente 3) - Usando nuevos productos insertados
(1, 180.00, 2, 4), -- Taladro Inalámbrico (P027)
-- Cotización 3 (cliente 4)  
(1, 95.00, 3, 5), -- Amoladora (P028)
-- Cotización 4 (cliente 5)
(2, 35.00, 4, 1), -- 2 Llaves Inglesas (P024)
(3, 28.50, 4, 2), -- 3 Sierras (P025)
(1, 22.00, 4, 6), -- 1 Nivel (P029)
-- Cotización 5 (cliente 6)
(1, 45.00, 5, 9), -- Juego Llaves (P032)
(1, 22.00, 5, 6), -- Nivel (P029)
-- Cotización 6 (cliente 7)
(1, 350.00, 6, 8), -- Soldadora (P031)
-- Cotización 7 (cliente 8)
(1, 85.00, 7, 15), -- Prensa (P038)
(2, 32.00, 7, 17), -- 2 Kit Brocas (P040)
(1, 12.50, 7, 7), -- Cinta Métrica (P030)
-- Cotización 8 (cliente 9)
(1, 280.00, 8, 10), -- Compresor (P033)
(1, 10.00, 8, 2), -- Destornillador original
-- Cotización 9 (cliente 10)
(1, 120.00, 9, 11), -- Escalera (P034)
(1, 25.50, 9, 1), -- Martillo original
-- Cotización 10 (cliente 11)
(1, 450.00, 10, 16), -- Generador (P039)
-- Cotización 11 (cliente 12)
(1, 75.00, 11, 12), -- Pistola Calor (P035)
(1, 10.00, 11, 2), -- Destornillador original
-- Cotización 12 (cliente 13)
(2, 55.00, 12, 19), -- 2 Multímetros (P042)
(1, 28.50, 12, 2), -- 1 Sierra (P025)
-- Cotización 13 (cliente 14)
(1, 220.00, 13, 14), -- Motobomba (P037)
(2, 45.00, 13, 9); -- 2 Juegos Llaves (P032)

-- VENTAS (15 registros con diferentes empleados)
INSERT INTO sale (date, payment_method, total, id_client, id_user)
VALUES 
(GETDATE(), 'Tarjeta', 215.50, 3, 3),
(GETDATE(), 'Efectivo', 95.00, 4, 4),
(GETDATE(), 'Transferencia', 180.00, 5, 5),
(GETDATE(), 'Efectivo', 67.00, 6, 6),
(GETDATE(), 'Tarjeta', 350.00, 7, 7),
(GETDATE(), 'Efectivo', 125.50, 8, 8),
(GETDATE(), 'Transferencia', 280.00, 9, 9),
(GETDATE(), 'Tarjeta', 120.00, 10, 10),
(GETDATE(), 'Efectivo', 450.00, 11, 11),
(GETDATE(), 'Tarjeta', 110.50, 12, 3),
(GETDATE(), 'Efectivo', 165.00, 13, 4),
(GETDATE(), 'Transferencia', 290.50, 14, 5),
(GETDATE(), 'Tarjeta', 85.00, 15, 6),
(GETDATE(), 'Efectivo', 195.50, 16, 7),
(GETDATE(), 'Transferencia', 320.00, 17, 8);

-- DETALLE DE VENTAS (productos vendidos)
INSERT INTO sale_detail (quantity, unit_price, id_sale, id_product)
VALUES 
-- Venta 2 (cliente 3) - Usando productos nuevos
(1, 180.00, 2, 4), -- Taladro Inalámbrico (P027)
(1, 35.00, 2, 1), -- Llave Inglesa (P024)
-- Venta 3 (cliente 4)
(1, 95.00, 3, 5), -- Amoladora (P028)
-- Venta 4 (cliente 5)
(1, 180.00, 4, 4), -- Taladro Inalámbrico (P027)
-- Venta 5 (cliente 6)
(1, 45.00, 5, 9), -- Juego Llaves (P032)
(1, 22.00, 5, 6), -- Nivel (P029)
-- Venta 6 (cliente 7)
(1, 350.00, 6, 8), -- Soldadora (P031)
-- Venta 7 (cliente 8)
(1, 85.00, 7, 15), -- Prensa (P038)
(2, 20.00, 7, 17), -- 2 Kit Brocas (P040)
-- Venta 8 (cliente 9)
(1, 280.00, 8, 10), -- Compresor (P033)
-- Venta 9 (cliente 10)
(1, 120.00, 9, 11), -- Escalera (P034)
-- Venta 10 (cliente 11)
(1, 450.00, 10, 16), -- Generador (P039)
-- Venta 11 (cliente 12)
(1, 75.00, 11, 12), -- Pistola Calor (P035)
(1, 35.50, 11, 1), -- Llave Inglesa (P024)
-- Venta 12 (cliente 13)
(1, 280.00, 12, 10), -- Compresor (P033)
(1, 10.50, 12, 2), -- Destornillador original
-- Venta 13 (cliente 14)
(1, 220.00, 13, 14), -- Motobomba (P037)
(2, 35.00, 13, 1), -- 2 Llaves Inglesas (P024)
-- Venta 14 (cliente 15)
(1, 85.00, 14, 15), -- Prensa (P038)
-- Venta 15 (cliente 16)
(2, 55.00, 15, 19), -- 2 Multímetros (P042)
(1, 85.50, 15, 2), -- Sierra (P025)
-- Venta 16 (cliente 17)
(1, 450.00, 16, 16); -- Generador (P039)