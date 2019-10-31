using System;
namespace Example.Ordering.Domain.SeedWorks
{
    using System.Collections.Generic;

    public interface IFailable
    {
        IEnumerable<DomainError> Errors { get; }

        void AddError(DomainError error);

        void AddErrors(IEnumerable<DomainError> errors);
    }
}
