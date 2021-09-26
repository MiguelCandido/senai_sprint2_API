USE M_Rental;
GO

INSERT INTO empresa (nomeEmpresa)
VALUES ('LocaNai'), ('SeDora');

INSERT INTO marca (nomeMarca)
VALUES ('Chevrolet'), ('Honda');

INSERT INTO modelo(idMarca,nomeModelo)
VALUES (1, 'Opala diplomata'), (2, 'PCX 150');

INSERT INTO veiculo(idEmpresa,idModelo,tipoVeiculo,placaVeiculo)
VALUES (1,2,'moto','BOY1234'), (2,1,'carro','MCB2901');

INSERT INTO cliente(nomeCliente,sobrenomeCliente,cpfCliente)
VALUES ('Thiago','Nascimento',11223344551),('Odirlei','Sabella',11223344552),('Paulo','Brandão',11223344553);

INSERT INTO aluguel(idCliente,idVeiculo,dataRetirada,dataValidade,valorAluguel)
VALUES (2,1,DATEFROMPARTS(2021,03,01),DATEFROMPARTS(2021,03,12),75.00), (3,2,DATEFROMPARTS(2021,06,01),DATEFROMPARTS(2021,06,09),105.00), (1,2,DATEFROMPARTS(2021,07,25),DATEFROMPARTS(2021,08,02),105.00);