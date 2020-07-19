using Domain.Core;

namespace Domain.SharedKernel
{
    public class ValidEmailFormatRule : IBusinessRule
    {
        private readonly string? _email;

        public ValidEmailFormatRule(string? email)
        {
            _email = email;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_email) || ! _email.Contains('@') || ! _email.Contains('.');

        public string Message => string.Format(Messages.InvalidEmailFormat, _email ?? string.Empty);
    }
}
