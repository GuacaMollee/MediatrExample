namespace Example.Ordering.Domain.SeedWorks
{
    public class ValidationError : DomainError
    {
        private ValidationError(string key, string message) : base(DomainErrors.Validation, key, message) { }

        public static ValidationError Create(string key, string message) =>
            new ValidationError(key, message);
    }
}
