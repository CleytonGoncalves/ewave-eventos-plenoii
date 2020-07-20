using System;
using AutoFixture;
using Domain.SharedKernel;

namespace UnitTests.Core
{
    public class EmailCustomization : ICustomization
    {
        public void Customize(IFixture fixture) =>
            fixture.Register(() => new Email($"{Guid.NewGuid()}@{Guid.NewGuid()}.com"));
    }
}
