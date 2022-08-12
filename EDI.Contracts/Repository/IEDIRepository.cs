using EDI.Contracts.Generics;
using EDI.Entities.Entities;

namespace EDI.Contracts.Repository
{
    public interface IEDIRepository : IGenericActionDbAdd<Item>, IGenericActionDbUpdate<Item>, IGenericActionDbQuery<Item>
    {
    }
}
