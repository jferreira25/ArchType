#ArchType V2
**O que já existe ?**
 - Dapper
 - FluentValidation
 - IdentityServer 4

**O que há de novo **

 - Arquitetura desacoplada utilizando conceitos ddd/cqrs 
 - Melhorias Swagger
 - Ideia de packages para ter apenas oque será usado ex: banco oracle / sql/cosmos - mensageria service bus
 - Testes de unidade xUnit com AAA (Arrange, Act, Assert)<br>
 - Moq
 - Melhoria Serilog
 - Redis
 - Melhoria implementação httpRequest onde poderia dar problema de Http socket exception
 - Ajuste no swagger para não precisar passar "bearer" em seu request deixando requisições padronizadas
 
 **Vantagens**
 
 - Response padrão para todas futuras aplicações
 - Melhor visualização para possiveis manutenções
 - Menor acoplamento pensando em sistemas distribuidos além de utilizar redis ao invés de memoryCache
 
 **Implementações A serem feitas**
 
 - Redis
 - Serilog
 - Docker file
 
 
##Conhendo sua estrutura

![alt text](EstruturaGeral.png)

A proposta de estrutura é subdividida em 5 pastas
1 - Presentation : onde de fato fica nossa aplicação seja ela api/function/windows service...
2 - Domain : Toda a regra de negócio fica desacoplada nessa sessão, tendo nossos patterns cqrs/ddd/solid
3 - Infrastructure: Toda comunicação externa  está associada a nossa infra seja elas:
 - banco de dados (não relacional ou relacional)
 - serviços externos como chamada api de CEP
 - consumir ou publicar eventos (serviceBus)
4 - Crosscutting: toda dependencia que poderá ser  usado em qualquer uma das pastas ficaria acoplada diretamente na nossa pasta cross 
ex:
 - AppSettings consumida em toda parte da aplicação
 - Extensios
 - Transaction
 5 - Tests: nela é contida nossos testes de unidade integração e compartilhamento