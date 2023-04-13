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
            RuleFor(updateOrderCommand => updateOrderCommand.Id).GreaterThan(0);
            RuleFor(updateOrderCommand => updateOrderCommand.Number).NotEmpty().MinimumLength(2).MaximumLength(250);
            RuleFor(updateOrderCommand => updateOrderCommand.CreationDate).NotEmpty();
            RuleFor(updateOrderCommand => updateOrderCommand.ProviderId).GreaterThan(0);
        }
    }
}
