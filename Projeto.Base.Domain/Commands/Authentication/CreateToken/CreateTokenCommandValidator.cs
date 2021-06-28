using FluentValidation;

namespace Projeto.Base.Domain.Commands.Authentication.CreateToken
{
    public class CreateTokenCommandValidator : AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(token => token.Login).NotEmpty().WithMessage("login não pode ser nulo");
            RuleFor(token => token.Password).NotEmpty().WithMessage("senha não pode estar vazia");
        }
    }
}
