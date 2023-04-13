using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Commands.Delete
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator() 
        {
            RuleFor(deleteOrderCommand => deleteOrderCommand.Id).GreaterThan(0);
        }
    }
}
