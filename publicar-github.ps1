param([string]$Repositorio = 'formacao-dotnet-developer')
$ErrorActionPreference = 'Stop'
if (-not (Get-Command git -ErrorAction SilentlyContinue)) { throw 'Instale o Git antes de continuar.' }
if (-not (Get-Command gh -ErrorAction SilentlyContinue)) { throw 'Instale o GitHub CLI (gh) antes de continuar.' }
gh auth status
if ($LASTEXITCODE -ne 0) { gh auth login }
if (-not (Test-Path .git)) { git init -b main }
git add .
git diff --cached --quiet
if ($LASTEXITCODE -ne 0) { git commit -m 'feat: projetos da formacao .NET Developer em .NET 10' }
$nome = (gh api user --jq .login).Trim()
$existe = gh repo view "$nome/$Repositorio" --json name 2>$null
if ($LASTEXITCODE -eq 0) {
  git remote remove origin 2>$null
  git remote add origin "https://github.com/$nome/$Repositorio.git"
  git push -u origin main
} else {
  gh repo create "$nome/$Repositorio" --public --source . --remote origin --push --description 'Projetos didaticos da Formacao .NET Developer com .NET 10 e C# 14'
}
Write-Host "Repositorio: https://github.com/$nome/$Repositorio"
