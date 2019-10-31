namespace Example.Ordering.Api.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using Domain.SeedWorks.Cqrs;
    using Example.Ordering.Domain.SeedWorks;
    using Example.Ordering.Api.Controllers.Models;

    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        // Some errors should make it to the user of this API
        private readonly Func<DomainError, bool> _errorShouldBeReturned = e =>
            !(e is null);


        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        protected ActionResult Result<TResponse>(ResultBase<TResponse> result)
        {
            if (result == null) throw new ArgumentException("ResultBase<TResponse> cannot be null");

            switch (result)
            {
                case QueryResult<TResponse> r when r.Result != null:
                    return Ok(result.Result);
                case var r when r.Errors.Any(_errorShouldBeReturned):
                    return BadRequest(ErrorModel.Create(result.Errors));
                case CommandResult<TResponse> r when r.Result != null:
                    return Ok(result.Result);
                case QueryResult<TResponse> _:
                    return NotFound();
                default:
                    return NoContent();
            }
        }

        protected ActionResult Result<TResponse>(ResultBase<TResponse> result, Func<TResponse, ActionResult> customResponse)
        {
            if (result == null) throw new ArgumentException("ResultBase<TResponse> cannot be null");

            switch (result)
            {
                case var r when r.Errors.Any():
                    return BadRequest(ErrorModel.Create(result.Errors));
                default:
                    return customResponse(result.Result);
            }
        }
    }
}
