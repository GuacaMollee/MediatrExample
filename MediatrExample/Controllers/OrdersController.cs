namespace Example.Ordering.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Example.Ordering.Domain.Orders;
    using Example.Ordering.Domain.Orders.Commands;
    using Example.Ordering.Domain.Orders.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class OrdersController : BaseController
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<Order>> Get() =>
            await mediator.Send(new GetAllOrdersQuery());

        [HttpGet("{id}")]
        public async Task<Order> Get(Guid id) =>
            await mediator.Send(new GetOrderQuery(id));

        [HttpPost("create")]
        public async Task<ActionResult<CreateOrderCommandResult>> Post([FromBody] CreateOrderCommand quote) =>
            await Mediator.Send(quote);
    }
}