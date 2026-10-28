USE Ecommerce_DB;
GO

INSERT INTO CATEGORIA(Nombre, Estado)
VALUES('Computación',1),('Impresión', 1);

INSERT INTO IMAGEN(ImagenUrl)
VALUES('https://http2.mlstatic.com/D_NQ_NP_2X_845734-MLA112934092297_062026-F.webp'),
('https://http2.mlstatic.com/D_NQ_NP_2X_844495-MLA117829392930_102026-F.webp'),
('https://http2.mlstatic.com/D_NQ_NP_2X_899224-MLA108576942549_032026-F.webp'),
('https://http2.mlstatic.com/D_NQ_NP_2X_793004-MLA97126547262_112025-F.webp'),
('https://http2.mlstatic.com/D_NQ_NP_2X_765298-CBT116262773488_092026-F.webp');

INSERT INTO PRODUCTO(Nombre, Descripcion, Precio, IdCategoria, Estado, Stock, IdImagen)
VALUES('Notebook Lenovo IdeaPad Slim 3',
'Descubrí una nueva dimensión de eficiencia diaria
y portabilidad absoluta con la Lenovo IdeaPad Slim 3.', 50.000, 1, 1, 20, 1),
('Notebook Asus Vivobook Go 15 Ryzen 5','La Asus Vivobook Go 15 combina un diseño liviano
con un desempeño ágil para el ritmo diario.', 45.000, 1, 1, 25, 2),
('Notebook HP 15 con Procesador Intel Core 3', 'Tu compañera para todo
Laptop HP 15, tu compañera para todo lo que haces', 48.000, 1, 1, 15, 3),
('Notebook Acer Aspire Lite Al14-32p-38h9', 'NOTEBOOK ACER ASPIRE LITE 14 CI3 N355', 37.000, 1, 1, 10, 4),
('Legion 5 Ultra 9 Rtx 5060 32gb 1tb 240hz 16 Negro', 'Laptop Gamer Lenovo Legion 5 16IAX10', 62.000, 1, 1, 12, 5);