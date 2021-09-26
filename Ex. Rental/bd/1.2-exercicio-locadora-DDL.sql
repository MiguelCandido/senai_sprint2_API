CREATE DATABASE M_Rental;
GO 

USE M_Rental;
GO 

CREATE TABLE empresa(
  idEmpresa INT PRIMARY KEY IDENTITY(1,1),
  nomeEmpresa VARCHAR(30)
);
GO

CREATE TABLE marca(
  idMarca INT PRIMARY KEY IDENTITY(1,1),
  nomeMarca VARCHAR(30) NOT NULL
);
GO

CREATE TABLE modelo(
idModelo INT PRIMARY KEY IDENTITY(1,1),
idMarca INT FOREIGN KEY REFERENCES marca(idMarca),
nomeModelo VARCHAR(30) NOT NULL 
);
GO 

CREATE TABLE veiculo(
idVeiculo INT PRIMARY KEY IDENTITY(1,1),
idModelo INT FOREIGN KEY REFERENCES modelo(idModelo),
idEmpresa INT FOREIGN KEY REFERENCES empresa(idEmpresa),
tipoVeiculo VARCHAR(20) NOT NULL,
placaVeiculo CHAR(7) NOT NULL 
);
GO 

CREATE TABLE cliente(
  idCliente INT PRIMARY KEY IDENTITY(1,1),
  nomeCliente VARCHAR(30) NOT NULL,
  sobrenomeCliente VARCHAR(30) NOT NULL,
  cpfCliente CHAR(11) NOT NULL
);
GO

CREATE TABLE aluguel(
idAluguel INT PRIMARY KEY IDENTITY(1,1),
idCliente INT FOREIGN KEY REFERENCES cliente(idCliente),
idVeiculo INT FOREIGN KEY REFERENCES veiculo(idVeiculo),
dataValidade DATE NOT NULL,
dataRetirada DATE NOT NULL,
valorAluguel MONEY NOT NULL 
);
GO 

