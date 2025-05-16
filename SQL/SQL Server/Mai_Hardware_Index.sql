CREATE INDEX idx_clients_id_user ON clients(id_user);
CREATE INDEX idx_sale_id_client ON sale(id_client);
CREATE INDEX idx_sale_id_user ON sale(id_user);
CREATE INDEX idx_quotation_id_client ON quotation(id_client);
CREATE INDEX idx_quotation_detail_id_quotation ON quotation_detail(id_quotation);
CREATE INDEX idx_quotation_detail_id_product ON quotation_detail(id_product);
CREATE INDEX idx_sale_detail_id_sale ON sale_detail(id_sale);
CREATE INDEX idx_sale_detail_id_product ON sale_detail(id_product);