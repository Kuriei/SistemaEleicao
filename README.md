# SistemaEleicao
Sistema de eleição em C# com testes unitários xUnit.

# Sistema de Eleição

Sistema de votação desenvolvido em C# com .NET 10, utilizando testes unitários com xUnit.

## Funcionalidades

- Cadastro de candidatos com nome e número.
- Validação para impedir números de candidatos duplicados.
- Cadastro de eleitores utilizando título ou CPF simulado.
- Registro de votos com prevenção de votos duplicados.
- Contabilização de votos válidos, brancos e nulos.
- Apuração dos resultados, identificação do vencedor e de empates.
- Testes automatizados das regras de negócio.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub
- Conventional Commits

## Estrutura do projeto

- `SistemaEleicao.Console`: aplicação principal e regras de negócio.
- `SistemaEleicao.Tests`: testes unitários automatizados.
- `SistemaEleicao.sln`: solução que reúne os projetos.

## Como executar

É necessário ter o SDK do .NET 10 instalado.

Na pasta raiz do projeto, execute:

```bash
dotnet restore SistemaEleicao.sln
dotnet build SistemaEleicao.sln
dotnet run --project SistemaEleicao.Console/SistemaEleicao.Console.csproj
```

## Como executar os testes

Na pasta raiz do projeto, execute:

```bash
dotnet test SistemaEleicao.sln
```

## Regras de votação

- Cada eleitor cadastrado pode votar apenas uma vez.
- O número de cada candidato deve ser único.
- Votos em candidatos inexistentes são contabilizados como nulos.
- O eleitor pode escolher voto branco ou nulo.
- A apuração identifica o vencedor ou os candidatos empatados.

## Autor
Aluno: Cauã Parreiras Vieira
RA: 32516918
Desenvolvido para a atividade acadêmica de Garantia da Qualidade de Software.
