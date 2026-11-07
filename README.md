# Formação .NET Developer — edição .NET 10 LTS (2026)

Projetos de estudo independentes inspirados nos módulos públicos da formação DIO. **Não representam a implementação de todas as 50 atividades**, pois os enunciados autenticados não foram disponibilizados.

## Requisitos
- .NET SDK 10.0.x (estável, LTS)
- Visual Studio compatível com .NET 10 ou VS Code com extensão C#

## Executar
Entre na pasta de um projeto e execute `dotnet restore` e `dotnet run`.
Para executar a API: `dotnet run --project 05-APIs/ApiProdutos/ApiProdutos.csproj`.
Para validar todos os projetos: execute `python validar_projetos.py` na raiz (Python 3.10+).

## Observações
- Todos os `.csproj` foram atualizados para `net10.0` e a linguagem C# 14.
- O arquivo `global.json` solicita SDK 10.0.100 com atualizações de patch.
- SQL Server, MongoDB e Azure exigem configuração externa para integração real.
- Não foram instaladas dependências NuGet nem executada compilação neste ambiente (SDK ausente).
- .NET 11 estava em RC3 em 07/11/2026, portanto não foi adotado.

## Publicar no GitHub

Instale Git e GitHub CLI, abra PowerShell nesta pasta e execute:

```powershell
.\publicar-github.ps1
```

O script autentica pelo GitHub CLI, cria um repositório público na sua conta caso ainda não exista e envia os arquivos. Revise o código antes de publicar.

**Escopo:** este pacote contém 15 projetos didáticos, não todas as atividades da formação. A compilação ainda não foi verificada neste ambiente.

## Desafios adicionais

Seis implementações adicionais em `08-Desafios-Praticos`. Consulte `DESAFIOS_IMPLEMENTADOS.md` para escopo e limitações.
