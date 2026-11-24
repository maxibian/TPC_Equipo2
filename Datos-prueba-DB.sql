USE Ecommerce_DB;
GO

INSERT INTO ROL(Nombre)
VALUES('Administrador'),('Usuario');

INSERT INTO CATEGORIA(Nombre, Estado)
VALUES('Computación',1),('Impresión', 1);
GO


INSERT INTO PRODUCTO(Nombre, Descripcion, Precio, IdCategoria, Estado, Stock)
VALUES('Notebook Lenovo IdeaPad Slim 3',
'Descubrí una nueva dimensión de eficiencia diaria
y portabilidad absoluta con la Lenovo IdeaPad Slim 3.', 50000.00, 1, 1, 20),
('Notebook Asus Vivobook Go 15 Ryzen 5','La Asus Vivobook Go 15 combina un diseño liviano
con un desempeño ágil para el ritmo diario.', 45000.00, 1, 1, 25),
('Notebook HP 15 con Procesador Intel Core 3', 'Tu compañera para todo
Laptop HP 15, tu compañera para todo lo que haces', 48000.00, 1, 1, 15),
('Notebook Acer Aspire Lite Al14-32p-38h9', 'NOTEBOOK ACER ASPIRE LITE 14 CI3 N355', 37000.00, 1, 1, 10),
('Legion 5 Ultra 9 Rtx 5060 32gb 1tb 240hz 16 Negro', 'Laptop Gamer Lenovo Legion 5 16IAX10', 62000.00, 1, 1, 12),
('Impresora HP Smart Tank 210 Sistema Continuo', 'Impresora HP Smart Tank 210 (3D4L3A)
Ideal para uso en el hogar y oficina', 30000.00, 2, 1, 15),
('Impressora térmica Epson TM-T20IV TM-T20IV-SP', 'La Impresora Epson TM-T20IV-SP esta diseñada
para entornos que requieren velocidad,confiabilidad y un rendimiento 
constante', 22000.00, 2, 1, 18),
('Impresora Hp Deskjet Ink Advantage 2975', '100% funcional. - Puede tener consumibles (toner / tinta) parcialmente utilizados o ya instalados.
- Empaque y accesorios originales incluidos', 12000.00, 2, 1, 5),
('Epson 3350 Impresora Multifuncion EcoTank L3350', 'La Epson es una impresora multifunción con sistema de tanque de tinta continuo,
ideal para el hogar y la oficina.', 28000.00, 2, 1, 5),
('Multifuncional Brother Dcpt430w', 'La multifunción Brother DCP-T430W es la elección ideal para quienes buscan
eficiencia y versatilidad en un solo dispositivo.', 32000.00, 2, 1, 8 );
GO

INSERT INTO IMAGEN (IdProducto, ImagenUrl, Estado)
VALUES
(1, 'https://http2.mlstatic.com/D_NQ_NP_2X_845734-MLA112934092297_062026-F.webp', 1),
(2, 'https://http2.mlstatic.com/D_NQ_NP_2X_844495-MLA117829392930_102026-F.webp', 1),
(3, 'https://http2.mlstatic.com/D_NQ_NP_2X_899224-MLA108576942549_032026-F.webp', 1),
(4, 'https://http2.mlstatic.com/D_NQ_NP_2X_793004-MLA97126547262_112025-F.webp', 1),
(5, 'https://http2.mlstatic.com/D_NQ_NP_2X_765298-CBT116262773488_092026-F.webp', 1),
(6, 'https://http2.mlstatic.com/D_NQ_NP_2X_804138-MLA114374992867_072026-F.webp', 1),
(7, 'https://http2.mlstatic.com/D_NQ_NP_2X_816796-MLA98122560087_112025-F.webp',1),
(8, 'https://http2.mlstatic.com/D_NQ_NP_2X_793581-MLA114435498028_082026-F.webp',1),
(9, 'https://http2.mlstatic.com/D_NQ_NP_2X_678386-MLA114848745831_072026-F.webp', 1),
(10, 'https://http2.mlstatic.com/D_NQ_NP_2X_946152-MLA99581037044_122025-F.webp', 1);
GO

INSERT INTO USUARIO (NombreUsuario, Contrasena, IdRol, Estado)
VALUES ('pepeargento@gmail.com', 'asd123', 2, 1),
('luucasarieel@hotmail.com', 'asd123', 1, 1),
('carlosalberto@hotmail.com', 'abc123', 2, 1),
('florenciagutierrez@gmail.com', 'abc123', 2, 1),
('candelafariña@hotmail.com', 'aaa123', 1, 1),
('agustinalujan@gmail.com', 'asd123', 1, 1),
('juandominguez@gmail.com', 'asd123', 2, 1)
GO
INSERT INTO CLIENTE (Nombre, Apellido, Email, Telefono, IdUsuario)
VALUES ('Pepe', 'Argento', 'pepeargento@gmail.com', 88888888, 1),
('Lucas', 'Jakovcevic', 'luucasarieel@hotmail.com', 1168919069, 2),
('Carlos', 'Alberto', 'carlosalberto@hotmail.com', 1111111, 3),
('Florencia', 'Gutierrez', 'florenciagutierrez@gmail.com', 2222222, 4),
('Candela', 'Fariña', 'candelafariña@hotmail.com', 3333333, 5),
('Agustina', 'Lujan', 'agustinalujan@gmail.com', 44444, 6),
('JuanPablo', 'Dominguez', 'juandominguez@gmail.com', 555555, 7)
GO
INSERT INTO DIRECCION (IdCliente, Calle, Numero, Localidad, Provincia, CodigoPostal, Estado)
VALUES (1, 'Francia', 400, 'San Isidro', 'Buenos Aires', '1642', 1),
(1, 'Necochea', 3945, 'Cañuelas', 'Buenos Aires', '1620', 1),
(2, 'Yrigoyen', 433, 'Martinez', 'Buenos Aires', '1645', 1),
(2, 'Rolón', 1717, 'Beccar', 'Buenos Aires', '1643', 1),
(3, 'Dardo Rocha', 500, 'Vicente Lopez', 'Buenos Aires', '1650', 1),
(3, 'Brasil', 1540, 'Olivos', 'Buenos Aires', '1630', 1),
(4, 'Catamarca', 1830, 'Cordoba', 'Cordoba', '2200', 1),
(5, 'Figal', 1711, 'La Pampa', 'La Pampa', '1212', 1),
(5, 'Ecuador', 1500, 'Talquehuen', 'La Pampa', '1211', 1),
(6, 'Blanco Encalada', 1100, 'San Isidro', 'Buenos Aires', '1600', 1),
(7, 'Rio Newen', 2022, 'Cordoba', 'Cordoba Capital', '1414', 1)
GO
INSERT INTO TIPOTARJETA (NombreTipoTarjeta)
VALUES ('Débito'), ('Crédito')
GO
INSERT INTO MARCATARJETA (NombreMarcaTarjeta, Estado)
VALUES ('Visa', 1), ('Mastercard', 1),('American Express', 1)
GO
INSERT INTO TARJETA(IdCliente, NumeroTarjeta, FechaVencimiento, NombreYApellidoTitular, IdTipoTarjeta, IdMarcaTarjeta, Estado)
VALUES (1, '0000 1111 3333', '2026-12-20', 'Pepe Argento', 2, 1, 1),
(2, '1111 2222 3333', '2030-7-28', 'Lucas Jakovcevic', 2, 3, 1),
(2, '2222 3333 4444', '2028-11-10', 'Lucas Jakovcevic', 1, 1, 1),
(3, '3333 4444 5555', '2027-10-30', 'Carlos Alberto', 1, 2, 1),
(3, '4433 5544 6655', '2026-10-10', 'Carlos Alberto', 2, 2, 1),
(4, '4444 5555 6666' , '2028-5-11', 'Florencia Guetierrez', 2, 2, 1),
(4, '5555 6666 7777', '2027-11-12', 'Florencia Guetierrez', 1, 2, 1),
(5, '6666 7777 8888', '2029-2-12', 'Candela Fariña', 2, 1, 1),
(5, '6677 7788 9910', '2026-12-12', 'Candela Fariña', 1, 1, 1),
(6, '7777 8888 9999', '2031-4-8', 'Agustina Lujan', 2, 3, 1),
(6, '7777 8888 8888', '2030-8-8', 'Agustina Lujan', 1, 3, 1),
(7, '8888 9999 1111', '2027-4-4', 'JuanPablo Dominguez', 2, 2, 1),
(7, '1010 1212 1313', '2032-7-7', 'JuanPablo Dominguez', 1, 2, 1)
GO
INSERT INTO ESTADOVENTA (Nombre)
VALUES
    ('Pendiente'),
    ('Pagado'),
    ('En preparación'),
    ('Enviado'),
    ('Entregado'),
    ('Cancelado');
GO

INSERT INTO FORMAENTREGA (Nombre, Estado, RequiereDireccion)
VALUES ('Retiro en el local', 1, 0),
('Envio', 1, 1),
('Punto de encuentro', 1, 1)
GO

INSERT INTO FORMAPAGO (Nombre, Estado)
VALUES ('Efectivo', 1),
('Debito', 1)
GO

ALTER TABLE VENTA
ADD CodigoSeguimiento VARCHAR(100) NULL;