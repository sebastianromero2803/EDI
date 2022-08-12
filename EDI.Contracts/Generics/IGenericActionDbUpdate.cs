
using EDI.Entities.Entities;

namespace EDI.Contracts.Generics
{
    public interface IGenericActionDbUpdate<T> where T : class
    {
        Task<bool> UpdateAsync(string id, T item);
    }
}
