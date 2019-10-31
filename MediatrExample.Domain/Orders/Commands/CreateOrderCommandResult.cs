namespace Example.Ordering.Domain.Orders.Commands
{
    using Example.Ordering.Domain.Orders.Notifications;
    using Example.Ordering.Domain.SeedWorks;
    using Example.Ordering.Domain.SeedWorks.Cqrs;

    public class CreateOrderCommandResult :  CommandResult<bool>
    {
        public CreateOrderCommandResult(string name)
            : base(true, Notifications.CreateFrom(new OrderCreatedNotification { Name = name }))
        {
        }

        public CreateOrderCommandResult(DomainError error)
            : base(error)
        {
        }
    }
}
