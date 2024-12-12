## Instruções 
1) Criar banco no SQL Server chamado bibliotecadb
2) Criar e executar as migrations, dentro de AuthBiblioteca,
 executar: add-migration "nome" e update-database usando o terminal de pacotes no caso.
Em SistemaBiblioteca, execute:
  Add-Migration InitialCreate -Project Infrastructure -StartupProject SistemaBiblioteca
e depois executar:
 Update-Database -Project Infrastructure -StartupProject SistemaBiblioteca

3) Iniciar os dois projetos AuthBiblioteca e SistemaBiblioteca
