namespace Example.Ordering.Api.CommandHandlers
{
    using Example.Ordering.Domain.Orders.Commands;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        public Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Execute / handle command
            return Task.FromResult(new CreateOrderCommandResult("Jan"));
        }
    }
}
