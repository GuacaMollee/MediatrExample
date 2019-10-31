namespace Example.Ordering.Api.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Ordering.Api.Repositories;
    using Example.Ordering.Domain.Orders;
    using Example.Ordering.Domain.Orders.Queries;
    using MediatR;

    public class GetOrderHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var result = orderRepository.Get(request.Id);
            return Task.FromResult(result);
        }
    }
}
