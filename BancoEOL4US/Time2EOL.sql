CREATE DATABASE Time2EOL;

USE Time2EOL;

CREATE TABLE TipoUsuario(
	idTipoUsuario	INT PRIMARY KEY IDENTITY(1,1),
	permissaoTipoUsuario		VARCHAR(20) DEFAULT('Funcionario') NOT NULL
);

CREATE TABLE Usuario(
	idUsuario	INT PRIMARY KEY IDENTITY(1,1),
	nomeUsuario	VARCHAR(50) NOT NULL,
	telefoneUsuario	VARCHAR(14),
	emailUsuario	VARCHAR(50) NOT NULL,
	senhaUsuario	VARCHAR(500) NOT NULL,
	FK_idTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario) NOT NULL
);

CREATE TABLE Ficha(
	idFicha	INT PRIMARY KEY IDENTITY(1,1),
	sist_opFicha	VARCHAR(100) NOT NULL,
	processadorFicha	VARCHAR(100) NOT NULL,
	placa_videoFicha	VARCHAR(100) NOT NULL,
	audioFicha	VARCHAR(100) NOT NULL,
	telaFicha	VARCHAR(100) NOT NULL,
	memoriaFicha	VARCHAR(100) NOT NULL,
	armazenamentoFicha	VARCHAR(100) NOT NULL
);

CREATE TABLE Fabricante(
	idFabricante	INT PRIMARY KEY IDENTITY(1,1),
	nomeFabricante	VARCHAR(50) NOT NULL,
);

CREATE TABLE Produto(
	idProduto	INT PRIMARY KEY IDENTITY(1,1),
	nomeProduto	VARCHAR(50) NOT NULL,
	modeloProduto	VARCHAR(50) NOT NULL,
	/*fabricanteProduto	VARCHAR(50) NOT NULL,*/
	dt_lancProduto	DATE NOT NULL,
	FK_idFabricante	INT FOREIGN KEY REFERENCES Fabricante(idFabricante) NOT NULL,
	/*fichaProduto	TEXT NOT NULL,*/
	FK_idFicha INT FOREIGN KEY REFERENCES Ficha(idFicha) NOT NULL,
	FK_idUsuario	INT FOREIGN KEY REFERENCES Usuario(idUsuario) NOT NULL
);

CREATE TABLE Conservacao(
	idConservacao	INT PRIMARY KEY IDENTITY(1,1),
	estadoConservacao	VARCHAR(50) NOT NULL,
);

CREATE TABLE Imagem(
	idImagem INT PRIMARY KEY IDENTITY (1,1),
	imagem VARCHAR(150),
	altImagem VARCHAR (150)
);

CREATE TABLE Anuncio(
	idAnuncio	INT PRIMARY KEY IDENTITY(1,1),
	precoAnuncio	DECIMAL(7,2) NOT NULL,
	dt_finalAnuncio	DATE NOT NULL,
	statusAnuncio	VARCHAR(15) DEFAULT('Inativo') NOT NULL,
	/*conservacaoAnuncio	VARCHAR(10) NOT NULL,*/
	FK_idConservacao	INT FOREIGN KEY REFERENCES Conservacao(idConservacao) NOT NULL,
	FK_idProduto	INT FOREIGN KEY REFERENCES Produto(idProduto) NOT NULL,
	fk_idImagem INT FOREIGN KEY REFERENCES Imagem(idImagem) NOT NULL,
	fk_idImagem02 INT FOREIGN KEY REFERENCES Imagem(idImagem) NOT NULL,
	fk_idImagem03 INT FOREIGN KEY REFERENCES Imagem(idImagem) NOT NULL
);

CREATE TABLE Interesse(
	idInteresse	INT PRIMARY KEY IDENTITY(1,1),
	dataInteresse	DATE NOT NULL,
	FK_idUsuario	INT FOREIGN KEY REFERENCES Usuario(idUsuario) NOT NULL,
	FK_idAnuncio	INT FOREIGN KEY REFERENCES Anuncio(idAnuncio) NOT NULL
);

SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Ficha;
SELECT * FROM Fabricante;
SELECT * FROM Produto;
SELECT * FROM Conservacao;
SELECT * FROM Anuncio;
SELECT * FROM Interesse;
SELECT * FROM Imagem;

INSERT INTO TipoUsuario VALUES
(
	'Administrador'
),(
	'Funcionario'
);

INSERT INTO Usuario VALUES
(
	'Admin', '(11)12345-6789', 'admin@admin.com', 'fic@132',  1
),(
	'Rafael Miranda', '(11)12765-1209', 'Rafamiranda223@thoughtworks.com', 'rafinha4432', 2
),(
	'Rodrigo Pedro', '(11)12896-3723', 'Rodrigo.Pedro@Thoughtworks.com', 'rodriguinho4000', 2
),(
	'Kleber Rodriguez', '(11)98765-6789', 'kleber.rodriguez@thoughtworks.com', 'kleber23331', 2
);

INSERT INTO Fabricante VALUES
(
	'Dell'
),(
	'Apple'
),(
	'Outros'
);

INSERT INTO Conservacao VALUES
(
	'Ótimo'
),(
	'Bom'
),(
	'Ruim'
);

INSERT INTO Ficha VALUES
('Windows 10', 'Intel Core', 'Intel® UHD Graphics 620', 'Waves MaxxAudio® Pro', '15', '4GB', '1T'),
('Mac OS Sierra', 'Intel Core i5', 'Intel HD Graphics 6000', 'Não Especificado', '13.3"', '8GB', '128GB'),
('-', '-', '-', '-', '23,8"', '-','-');

INSERT INTO Produto VALUES
('Dell Inspiron', 'I15-3583-A2YP', '01/10/2017', 1, 1, 1),
('MacBook Air', 'MQD32BZ/A', '01/10/2017', 2, 2, 1),
('Monitor Dell LED Full HD', 'SE2416H', '05/10/2018', 1, 3, 1);

INSERT INTO Imagem VALUES
('https://images-americanas.b2w.io/produtos/01/00/img/468209/2/468209299_4GG.jpg', 'Dell Frente'),
('https://images-americanas.b2w.io/produtos/01/00/img/468209/2/468209299_3GG.jpg', 'Dell Lateral'),
('https://images-americanas.b2w.io/produtos/01/00/img/468209/2/468209299_5GG.jpg','Dell Costas'),
('https://images-americanas.b2w.io/produtos/01/00/offers/01/00/item/132490/7/132490742_1GG.png','Apple Frente'),
('https://images-americanas.b2w.io/produtos/01/00/offers/01/00/item/132490/7/132490742_2GG.jpg','Apple Lateral'),
('https://images-americanas.b2w.io/produtos/01/00/img/18845/5/18845531_1GG.jpg', 'Monitor Dell Frente'),
('https://images-americanas.b2w.io/produtos/01/00/img/18845/5/18845531_3GG.jpg', 'Monitor Dell Lateral'),
('https://images-americanas.b2w.io/produtos/01/00/img/18845/5/18845531_2GG.jpg', 'Monitor Dell Entradas'),
('https://images-submarino.b2w.io/produtos/01/00/offers/01/00/item/132490/9/132490902_2GG.jpg', 'Apple Duplo');


INSERT INTO Anuncio VALUES
('2200', '01/10/2019', 'Ativo', 1, 1, 1, 2, 3),
('4000', '01/10/2019', 'Ativo', 1, 2, 4, 5, 9),
('600', '05/10/2019', 'Ativo', 1, 3, 6, 7, 8);

INSERT INTO Interesse VALUES
('05/10/2019', 3, 1),
('05/10/2019', 4, 1),
('06/10/2019', 2, 1);
