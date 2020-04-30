--CREATE DATABASE LojaDesporto;
--GO

-- DELETING ZONE
--USE LojaDesporto
--GO
--ALTER TABLE Proj.Artigo
--	DROP CONSTRAINT IF EXISTS ID_DEVOLUCAO;
--ALTER TABLE Proj.Artigo
--	DROP CONSTRAINT IF EXISTS NUM_COMPRA;
--ALTER TABLE Proj.Artigo
--	DROP CONSTRAINT IF EXISTS ID_TRANSPORTE;
--ALTER TABLE Proj.Artigo
--	DROP CONSTRAINT IF EXISTS ID_ARMAZEM;
--ALTER TABLE Proj.Artigo
--	DROP CONSTRAINT IF EXISTS NUM_LOJA
--DROP TABLE IF EXISTS Proj.Devolucao;
--DROP TABLE IF EXISTS Proj.Compra;
--DROP TABLE IF EXISTS Proj.Funcionario;
--DROP TABLE IF EXISTS Proj.Cliente;
--DROP TABLE IF EXISTS Proj.Transporte;
--DROP TABLE IF EXISTS Proj.Armazem;
--DROP TABLE IF EXISTS Proj.Loja;
--DROP TABLE IF EXISTS Proj.Artigo;
--DROP SCHEMA IF EXISTS Proj;
--DROP DATABASE IF EXISTS LojaDesporto; 

--USE LojaDesporto
--GO

CREATE SCHEMA Proj;
GO

-- CREATING TABLES
CREATE TABLE Proj.Artigo(
	Codigo			INT				NOT NULL,
	Preco			DECIMAL(5,2)	CHECK(Preco > 0),	-- 5 Números no total com 2 digitos de precisão decimal 
	Nome			VARCHAR(40)		NOT NULL,
	Categoria		VARCHAR(20)		NOT NULL,			-- Vestuário, calçado, acessórios, etc...
	QuantArtigos	INT				CHECK(QuantArtigos >= 0),
	NumLoja			INT,
	IDArmazem		INT,
	IDTransporte	INT,
	NumCompra		INT,
	IDDevolucao		INT,
	PRIMARY KEY(Codigo)
);

CREATE TABLE Proj.Loja(
	NumLoja			INT				CHECK(NumLoja > 0),
	Nome			VARCHAR(30)		NOT NULL,
	Localizacao		VARCHAR(20)		NOT NULL,
	PRIMARY KEY(NumLoja)
); 

CREATE TABLE Proj.Armazem(
	IDArmazem		INT				CHECK(IDArmazem > 0),
	Capacidade		INT				CHECK(Capacidade > 0),
	NumLoja			INT				CHECK(NumLoja > 0),
	PRIMARY KEY(IDArmazem),
	FOREIGN KEY(NumLoja) REFERENCES Proj.Loja(NumLoja)
);

CREATE TABLE Proj.Transporte(
	IDTransporte	INT				CHECK(IDTransporte > 0),
	DataTransp		DATE,
	Destino			VARCHAR(40),
	PRIMARY KEY(IDTransporte)
);

CREATE TABLE Proj.Cliente(
	NIF				BIGINT			CHECK(NIF > 0),
	Morada			VARCHAR(40),
	Nome			VARCHAR(20)		NOT NULL,
	NumTelem		BIGINT			CHECK(NumTelem > 0),
	PRIMARY KEY(NIF)
);

CREATE TABLE Proj.Funcionario(
	NumFunc			INT				CHECK(NumFunc > 0),
	Morada			VARCHAR(40)		NOT NULL,
	Nome			VARCHAR(20)		NOT NULL,
	NumTelem		BIGINT			CHECK(NumTelem > 0),
	NumLoja			INT				CHECK(NumLoja > 0),
	PRIMARY KEY(NumFunc),
	FOREIGN KEY(NumLoja) REFERENCES Proj.Loja(NumLoja)
);

CREATE TABLE Proj.Compra(
	NumCompra		INT				CHECK(NumCompra > 0),
	Data			DATE			NOT NULL,
	Montante		DECIMAL(5,2)	CHECK(Montante > 0),	-- 5 Números no total com 2 digitos de precisão decimal 
	NIF				BIGINT			CHECK(NIF > 0),
	NumFunc			INT				CHECK(NumFunc > 0),
	PRIMARY KEY(NumCompra),
	FOREIGN KEY(NIF) REFERENCES Proj.Cliente(NIF),
	FOREIGN KEY(NumFunc) REFERENCES Proj.Funcionario(NumFunc)
);

CREATE TABLE Proj.Devolucao(
	IDDevolucao		INT				CHECK(IDDevolucao > 0),
	Data			DATE			NOT NULL,
	Montante		DECIMAL(5,2)	CHECK(Montante > 0),	-- 5 Números no total com 2 digitos de precisão decimal 
	NIF				BIGINT			CHECK(NIF > 0),
	NumFunc			INT				CHECK(NumFunc > 0),
	PRIMARY KEY(IDDevolucao),
	FOREIGN KEY(NIF) REFERENCES Proj.Cliente(NIF),
	FOREIGN KEY(NumFunc) REFERENCES Proj.Funcionario(NumFunc)
);

-- INSERT DATA
INSERT INTO Proj.Artigo(Codigo, Preco, Nome, Categoria, QuantArtigos, NumLoja, IDArmazem, IDTransporte, NumCompra, IDDevolucao)	
-- NA LOJA
	-- LOJA 1
VALUES  (156428, 69.99, 'Camisola Equipamento SLB', 'Vestuário', 12, 1, Null, Null, Null, Null),
		(245875, 59.99, 'Camisola Equipamento SCP', 'Vestuário', 18, 1, Null, Null, Null, Null),
		(114526, 19.99, 'Pulseira Desportiva', 'Acessórios', 20, 1, Null, Null, Null, Null),
		(177895, 9.99, 'Tapete ginástica/yoga', 'Acessórios', 30, 1, Null, Null, Null, Null),
		(103568, 1.99, 'Touca natação', 'Acessórios', 10, 1, Null, Null, Null, Null),
		(165856, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 15, 1, Null, Null, Null, Null),
		(187853, 9.99, 'Bolas Ténis Dunlop Bipk4', 'Acessórios', 28, 1, Null, Null, Null, Null),
		(130055, 19.99, 'Calções Puma', 'Vestuário', 19, 1, Null, Null, Null, Null),
		(172733, 59.99, 'Camisola Equipamento FCP', 'Vestuário', 12, 1, Null, Null, Null, Null),
		(291208, 29.99, 'Relógio Silver Portugal', 'Acessório', 13, 1, Null, Null, Null, Null),
		(827127, 14.99, 'Boné Adidas a3', 'Acessório', 23, 1, Null, Null, Null, Null),
		(758763, 15.49, 'Casaco de Ciclismo', 'Vestuário', 12, 1, Null, Null, Null, Null),
		(172630, 4.99, 'Gorro Star Wars', 'Acessórios', 20, 1, Null, Null, Null, Null),
		(198932, 189.99, 'Halteres 20 Kg Bodytone', 'Acessórios', 29, 1, Null, Null, Null, Null),
		(231230, 3.99, 'Meias Invisíveis', '´Vestuário', 14, 1, Null, Null, Null, Null),
		(231310, 7.99, 'Meias Curtas Adidas', 'Vestuário', 15, 1, Null, Null, Null, Null),
		(198359, 41.24, 'Camisola Térmica Nike', 'Vestuário', 12, 1, Null, Null, Null, Null),
		(187651, 49.99, 'Casaco Adidas Foil', 'Vestuário', 10, 1, Null, Null, Null, Null),
		(190826, 39.99, 'Corta-vento Nike', 'Vestuário', 12,  1, Null, Null, Null, Null),
		(168194, 12.99, 'Luvas Boxe', 'Acessórios', 25, 1, Null, Null, Null, Null),
		(892339, 14.99, 'Calções Silver Re-mimetic', 'Vestuário', 14, 1, Null, Null, Null, Null),
		(128626, 41.24, 'Botas Converse Rival', 'Calçado', 24, 1, Null, Null, Null, Null),
		(101561, 39.99, 'Smartwatch Innova', 'Acessórios', 19, 1, Null, Null, Null, Null),
		(178978, 12.99, 'Óculos Natação', 'Acessórios', 10, 1, Null, Null, Null, Null),
	-- LOJA 2
		(187854, 9.99, 'Bolas Ténis Dunlop Bipk4', 'Acessórios', 20, 2, 110, Null, Null, Null),
		(302548, 64.49, 'Camisola Equipamento FCP', 'Vestuário', 14, 2, Null, Null, Null, Null),
		(825488, 39.19, 'Sapatilha Adidas Runfalcon', 'Calçado', 20, 2, Null, Null, Null, Null),
		(130057, 19.99, 'Calções Puma', 'Vestuário', 20, 2, Null, Null, Null, Null),
		(148597, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 15, 2, Null, Null, Null, Null),
		(154004, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 10, 2, 140, Null, Null, Null),
		(165857, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 12, 2, Null, Null, Null, Null),
		(268193, 12.99, 'Luvas Boxe', 'Acessórios', 16, 2, Null, Null, Null, Null),
		(177890, 9.99, 'Tapete ginástica/yoga', 'Acessórios', 20, 2, Null, Null, Null, Null),
		(198933, 189.99, 'Halteres 20 Kg Bodytone', 'Acessórios', 19, 2, Null, Null, Null, Null),
		(231231, 3.99, 'Meias Invisíveis', '´Vestuário', 10, 2, Null, Null, Null, Null),
		(231311, 7.99, 'Meias Curtas Adidas', 'Vestuário', 25, 2, Null, Null, Null, Null),
		(291209, 29.99, 'Relógio Silver Portugal', 'Acessório', 30, 2, Null, Null, Null, Null),
		(827128, 14.99, 'Boné Adidas a3', 'Acessório', 13, 2, Null, Null, Null, Null),
		(758764, 15.49, 'Casaco de Ciclismo', 'Vestuário', 20, 2, Null, Null, Null, Null),
		(172631, 4.99, 'Gorro Star Wars', 'Acessórios', 12, 2, Null, Null, Null, Null),
		(187634, 29.99, 'Sapatilha Puma Up Clássico', 'Calçado', 10, 2, Null, Null, Null, Null),
		(198360, 41.24, 'Camisola Térmica Nike', 'Vestuário', 21, 2, Null, Null, Null, Null),
		(156429, 69.99, 'Camisola Equipamento SLB', 'Vestuário', 20, 2, Null, Null, Null, Null),
		(245874, 59.99, 'Camisola Equipamento SCP', 'Vestuário', 18, 2, Null, Null, Null, Null),
		(172734, 59.99, 'Camisola Equipamento FCP', 'Vestuário', 28, 2, Null, Null, Null, Null),
		(187652, 49.99, 'Casaco Adidas Foil', 'Vestuário', 12, 2, Null, Null, Null, Null),
		(190827, 39.99, 'Corta-vento Nike', 'Vestuário', 21,  2, Null, Null, Null, Null),
		(101562, 39.99, 'Smartwatch Innova', 'Acessórios', 29, 2, Null, Null, Null, Null),
		(178979, 12.99, 'Óculos Natação', 'Acessórios', 15, 2, Null, Null, Null, Null),
	-- LOJA 3
		(636548, 9.49, 'Mochila Puma Phase', 'Acessórios', 15, 3, Null, Null, Null, Null),
		(128627, 41.24, 'Botas Converse Rival', 'Calçado', 39, 3, Null, Null, Null, Null),
		(204860, 179.99, 'Prancha de surf Quiksilver', 'Acessórios', 17, 3, Null, Null, Null, Null),
		(165858, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 19, 3, Null, Null, Null, Null),
		(176530, 9.99, 'Luvas Ciclismo Mitical', 'Acessórios', 33, 3, Null, Null, Null, Null),
		(101563, 39.99, 'Smartwatch Innova', 'Acessórios', 20, 3, Null, Null, Null, Null),
		(821728, 25.99, 'Boné North Face', 'Acessório', 45, 3, Null, Null, Null, Null),
		(148598, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 19, 3, Null, Null, Null, Null),
		(154005, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 23, 3, Null, Null, Null, Null),
		(827227, 49.99, 'Casaco Adidas Foil', 'Vestuário', 15, 3, Null, Null, Null, Null),
		(826096, 29.99, 'Calças Montanha', 'Vestuário', 20, 3, Null, Null, Null, Null),
		(176537, 69.99, 'Sapatilha Air Max', 'Calçado', 29, 3, Null, Null, Null, Null),
		(190005, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 32, 3, Null, Null, Null, Null),
		(758765, 15.49, 'Casaco de Ciclismo', 'Vestuário', 25, 3, Null, Null, Null, Null),
		(172632, 4.99, 'Gorro Star Wars', 'Acessórios', 30, 3, Null, Null, Null, Null),
		(209170, 39.99, 'Corta-vento Nike', 'Vestuário', 10, 3, Null, Null, Null, Null),
		(187635, 29.99, 'Sapatilha Puma Up Clássico', 'Calçado', 10, 3, Null, Null, Null, Null),
		(156430, 69.99, 'Camisola Equipamento SLB', 'Vestuário', 12, 3, Null, Null, Null, Null),
		(245877, 59.99, 'Camisola Equipamento SCP', 'Vestuário', 22, 3, Null, Null, Null, Null),
		(187653, 49.99, 'Casaco Adidas Foil', 'Vestuário', 19, 3, Null, Null, Null, Null),
		(190828, 39.99, 'Corta-vento Nike', 'Vestuário', 4,  3, Null, Null, Null, Null),
		(198361, 41.24, 'Camisola Térmica Nike', 'Vestuário', 21, 3, Null, Null, Null, Null),
		(172735, 59.99, 'Camisola Equipamento FCP', 'Vestuário', 18, 3, Null, Null, Null, Null),
		(130056, 19.99, 'Calções Puma', 'Vestuário', 19, 3, Null, Null, Null, Null),
-- NO ARMAZEM
	-- ARMAZEM 110 (2000 CAPACIDADE)
		(128628, 41.24, 'Botas Converse Rival', 'Calçado', 240, Null, 110, Null, Null, Null),
		(165859, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 135, Null, 110, Null, Null, Null),
		(204861, 179.99, 'Prancha de surf Quiksilver', 'Acessórios', 150, Null, 110, Null, Null, Null),
		(176531, 9.99, 'Luvas Ciclismo Mitical', 'Acessórios', 130, Null, 110, Null, Null, Null),
		(101564, 39.99, 'Smartwatch Innova', 'Acessórios', 20, Null, 110, Null, Null, Null),
		(821729, 25.99, 'Boné North Face', 'Acessório', 70, Null, 110, Null, Null, Null),
		(231312, 7.99, 'Meias Curtas Adidas', 'Vestuário', 50, Null, 110, Null, Null, Null),
		(892340, 14.99, 'Calções Silver Re-mimetic', 'Vestuário', 45, Null, 110, Null, Null, Null),
		(402456, 49.99, 'Chuteiras Nike Mercurial', 'Calçado', 120, Null, 110, Null, Null, Null),
		(578954, 19.99, 'Bola Euro 2020', 'Acessórios', 70, Null, 110, Null, Null, Null),
		(148599, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 110, Null, 110, Null, Null, Null),
		(154006, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 80, Null, 110, Null, Null, Null),
		(827228, 49.99, 'Casaco Adidas Foil', 'Vestuário', 90, Null, 110, Null, Null, Null),
		(209171, 39.99, 'Corta-vento Nike', 'Vestuário', 110,  Null, 110, Null, Null, Null),
	-- ARMAZEM 120 (500 CAPACIDADE)
		(125489, 39.19, 'Sapatilha Adidas Runfalcon', 'Calçado', 60, Null, 120, Null, Null, Null),
		(826097, 29.99, 'Calças Montanha', 'Vestuário', 50, Null, 120, Null, Null, Null),
		(176538, 69.99, 'Sapatilha Air Max', 'Calçado', 55, Null, 120, Null, Null, Null),
		(190006, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 80, Null, 120, Null, Null, Null),
		(204862, 179.99, 'Prancha de surf Quiksilver', 'Acessórios', 40, Null, 120, Null, Null, Null),
		(168195, 12.99, 'Luvas Boxe', 'Acessórios', 45, Null, 120, Null, Null, Null),
		(176532, 9.99, 'Luvas Ciclismo Mitical', 'Acessórios', 130, Null, 120, Null, Null, Null),
		(172736, 59.99, 'Camisola Equipamento FCP', 'Vestuário', 30, Null, 120, Null, Null, Null),
	-- ARMAZEM 130 (3500 CAPACIDADE)
		(103569, 1.99, 'Touca natação', 'Acessórios', 270, Null, 130, Null, Null, Null),
		(101565, 39.99, 'Smartwatch Innova', 'Acessórios', 190, Null, 130, Null, Null, Null),
		(827129, 14.99, 'Boné Adidas a3', 'Acessório', 330, Null, 130, Null, Null, Null),
		(165860, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 150, Null, 130, Null, Null, Null),
		(177891, 9.99, 'Tapete ginástica/yoga', 'Acessórios', 200, Null, 130, Null, Null, Null),
		(187855, 9.99, 'Bolas Ténis Dunlop Bipk4', 'Acessórios', 280, Null, 130, Null, Null, Null),
		(198934, 189.99, 'Halteres 20 Kg Bodytone', 'Acessórios', 195, Null, 130, Null, Null, Null),
		(231232, 3.99, 'Meias Invisíveis', '´Vestuário', 100, Null, 130, Null, Null, Null),
		(231313, 7.99, 'Meias Curtas Adidas', 'Vestuário', 250, Null, 130, Null, Null, Null),
		(291210, 29.99, 'Relógio Silver Portugal', 'Acessório', 300, Null, 130, Null, Null, Null),
		(402457, 49.99, 'Chuteiras Nike Mercurial', 'Calçado', 110, Null, 130, Null, Null, Null),
	-- ARMAZEM 140 (1000 CAPACIDADE)
		(758766, 15.49, 'Casaco de Ciclismo', 'Vestuário', 120, Null, 140, Null, Null, Null),
		(172633, 4.99, 'Gorro Star Wars', 'Acessórios', 80, Null, 140, Null, Null, Null),
		(253619, 29.74, 'Calças Nike Academy', 'Vestuário', 200, Null, 140, Null, Null, Null),
		(821730, 25.99, 'Boné North Face', 'Acessório', 150, Null, 140, Null, Null, Null),
		(827412, 35.99, 'Calças Adidas Aop', 'Vestuário', 110, Null, 140, Null, Null, Null),
		(826098, 29.99, 'Calças Montanha', 'Vestuário', 140, Null, 140, Null, Null, Null),
		(154007, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 150, Null, 140, Null, Null, Null),
		(827229, 49.99, 'Casaco Adidas Foil', 'Vestuário', 50, Null, 150, Null, Null, Null),
	-- ARMAZEM 150 (4500 CAPACIDADE)
		(758767, 15.49, 'Casaco de Ciclismo', 'Vestuário', 200, Null, 150, Null, Null, Null),
		(825489, 39.19, 'Sapatilha Adidas Runfalcon', 'Calçado', 150, Null, 150, Null, Null, Null),
		(958944, 42.39, 'Sapatilha Nike Zoom', 'Calçado', 100, Null, 150, Null, Null, Null),
		(101566, 39.99, 'Smartwatch Innova', 'Acessórios', 110, Null, 150, Null, Null, Null),
		(130058, 19.99, 'Calções Puma', 'Vestuário', 190, Null, 150, Null, Null, Null),
		(148600, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 250, Null, 150, Null, Null, Null),
		(154008, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 230, Null, 150, Null, Null, Null),
		(165861, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 270, Null, 150, Null, Null, Null),
		(177892, 9.99, 'Tapete ginástica/yoga', 'Acessórios', 300, Null, 150, Null, Null, Null),
		(187856, 9.99, 'Bolas Ténis Dunlop Bipk4', 'Acessórios', 160, Null, 150, Null, Null, Null),
		(198935, 189.99, 'Halteres 20 Kg Bodytone', 'Acessórios', 40, Null, 150, Null, Null, Null),
		(204863, 179.99, 'Prancha de surf Quiksilver', 'Acessórios', 150, Null, 150, Null, Null, Null),
		(268194, 12.99, 'Luvas Boxe', 'Acessórios', 290, Null, 150, Null, Null, Null),
		(103570, 1.99, 'Touca natação', 'Acessórios', 125, Null, 150, Null, Null, Null),
		(652630, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 194, Null, 150, Null, Null, Null),
		(172737, 59.99, 'Camisola Equipamento FCP', 'Vestuário', 30, Null, 150, Null, Null, Null),
		(156431, 69.99, 'Camisola Equipamento SLB', 'Vestuário', 110, Null, 150, Null, Null, Null),
-- EM TRANSPORTE
		(402458, 49.99, 'Chuteiras Nike Mercurial', 'Calçado', 1, Null, Null, 130254, Null, Null),
		(578955, 19.99, 'Bola Euro 2020', 'Acessórios', 4, Null, Null, 120548, Null, Null),
		(154009, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 3, Null, Null, 175896, Null, Null),
		(827230, 49.99, 'Casaco Adidas Foil', 'Vestuário', 1, Null, Null, 158930, Null, Null),
		(892341, 14.99, 'Calções Silver Re-mimetic', 'Vestuário', 2, Null, Null, 190800, Null, Null),
		(156432, 69.99, 'Camisola Equipamento SLB', 'Vestuário', 1, Null, Null, 187232, Null, Null),
		(125490, 39.19, 'Sapatilha Adidas Runfalcon', 'Calçado', 1, Null, Null, 165489, Null, Null),
		(826099, 29.99, 'Calças Montanha', 'Vestuário', 1, Null, Null, 175876, Null, Null),
		(176539, 69.99, 'Sapatilha Air Max', 'Calçado', 1, Null, Null, 156899, Null, Null),
		(190007, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 1, Null, Null, 178999, Null, Null),
		(103572, 1.99, 'Touca natação', 'Acessórios', 3, Null, Null, 120061, Null, Null),
		(101568, 39.99, 'Smartwatch Innova', 'Acessórios', 1, Null, Null, 135896, Null, Null),
		(827130, 14.99, 'Boné Adidas a3', 'Acessório', 3, Null, Null, 185896, Null, Null),
		(758768, 15.49, 'Casaco de Ciclismo', 'Vestuário', 2, Null, Null, 147025, Null, Null),
		(172634, 4.99, 'Gorro Star Wars', 'Acessórios', 2, Null, Null, 105896, Null, Null),
		(253620, 29.74, 'Calças Nike Academy', 'Vestuário', 2, Null, Null, 148667, Null, Null),
		(821731, 25.99, 'Boné North Face', 'Acessório', 1, Null, Null, 152338, Null, Null),
		(652631, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 1, Null, Null, 100259, Null, Null),
		(176533, 9.99, 'Luvas Ciclismo Mitical', 'Acessórios', 2, Null, Null, 175296, Null, Null),
		(148601, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 2, Null, Null, 165896, Null, Null),
		(198208, 79.99, 'Casaco Puma Metal Mulher', 'Vestuário', 1, Null, Null, 174896, Null, Null),
-- COMPRADOS
		(578956, 19.99, 'Bola Euro 2020', 'Acessórios', 2, Null, Null, Null, 30000, Null),
		(758769, 15.49, 'Casaco de Ciclismo', 'Vestuário', 2, Null, Null, Null, 30352, Null),
		(825490, 39.19, 'Sapatilha Adidas Runfalcon', 'Calçado', 1, Null, Null, Null, 31671, Null),
		(958945, 42.39, 'Sapatilha Nike Zoom', 'Calçado', 4, Null, Null, Null, 30051, Null),
		(101569, 39.99, 'Smartwatch Innova', 'Acessórios', 1, Null, Null, Null, 30098, Null),
		(130059, 19.99, 'Calções Puma', 'Vestuário', 2, Null, Null, Null, 31527, Null),
		(148602, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 4, Null, Null, Null, 30027, Null),
		(154010, 14.99, 'Bola basquetebol Nike baller', 'Acessórios', 2, Null, Null, Null, 30100, Null),
		(165862, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 2, Null, Null, Null, 30110, Null),
		(177893, 9.99, 'Tapete ginástica/yoga', 'Acessórios', 3, Null, Null, Null, 30167, Null),
		(187857, 9.99, 'Bolas Ténis Dunlop Bipk4', 'Acessórios', 6, Null, Null, Null, 32098, Null),
		(198936, 189.99, 'Halteres 20 Kg Bodytone', 'Acessórios', 2, Null, Null, Null, 32167, Null),
		(204864, 179.99, 'Prancha de surf Quiksilver', 'Acessórios', 1, Null, Null, Null, 32569, Null),
		(268195, 12.99, 'Luvas Boxe', 'Acessórios', 2, Null, Null, Null, 33456, Null),
		(103573, 1.99, 'Touca natação', 'Acessórios', 3, Null, Null, Null, 35897, Null),
		(652632, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 1, Null, Null, Null, 34251, Null),
		(526312, 4.99, 'Gorro Star Wars', 'Acessórios', 3, Null, Null, Null, 30972, Null),
		(827231, 49.99, 'Casaco Adidas Foil', 'Vestuário', 1, Null, Null, Null, 31263, Null),
		(209172, 39.99, 'Corta-vento Nike', 'Vestuário', 1,  Null, Null, Null, 30001, Null),
		(213143, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 1, Null, Null, Null, 30212, Null),
		(442211, 11.99, 'Casaco Montanha Boriken', 'Vestuário', 2, Null, Null, Null, 33212, Null),
		(290212, 6.49, 'Casaco Polar Up', 'Vestuário', 2, Null, Null, Null, 39212, Null),
		(908123, 10.49, 'Casaco Acolchoado Boriken', 'Vestuário', 2, Null, Null, Null, 38222, Null),
		(892342, 14.99, 'Calções Silver Re-mimetic', 'Vestuário', 1, Null, Null, Null, 31273, Null),
		(827413, 35.99, 'Calças Adidas Aop', 'Vestuário', 1, Null, Null, Null, 30198, Null),
		(826100, 29.99, 'Calças Montanha', 'Vestuário', 1, Null, Null, Null, 34108, Null),
		(253621, 29.74, 'Calças Nike Academy', 'Vestuário', 1, Null, Null, Null, 39100, Null),
		(821732, 25.99, 'Boné North Face', 'Acessório', 1, Null, Null, Null, 31111, Null),
		(231631, 12.99, 'Boné Adidas Logo Metal', 'Acessório', 1, Null, Null, Null, 31221, Null),
		(827131, 14.99, 'Boné Adidas a3', 'Acessório', 1, Null, Null, Null, 31999, Null),
		(231233, 3.99, 'Meias Invisíveis', '´Vestuário', 4, Null, Null, Null, 30932, Null),
		(231314, 7.99, 'Meias Curtas Adidas', 'Vestuário', 2, Null, Null, Null, 32399, Null),
		(291211, 29.99, 'Relógio Silver Portugal', 'Acessório', 1, Null, Null, Null, 30008, Null),
		(921733, 24.99, 'Pulsómetro Army Watch', 'Acessório', 1, Null, Null, Null, 35548, Null),
		(156433, 69.99, 'Camisola Equipamento SLB', 'Vestuário', 2, Null, Null, Null, 34252, Null),
-- DEVOLVIDOS
		(158770, 15.49, 'Casaco de Ciclismo', 'Vestuário', 2, Null, Null, Null, Null, 30023),
		(125491, 39.19, 'Sapatilha Adidas Runfalcon', 'Calçado', 1, Null, Null, Null, Null, 30030),
		(101570, 39.99, 'Smartwatch Innova', 'Acessórios', 1, Null, Null, Null, Null, 30011),
		(130060, 19.99, 'Calções Puma', 'Vestuário', 1, Null, Null, Null, Null, 30035),
		(148603, 14.99, 'Bola futebol Adidas final 19', 'Acessórios', 2, Null, Null, Null, Null, 30017),
		(165863, 89.99, 'Raquete Ténis Head Ig Challenge Pro', 'Acessórios', 1, Null, Null, Null, Null, 30042),
		(177894, 9.99, 'Tapete ginástica/yoga', 'Acessórios', 3, Null, Null, Null, Null, 30050),
		(198937, 189.99, 'Halteres 20 Kg Bodytone', 'Acessórios', 1, Null, Null, Null, Null, 30054),
		(204865, 179.99, 'Prancha de surf Quiksilver', 'Acessórios', 1, Null, Null, Null, Null, 30015),
		(168196, 12.99, 'Luvas Boxe', 'Acessórios', 2, Null, Null, Null, Null, 30060),
		(176534, 9.99, 'Luvas Ciclismo Mitical', 'Acessórios', 2, Null, Null, Null, Null, 30012),
		(176352, 7.99, 'Óculos Natação', 'Acessórios', 3, Null, Null, Null, Null, 30010),
		(172635, 4.99, 'Gorro Star Wars', 'Acessórios', 1, Null, Null, Null, Null, 30025),
		(187636, 29.99, 'Sapatilha Puma Up Clássico', 'Calçado', 1, Null, Null, Null, Null, 30041),
		(198362, 41.24, 'Camisola Térmica Nike', 'Vestuário', 1, Null, Null, Null, Null, 30036),
		(187654, 49.99, 'Casaco Adidas Foil', 'Vestuário', 1, Null, Null, Null, Null, 30020),
		(190829, 39.99, 'Corta-vento Nike', 'Vestuário', 1,  Null, Null, Null, Null, 30053),
		(176540, 69.99, 'Sapatilha Air Max', 'Calçado', 1, Null, Null, Null, Null, 30047),
		(190008, 49.99, 'Sapatilha Nike MD Runner 2', 'Calçado', 1, Null, Null, Null, Null, 30039),
		(178980, 12.99, 'Óculos Natação', 'Acessórios', 1, Null, Null, Null, Null, 30032),
		(198209, 79.99, 'Casaco Puma Metal Mulher', 'Vestuário', 1, Null, Null, Null, Null, 30028)

INSERT INTO Proj.Loja(NumLoja, Nome, Localizacao)
VALUES	(1, 'M&T Sports Line - Aveiro', 'Aveiro'),
		(2, 'M&T Sports Line - Porto', 'Porto'),
		(3, 'M&T Sports Line - Lisboa', 'Lisboa')

ALTER TABLE Proj.Artigo
ADD CONSTRAINT NUM_LOJA FOREIGN KEY(NumLoja) REFERENCES Proj.Loja(NumLoja);

INSERT INTO Proj.Armazem(IDArmazem, Capacidade, NumLoja)
VALUES	(130, 3500, 2),
		(110, 2000, 1),
		(150, 4500, 3),
		(120, 500, 1),
		(140, 1000, 2)

ALTER TABLE Proj.Artigo
ADD CONSTRAINT ID_ARMAZEM FOREIGN KEY(IDArmazem) REFERENCES Proj.Armazem(IDArmazem); 

INSERT INTO Proj.Transporte(IDTransporte, DataTransp, Destino)
VALUES	(130254, '2020-04-15', 'Av. Dr. Lourenço Peixinho, Aveiro'),
		(120548, '2020-01-22', 'Av. da Boavista, Porto'),
		(175896, '2020-02-24', 'R. 21 de Agosto, Viseu'),
		(158930, '2019-12-20', 'Av. Central, Braga'),
		(175876, '2020-04-16', 'R. do Brasil, Coimbra'),
		(165489, '2019-06-02', 'R. da Prata, Lisboa'),
		(174896, '2019-12-23', 'R. Cidade de Bejar, Guarda'),
		(175296, '2020-02-07', 'R. DomJoão III, Coimbra'),
		(100259, '2020-03-12', 'Estrada de Santiago, Aveiro'),
		(152338, '2020-03-27', 'R. Andrade Corvo, Braga'),
		(148667, '2020-04-11', 'R. Qta. da Alagoa, Viseu'),
		(165896, '2020-03-03', 'R. Alves Roçadas, Guarda'),
		(147025, '2020-03-09', 'Praça da Liberdade, Porto'),
		(105896, '2020-02-19', 'R. Infantaria 23, Coimbra'),
		(185896, '2019-11-03', 'R. da Paz, Viseu'),
		(135896, '2020-01-02', 'Av. da Igreja, Guarda'),
		(120061, '2020-01-23', 'R. Serrado, Viseu'),
		(178999, '2020-02-03', 'Av. Eira do Serrado, Guarda'),
		(156899, '2020-03-14', 'R. dos Gatos, Lisboa'),
		(187232, '2020-04-27', 'R. Dos Bons Homens, Porto'),
		(190800, '2020-04-29', 'R. das Almas, Peniche')

ALTER TABLE Proj.Artigo
ADD CONSTRAINT ID_TRANSPORTE FOREIGN KEY(IDTransporte) REFERENCES Proj.Transporte(IDTransporte);

INSERT INTO Proj.Cliente(NIF, Morada, Nome, NumTelem)
VALUES	(234167270, 'R. José Afonso, Aveiro', 'Maria Almeida', 925642354),
		(214139274, 'R. de Egas Moniz, Porto', 'Rui Tomás', 913245559),
		(209969279, Null, 'Carlos Pedro', 965699300),
		(222162274, 'R. António leitão, Coimbra', 'Jéssica Costa', 938341311),
		(199197979, Null, 'Mário Cruz', 960082959),
		(204138828, Null, 'Gonçalo Dias', 926602050),
		(232157891, 'R. dos Galos, Braga', 'Beatriz Prata', 960992011),
		(224234256, 'R. do Carmo, Aveiro', 'Guilherme Marques', 965711954),
		(212445278, 'R. São Frnaciso, Viseu', 'Liliana Barbosa', 919632390),
		(218368289, 'R. de Júlio Dinis, Porto', 'Pedro Costa', 934645399),
		(233464200, Null, 'Adriana Caetano', 920692366),
		(234162272, 'R. Paulo Emílio, Viseu', 'Inês Pereira', 960047392),
		(232187270, 'R.da Pena, Porto', 'Mónica Alves', 915634555),
		(200197299, 'R. João Mendes, Viseu', 'Diogo Matos', 966642056),
		(214131211, 'R. da Aviação Naval, Aveiro', 'Hugo Castro', 938445390),
		(224193223, 'R. Angola, Coimbra', 'Marisa Bernardo', 931946115),
		(209964271, 'R. Campo Alegre', 'Paulo Jesus', 965642354),
		(204003989, Null, 'Mariana Santos', 965642354),
		(219903030, 'R. Artur Bivar, Braga', 'João Pedro', 910012984),
		(211119034, 'R. Dr. Luíz Ferreira', 'Marta Silva', 961119421),
		(297361230, 'R. Direita, Lisboa','João Silva',925048749),
		(564820954, Null,'Manuel Dias',937174610),
		(438291045, 'Av. Lourenço Peixinho, Aveiro','Susana Cardoso',9145107491),
		(123456789, 'R. Emídio Navarro, Águeda','Gracinda Simões', 927451250),
		(721352076, Null,'Rui Pinheiro',964397521),
		(547198471, 'Praceta da Liberdade, Gouveia', 'Afonso Ramos', 934560126),
		(312467201, 'R. Mouzinho da Silveira, Setúbal', 'Ema Duarte' ,913739134),
		(538160672, 'Av. 1º de Maio, Seia', 'José Dias', 937143918),
		(123804287, 'Av. Bombeiros Voluntários, Braga', 'Matilde Coelho' ,967123986),
		(367192368, 'R. do Estádio Municipal, Portimão', 'Guilherme Domingues' ,925291856)

INSERT INTO Proj.Funcionario(NumFunc, Morada, Nome, NumTelem, NumLoja)
VALUES	(142056, 'Av. 25 de Abril, Aveiro', 'Pedro Martins', 915486359, 1),
		(132996, 'R. Forno, Coimbra', 'Eduardo Marques', 965770350, 1),
		(129078, 'R do Ferraz, Porto', 'Maria Bernardo', 960098423, 1),
		(123091, 'Av. dos Combatentes, Lisboa', 'Luís Brás', 936754434, 1),
		(139901, 'R. Gago Coutinho, Cascais', 'Sofia Marques', 938900097, 1),
		(134300, 'R. do Cortinhal, Mangualde', 'Madalena Prata', 928766568, 1),
		(136766, 'R. Camões, Celorico', 'Tiago Rocha', 939988760, 1),
		(136765, 'R. Infante Henrique, Lisboa', 'Carlos Simões', 965243746, 1),
		(138754, 'Av. da Pombas, Leiria', 'Mónica Silva', 912435678, 1),
		(138273, 'Av. da Bela Justa, Coimbra', 'Rosa Peixe', 917888790, 1),
		(110969, 'R. de São Martinho, Aveiro', 'Joana Vicente', 925436450, 2),
		(112034, 'R. de Trás, Porto', 'André Rebelo', 963485656, 2),
		(123303, 'Av. 31 de Janeiro, Braga', 'Márcio Costa', 965406233, 2),
		(130903, 'R. André Soares, Braga', 'Marco Pinto', 936273351, 2),
		(133214, 'R. Júlio Dinis, Ovar', 'Pedro Almeida', 915363728, 2),
		(127635, 'R. Liberdade, Almada', 'Rita Pais', 916667543, 2),
		(140002, 'R. Escura, Viseu', 'Aires Neves', 966787754, 2),
		(131111, 'R. Calouste Gulbenkian, Guarda', 'Sara Gomes', 965568987, 2),
		(139909, 'R. Manuel Martins, Trancoso', 'Gonçalo Oliveira', 929873232, 2),
		(139827, 'R. Pedro Alvares Cabral, Braga', 'Francisca Ferreira', 924343541, 2),
		(114936, 'R. das Violetas, Guimarães', 'Fábio Costa', 965294842, 3),
		(111890, 'R. Gonçalinho, Viseu', 'Edgar Alves', 912263455, 3),
		(132388, 'R. Dr. Manuel Alegre, Águeda', 'Andreia Cabeças', 966452830, 3),
		(133286, 'Av. Jaime Cortesão, Setúbal', 'Angela Pires', 934500987, 3),
		(139998, 'Av. de São Miguel, Guarda', 'Nuno Simões', 927765321, 3),
		(132456, 'R. Chã, Porto', 'Maria Grácio', 960098909, 3),
		(140003, 'R. Direita, Gouveia', 'Alexandre Pereira', 967786543, 3),
		(139999, 'R. do Sol, Porto', 'Sérgio Costa', 928765654, 3),
		(138726, 'R. da Escuridão, Sintra', 'Pedro Matos', 934524242, 3),
		(123632, 'Av. da Liberdade, Lisboa', 'Maria Louçã', 923233400, 3)

INSERT INTO Proj.Compra(NumCompra, Data, Montante, NIF, NumFunc)
VALUES	(30000, '2020-04-01', 39.98, 438291045, 139999),
		(30051, '2020-04-02', 169.56, 209964271, 134300),
		(30352, '2020-04-03', 30.98, 214131211, 129078),
		(31671, '2020-04-04', 39.19, 367192368, 139901),
		(30098, '2020-04-05', 39.99, 232157891, 133286),
		(31527, '2020-06-07', 39.98, 721352076, 111890),
		(30027, '2020-04-07', 59.96, 232187270, 131111),
		(30100, '2020-04-08', 29.98, 214139274, 130903),
		(30110, '2020-04-09', 179.98, 218368289, 133214),
		(30167, '2020-04-10', 29.97, 209964271, 112034),
		(32098, '2020-04-11', 59.99, 214139274, 132388),
		(32167, '2020-04-15', 279.98, 232157891, 114936),
		(32569, '2020-04-17', 179.99, 224234256, 133214),
		(33456, '2020-04-19', 25.98, 212445278, 111890),	
		(35897, '2020-04-21', 5.97, 199197979, 140002),
		(34251, '2020-02-12', 49.99, 222162274, 136765),
		(30972, '2020-02-12', 14.97, 233464200, 139999),
		(31263, '2020-01-01', 49.99, 438291045, 138273),
		(30001, '2020-03-29', 39.99, 222162274, 111890),
		(30212, '2020-02-23', 49.99, 211119034, 123632),
		(33212, '2020-01-19', 23.98, 209964271, 114936),
		(39212, '2020-01-06', 12.98, 564820954, 140003),
		(38222, '2020-01-20', 20.98, 721352076, 139999),
		(31273, '2020-01-14', 14.99, 204003989, 140003),
		(30198, '2020-01-27', 35.99, 367192368, 123303),
		(34108, '2020-01-28', 29.99, 222162274, 123303),
		(39100, '2020-02-27', 29.74, 234167270, 130903),
		(31111, '2020-03-01', 25.99, 209969279, 130903),
		(31221, '2020-03-07', 12.99, 212445278, 139827),
		(31999, '2020-03-24', 14.99, 224234256, 130903),
		(30932, '2020-03-08', 15.96, 438291045, 127635),
		(32399, '2020-03-29', 15.98, 367192368, 110969),
		(30008, '2020-01-31', 29.99, 218368289, 123303),
		(35548, '2020-04-04', 24.99, 200197299, 139909),
		(34252, '2020-03-30', 139.98, 214139274, 112034)

ALTER TABLE Proj.Artigo
ADD CONSTRAINT NUM_COMPRA FOREIGN KEY(NumCompra) REFERENCES Proj.Compra(NumCompra);

INSERT INTO Proj.Devolucao(IDDevolucao, Data, Montante, NIF, NumFunc)
VALUES	(30023, '2020-04-22', 30.98, 224234256, 112034),
		(30015, '2020-03-02', 179.99, 234167270, 132388),
		(30011, '2020-01-26', 39.99, 232157891, 133286),
		(30017, '2020-03-12', 29.98, 232187270, 131111),
		(30030, '2020-02-23', 39.19, 367192368, 139901),
		(30035, '2019-12-27', 19.99, 721352076, 111890),
		(30042, '2020-03-05', 89.99, 218368289, 133214),
		(30050, '2020-04-01', 29.97, 209964271, 112034),
		(30054, '2020-03-02', 189.99, 232157891, 114936),
		(30060, '2020-03-20', 25.98, 212445278, 111890),
		(30012, '2020-04-04', 19.98, 232157891, 132388),
		(30010, '2020-02-02', 23.97, 233464200, 139827),
		(30025, '2020-03-28', 4.99, 211119034, 133286),
		(30041, '2020-01-20', 29.99, 204138828, 133286),
		(30036, '2020-03-30', 41.24, 219903030, 134300),
		(30020, '2020-01-24', 49.99, 209969279, 133286),
		(30053, '2020-02-09', 39.99, 209964271, 138754),
		(30047, '2020-02-02', 69.99, 232157891, 123091),
		(30039, '2020-01-29', 49.99, 218368289, 129078),
		(30032, '2020-01-26', 12.99, 232187270, 134300),
		(30028, '2020-01-01', 79.99, 538160672, 138754)

ALTER TABLE Proj.Artigo
ADD CONSTRAINT ID_DEVOLUCAO FOREIGN KEY(IDDevolucao) REFERENCES Proj.Devolucao(IDDevolucao);

-- QUERYS TESTS
--SELECT * FROM Proj.Artigo;
--SELECT * FROM Proj.Armazem;
--SELECT * FROM Proj.Cliente;
--SELECT * FROM Proj.Compra;
--SELECT * FROM Proj.Devolucao;
--SELECT * FROM Proj.Funcionario;
--SELECT * FROM Proj.Loja;
--SELECT * FROM Proj.Transporte;