CREATE DATABASE Time2EOL;

USE Time2EOL;

CREATE TABLE TipoUsuario(
	idTipoUsuario	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	permissaoTU		BIT DEFAULT(0) NOT NULL
);

CREATE TABLE Usuario(
	idUsuario	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nomeUsuario	VARCHAR(50) NOT NULL,
	email	VARCHAR(50) NOT NULL,
	telefoneUsuario	VARCHAR(14),
	FK_idTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario)
);

CREATE TABLE Condicao(
	idCondicao	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	avaliacaoCondicao	VARCHAR(6) NOT NULL,
);

CREATE TABLE Categoria(
	idCategoria	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	marcaCategoria	VARCHAR(25) NOT NULL
);

CREATE TABLE Produto(
	idProduto	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nomeProduto	VARCHAR(50) NOT NULL,
	fabricanteProduto	VARCHAR(50) NOT NULL,
	dt_lancProduto	DATE NOT NULL,
	descricaoProduto	TEXT NOT NULL,
	FK_idCategoria	INT FOREIGN KEY REFERENCES Categoria(idCategoria),
	FK_idUsuario	INT FOREIGN KEY REFERENCES Usuario(idUsuario)
);

CREATE TABLE Anuncio(
	idAnuncio	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	precoAnuncio	DECIMAL(7,2) NOT NULL,
	dt_finalAnuncio	DATE NOT NULL,
	fotoAnuncio	VARCHAR(100) NOT NULL,
	statusAnuncio	BIT DEFAULT(1) NOT NULL,
	FK_idProduto	INT FOREIGN KEY REFERENCES Produto(idProduto),
	FK_idCondicao	INT FOREIGN KEY REFERENCES Condicao(idCondicao)
);

CREATE TABLE Interesse(
	idInteresse	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	dataInteresse	DATE NOT NULL,
	FK_idUsuario	INT FOREIGN KEY REFERENCES Usuario(idUsuario),
	FK_idAnuncio	INT FOREIGN KEY REFERENCES Anuncio(idAnuncio)
);

SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;
SELECT * FROM Produto;
SELECT * FROM Condicao;
SELECT * FROM Categoria;
SELECT * FROM Anuncio;
SELECT * FROM Interesse;

INSERT INTO TipoUsuario VALUES(
	1
),(
	0
);

INSERT INTO Usuario VALUES(
	'Admin', 'admin@admin.com', '(11)12345-6789', 1
),(
	'Kleber Rodriguez', 'kleber.rodriguez@thoughtworks.com', '(11)98765-6789', 2
);

INSERT INTO Categoria VALUES(
	'Dell'
),(
	'Apple'
),(
	'Outros'
);

INSERT INTO Condicao VALUES(
	'Ótimo'
),(
	'Bom'
),(
	'Ruim'
);