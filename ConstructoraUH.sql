
-- Crear la base de datos
CREATE DATABASE ConstructoraUH;
GO
USE ConstructoraUH;

-- Tabla de Empleados
CREATE TABLE Empleados (
    CarnetUnico INT PRIMARY KEY IDENTITY(1,1),
    NombreCompleto NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Direccion NVARCHAR(255) DEFAULT 'San José',
    Telefono NVARCHAR(15) NOT NULL,
    CorreoElectronico NVARCHAR(100) UNIQUE NOT NULL,
    Salario DECIMAL(10,2) CHECK (Salario >= 250000 AND Salario <= 500000) DEFAULT 250000,
    CategoriaLaboral NVARCHAR(20) CHECK (CategoriaLaboral IN ('Administrador', 'Operario', 'Peón')) NOT NULL
);

-- Tabla de Proyectos
CREATE TABLE Proyectos (
    CodigoProyecto INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NULL
);

-- Tabla de Asignaciones
CREATE TABLE Asignaciones (
    IdAsignacion INT PRIMARY KEY IDENTITY(1,1),
    CarnetUnico INT NOT NULL,
    CodigoProyecto INT NOT NULL,
    FechaAsignacion DATE DEFAULT GETDATE(),
    FOREIGN KEY (CarnetUnico) REFERENCES Empleados(CarnetUnico),
    FOREIGN KEY (CodigoProyecto) REFERENCES Proyectos(CodigoProyecto)
);

-- Mostrar las tablas creadas:
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE';

-- Mostrar la estructura de cada tabla:
EXEC sp_help 'Empleados';
EXEC sp_help 'Proyectos';
EXEC sp_help 'Asignaciones';

-- Datos de prueba para verificar la funcionalidad

-- Insertar empleados
INSERT INTO Empleados (NombreCompleto, FechaNacimiento, Telefono, CorreoElectronico, Salario, CategoriaLaboral)
VALUES 
('Juan Pérez', '1990-05-10', '12345678', 'juan.perez@email.com', 300000, 'Administrador'),
('Ana Gómez', '1985-08-15', '87654321', 'ana.gomez@email.com', 400000, 'Operario');

-- Insertar proyectos
INSERT INTO Proyectos (Nombre, FechaInicio, FechaFin)
VALUES 
('Edificio Central', '2024-01-01', '2024-12-31'),
('Puente Principal', '2024-02-15', NULL);

-- Asignar empleados a proyectos
INSERT INTO Asignaciones (CarnetUnico, CodigoProyecto)
VALUES 
(1, 1), -- Juan Pérez asignado a Edificio Central
(2, 2); -- Ana Gómez asignada a Puente Principal

DROP TABLE Empleados;
DROP TABLE Proyectos;
DROP TABLE Asignaciones;

IF OBJECT_ID('dbo.Asignaciones', 'U') IS NOT NULL DROP TABLE dbo.Asignaciones;
IF OBJECT_ID('dbo.Proyectos', 'U') IS NOT NULL DROP TABLE dbo.Proyectos;
IF OBJECT_ID('dbo.Empleados', 'U') IS NOT NULL DROP TABLE dbo.Empleados;

SELECT * FROM Empleadoes;
SELECT * FROM Proyectoes;
SELECT * FROM Asignacions;
