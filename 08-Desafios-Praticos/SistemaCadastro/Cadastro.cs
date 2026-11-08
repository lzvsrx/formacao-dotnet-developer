using System.Text.Json;
namespace SistemaCadastro;
public record Pessoa(Guid Id, string Nome, string Email);
public static class RegrasCadastro {
 public static string? Validar(string? nome,string? email) {
  if(string.IsNullOrWhiteSpace(nome)||nome.Trim().Length<2) return "Nome deve ter ao menos 2 caracteres.";
  if(string.IsNullOrWhiteSpace(email)||!System.Text.RegularExpressions.Regex.IsMatch(email,@"^[^\s@]+@[^\s@]+\.[^\s@]+$")) return "E-mail inválido.";
  return null;
 }
}
public class Cadastro {
 readonly string caminho;
 readonly List<Pessoa> pessoas;
 public Cadastro(string caminho) {
  this.caminho=caminho;
  pessoas=File.Exists(caminho)?JsonSerializer.Deserialize<List<Pessoa>>(File.ReadAllText(caminho))??new():new();
 }
 void Salvar(){Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(caminho))!);File.WriteAllText(caminho,JsonSerializer.Serialize(pessoas,new JsonSerializerOptions{WriteIndented=true}));}
 public IReadOnlyList<Pessoa> Listar()=>pessoas.AsReadOnly();
 public Pessoa Adicionar(string nome,string email){
  var erro=RegrasCadastro.Validar(nome,email);if(erro!=null)throw new ArgumentException(erro);
  if(pessoas.Any(p=>p.Email.Equals(email.Trim(),StringComparison.OrdinalIgnoreCase)))throw new InvalidOperationException("E-mail já cadastrado.");
  var p=new Pessoa(Guid.NewGuid(),nome.Trim(),email.Trim());pessoas.Add(p);Salvar();return p;
 }
 public bool Atualizar(Guid id,string nome,string email){
  var erro=RegrasCadastro.Validar(nome,email);if(erro!=null)throw new ArgumentException(erro);
  var i=pessoas.FindIndex(p=>p.Id==id);if(i<0)return false;
  if(pessoas.Any(p=>p.Id!=id&&p.Email.Equals(email.Trim(),StringComparison.OrdinalIgnoreCase)))throw new InvalidOperationException("E-mail já cadastrado.");
  pessoas[i]=pessoas[i] with {Nome=nome.Trim(),Email=email.Trim()};Salvar();return true;
 }
 public bool Remover(Guid id){var ok=pessoas.RemoveAll(p=>p.Id==id)>0;if(ok)Salvar();return ok;}
}
