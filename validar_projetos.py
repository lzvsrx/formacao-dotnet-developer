from pathlib import Path
import subprocess,sys
root=Path(__file__).resolve().parent
projects=sorted(root.rglob("*.csproj"))
print(f"Validando {len(projects)} projetos .NET 10")
failed=[]
for project in projects:
 print(f"\n>>> {project.relative_to(root)}",flush=True)
 result=subprocess.run(["dotnet","build",str(project),"--nologo"],check=False)
 if result.returncode:failed.append(str(project.relative_to(root)))
print("Falhas:",failed)
sys.exit(bool(failed))
