![Heroku](https://heroku-badges.herokuapp.com/?app=desafiotecnico-palestras)
# Gerenciador de Palestras

Dado o tempo curto e o escopo grande do projeto, optei por focar em dar apenas alguns exemplos de cada parte que acreditei ser importante. Por exemplo, ao invés de implementar vários CRUDs (que variam pouco entre em si e não demonstram muito), implementei algumas poucas funcionalidades porém cada uma demonstrando diferentes capacidades internas do sistema.

## Arquitetura

Baseada nos princípios da **Clean Architecture** (simplificada), movida a partir de **Use Cases**. Ela se encaixa muito bem com os princípios do DDD. Acho importante enfatizar que não é a tradicional arquitetura em camadas (N-Layer Architecture, em que a Infra é a base de tudo). Aqui, a base de tudo é a Domain, seguido da Application, juntas formando o **Core** da aplicação.
![](https://www.methodsandtools.com/archive/onion11.jpg)

## Considerações

### CQRS
**Write Model**: DDD com EF Core.

**Read Model**: executando raw SQL no banco (com Dapper). Comumente a demanda por leituras é muito maior que a demanda por escritas, então essa forma de Read Model separada de toda a complexidade inerente a escrita permite uma performance muito maior. Algumas implementações utilizam dynamic objects como resultado, mas optei por usar um view model estático para maior segurança.

![](https://i.imgur.com/80W4hyv.jpg)

### DDD
**Value Objects**: Algumas implementações definem a maior parte das propriedades como value objects (ex: ao invés de se ter uma propriedade `public string PalestranteNome { get; }`, teria
 `public Nome PalestranteNome { get; }`. As vantagens são várias, mas devido ao tempo defini apenas algumas de exemplo, como `Email` e os ids das entidades.
 
**Aggregate Roots**: Defini `Palestra` e `Funcionário` como aggregate roots, pois é em torno deles que gira toda a funcionalidade do sistema. Eles que garantem a consistência dos dados e encapsulam os comportamento dentro de seu contexto.

**Services**: Operações ou lógicas de negócio que não se encaixam no contexto de um único objeto. Fiz eles individuais (ao invés de uma grande classe só chamada service). Por exemplo: Uma palestra só deve ser criada se o local estiver disponível no período requisitado. É uma lógica de negócio, mas que vai além do escopo de uma única entidade. Comumente essa regra seria checada na Application (command handler, por exemplo), porém optei por passá-la para a Domain (constructor da entidade), para que assim SEMPRE que uma nova entidade for criada, a regra seja checada. Se isso fosse feito no command handler, seria possível esquecer de checá-la caso outro command handler também criasse palestras.

**Domain Events**: São disparados logo antes do SaveChanges, para que tudo que dependa dele entre como parte da mesma transação.

**Domain Notification**: Também é chamado de **Integration Event**.  É o mesmo domain event, mas realizado APÓS  o SaveChanges. É ele que notifica quem depende do sucesso da transação, como enviar email ao chefe para confirmar a participação do funcionário na palestra.

## Outros
- REST API com Swagger e Versionamento de API
- Banco de dados code-first (migrations) com PostgreSQL
- Unit of Work com disparo automático de eventos / notificações
- Conversão automática dos values objects no EF
- Pipelines de logging e validação automáticos com MediatR e FluentValidation
- Agendamento de Jobs com HangFire (ex: envio de email  p/ o organizador uma semana antes do evento)
- Docker (com Compose p/ integrar com o contêiner do banco)
- CI/CD no Heroku
- Logging com Serilog
- Testes unitários do domínio com AutoFixture, Moq, e FluentAssertions

### CI/CD
O projeto possui CI/CD com deploy no Heroku utilizando Docker:

[Swagger](https://desafiotecnico-palestras.herokuapp.com/index.html)

[Hangfire Dashboard](https://desafiotecnico-palestras.herokuapp.com/hangfire)

### Como rodar o projeto localmente

Opção 1. Docker: Na raiz da solution, execute no terminal `docker-compose run`. Pode ser que demore um pouquinho, mas será apenas na primeira execução enquanto o docker inicializa os contêineres.

Opção 2. VS/Rider/CLI do dotnet: exige PostgreSQL e deve ser configurado a connection string no `appSettings.json`.
