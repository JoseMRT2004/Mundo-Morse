CREATE DATABASE MundoMorseDB,

USE MundoMorseDB,

-- Tabla de Usuarios
CREATE TABLE Usuarios (
  Id INT PRIMARY KEY IDENTITY(1,1),
  Nombre NVARCHAR(100) NOT NULL,
  FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Traducción
CREATE TABLE HistorialTraduccion (
  Id INT PRIMARY KEY IDENTITY(1,1),
  UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
  TextoOriginal NVARCHAR(255),
  TraduccionMorse NVARCHAR(255),
  FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Adivinanza
CREATE TABLE HistorialAdivinanza (
  Id INT PRIMARY KEY IDENTITY(1,1),
  UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
  PalabraCorrecta NVARCHAR(50),
  PalabraUsuario NVARCHAR(50),
  EsCorrecto BIT,
  FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Sonido
CREATE TABLE HistorialSonido (
  Id INT PRIMARY KEY IDENTITY(1,1),
  UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
  CodigoMorse NVARCHAR(255),
  PalabraCorrecta NVARCHAR(50),
  PalabraUsuario NVARCHAR(50),
  EsCorrecto BIT,
  FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Carrera
CREATE TABLE HistorialCarrera (
  Id INT PRIMARY KEY IDENTITY(1,1),
  UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
  Palabra NVARCHAR(50),
  MorseUsuario NVARCHAR(255),
  Tiempo DECIMAL(10,2),
  EsCorrecto BIT,
  Puntaje INT,
  FechaRegistro DATETIME DEFAULT GETDATE()
);
