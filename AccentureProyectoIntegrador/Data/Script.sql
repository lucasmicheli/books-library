/* Creo Base de Datos */
CREATE DATABASE AccentureProyectoIntegrador;
GO

/* Uso Base de Datos */
USE AccentureProyectoIntegrador;
GO

/* Creo Tablas del Proyecto */
CREATE TABLE Libros (
	IdLibro INT PRIMARY KEY IDENTITY (1,1),
	Titulo VARCHAR(70) NOT NULL,
	ISBN VARCHAR(20) NOT NULL,
	FechaPublicacion DATE NOT NULL,
	Sinopsis VARCHAR(100),
	Portada VARCHAR(350),
	Id_Editorial int not null,
	Id_Genero int not null,
	CONSTRAINT UQ_Libro UNIQUE (Titulo),
	CONSTRAINT FK_Editorial FOREIGN KEY (Id_Editorial) REFERENCES Editoriales(IdEditorial) ON DELETE CASCADE,
	CONSTRAINT FK_Genero FOREIGN KEY (Id_Genero) REFERENCES Generos(IdGenero) ON DELETE CASCADE
);
GO

CREATE TABLE Generos (
	IdGenero INT PRIMARY KEY IDENTITY (1,1),
	NombreGenero VARCHAR(30) NOT NULL,
	CONSTRAINT UQ_Genero UNIQUE (NombreGenero)
);
GO

CREATE TABLE Editoriales (
	IdEditorial INT PRIMARY KEY IDENTITY (1,1),
	NombreEditorial VARCHAR(40) NOT NULL,
	CONSTRAINT UQ_Editorial UNIQUE (NombreEditorial)
);
GO

CREATE TABLE Autores (
	IdAutor INT PRIMARY KEY IDENTITY (1,1),
	NombreAutor VARCHAR(50) NOT NULL,
	CONSTRAINT UQ_Autor UNIQUE (NombreAutor)
);
GO

CREATE TABLE LibrosXAutores (
	IdLibro INT,
	IdAutor INT,
	CONSTRAINT PK_LxA PRIMARY KEY (IdLibro, IdAutor),
	CONSTRAINT FK_IdLibro FOREIGN KEY (IdLibro) REFERENCES Libros(IdLibro) ON DELETE CASCADE,
	CONSTRAINT FK_IdAutor FOREIGN KEY (IdAutor) REFERENCES Autores(IdAutor) ON DELETE CASCADE
);
GO

CREATE TABLE LibrosXEditoriales (
	IdLibro INT,
	IdEditorial INT,
	CONSTRAINT PK_LxE PRIMARY KEY (IdLibro, IdEditorial),
	CONSTRAINT FK_IdLibro FOREIGN KEY (IdLibro) REFERENCES Libros(IdLibro) ON DELETE CASCADE,
	CONSTRAINT FK_IdEditorial FOREIGN KEY (IdEditorial) REFERENCES Editoriales(IdEditorial) ON DELETE CASCADE
);
GO

CREATE TABLE LibrosXGeneros (
	IdLibro INT,
	IdGenero INT,
	CONSTRAINT PK_LxG PRIMARY KEY (IdLibro, IdGenero),
	CONSTRAINT FK_IdLibro FOREIGN KEY (IdLibro) REFERENCES Libros(IdLibro) ON DELETE CASCADE,
	CONSTRAINT FK_IdGenero FOREIGN KEY (IdGenero) REFERENCES Generos(IdGenero) ON DELETE CASCADE
);
GO

INSERT INTO Autores (NombreAutor) VALUES
('Dan Brown'),
('J R R Tolkien'),
('George R R Martin'),
('J L Borges'),
('Gabriel García Márquez'),
('J K Rowling'),
('Steven Pinker'),
('Oliver Sacks'),
('Pedro Mairal'),
('Rachel Carson'),
('Charles Darwin');
GO

INSERT INTO Editoriales (NombreEditorial) VALUES
('Paidós'),
('Planeta'),
('De Bolsillo'),
('Debate'),
('Grijalbo'),
('Crítica'),
('Santillana'),
('Aique'),
('Minotauro'),
('Salamandra'),
('Siglo XXI'),
('Emecé');
GO

INSERT INTO Generos (NombreGenero) VALUES
('Ciencia'),
('Ficción'),
('No Ficción'),
('Suspenso'),
('Thriller'),
('Romántico'),
('Ciencia Ficción'),
('Poesía'),
('Infantiles'),
('Policial'),
('Ensayos');
GO

INSERT INTO Libros (Titulo, ISBN, FechaPublicacion, Sinopsis, Portada, Id_Editorial, Id_Genero)
VALUES
('En defensa de la ilustración','978-950-12-9772-0','2018-06-01','Datos, ciencia y estadística','https://static0planetadelibroscom.cdnstatics.com/usuaris/libros/fotos/270/m_libros/portada_en-defensa-de-la-ilustracion_steven-pinker_201803271600.jpg',1,1),
('La Uruguaya','978-950-04-3820-9','2016-02-10','La vida de un escritor en decadencia','https://planetadelibrosar6.cdnstatics.com/usuaris/libros/fotos/216/m_libros/portada_la-uruguaya_pedro-mairal_201604261456.jpg',12,2),
('Despertares','978-84-339-7405-1','1991-12-12','Un médico y una cura psiquiátrica','https://images-na.ssl-images-amazon.com/images/I/5193dkl4LQL._SX321_BO1,204,203,200_.jpg',8,2),
('Ficciones','978-987-566-647-4','1980-06-06','Lo mejor de Borges','https://www.cuspide.com/content/cover/large/9789875666474_1.jpg?id_com=1113',7,2),
('Don Quijote de la Mancha','978-950-46-3967-1','1995-07-08','Nueva edición de un clásico español','https://imagessl5.casadellibro.com/a/l/t5/45/9788466236645.jpg',5,3),
('Primavera Silenciosa','978-84-16771-17-2','1969-05-04','Libro sobre ecología','https://www.planetadelibros.com/usuaris/libros/fotos/219/m_libros/portada_primavera-silenciosa_rachel-carson_201606300113.jpg',4,2);

INSERT INTO LibrosXAutores(IdLibro, IdAutor)
VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6);

SELECT * FROM Libros
SELECT * FROM Autores
SELECT * FROM Editoriales
SELECT * FROM Generos

SELECT * FROM LibrosXAutores
SELECT * FROM LibrosXEditoriales
SELECT * FROM LibrosXGeneros

SELECT Titulo, NombreAutor
FROM Libros L
JOIN LibrosXAutores LxA
ON L.IdLibro = LxA.IdLibro
JOIN Autores A
ON A.IdAutor = LxA.IdAutor
