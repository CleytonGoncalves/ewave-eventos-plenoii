using Domain.Palestras;
using FluentValidation;

namespace Application.Palestras.DefinirPalestrante
{
    public sealed class DefinirPalestranteCommandValidator : AbstractValidator<DefinirPalestranteCommand>
    {
        public DefinirPalestranteCommandValidator(IPalestraRepository repository)
        {
            RuleFor(x => x.PalestraId)
                .NotEmpty()
                .MustAsync(async (id, cancellationToken) => await repository.Exists(id))
                .WithMessage(Messages.IdNotFound);
        }
    }
}
