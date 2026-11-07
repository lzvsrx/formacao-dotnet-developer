var notas=new List<double>{8,7.5,10,9}; Console.WriteLine($"Média: {notas.Average():F2}"); foreach(var nota in notas.OrderDescending()) Console.WriteLine(nota);
