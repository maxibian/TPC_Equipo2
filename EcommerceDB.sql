CREATE DATABASE Ecommerce_DB
COLLATE Latin1_General_CI_AI;
GO

USE Ecommerce_DB;
GO

CREATE TABLE ROL (
	IdRol INT PRIMARY KEY IDENTITY (1,1),
	Nombre VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE CATEGORIA (
	IdCategoria INT PRIMARY KEY IDENTITY (1,1),
	Nombre VARCHAR(50) NOT NULL UNIQUE,
	Estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE IMAGEN (
	IdImagen INT PRIMARY KEY IDENTITY (1,1),
	ImagenUrl VARCHAR(255) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE USUARIO (
	IdUsuario INT PRIMARY KEY IDENTITY (1,1),
	NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
	Contrasena VARCHAR(255) NOT NULL,
	IdRol INT NOT NULL,
	Estado BIT NOT NULL DEFAULT 1,

	FOREIGN KEY(IdRol) REFERENCES ROL(IdRol)
);
GO

CREATE TABLE TIPOTARJETA (
    IdTipoTarjeta INT PRIMARY KEY IDENTITY(1,1),
    NombreTipoTarjeta VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE TARJETA (
    IdTarjeta INT PRIMARY KEY IDENTITY(1,1),
    NumeroTarjeta VARCHAR(19) NOT NULL UNIQUE,
    FechaVencimiento DATE NOT NULL,
    NombreYApellidoTitular VARCHAR(100) NOT NULL,
    --CodigoSeguridad INT NOT NULL, no guardar (dato sensible)
    IdTipoTarjeta INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    FOREIGN KEY (IdTipoTarjeta) REFERENCES TIPOTARJETA(IdTipoTarjeta)
);
GO

CREATE TABLE DIRECCION (
    IdDireccion INT PRIMARY KEY IDENTITY(1,1),
    Calle VARCHAR(30) NOT NULL,
    Numero INT NOT NULL,
    Localidad VARCHAR(30) NOT NULL,
    CodigoPostal VARCHAR(10) NOT NULL,
    Observacion VARCHAR(200) NULL,
    Estado BIT NOT NULL DEFAULT 1

);
GO

CREATE TABLE CLIENTE (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Telefono VARCHAR(50) NOT NULL,
	IdUsuario INT NOT NULL UNIQUE,
    IdDireccion INT NOT NULL,
    IdTarjeta INT NULL,

	FOREIGN KEY(IdUsuario) REFERENCES USUARIO(IdUsuario),
    FOREIGN KEY (IdDireccion) REFERENCES DIRECCION(IdDireccion),
    FOREIGN KEY (IdTarjeta) REFERENCES TARJETA(IdTarjeta)
);
GO

CREATE TABLE PRODUCTO (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(150) NULL,
    Precio DECIMAL(10,2) NOT NULL,
    IdCategoria INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    Stock INT NOT NULL DEFAULT 0,
    IdImagen INT NULL,

    CONSTRAINT CK_Producto_Precio CHECK (Precio >= 0),
    CONSTRAINT CK_Producto_Stock CHECK (Stock >= 0),

	FOREIGN KEY (IdCategoria) REFERENCES CATEGORIA(IdCategoria),
	FOREIGN KEY (IdImagen) REFERENCES IMAGEN(IdImagen)
);
GO

CREATE TABLE CARRITO (
    IdCarrito INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL UNIQUE,

    CONSTRAINT UQ_Carrito_Cliente UNIQUE (IdCarrito, IdCliente),

    FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente)
);
GO

CREATE TABLE ITEMCARRITO
(
    IdItemCarrito INT IDENTITY(1,1) PRIMARY KEY,
    IdCarrito INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,

    FOREIGN KEY (IdCarrito) REFERENCES CARRITO(IdCarrito),
    FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto),

    CONSTRAINT CK_ItemCarrito_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT UQ_ItemCarrito_Producto UNIQUE (IdCarrito, IdProducto)
);
GO

CREATE TABLE FORMAPAGO (
        IdFormaPago INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(50) NOT NULL UNIQUE,
        Estado BIT NOT NULL DEFAULT 1
    );
GO

CREATE TABLE FORMAENTREGA (
        IdFormaEntrega INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(50) NOT NULL UNIQUE,
        Estado BIT NOT NULL DEFAULT 1
    );
GO

CREATE TABLE VENTA (
        IdVenta INT IDENTITY(1,1) PRIMARY KEY,
        IdCliente INT NOT NULL,
        Fecha DATETIME2(0) NOT NULL DEFAULT (SYSDATETIME()),
        VentaTotal DECIMAL(10,2) NOT NULL,
        IdFormaPago INT NOT NULL,
        IdFormaEntrega INT NOT NULL,
        IdDireccion INT NOT NULL,
        IdCarrito INT NOT NULL UNIQUE, --No estoy seguro de si hace falta IdCarrito
        
        CONSTRAINT CK_PEDIDO_Total CHECK (VentaTotal >= 0),
        

        FOREIGN KEY (IdFormaPago) REFERENCES FORMAPAGO(IdFormaPago),
        FOREIGN KEY (IdFormaEntrega) REFERENCES FORMAENTREGA(IdFormaEntrega),
        FOREIGN KEY (IdDireccion) REFERENCES DIRECCION(IdDireccion),
        FOREIGN KEY (IdCarrito) REFERENCES CARRITO(IdCarrito),

        CONSTRAINT FK_VENTA_CLIENTE
        FOREIGN KEY (IdCliente)
        REFERENCES CLIENTE(IdCliente),

        CONSTRAINT FK_VENTA_CARRITO_CLIENTE
        FOREIGN KEY (IdCarrito, IdCliente)
        REFERENCES CARRITO(IdCarrito, IdCliente)
    );
GO

CREATE TABLE DETALLEVENTA (
        IdDetalleVenta  INT IDENTITY(1,1) PRIMARY KEY,
        IdVenta INT NOT NULL,
        IdProducto INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10,2) NOT NULL,

        FOREIGN KEY (IdVenta) REFERENCES VENTA(IdVenta),
        FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto),

        CONSTRAINT CK_DetalleVenta_Cantidad
        CHECK (Cantidad > 0),

        CONSTRAINT CK_DetallePedido_Precio
        CHECK (PrecioUnitario >= 0)
);
GO

