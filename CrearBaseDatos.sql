CREATE TABLE Categorias
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Productos
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    CategoriaId INT NOT NULL,
    Stock INT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (CategoriaId)
        REFERENCES Categorias(Id)
        ON DELETE CASCADE
);

INSERT INTO Categorias (Nombre)
VALUES
    (N'Alimentos'),
    (N'Electrónica'),
    (N'Hogar'),
    (N'Ropa');