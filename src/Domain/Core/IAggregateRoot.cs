namespace Domain.Core
{
    /// <summary> Marca a entidade como sendo a raiz de um agregado </summary>
    #pragma warning disable CA1040 // Avoid empty interfaces: Não é problema ao ser usada como marcador compile-time ao invés de definir comportamento
    public interface IAggregateRoot
    {
    }
    #pragma warning restore CA1040 // Avoid empty interfaces
}
