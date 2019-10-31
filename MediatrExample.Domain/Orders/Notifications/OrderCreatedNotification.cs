namespace Example.Ordering.Domain.Orders.Notifications
{
    using MediatR;

    public class OrderCreatedNotification : INotification
    {
        public string Name { get; set; }
    }
}
