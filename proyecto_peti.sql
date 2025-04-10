-- Crear la base de datos
CREATE DATABASE proyecto_peti;
GO

USE proyecto_peti;
GO

-- Tabla de Usuarios con seguridad mejorada (compatible con tu login)
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,  -- Almacena el hash PBKDF2
    Email NVARCHAR(100) NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
    LastLogin DATETIME NULL
);
GO

-- Tabla del Plan Estratégico con metadatos
CREATE TABLE PlanEstrategico (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL DEFAULT 'Mi Plan Estratégico',
    Descripcion NVARCHAR(255) NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaActualizacion DATETIME NULL,
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Borrador' 
        CHECK (Estado IN ('Borrador', 'Publicado', 'Archivado')),
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
GO

-- Tabla de Misión con control de versiones
CREATE TABLE Mision (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Contenido NVARCHAR(MAX) NOT NULL,
    Version INT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id) ON DELETE CASCADE
);
GO

-- Tabla de Visión con control de versiones
CREATE TABLE Vision (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Contenido NVARCHAR(MAX) NOT NULL,
    Version INT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id) ON DELETE CASCADE
);
GO

-- Tabla de Valores con ordenamiento
CREATE TABLE Valores (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Valor NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(500) NULL,
    Orden INT NOT NULL DEFAULT 0,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id) ON DELETE CASCADE
);
GO

-- Tabla de Objetivos Estratégicos con prioridad
CREATE TABLE ObjetivosEstrategicos (
    Id INT PRIMARY KEY IDENTITY,
    PlanId INT NOT NULL,
    Objetivo NVARCHAR(MAX) NOT NULL,
    Prioridad INT NOT NULL DEFAULT 3 CHECK (Prioridad BETWEEN 1 AND 5),
    FechaEstimada DATE NULL,
    Completado BIT NOT NULL DEFAULT 0,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PlanId) REFERENCES PlanEstrategico(Id) ON DELETE CASCADE
);
GO

-- Tabla de Objetivos Específicos con seguimiento
CREATE TABLE ObjetivosEspecificos (
    Id INT PRIMARY KEY IDENTITY,
    ObjetivoId INT NOT NULL,
    Detalle NVARCHAR(MAX) NOT NULL,
    Completado BIT NOT NULL DEFAULT 0,
    FechaCompletado DATETIME NULL,
    FechaEstimada DATE NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ObjetivoId) REFERENCES ObjetivosEstrategicos(Id) ON DELETE CASCADE
);
GO

-- Índices para mejorar el rendimiento
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_PlanEstrategico_UserId ON PlanEstrategico(UserId);
CREATE INDEX IX_ObjetivosEstrategicos_PlanId ON ObjetivosEstrategicos(PlanId);
CREATE INDEX IX_ObjetivosEspecificos_ObjetivoId ON ObjetivosEspecificos(ObjetivoId);
GO