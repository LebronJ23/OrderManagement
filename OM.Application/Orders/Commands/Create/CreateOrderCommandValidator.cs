using FluentValidation;

namespace OM.Application.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(createOrderCommand => createOrderCommand.Number).NotEmpty().MinimumLength(2).MaximumLength(250);
            RuleFor(createOrderCommand => createOrderCommand.CreationDate).NotEmpty();
            RuleFor(createOrderCommand => createOrderCommand.ProviderId).GreaterThan(0);
        }
    }
}
