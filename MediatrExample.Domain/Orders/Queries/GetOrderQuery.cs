namespace Example.Ordering.Domain.Orders.Queries
{
    using Example.Ordering.Domain.Orders;
    using MediatR;
    using System;

    public class GetOrderQuery : IRequest<Order>
    {
        public GetOrderQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}