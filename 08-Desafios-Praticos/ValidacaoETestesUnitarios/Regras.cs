namespace ValidacaoETestesUnitarios;
public static class Regras {
 public static bool SenhaForte(string? senha) => senha is {Length: >=8} && senha.Any(char.IsUpper) && senha.Any(char.IsLower) && senha.Any(char.IsDigit) && senha.Any(c=>!char.IsLetterOrDigit(c));
 public static decimal CalcularTotal(decimal preco,int quantidade) {
  if(preco<0)throw new ArgumentOutOfRangeException(nameof(preco));
  if(quantidade<=0)throw new ArgumentOutOfRangeException(nameof(quantidade));
  return checked(preco*quantidade);
 }
 public static bool PodeReservar(int capacidade,int hospedes)=>capacidade>0&&hospedes>0&&hospedes<=capacidade;
}
