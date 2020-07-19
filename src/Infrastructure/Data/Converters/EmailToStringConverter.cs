using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Converters
{
    public class EmailToStringConverter : ValueConverter<Email, string>
    {
        public EmailToStringConverter(ConverterMappingHints? mappingHints = null)
            : base(email => email.ToString(), value => new Email(value), mappingHints)
        {
        }
    }
}
