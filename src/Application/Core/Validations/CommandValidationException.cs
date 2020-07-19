using System;

namespace Application.Core.Validations
{
    #pragma warning disable CA1032 // Implement standard exception constructors
    public class InvalidCommandException : Exception
    {
        public string? Details { get; }

        public InvalidCommandException(string message, string? details = null) : base(message)
        {
            Details = details;
        }
    }
    #pragma warning restore CA1032 // Implement standard exception constructors
}
