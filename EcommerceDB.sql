CREATE TABLE HISTORIALPEDIDO (
IdHistorial int identity (1,1) primary key not null,
IdPedido int foreign key references Pedido (IdPedido) not null,
IdCliente int foreign key references CLIENTE(IdCliente) not null,
)