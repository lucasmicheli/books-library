/* Creo Base de Datos */
CREATE DATABASE AccentureProject;
GO

/* Uso Base de Datos */
USE AccentureProject;
GO

/* Creo Tablas del Proyecto */
CREATE TABLE Libros (
	IdLibro INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Titulo VARCHAR(30) NOT NULL,
	ISBN VARCHAR(30) NOT NULL,
	FechaPublicacion DATE NOT NULL,
	Sinopsis VARCHAR(50) NOT NULL,
	Id_Editorial int not null,
	Id_Genero int not null,
	Id_Autor int not null,
	CONSTRAINT PK_Libro UNIQUE (IdLibro, Titulo, ISBN, FechaPublicacion, Sinopsis),
	CONSTRAINT FK_Editorial FOREIGN KEY (Id_Editorial) REFERENCES Editoriales(IdEditorial),
	CONSTRAINT FK_Genero FOREIGN KEY (Id_Genero) REFERENCES Generos(IdGenero),
	CONSTRAINT FK_Autor FOREIGN KEY (Id_Autor) REFERENCES Autores(IdAutor)
);
GO

CREATE TABLE Generos (
	IdGenero INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	NombreGenero VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Genero UNIQUE (IdGenero, NombreGenero)
);
GO

CREATE TABLE Editoriales (
	IdEditorial INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	NombreEditorial VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Editorial UNIQUE (IdEditorial, NombreEditorial)
);
GO

CREATE TABLE Autores (
	IdAutor INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Autor UNIQUE (IdAutor, Nombre)
);
GO

CREATE TABLE LibrosXAutores (
	IdLibroxAutor INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	IdLibro INT NOT NULL,
	IdAutor INT NOT NULL,
	CONSTRAINT PK_LxA UNIQUE (IdLibroxAutor),
	CONSTRAINT FK_IdLibro FOREIGN KEY (IdLibro) REFERENCES Libros(IdLibro),
	CONSTRAINT FK_IdAutor FOREIGN KEY (IdAutor) REFERENCES Autores(IdAutor)
);
GO