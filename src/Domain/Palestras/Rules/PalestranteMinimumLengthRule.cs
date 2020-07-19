using Domain.Core;

namespace Domain.Palestras.Rules
{
    public class PalestranteMinimumLengthRule : IBusinessRule
    {
        public const int MIN_LENGTH = 3;
        private readonly string? _palestrante;

        public PalestranteMinimumLengthRule(string? palestrante)
        {
            _palestrante = palestrante;
        }

        public bool IsBroken() => _palestrante == null || _palestrante.Length < MIN_LENGTH;

        public string Message => string.Format(Messages.PalestranteMinimumLengthError, MIN_LENGTH);
    }
}
