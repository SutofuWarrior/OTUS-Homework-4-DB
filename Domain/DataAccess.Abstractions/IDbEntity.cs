namespace DataAccess.Abstractions
{
    public interface IDbEntity<T>
    {
        T Id { get; set; }
    }
}
