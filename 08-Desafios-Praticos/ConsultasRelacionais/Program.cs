using System;
using System.Collections.Generic;
using System.Linq;
record Cliente(int Id, string Nome);
record Pedido(int Id, int ClienteId, decimal Total);
var clientes = new[] { new Cliente(1,"Ana"), new Cliente(2,"Bruno"), new Cliente(3,"Carla") };
var pedidos = new[] { new Pedido(101,1,120m), new Pedido(102,1,80m), new Pedido(103,2,50m) };
var consulta = from c in clientes
               join p in pedidos on c.Id equals p.ClienteId into grupo
               select new { c.Nome, Quantidade = grupo.Count(), Total = grupo.Sum(p => p.Total) };
foreach(var linha in consulta.OrderByDescending(x=>x.Total))
    Console.WriteLine($"{linha.Nome}: {linha.Quantidade} pedidos; R$ {linha.Total:F2}");
