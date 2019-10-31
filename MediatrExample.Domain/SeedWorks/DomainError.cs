namespace Example.Ordering.Domain.SeedWorks
{
    public abstract class DomainError
    {
        public DomainErrors Error { get; }
        public string Key { get; }
        public string Message { get; }

        protected DomainError(DomainErrors error, string key, string message)
        {
            Error = error;
            Key = key;
            Message = message;
        }
    }
}
