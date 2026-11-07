var suite = new Suite("Premium", 2, 150m);
var reserva = new Reserva(suite,12);
reserva.CadastrarHospedes([new Pessoa("Ana"),new Pessoa("João")]);
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor: {reserva.CalcularValorDiaria():C}");
public record Pessoa(string Nome);
public record Suite(string Tipo,int Capacidade,decimal ValorDiaria);
public sealed class Reserva {
 private List<Pessoa> hospedes=[];
 public Reserva(Suite suite,int diasReservados) {if(diasReservados<=0||suite.Capacidade<=0||suite.ValorDiaria<0)throw new ArgumentException("Dados inválidos");Suite=suite;DiasReservados=diasReservados;}
 public Suite Suite {get;}
 public int DiasReservados {get;}
 public void CadastrarHospedes(IEnumerable<Pessoa> pessoas) {var lista=pessoas.ToList();if(lista.Count==0||lista.Count>Suite.Capacidade||lista.Any(p=>string.IsNullOrWhiteSpace(p.Nome)))throw new ArgumentException("Hóspedes inválidos ou capacidade excedida");hospedes=lista;}
 public int ObterQuantidadeHospedes()=>hospedes.Count;
 public decimal CalcularValorDiaria()=>Suite.ValorDiaria*DiasReservados*(DiasReservados>=10?0.90m:1m);
}
