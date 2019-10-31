namespace Example.Ordering.Domain.Orders.Queries
{
    using Example.Ordering.Domain.Orders;
    using MediatR;
    using System.Collections.Generic;

    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public GetAllOrdersQuery()
        {
        }

    }
}