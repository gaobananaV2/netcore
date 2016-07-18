namespace Peak.EStore.Infrastructure.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }

    // the  IRepository interface inherits from the  IReadOnlyRepository , giving it a contract that supports both read and write methods.
}