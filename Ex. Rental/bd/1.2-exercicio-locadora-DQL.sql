USE M_Rental;
GO

SELECT * FROM empresa 
SELECT * FROM veiculo
SELECT * FROM modelo 
SELECT * FROM marca
SELECT * FROM cliente
SELECT * FROM aluguel 

-- listar todos os alugueis mostrando as datas de início e
-- fim, o nome do cliente que alugou e nome do modelo do carro
SELECT dataRetirada AS 'Data de inicio', dataValidade AS 'Data de fim', cliente.nomeCliente, modelo.nomeModelo FROM aluguel
JOIN cliente on aluguel.idCliente = cliente.idCliente
JOIN veiculo on aluguel.idVeiculo = veiculo.idVeiculo
JOIN modelo on veiculo.idModelo  = modelo.idModelo

--listar os alugueis de um determinado cliente mostrando 
--seu nome, as datas de início e fim e o nome do modelo do carro
SELECT nomeCliente, aluguel.dataRetirada AS 'Data de inicio', aluguel.dataValidade AS 'Data de fim', modelo.nomeModelo FROM cliente
JOIN aluguel on cliente.idCliente = aluguel.idCliente
JOIN veiculo on aluguel.idVeiculo = veiculo.idVeiculo
JOIN modelo on veiculo.idModelo  = modelo.idModelo
WHERE cliente.idCliente = 2;