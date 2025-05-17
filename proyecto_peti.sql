<<<<<<< HEAD
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
=======
-- Crear la base de datos
CREATE DATABASE proyecto_peti;
GO

USE proyecto_peti;
GO

-- Tabla de Usuarios
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);
GO

-- Plan Estratégico
CREATE TABLE PlanEstrategico (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- Información de la Empresa
CREATE TABLE InformacionEmpresa (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    NombreEmpresa NVARCHAR(255),
    Descripcion NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Misión
CREATE TABLE Mision (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Contenido NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Visión
CREATE TABLE Vision (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Contenido NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Valores
CREATE TABLE Valores (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Valor NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Objetivos Estratégicos
CREATE TABLE ObjetivosEstrategicos (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Objetivo NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Objetivos Específicos
CREATE TABLE ObjetivosEspecificos (
    Id INT PRIMARY KEY IDENTITY,
    ObjetivoId INT NOT NULL,
    Detalle NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (ObjetivoId) REFERENCES ObjetivosEstrategicos(Id)
);
GO

-- Análisis FODA
CREATE TABLE AnalisisFODA (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Fortalezas NVARCHAR(MAX),
    Debilidades NVARCHAR(MAX),
    Oportunidades NVARCHAR(MAX),
    Amenazas NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Cadena de Valor
CREATE TABLE CadenaValor (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    ActividadPrimaria NVARCHAR(MAX),
    ActividadSecundaria NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Iniciativas Estratégicas
CREATE TABLE IniciativasEstrategicas (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Perspectiva NVARCHAR(100),
    Descripcion NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Matriz RACI
CREATE TABLE MatrizRACI (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Actividad NVARCHAR(255),
    Responsable NVARCHAR(100),
    Aprobador NVARCHAR(100),
    Consultado NVARCHAR(100),
    Informado NVARCHAR(100),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Fuerzas de Porter
CREATE TABLE FuerzasPorter (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    AmenazaNuevos NVARCHAR(MAX),
    RivalidadCompetidores NVARCHAR(MAX),
    PoderProveedores NVARCHAR(MAX),
    PoderClientes NVARCHAR(MAX),
    AmenazaSustitutos NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Análisis PEST
CREATE TABLE AnalisisPEST (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Politico NVARCHAR(MAX),
    Economico NVARCHAR(MAX),
    Social NVARCHAR(MAX),
    Tecnologico NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Matriz CAME
CREATE TABLE MatrizCAME (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Corregir NVARCHAR(MAX),
    Afrontar NVARCHAR(MAX),
    Mantener NVARCHAR(MAX),
    Explotar NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO

-- Resumen Ejecutivo
CREATE TABLE ResumenEjecutivo (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Introduccion NVARCHAR(MAX),
    Alcance NVARCHAR(MAX),
    ResultadosEsperados NVARCHAR(MAX),
    Conclusiones NVARCHAR(MAX),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id)
);
GO
>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
