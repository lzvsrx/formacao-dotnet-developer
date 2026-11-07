var calc=new Calculadora();
Console.WriteLine(calc.Somar(4,5));Console.WriteLine(calc.Subtrair(9,3));Console.WriteLine(calc.Multiplicar(2,8));Console.WriteLine(calc.Dividir(10,2));
Console.WriteLine(string.Join("\n",calc.Historico));
public sealed class Calculadora {
 private readonly List<string> historico=[];
 public IReadOnlyList<string> Historico=>historico.AsReadOnly();
 private decimal Registrar(decimal a,string operacao,decimal b,decimal resultado){historico.Add($"{a} {operacao} {b} = {resultado}");return resultado;}
 public decimal Somar(decimal a,decimal b)=>Registrar(a,"+",b,a+b);
 public decimal Subtrair(decimal a,decimal b)=>Registrar(a,"-",b,a-b);
 public decimal Multiplicar(decimal a,decimal b)=>Registrar(a,"*",b,a*b);
 public decimal Dividir(decimal a,decimal b)=>Registrar(a,"/",b,b==0?throw new DivideByZeroException():a/b);
}
