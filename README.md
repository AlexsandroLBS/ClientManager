# Ploomes Client Management

Desafio teste para o processo seletivo para o cargo de Dessenvolvedor BackEnd C# na [Ploomes](https://www.ploomes.com/). O projeto consiste em uma aplicação para gerenciamento de ordens de pedico, com criação de clientes e fornecedores e criação de ordens utilizando estes. Além disso, cancelamento e finalização de pedidos.

No que diz respeito a padrões de projeto, a aplicação segue o padrão [CQRS](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs) (Command and Query Responsibility Segregation) de forma que as depencias ficam bem segredadas. E para gerenciamento de banco e orientação de dados foi utilizado [Entity Framework](https://learn.microsoft.com/en-us/aspnet/entity-framework)

## Execução

Para executar a aplicação via docker, vá para a raiz do projeto e utlize o comando [Docker Compose](https://docs.docker.com/compose/)
```
docker-compose up 
```

Após execução, a aplicação ficará disponivel em: 
  - http://localhost:5102/swagger/index.html



## Tecnologias utlizadas

- .NET 7.0
- Entity Framework
- SQLServer
- Docker
