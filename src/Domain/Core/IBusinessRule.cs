namespace Domain.Core
{
    /// <summary> Define regra de negócio no escopo de um agregado </summary>
    public interface IBusinessRule
    {
        bool IsBroken();
        string Message { get; }
    }
}
