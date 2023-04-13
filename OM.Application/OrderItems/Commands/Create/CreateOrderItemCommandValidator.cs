using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Commands.Create
{
    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator() 
        {
            RuleFor(createOrderItemCommand => createOrderItemCommand.OrderId).GreaterThan(0);
            RuleFor(createOrderItemCommand => createOrderItemCommand.Name).NotEmpty().MinimumLength(2).MaximumLength(250);
            RuleFor(createOrderItemCommand => createOrderItemCommand.Unit).NotEmpty();
            RuleFor(createOrderItemCommand => createOrderItemCommand.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
