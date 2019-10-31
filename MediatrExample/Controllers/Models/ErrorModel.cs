namespace Example.Ordering.Api.Controllers.Models
{
    using Example.Ordering.Domain.SeedWorks;
    using System.Collections.Generic;

    public class ErrorModel
    {
        public IEnumerable<DomainError> Errors { get; }

        private ErrorModel(IEnumerable<DomainError> errors) => Errors = errors;

        public static ErrorModel Create(IEnumerable<DomainError> errors) => new ErrorModel(errors);
    }
}
