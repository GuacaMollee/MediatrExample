namespace Example.Ordering.Domain.Orders.Commands
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
    {
        public string Name { get; set; }
    }
}
