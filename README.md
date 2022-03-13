# Desafio Back-End Cidade Alta

## Descrição

API de gerenciamento de código penal do Cidade Alta.

## Tecnologias

- [.NET Core 6](https://nodejs.org/en/)
- [EF Core 6](https://www.typescriptlang.org/)
- [PostgreSQL](https://www.postgresql.org/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Executando a aplicação

Ao executar o projeto, o arquivo `appsettings.Development.json` contém a string de conexão com o banco de dados já preenchida apontando para o container docker do postgres. Se desejar pode modificar essa string para adequar a qualquer banco relacional.
<br>
Para executar o projeto  siga as instruções abaixo.

```bash
# Ambiente de desenvolvimento local
$ docker-compose up -d --build # Para executar o container do banco de dados.
$ dotnet build --project desafio-cda.api # Para buildar os pacotes do projeto.
$ dotnet run --project desafio-cda.api # Para executar o projeto.
```
## Rodando as migrations

O projeto utiliza o EF Core 6 para lidar com conexão e ações no banco e para configurar o banco de dados apropriadamente é necessário rodar as migrations.

```bash
# Rodando as migrations
$ dotnet ef database update --project desafio-cda.api
```

## Swagger

O swagger é funciona na rota `/swagger`. A url local é `https://localhost:7217/swagger/index.html`.

## Contatos

- Autor - [Leonardo Lima Cavalcante](https://github.com/leolimcav)
- [LinkedIn](https://www.linkedin.com/in/leonardo-lima-cavalcante/)
