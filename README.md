# MELHORIAS A SEREM IMPLEMENTADAS

[x] registrar dependencias como é feita no antigo archType<br>

[ ] positivo/negativo frameworks utilizados ?<br>
[ ] Apresentar oq o antigo tinha / novo tem .<br>
 - Antigo:<br>
	- Arquitetura com alto grau de  acoplamento<br>
	- Serilog<br>
	- Dapper
	- FluentValidation
	- IdentityServer 4
	- Swagger
	- Moq
- Novo:
 - Arquitetura desacoplada utilizando conceitos ddd/cqrs <br>
 - Mediator<br>
 - Dapper<br>
 - Swagger<br>
 - FluentValidation
 - Ideia de packages para ter apenas oque será usado ex: banco oracle / sql/cosmos - mensageria service bus<br>
 - Testes de unidade xUnit com AAA (Arrange, Act, Assert)<br>
 - Moq<br>
 - IdentityServer 4<br>
 ---para implementar---<br>
- Serilog -> qlqr coisa olhar https://conectcar.visualstudio.com/Canais%20Externos/_git/Itau.PedidoTag.API?path=%2FConectcar.Itau.Api%2FConectcar.Itau.Api%2Fappsettings.json<br>
- redis<br>

Vantagens da v2<br>
 - Ajuste no swagger para não precisar passar "bearer" em seu request<br>
 - Melhoria implementação httpRequest onde poderia dar problema de Http socket exception<br>
 - Melhor visualização para possiveis manutenções<br>
[x] identity projeto<br>
[x] colocar filter validation antes de bater no controller ao invés de deixar no command<br>
[x] melhorar httpRequest<br>

[ ] log<br>
[ ] redis<br>
[ ] docker file<br>
[ ] documentação explicando cada ponto (ex: services oq colocar dentro, infra.data oq colocar dentro) doc padronizar chamadas da classe abstrata<br>



