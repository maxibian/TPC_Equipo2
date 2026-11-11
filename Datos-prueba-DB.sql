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

INSERT INTO ESTADOVENTA (Nombre)
VALUES
    ('Pendiente'),
    ('Pagado'),
    ('En preparación'),
    ('Enviado'),
    ('Entregado'),
    ('Cancelado');
GO
