-- Base de datos
CREATE DATABASE proyecto_peti;
GO

USE proyecto_peti;
GO

-- Tabla de Usuarios (ya existente)
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);

-- Tabla del Plan Estratégico por usuario
CREATE TABLE PlanEstrategico (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Tabla de Misión
CREATE TABLE Mision (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Contenido NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);

-- Tabla de Visión
CREATE TABLE Vision (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Contenido NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);

-- Tabla de Valores (1 o varios por plan)
CREATE TABLE Valores (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Valor NVARCHAR(200),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);

-- Tabla de Objetivos Estratégicos
CREATE TABLE ObjetivosEstrategicos (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Objetivo NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);

-- Tabla de Objetivos Específicos (ligados a cada objetivo estratégico)
CREATE TABLE ObjetivosEspecificos (
    Id INT PRIMARY KEY IDENTITY,
    ObjetivoId INT NOT NULL,
    Detalle NVARCHAR(MAX),
    FOREIGN KEY (ObjetivoId) REFERENCES ObjetivosEstrategicos(Id)
);