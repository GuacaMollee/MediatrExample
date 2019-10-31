namespace Example.Ordering.Domain.SeedWorks.Cqrs
{
    using System.Collections.Generic;

    public abstract class CommandResult<T> : ResultBase<T>
    {
        // ReSharper disable once UnusedMember.Global used by FailFastBehavior
        protected CommandResult()
        {
        }

        protected CommandResult(DomainError error)
            : base(error)
        {
        }

        protected CommandResult(IEnumerable<DomainError> errors)
            : base(errors)
        {
        }

        protected CommandResult(T result, Notifications notifications = null)
            : base(result, notifications)
        {
        }
    }
}
