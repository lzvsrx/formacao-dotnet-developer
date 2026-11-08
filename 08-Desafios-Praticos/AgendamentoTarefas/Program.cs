using System.Text.Json;
using System.Globalization;
record Tarefa(Guid Id, string Titulo, DateTimeOffset Prazo, int Prioridade, bool Concluida);
var arquivo = Path.Combine(AppContext.BaseDirectory,"tarefas.json");
List<Tarefa> tarefas;
try { tarefas = File.Exists(arquivo) ? JsonSerializer.Deserialize<List<Tarefa>>(File.ReadAllText(arquivo)) ?? new() : new(); }
catch (JsonException) { Console.Error.WriteLine("Arquivo JSON inválido."); return; }
void Salvar() => File.WriteAllText(arquivo,JsonSerializer.Serialize(tarefas,new JsonSerializerOptions{WriteIndented=true}));
while(true) {
 Console.WriteLine("\n1 Adicionar | 2 Listar | 3 Concluir | 4 Excluir | 0 Sair");
 switch(Console.ReadLine()?.Trim()) {
  case "1":
   Console.Write("Título: "); var titulo=Console.ReadLine()?.Trim();
   if(string.IsNullOrWhiteSpace(titulo)){Console.WriteLine("Título obrigatório.");break;}
   Console.Write("Prazo (yyyy-MM-dd HH:mm): ");
   if(!DateTime.TryParseExact(Console.ReadLine(),"yyyy-MM-dd HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None,out var data)){Console.WriteLine("Data inválida.");break;}
   Console.Write("Prioridade (1-5): ");
   if(!int.TryParse(Console.ReadLine(),out var prio)||prio is <1 or >5){Console.WriteLine("Prioridade inválida.");break;}
   tarefas.Add(new(Guid.NewGuid(),titulo,new DateTimeOffset(data),prio,false));Salvar();Console.WriteLine("Cadastrada.");break;
  case "2":
   foreach(var t in tarefas.OrderBy(t=>t.Concluida).ThenBy(t=>t.Prazo))
    Console.WriteLine($"{t.Id} | {t.Titulo} | {t.Prazo:yyyy-MM-dd HH:mm zzz} | P{t.Prioridade} | {(t.Concluida?"Concluída":t.Prazo<DateTimeOffset.Now?"ATRASADA":"Pendente")}");
   break;
  case "3": case "4":
   var excluir = false; // opção é lida novamente abaixo via menu de operação
   Console.Write("ID: ");
   if(!Guid.TryParse(Console.ReadLine(),out var id)){Console.WriteLine("ID inválido.");break;}
   var i=tarefas.FindIndex(t=>t.Id==id);
   if(i<0){Console.WriteLine("Não encontrada.");break;}
   Console.Write("Digite C para concluir ou E para excluir: ");excluir=string.Equals(Console.ReadLine(),"E",StringComparison.OrdinalIgnoreCase);
   if(excluir) tarefas.RemoveAt(i);else tarefas[i]=tarefas[i] with { Concluida=true };
   Salvar();Console.WriteLine("Atualizada.");break;
  case "0": return;
  default: Console.WriteLine("Opção inválida.");break;
 }
}
