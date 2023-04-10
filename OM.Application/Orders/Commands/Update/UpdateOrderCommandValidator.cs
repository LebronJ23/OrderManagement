using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Commands.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() 
        {
            RuleFor(createOrderCommand => createOrderCommand.Id).GreaterThan(0);
            RuleFor(createOrderCommand => createOrderCommand.Number).NotEqual(string.Empty).MaximumLength(250);
            RuleFor(createOrderCommand => createOrderCommand.CreationDate).NotEmpty();
            RuleFor(createOrderCommand => createOrderCommand.ProviderId).GreaterThan(0);
        }
    }
}
