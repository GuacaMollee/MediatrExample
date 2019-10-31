namespace Example.Ordering.Domain.SeedWorks.Cqrs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;

    public abstract class ResultBase<T> : INotificationsPublisher, IFailable
    {
        private readonly Notifications _notifications;
        private readonly List<DomainError> _errors = new List<DomainError>();

        public T Result { get; }

        public IEnumerable<DomainError> Errors => _errors;

        public bool HasError => _errors.Any();

        protected ResultBase()
        {
        }

        protected ResultBase(T result, Notifications notifications)
        {
            Result = result;
            _notifications = notifications;
        }

        protected ResultBase(DomainError error)
        {
            AddError(error);
        }

        protected ResultBase(IEnumerable<DomainError> errors)
        {
            AddErrors(errors);
        }

        public void AddError(DomainError error)
        {
            if (error == null) throw new ArgumentException("DomainError cannot be null");
            _errors.Add(error);
        }

        public void AddErrors(IEnumerable<DomainError> errors)
        {
            if (errors == null) throw new ArgumentException("DomainErrors cannot be null");
            _errors.AddRange(errors);
        }

        public Task PublishNotifications(IMediator mediator) =>
            _notifications != null
                ? Task.WhenAll(_notifications.Select(notification => mediator.Publish(notification)))
                : Task.FromResult<Task>(null);
    }
}
