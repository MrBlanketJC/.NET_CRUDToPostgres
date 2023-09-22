--Crear tabla manual. Autoincremental ID y primary key
create table empleados(
	idempleados serial primary key,
	idempleados INT GENERATED BY DEFAULT AS IDENTITY primary key,
	apellidos varchar(100),
	nombres varchar(100),
	telefonos varchar(20),
	correo varchar(50),
	provincia varchar(20),
	canton varchar(20),
	direccion varchar(20),
	estado boolean
)

--Insertar Manual
insert into empleados (idempleados, apellidos, nombres, telefonos, correo, provincia, canton, direccion, estado)
values (2, 'Barahona', 'Martin', '0998855663', 'mbarahona@dominio.com', 'Guayas', 'Guayaquil', 'Av. Perimetral N45', true)