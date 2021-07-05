# MELHORIAS A SEREM IMPLEMENTADAS

[x] registrar dependencias como é feita no antigo archType

[ ] positivo/negativo frameworks utilizados ?
[ ] Apresentar oq o antigo tinha / novo tem .
 - Antigo:
	- Arquitetura com alto grau de  acoplamento
	- Serilog
	- Dapper
	- FluentValidation
	- IdentityServer 4
	- Swagger
- Novo:
 - Arquitetura desacoplada utilizando conceitos ddd/cqrs
 - Mediator
 - Dapper
 - Swagger
 - FluentValidation
 - Ideia de packages para ter apenas oque será usado ex: banco oracle / sql/cosmos - mensageria service bus
 - Testes de unidade xUnit
 ---para implementar---
- IdentityServer 4
- Serilog
- redis

Vantagens da v2
 - Ajuste no swagger para não precisar passar "bearer" em seu request
 - Melhoria implementação httpRequest onde poderia dar problema de Http socket exception
 - Melhor visualização para possiveis manutenções
[ ] identity projeto
[X] colocar filter validation antes de bater no controller ao invés de deixar no command
[ ] log
[ ] redis
[ ] docker file
[ ] documentação explicando cada ponto (ex: services oq colocar dentro, infra.data oq colocar dentro) doc padronizar chamadas da classe abstrata
[x] melhorar httpRequest



