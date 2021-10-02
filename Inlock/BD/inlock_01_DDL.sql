create database inlock_games_manha
go

use inlock_games_manha
go

create table estudio(
idEstudio int primary key identity(1,1),
nomeEstudio varchar(50)
)
go

create table jogo(
idJogo int primary key identity(1,1),
idEstudio int foreign key references estudio(idEstudio),
nomeJogo varchar(70),
descrição varchar(250),
dataLançamento date,
valor money
)
go

create table tipoUsuario(
idTipoUsuario int primary key identity(1,1),
tipo varchar(20)
)
go

create table usuario(
idUsuario int primary key identity(1,1),
idTipoUsuario int foreign key references tipoUsuario(idTipoUsuario),
email varchar(40),
senha varchar(40)
)
go
