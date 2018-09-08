CREATE DATABASE LibrosBibliaDb
GO
USE LibrosBibliaDb
GO
CREATE TABLE LibrosBiblia
(
	LibroId int primary key identity,
	Descripcion varchar(50),
	Siglas varchar(10),
	TipoId varchar(20)

);
