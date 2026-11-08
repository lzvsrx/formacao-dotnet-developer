using ValidacaoETestesUnitarios;
Console.WriteLine($"Senha válida: {Regras.SenhaForte("Abc123!@")}");
Console.WriteLine($"Pedido: {Regras.CalcularTotal(19.90m,3):F2}");
Console.WriteLine($"Reserva: {Regras.PodeReservar(4,3)}");
