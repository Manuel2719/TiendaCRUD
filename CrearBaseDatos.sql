
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

    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (CategoriaId)
        REFERENCES Categorias(Id)
);
