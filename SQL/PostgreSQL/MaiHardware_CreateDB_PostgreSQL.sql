--DROP DATABASE IF EXISTS maihardware_storedb;
--CREATE DATABASE maihardware_storedb;

DROP TABLE IF EXISTS users CASCADE;
DROP TABLE IF EXISTS products CASCADE;
DROP TABLE IF EXISTS temp_cart CASCADE;
DROP TABLE IF EXISTS cart_detail CASCADE;
DROP TABLE IF EXISTS sales CASCADE;
DROP TABLE IF EXISTS invoices CASCADE;
DROP TABLE IF EXISTS histories CASCADE;

CREATE TABLE users (
	id_user SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE,
	rol VARCHAR(20) NOT NULL CHECK (rol IN ('Vendedor', 'Admin')),
	token_telegram VARCHAR(200),
	status BOOLEAN DEFAULT TRUE
);

CREATE TABLE products (
	id_product SERIAL PRIMARY KEY,
	name VARCHAR(40) NOT NULL,
	reference VARCHAR(15) UNIQUE,
	description TEXT NOT NULL,
	price NUMERIC(10,2) NOT NULL,
	stock INT NOT NULL,
	sizes VARCHAR(20),
	category VARCHAR(50),
	date_sign TIMESTAMP DEFAULT now()
);

CREATE TABLE temp_cart (
	id_car SERIAL PRIMARY KEY,
	id_user INT REFERENCES users(id_user),
	date_car TIMESTAMP DEFAULT now()
);

CREATE TABLE cart_detail (
	id_detail SERIAL PRIMARY KEY,
	id_car INT REFERENCES temp_cart(id_car),
	id_product INT REFERENCES products(id_product),
	quantity INT NOT NULL,
	price NUMERIC(10,2) NOT NULL,
	total NUMERIC(10,2)
);

CREATE TABLE sales (
	id_sale SERIAL PRIMARY KEY,
	id_user INT REFERENCES users(id_user),
	date_sale TIMESTAMP DEFAULT now(),
	total NUMERIC(10,2),
	type_sale VARCHAR(20) NOT NULL CHECK (type_sale IN ('Contado', 'Cotizado'))
);

CREATE TABLE invoices (
	id_invoice SERIAL PRIMARY KEY,
	id_sale INT REFERENCES sales(id_sale),
	id_product INT REFERENCES products(id_product),
	quantity INT NOT NULL,
	price NUMERIC(10,2) NOT NULL,
	total NUMERIC(10,2)
);

CREATE TABLE histories (
	id_history SERIAL PRIMARY KEY,
	id_user INT REFERENCES users(id_user),
	date_time TIMESTAMP DEFAULT now(),
	query TEXT,
	query_results TEXT
);