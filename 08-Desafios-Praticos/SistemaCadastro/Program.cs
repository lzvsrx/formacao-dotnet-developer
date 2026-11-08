using SistemaCadastro;
var cadastro=new Cadastro(Path.Combine(AppContext.BaseDirectory,"cadastros.json"));
while(true){
 Console.WriteLine("\n1 Cadastrar | 2 Listar | 3 Editar | 4 Excluir | 0 Sair");
 var opcao=Console.ReadLine();if(opcao=="0")break;
 try {
  if(opcao=="1"){Console.Write("Nome: ");var nome=Console.ReadLine()??"";Console.Write("E-mail: ");var email=Console.ReadLine()??"";Console.WriteLine($"Criado: {cadastro.Adicionar(nome,email).Id}");}
  else if(opcao=="2")foreach(var p in cadastro.Listar())Console.WriteLine($"{p.Id} | {p.Nome} | {p.Email}");
  else if(opcao=="3"||opcao=="4"){
   Console.Write("ID: ");if(!Guid.TryParse(Console.ReadLine(),out var id)){Console.WriteLine("ID inválido.");continue;}
   if(opcao=="4")Console.WriteLine(cadastro.Remover(id)?"Excluído.":"Não encontrado.");
   else{Console.Write("Novo nome: ");var nome=Console.ReadLine()??"";Console.Write("Novo e-mail: ");var email=Console.ReadLine()??"";Console.WriteLine(cadastro.Atualizar(id,nome,email)?"Atualizado.":"Não encontrado.");}
  }else Console.WriteLine("Opção inválida.");
 }catch(Exception e)when(e is ArgumentException or InvalidOperationException){Console.WriteLine(e.Message);}
}
