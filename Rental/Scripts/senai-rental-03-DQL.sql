USE AUTOMOVEIS_TARDE;
GO

SELECT * FROM CLIENTE
SELECT * FROM ALUGUEL
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM EMPRESA

-- SELECT UTILIZANDO JOIN->

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro

SELECT IdAluguel, NomeCliente, NomeModelo, PlacaVeiculo,DataAluguel , DataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
INNER JOIN MODELO
ON MODELO.IdModelo = veiculo.IdModelo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente



-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT IdAluguel, NomeCliente, NomeModelo, PlacaVeiculo,DataAluguel , DataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
INNER JOIN MODELO
ON MODELO.IdModelo = veiculo.IdModelo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente
WHERE NomeCliente = 'Mateus'
