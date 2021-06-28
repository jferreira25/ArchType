namespace Projeto.Base.Domain.Interfaces.Tools
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string login);
    }
}