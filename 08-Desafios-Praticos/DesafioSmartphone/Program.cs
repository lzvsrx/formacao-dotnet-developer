Smartphone[] celulares=[new Nokia("11999999999","Nokia","111",64),new Iphone("11888888888","Apple","222",128)];
foreach(var celular in celulares){celular.Ligar();celular.ReceberLigacao();celular.InstalarAplicativo("Mapas");}
public abstract class Smartphone(string numero,string modelo,string imei,int memoria) {
 public string Numero {get;}=numero;
 public string Modelo {get;}=modelo;
 public string Imei {get;}=imei;
 public int Memoria {get;}=memoria;
 public void Ligar()=>Console.WriteLine($"Ligando de {Numero}");
 public void ReceberLigacao()=>Console.WriteLine($"Chamada recebida em {Modelo}");
 public abstract void InstalarAplicativo(string nome);
}
public sealed class Nokia(string numero,string modelo,string imei,int memoria):Smartphone(numero,modelo,imei,memoria){public override void InstalarAplicativo(string nome)=>Console.WriteLine($"Nokia: instalando {nome}");}
public sealed class Iphone(string numero,string modelo,string imei,int memoria):Smartphone(numero,modelo,imei,memoria){public override void InstalarAplicativo(string nome)=>Console.WriteLine($"iPhone: instalando {nome}");}
