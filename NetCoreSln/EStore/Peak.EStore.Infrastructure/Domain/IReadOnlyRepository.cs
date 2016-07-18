using System.Collections.Generic;
using Peak.EStore.Infrastructure.Querying;

namespace Peak.EStore.Infrastructure.Domain
{

    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count); 
    }
}