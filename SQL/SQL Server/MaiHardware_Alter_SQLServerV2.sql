ALTER TABLE quotation
ADD status VARCHAR(20) NOT NULL DEFAULT 'Pendiente' 
CHECK (status IN ('Activo', 'Pendiente', 'Cancelado', 'Convertida'));
