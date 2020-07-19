using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Domain.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Converters
{
    public class StronglyTypedIdValueConverterSelector : ValueConverterSelector
    {
        // The dictionary in the base type is private, so we need our own one here.
        private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo> _converters
            = new ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo>();

        public StronglyTypedIdValueConverterSelector(ValueConverterSelectorDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type? providerClrType = null)
        {
            var baseConverters = base.Select(modelClrType, providerClrType);
            foreach (var converter in baseConverters)
                yield return converter;

            var underlyingModelType = UnwrapNullableType(modelClrType)!;
            var underlyingProviderType = UnwrapNullableType(providerClrType);

            // 'null' means 'get any value converters for the modelClrType'
            if (underlyingProviderType is null || underlyingProviderType == typeof(Guid))
            {
                bool isTypedIdValue = typeof(TypedIdBase).IsAssignableFrom(underlyingModelType);

                if (isTypedIdValue)
                {
                    var converterType = typeof(TypedIdValueConverter<>).MakeGenericType(underlyingModelType!);

                    yield return _converters.GetOrAdd((underlyingModelType, typeof(Guid)), _ =>
                    {
                        return new ValueConverterInfo(
                            modelClrType: modelClrType,
                            providerClrType: typeof(Guid),
                            factory: valueConverterInfo => (ValueConverter) Activator.CreateInstance(converterType,
                                valueConverterInfo.MappingHints)!);
                    });
                }
            }
        }

        private static Type? UnwrapNullableType(Type? type) =>
            type is null ? null : Nullable.GetUnderlyingType(type) ?? type;
    }
}
