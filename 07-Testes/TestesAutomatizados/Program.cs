using ValidacaoETestesUnitarios;
using SistemaCadastro;
int total=0, falhas=0;
void Teste(string nome,Action teste){total++;try{teste();Console.WriteLine($"PASS {nome}");}catch(Exception e){falhas++;Console.WriteLine($"FAIL {nome}: {e.Message}");}}
void Igual<T>(T esperado,T atual){if(!EqualityComparer<T>.Default.Equals(esperado,atual))throw new Exception($"Esperado {esperado}; recebido {atual}");}
Teste("senha forte",()=>Igual(true,Regras.SenhaForte("Abc123!@")));
Teste("senha curta",()=>Igual(false,Regras.SenhaForte("Ab1!")));
Teste("senha sem símbolo",()=>Igual(false,Regras.SenhaForte("Abcdef123")));
Teste("preço total",()=>Igual(59.70m,Regras.CalcularTotal(19.90m,3)));
Teste("quantidade inválida",()=>{try{Regras.CalcularTotal(1,0);throw new Exception("Exceção não lançada");}catch(ArgumentOutOfRangeException){}});
Teste("capacidade",()=>Igual(false,Regras.PodeReservar(2,3)));
Teste("e-mail inválido",()=>Igual("E-mail inválido.",RegrasCadastro.Validar("Maria","errado")));
Teste("cadastro CRUD e unicidade",()=>{
 var arquivo=Path.Combine(Path.GetTempPath(),$"cadastro-test-{Guid.NewGuid()}.json");
 try{var c=new Cadastro(arquivo);var p=c.Adicionar("Maria","maria@teste.com");Igual(1,c.Listar().Count);Igual(true,c.Atualizar(p.Id,"Maria Silva","maria2@teste.com"));
 var recarregado=new Cadastro(arquivo);Igual("Maria Silva",recarregado.Listar()[0].Nome);
 try{recarregado.Adicionar("Outra","maria2@teste.com");throw new Exception("Duplicidade aceita");}catch(InvalidOperationException){}
 Igual(true,recarregado.Remover(p.Id));Igual(0,recarregado.Listar().Count);
 }finally{if(File.Exists(arquivo))File.Delete(arquivo);}
});
Console.WriteLine($"{total-falhas}/{total} testes passaram");
Environment.ExitCode=falhas==0?0:1;
