namespace Example.Ordering.Api.Handlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Ordering.Api.Repositories;
    using Example.Ordering.Domain.Orders;
    using Example.Ordering.Domain.Orders.Queries;
    using MediatR;

    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = orderRepository.Get();
            return Task.FromResult(result);
        }
    }
}
