-- Todos os clientes, inclusive os que não possuem pedidos
SELECT c.Id,c.Nome,p.Id AS PedidoId,p.Total FROM Clientes c LEFT JOIN Pedidos p ON p.ClienteId=c.Id ORDER BY c.Nome;
-- Resumo por cliente
SELECT c.Id,c.Nome,COUNT(p.Id) AS Quantidade,COALESCE(SUM(p.Total),0) AS Total FROM Clientes c LEFT JOIN Pedidos p ON p.ClienteId=c.Id GROUP BY c.Id,c.Nome ORDER BY Total DESC;
-- Clientes sem pedidos
SELECT c.* FROM Clientes c WHERE NOT EXISTS(SELECT 1 FROM Pedidos p WHERE p.ClienteId=c.Id);
-- Pedidos acima da média
SELECT p.* FROM Pedidos p WHERE p.Total > (SELECT AVG(Total) FROM Pedidos);
