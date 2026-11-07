using System.Globalization;
var estacionamento = new Estacionamento(5m, 2m);
while (true) {
 Console.WriteLine("1 Cadastrar | 2 Remover | 3 Listar | 0 Sair");
 switch (Console.ReadLine()) {
  case "1": Console.Write("Placa: "); Console.WriteLine(estacionamento.Adicionar(Console.ReadLine() ?? "") ? "Cadastrado" : "Placa inválida ou duplicada"); break;
  case "2": Console.Write("Placa: "); var placa=Console.ReadLine()??""; Console.Write("Horas: ");
   if (!int.TryParse(Console.ReadLine(), out var horas) || horas<=0) {Console.WriteLine("Horas inválidas");break;}
   Console.WriteLine(estacionamento.Remover(placa,horas) is decimal valor ? $"Total: {valor.ToString("C",new CultureInfo("pt-BR"))}" : "Placa não encontrada");break;
  case "3": Console.WriteLine(string.Join(Environment.NewLine,estacionamento.Listar()));break;
  case "0":return;
  default:Console.WriteLine("Opção inválida");break;
 }
}
public sealed class Estacionamento(decimal precoInicial,decimal precoHora) {
 private readonly HashSet<string> placas = new(StringComparer.OrdinalIgnoreCase);
 public bool Adicionar(string placa) {placa=placa.Trim().ToUpperInvariant();return placa.Length is >= 6 and <= 8 && placas.Add(placa);}
 public decimal? Remover(string placa,int horas) {if(horas<=0)throw new ArgumentOutOfRangeException(nameof(horas));return placas.Remove(placa.Trim())?precoInicial+precoHora*horas:null;}
 public IReadOnlyCollection<string> Listar()=>placas.OrderBy(p=>p).ToArray();
}
