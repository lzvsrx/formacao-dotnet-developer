var conta=new Conta("Maria",100m);
conta.Depositar(75m);conta.Sacar(40m);
Console.WriteLine($"Titular: {conta.Titular} | Saldo: {conta.Saldo:C}");
foreach(var movimento in conta.Extrato)Console.WriteLine(movimento);
public sealed class Conta {
 private readonly List<string> extrato=[];
 public Conta(string titular,decimal saldoInicial=0){if(string.IsNullOrWhiteSpace(titular)||saldoInicial<0)throw new ArgumentException("Conta inválida");Titular=titular;Saldo=saldoInicial;}
 public string Titular {get;}
 public decimal Saldo {get;private set;}
 public IReadOnlyList<string> Extrato=>extrato.AsReadOnly();
 public void Depositar(decimal valor){if(valor<=0)throw new ArgumentOutOfRangeException(nameof(valor));Saldo+=valor;extrato.Add($"Depósito: {valor:C}");}
 public bool Sacar(decimal valor){if(valor<=0)throw new ArgumentOutOfRangeException(nameof(valor));if(valor>Saldo)return false;Saldo-=valor;extrato.Add($"Saque: {valor:C}");return true;}
}
