namespace CP.Domain.Interfaces.Validation
{
    public interface IRule<in TEntity>
    {
        string MessageError { get; }
        bool Validate(TEntity entity);
    }
}
