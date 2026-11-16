--select * from ITEMCARRITO

--select * from PRODUCTO

--SELECT C.IdCarrito, C.IdCliente FROM CARRITO C WHERE C.IdCliente = 1

--SELECT C.IdCarrito, C.IdCliente, IC.IdItemCarrito, IC.IdCarrito, IC.IdProducto, IC.Cantidad  FROM CARRITO C LEFT JOIN ITEMCARRITO IC ON C.IdCarrito = IC.IdCarrito WHERE C.IdCliente = 1  


--SELECT C.IdCarrito, C.IdCliente, IC.IdItemCarrito, IC.IdCarrito, IC.IdProducto, IC.Cantidad, P.Nombre, P.Descripcion, P.Precio, P.IdCategoria, P.Estado, P.Stock  FROM CARRITO C LEFT JOIN ITEMCARRITO IC ON C.IdCarrito = IC.IdCarrito LEFT JOIN PRODUCTO P ON P.IdProducto = IC.IdProducto WHERE C.IdCliente = 1  

--SELECT  P.Nombre, P.Descripcion, P.Precio, P.IdCategoria, IC.Cantidad, P.Stock  FROM CARRITO C LEFT JOIN ITEMCARRITO IC ON C.IdCarrito = IC.IdCarrito LEFT JOIN PRODUCTO P ON P.IdProducto = IC.IdProducto WHERE C.IdCliente = 1  AND P.Estado = 1

--SELECT  P.Nombre, P.Descripcion, P.Precio, CA.Nombre, IC.Cantidad, P.Stock  FROM CARRITO C LEFT JOIN ITEMCARRITO IC ON C.IdCarrito = IC.IdCarrito LEFT JOIN PRODUCTO P ON P.IdProducto = IC.IdProducto LEFT JOIN CATEGORIA CA ON P.IdCategoria = CA.IdCategoria WHERE C.IdCliente = 1  AND P.Estado = 1

SELECT P.Nombre, P.Descripcion, P.Precio, CA.Nombre, IC.Cantidad, P.Stock FROM CARRITO C LEFT JOIN ITEMCARRITO IC ON C.IdCarrito = IC.IdCarrito LEFT JOIN PRODUCTO P ON P.IdProducto = IC.IdProducto LEFT JOIN CATEGORIA CA ON P.IdCategoria = CA.IdCategoria WHERE C.IdCliente = 1 AND P.Estado = 1

SELECT * from ITEMCARRITO