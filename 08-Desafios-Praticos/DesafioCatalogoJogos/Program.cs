var catalogo=new Catalogo();catalogo.Adicionar(new Jogo(1,"Hollow Knight","Metroidvania"));catalogo.Adicionar(new Jogo(2,"Stardew Valley","Simulação"));
foreach(var jogo in catalogo.Buscar("valley"))Console.WriteLine($"{jogo.Id}: {jogo.Nome} - {jogo.Genero}");
public record Jogo(int Id,string Nome,string Genero);
public sealed class Catalogo {
 private readonly Dictionary<int,Jogo> jogos=[];
 public void Adicionar(Jogo jogo){if(jogo.Id<=0||string.IsNullOrWhiteSpace(jogo.Nome)||string.IsNullOrWhiteSpace(jogo.Genero))throw new ArgumentException("Jogo inválido");if(!jogos.TryAdd(jogo.Id,jogo))throw new InvalidOperationException("ID duplicado");}
 public bool Remover(int id)=>jogos.Remove(id);
 public IEnumerable<Jogo> Buscar(string termo)=>jogos.Values.Where(j=>j.Nome.Contains(termo,StringComparison.OrdinalIgnoreCase)).OrderBy(j=>j.Nome);
 public IEnumerable<Jogo> Listar()=>jogos.Values.OrderBy(j=>j.Id);
}
