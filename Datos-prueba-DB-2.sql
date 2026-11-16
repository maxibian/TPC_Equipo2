USE Ecommerce_DB;
GO

INSERT INTO ROL(Nombre)
VALUES
('Cliente'),
('Admin');

INSERT INTO USUARIO(NombreUsuario, Contrasena, IdRol, Estado)
VALUES
('JuanPerez','1234',1,1);


INSERT INTO Cliente(Nombre, Apellido, Email, Telefono, IdUsuario)
VALUES
('Juan','Perez','jperez@gmail.com',2211231234,1);

INSERT INTO Carrito (IdCliente)
VALUES
(1);

INSERT INTO ItemCarrito (IdCarrito, IdProducto, Cantidad)
VALUES
(1, 1, 2),
(1, 2, 1),
(1, 3, 3),
(1, 4, 1),
(1, 5, 2);