namespace Example.Ordering.Domain.SeedWorks
{
    using System.Threading.Tasks;
    using MediatR;

    public interface INotificationsPublisher
    {
        Task PublishNotifications(IMediator mediator);
    }
}
