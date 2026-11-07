CREATE TABLE Clientes (Id INT IDENTITY PRIMARY KEY, Nome NVARCHAR(100) NOT NULL);
CREATE TABLE Pedidos (Id INT IDENTITY PRIMARY KEY, ClienteId INT NOT NULL REFERENCES Clientes(Id), Total DECIMAL(12,2) NOT NULL CHECK (Total>=0));
INSERT INTO Clientes (Nome) VALUES (N'Ana'),(N'João');
INSERT INTO Pedidos(ClienteId,Total) VALUES (1,125.50),(2,80.00);
SELECT c.Nome, SUM(p.Total) AS TotalGasto FROM Clientes c JOIN Pedidos p ON p.ClienteId=c.Id GROUP BY c.Nome;
