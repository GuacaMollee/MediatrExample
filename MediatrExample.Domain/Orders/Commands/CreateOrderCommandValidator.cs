namespace Example.Ordering.Domain.Orders.Commands
{
    using FluentValidation;

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Name).NotNull();
            RuleFor(command => command.Name).Must(a => {
                System.Console.WriteLine("Test");
                return a == "henk";
            });
        }
    }
}
