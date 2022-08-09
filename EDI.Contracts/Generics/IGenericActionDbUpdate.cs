
namespace EDI.Contracts.Generics
{
    public interface IGenericActionDbUpdate<T> where T : class
    {
        Task<bool> UpdateAsync(T entity);
    }
}
