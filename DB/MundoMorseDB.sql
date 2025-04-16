// todo: agregar las demas tablas para guardar los datos de los diferentes modos de juegos 

CREATE TABLE HistorialTraducciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    PalabraOriginal NVARCHAR(100) NOT NULL,
    TraduccionMorse NVARCHAR(300) NOT NULL,
    FechaHora DATETIME DEFAULT GETDATE()
);
