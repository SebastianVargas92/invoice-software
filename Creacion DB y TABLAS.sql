
--INICIO

------------------------------CREAR BASE DE DATOS-------------------------
CREATE DATABASE BaseUltima
go
use BaseUltima
----------------------------------CREAR TABLAS--------------------------

CREATE TABLE ROLES(
idRol int identity(1,1) primary key,
nombre nvarchar(50)
)
insert into ROLES values('admin')
insert into ROLES values('cajero')

CREATE TABLE USUARIOS(
idUsuario int identity(1,1) primary key,
loginName nvarchar(100) not null,
nombre nvarchar(100) not null,
password nvarchar(100) not null,
email nvarchar(150),
idRol int not null

--RELACIONES
CONSTRAINT RELACION_A_ROL FOREIGN KEY (idRol) REFERENCES ROLES (idRol)
)
insert INTO USUARIOS values ('admin','Supervisor','1234','capchinebra@gmail.com',1)
insert INTO USUARIOS values ('empleado','Cajero','4321','cajero@gmail.com',2)


--select * from USUARIOS where loginName='admin' and password='1234'
--select * from USUARIOS where password='134'


CREATE TABLE GRUPOS(
idGrupo int identity (1,1) Primary key,
nombre nvarchar(100)
)
 insert into GRUPOS values('Varios')
 insert into GRUPOS values('BEBIDAS')
 insert into GRUPOS values('ALMACEN')

CREATE TABLE MARCAS(
idMarca int identity (1,1) Primary key,
nombre nvarchar(100)
)
 insert into MARCAS values('Sin Marca')
 insert into MARCAS values('Coca Cola')

CREATE TABLE IVA(
idIva int identity (1,1) Primary key,
valor float
)
 insert into IVA values (21)
 insert into IVA values (10.5)
 insert into IVA values (0)
 insert into IVA values (27)

CREATE TABLE PROVINCIA(
idProvincia int identity (1,1) Primary key,
provincia nvarchar(50)
)
insert into PROVINCIA values('Mendoza')


CREATE TABLE LOCALIDAD(
id int identity (1,1) Primary key,
localidad nvarchar(50),
idProvincia int

--RELACIONES
CONSTRAINT RELACION_A_PROVINCIA FOREIGN KEY (idProvincia) REFERENCES PROVINCIA (idProvincia)
)
insert into LOCALIDAD values ('Capital',1)

CREATE TABLE DOMICILIO(
idDomicilio int identity(1,1) Primary Key,
calle nvarchar(100),
idLocalidad int

--RELACIONES
CONSTRAINT RELACION_A_LOCALIDAD FOREIGN KEY (idLocalidad) REFERENCES LOCALIDAD (id)

)

insert into DOMICILIO values('-',1)


--select *from PROVINCIA
--select *from LOCALIDAD
--select idDomicilio,calle, LOCALIDAD.localidad, PROVINCIA.provincia 
--from DOMICILIO
--inner join LOCALIDAD on DOMICILIO.idLocalidad = LOCALIDAD.id
--inner join PROVINCIA on LOCALIDAD.idProvincia = PROVINCIA.idProvincia




CREATE TABLE RESPONSABILIDAD(
idResp int identity(1,1) Primary Key,
nombre nvarchar(50)
)

insert into RESPONSABILIDAD values ('Consumidor Final')
insert into RESPONSABILIDAD values ('Responsable Inscripto')
insert into RESPONSABILIDAD values ('Monotriburo')


CREATE TABLE PROVEEDOR(
idProveedor int identity (1,1) Primary key,
razonSocial nvarchar(100),
cuit nvarchar(13),
idDomicilio int,
respIva int,
telefono nvarchar(50),
email nvarchar(100),
contacto nvarchar(100),
saldo money

--RELACIONES
CONSTRAINT RELACION_A_DOMICILIO FOREIGN KEY (idDomicilio) REFERENCES DOMICILIO (idDomicilio),
CONSTRAINT RELACION_A_RESPONSABILIDAD FOREIGN KEY (respIva) REFERENCES RESPONSABILIDAD (idResp),

)

 insert into PROVEEDOR values('Sin Proveedor','20-31221365-0',1,1,'telefono','mail','contacto',0)
 
 
 CREATE TABLE CLIENTE(
idCliente int identity (1,1) Primary key,
nombre nvarchar(100),
cuit nvarchar(13),
idDomicilio int,
respIva int,
telefono nvarchar(50),
email nvarchar(100),
contacto nvarchar(100),
saldo money

--RELACIONES
CONSTRAINT RELACION_A_DOMICILIO_CLI FOREIGN KEY (idDomicilio) REFERENCES DOMICILIO (idDomicilio),
CONSTRAINT RELACION_A_RESPONSABILIDAD_CLI FOREIGN KEY (respIva) REFERENCES RESPONSABILIDAD (idResp),

)


insert into CLIENTE values('Consumidor Final','-',1,1,'-','-','-',0)


CREATE TABLE ARTICULOS(
idArticulo int identity (1,1) primary key,
codigo nvarchar(100) unique,
descripcion nvarchar(100),
costo money,
rentabilidad float,
precio money,
lista2 money,
lista3 money,
iva int,
puntoPedido float,
cantMax float,
stock float,
grup int,
marc int,
prov int,
ultimaModificacion date,
baja bit,
impInterno float

--RELACIONES
CONSTRAINT RELACION_A_GRUPOS FOREIGN KEY (grup) REFERENCES GRUPOS (idGrupo),
CONSTRAINT RELACION_A_MARCAS FOREIGN KEY (marc) REFERENCES MARCAS (idMarca),
CONSTRAINT RELACION_A_PROVEEDOR FOREIGN KEY (prov) REFERENCES PROVEEDOR (idProveedor),
CONSTRAINT RELACION_A_IVA FOREIGN KEY (iva) REFERENCES IVA (idIva)
)

 insert into ARTICULOS values('1','Uno',0,0,0,0,0,1,0,0,0,1,1,1,SYSDATETIME(),0,0)
  insert into ARTICULOS values('2','Dos',0,0,0,0,0,1,0,0,0,1,1,1,SYSDATETIME(),0,0)
   insert into ARTICULOS values('3','Tres',0,0,0,0,0,1,0,0,0,1,1,1,SYSDATETIME(),0,0)
    insert into ARTICULOS values('4','Cuatro',0,0,0,0,0,1,0,0,0,1,1,1,SYSDATETIME(),0,0)
     insert into ARTICULOS values('5','Cinco',0,0,0,0,0,1,0,0,0,1,1,1,SYSDATETIME(),0,0)
      insert into ARTICULOS values('6','Seis',0,0,0,0,0,1,0,0,0,1,1,1,SYSDATETIME(),0,0)



CREATE TABLE FORMA_DE_PAGO(
id int identity(1,1) primary key,
tipo nvarchar(50)
)
insert into FORMA_DE_PAGO values ('Efectivo')
insert into FORMA_DE_PAGO values ('Tarjera')
select *from FORMA_DE_PAGO
 
CREATE TABLE TIPO_FACTURA(
id int identity(1,1) primary key,
tipo nvarchar(50)
)
select * from TIPO_FACTURA
insert into TIPO_FACTURA values ('A')
insert into TIPO_FACTURA values ('B')
insert into TIPO_FACTURA values ('C')

 
CREATE TABLE FACTURAS(
id int identity (1,1)primary key not null,
numero int not null,
idTipoFactura int not null,
fecha date not null,
idCliente int not null,
idUsuario int not null,
neto money,
iva money,
total money,
descuento money,
idFormaDePago int,
cancelada bit,


CONSTRAINT RELACION_A_CLIENTE FOREIGN KEY (idCliente) REFERENCES CLIENTE (idCliente),
CONSTRAINT RELACION_A_USUARIOS FOREIGN KEY (idUsuario) REFERENCES USUARIOS (idUsuario),
CONSTRAINT RELACION_A_FORMA_DE_PAGO FOREIGN KEY (idFormaDePago) REFERENCES FORMA_DE_PAGO (id),
CONSTRAINT RELACION_A_TIPO_FACTURA FOREIGN KEY (idTipoFactura) REFERENCES TIPO_FACTURA (id)


)
go 

 select idArticulo, codigo, descripcion,costo, rentabilidad, precio, lista2,lista3,IVA.valor, baja
 from ARTICULOS 
 inner join GRUPOS on ARTICULOS.grup = GRUPOS.idGrupo
 inner join MARCAS on ARTICULOS.marc = MARCAS.idMarca
 inner join PROVEEDOR on ARTICULOS.prov = PROVEEDOR.idProveedor
 inner join IVA on ARTICULOS.iva = IVA.idIva
 
 select *from FACTURAS
 insert into FACTURAS values(0001,1,SYSDATETIME(),1,1,0,0,0,0,1,0)
  insert into FACTURAS values(0002,1,SYSDATETIME(),1,1,0,0,0,0,1,0)
  insert into FACTURAS values(0003,1,SYSDATETIME(),1,1,0,0,0,0,1,0)
 
select FACTURAS.id,numero,TIPO_FACTURA.id, TIPO_FACTURA.tipo, fecha, CLIENTE.idCliente, CLIENTE.nombre, USUARIOS.idUsuario,USUARIOS.nombre, neto,iva,total,descuento,FORMA_DE_PAGO.id,FORMA_DE_PAGO.tipo,cancelada
from FACTURAS
inner join TIPO_FACTURA on FACTURAS.idTipoFactura = TIPO_FACTURA.id
inner join CLIENTE on FACTURAS.idCliente = CLIENTE.idCliente
inner join USUARIOS on FACTURAS.idUsuario = USUARIOS.idUsuario
inner join FORMA_DE_PAGO on FACTURAS.idFormaDePago = FORMA_DE_PAGO.id



CREATE TABLE FACTURA_DETALLE(
id int identity (1,1)primary key not null,
idFactura int not null,
idArticulo int not null,
precioVenta money not null,
cantidad float,
subTotal money

CONSTRAINT RELACION_A_FACTURA FOREIGN KEY (idFactura) REFERENCES FACTURAS (id),
CONSTRAINT RELACION_A_ARTICULO FOREIGN KEY (idArticulo) REFERENCES ARTICULOS (idArticulo),


)
insert into FACTURA_DETALLE values (1,3,1,100,000)

BEGIN
insert into FACTURA_DETALLE values (2,2,50,5,250)
Begin
update ARTICULOS set stock = stock - 1 where ARTICULOS.idArticulo = 2

END
END

select * from ARTICULOS
select * from FACTURA_DETALLE

--select FACTURAS.id, FACTURAS.numero,ARTICULOS.idArticulo, ARTICULOS.codigo, ARTICULOS.descripcion, ARTICULOS.precio, cantidad, subTotal 
--from FACTURA_DETALLE
--inner join FACTURAS on FACTURAS.id = FACTURA_DETALLE.idFactura
--inner join ARTICULOS on ARTICULOS.idArticulo = FACTURA_DETALLE.idArticulo
---where idFactura = 3


---select * from FACTURA_DETALLE where idFactura = 2

select * from USUARIOS




CREATE TABLE COMPRAS(
id int identity (1,1)primary key not null,
puntoDeVenta int not null,
numero int not null,
idTipoFactura int not null,
fecha date not null,
idProveedor int not null,
idUsuario int not null,
neto money,
iva money,
total money,
descuento money,
idFormaDePago int,
cancelada bit,


CONSTRAINT RELACION_A_PROVEEDOR_COM FOREIGN KEY (idProveedor) REFERENCES PROVEEDOR (idProveedor),
CONSTRAINT RELACION_A_USUARIOS_COM FOREIGN KEY (idUsuario) REFERENCES USUARIOS (idUsuario),
CONSTRAINT RELACION_A_FORMA_DE_PAGO_COM FOREIGN KEY (idFormaDePago) REFERENCES FORMA_DE_PAGO (id)



)
go 

CREATE TABLE COMPRA_DETALLE(
id int identity (1,1)primary key not null,
idCompra int not null,
idArticulo int not null,
precioVenta money not null,
cantidad float,
subTotal money

CONSTRAINT RELACION_A_COMPRAS FOREIGN KEY (idCompra) REFERENCES COMPRAS (id),
CONSTRAINT RELACION_A_ARTICULO_COMP FOREIGN KEY (idArticulo) REFERENCES ARTICULOS (idArticulo)

)

--FIN

select * from COMPRAS
insert into COMPRAS values (1,1,1,SYSDATETIME(),1,1,10,10,10,0,1,0)


-----------PRUEBAS VARIAS-----------



SELECT * from 




 drop table ARTICULOS
 delete from ARTICULOS
 
 SELECT SYSDATETIME(); 
 SELECT CONVERT (date, SYSDATETIME())


                
 select * from ARTICULOS where baja = 0 order by CAST(codigo AS INT) ASC 
 select * from GRUPOS
 select * from MARCAS
 select * from PROVEEDOR
 select * from IVA
 select * from LOCALIDAD
 select * from PROVINCIA 
 select * from FORMA_DE_PAGO
 select * from CLIENTE
 select * from RESPONSABILIDAD
 select * from TIPO_FACTURA
 
  select * from USUARIOS
  
  select * from FACTURAS
 select * from FACTURA_DETALLE where idFactura = 1
 select * from FACTURAS where id = 1
 
 
  delete from FACTURAS where id = 8
  delete from FACTURA_DETALLE
  delete from FACTURAS
 
 
 select idArticulo, codigo, descripcion,costo, rentabilidad, precio, lista2,lista3,IVA.valor, baja
 from ARTICULOS 
 inner join GRUPOS on ARTICULOS.grup = GRUPOS.idGrupo
 inner join MARCAS on ARTICULOS.marc = MARCAS.idMarca
 inner join PROVEEDOR on ARTICULOS.prov = PROVEEDOR.idProveedor
 inner join IVA on ARTICULOS.iva = IVA.idIva
 where baja = 0 order by CAST(codigo AS INT) ASC 


update Articulos set codigo=-(idArticulo), baja=1 where idArticulo = 20

---PROVEEDOR
select idProveedor, razonSocial, cuit,DOMICILIO.idDomicilio, DOMICILIO.calle,LOCALIDAD.id, LOCALIDAD.localidad,PROVINCIA.idProvincia, PROVINCIA.provincia,RESPONSABILIDAD.idResp, RESPONSABILIDAD.nombre, email,telefono,contacto,saldo
from PROVEEDOR
inner join RESPONSABILIDAD on PROVEEDOR.respIva = RESPONSABILIDAD.idResp
inner join DOMICILIO on PROVEEDOR.idDomicilio = DOMICILIO.idDomicilio
inner join LOCALIDAD on LOCALIDAD.id = DOMICILIO.idLocalidad
inner join PROVINCIA on PROVINCIA.idProvincia = LOCALIDAD.idProvincia

select * from PROVEEDOR

-----CLIENTE
select idCliente, CLIENTE.nombre, cuit,DOMICILIO.idDomicilio, DOMICILIO.calle,LOCALIDAD.id, LOCALIDAD.localidad,PROVINCIA.idProvincia, PROVINCIA.provincia,RESPONSABILIDAD.idResp, RESPONSABILIDAD.nombre, email,telefono,contacto,saldo
from CLIENTE
inner join RESPONSABILIDAD on CLIENTE.respIva = RESPONSABILIDAD.idResp
inner join DOMICILIO on CLIENTE.idDomicilio = DOMICILIO.idDomicilio
inner join LOCALIDAD on LOCALIDAD.id = DOMICILIO.idLocalidad
inner join PROVINCIA on PROVINCIA.idProvincia = LOCALIDAD.idProvincia

