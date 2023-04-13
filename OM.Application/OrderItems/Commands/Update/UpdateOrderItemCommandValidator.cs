using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Commands.Update
{
    public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemCommandValidator()
        {
            RuleFor(createOrderItemCommand => createOrderItemCommand.Id).GreaterThan(0);
            RuleFor(createOrderItemCommand => createOrderItemCommand.Name).NotEmpty().MinimumLength(2).MaximumLength(250);
            RuleFor(createOrderItemCommand => createOrderItemCommand.Unit).NotEmpty();
            RuleFor(createOrderItemCommand => createOrderItemCommand.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
