namespace Example.Ordering.Domain.SeedWorks.Cqrs
{
    public abstract class QueryResult<T> : ResultBase<T>
    {
        // ReSharper disable once UnusedMember.Global used by FailFastBehavior
        protected QueryResult()
        {
        }

        protected QueryResult(T result, Notifications notifications = null)
            : base(result, notifications)
        {
        }

        protected QueryResult(DomainError error)
            : base(error)
        {
        }
    }
}
