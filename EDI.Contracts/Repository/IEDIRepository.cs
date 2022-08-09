using EDI.Contracts.Generics;
using EDI.Entities.Entities;

namespace EDI.Contracts.Repository
{
    public interface IEDIRepository : IGenericActionDbAdd<X12_315>, IGenericActionDbUpdate<X12_315>, IGenericActionDbQuery<X12_315>
    {
    }
}
