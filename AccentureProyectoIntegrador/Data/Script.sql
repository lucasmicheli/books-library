/* Creo Base de Datos */
CREATE DATABASE AccentureProyectoIntegrador;
GO

/* Uso Base de Datos */
USE AccentureProyectoIntegrador;
GO

/* Creo Tablas del Proyecto */
CREATE TABLE Libros (
	ISBN INT PRIMARY KEY IDENTITY (1,1),
	Titulo VARCHAR(50) NOT NULL,
	FechaPublicacion DATE NOT NULL,
	Sinopsis VARCHAR(50) NOT NULL,
	Id_Editorial int not null,
	Id_Genero int not null,
	Id_AxL int not null,
	CONSTRAINT PK_Libro UNIQUE (ISBN, Titulo, FechaPublicacion, Sinopsis),
	CONSTRAINT FK_Editorial FOREIGN KEY (Id_Editorial) REFERENCES Editoriales(IdEditorial),
	CONSTRAINT FK_Genero FOREIGN KEY (Id_Genero) REFERENCES Generos(IdGenero)
);
GO

CREATE TABLE Generos (
	IdGenero INT PRIMARY KEY IDENTITY (1,1),
	NombreGenero VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Genero UNIQUE (IdGenero, NombreGenero)
);
GO

CREATE TABLE Editoriales (
	IdEditorial INT PRIMARY KEY IDENTITY (1,1),
	NombreEditorial VARCHAR(40) NOT NULL,
	CONSTRAINT PK_Editorial UNIQUE (IdEditorial, NombreEditorial)
);
GO

CREATE TABLE Autores (
	IdAutor INT PRIMARY KEY IDENTITY (1,1),
	NombreAutor VARCHAR(70) NOT NULL,
	CONSTRAINT PK_Autor UNIQUE (IdAutor, NombreAutor)
);
GO

CREATE TABLE LibrosXAutores (
	IdLxA INT PRIMARY KEY IDENTITY (1,1),
	ISBN INT NOT NULL,
	IdAutor INT NOT NULL,
	CONSTRAINT PK_LxA UNIQUE (ISBN, IdAutor),
	CONSTRAINT FK_IdLibro FOREIGN KEY (ISBN) REFERENCES Libros(ISBN) ON DELETE CASCADE,
	CONSTRAINT FK_IdAutor FOREIGN KEY (IdAutor) REFERENCES Autores(IdAutor) ON DELETE CASCADE
);
GO

INSERT INTO Autores (NombreAutor) VALUES
('Dan Brown'),
('J R R Tolkien'),
('George R R Martin'),
('J L Borges'),
('Gabriel García Márquez'),
('J K Rowling');
GO

SELECT * FROM Libros

SELECT * FROM Autores

SELECT * FROM LibrosXAutores

SELECT Titulo, NombreAutor
FROM Libros L
JOIN LibrosXAutores LxA
ON L.ISBN = LxA.ISBN
JOIN Autores A
ON A.IdAutor = LxA.IdAutor
