using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Commands.Delete
{
    public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
    {
        public DeleteOrderItemCommandValidator()
        {
            RuleFor(deleteOrderItemCommand => deleteOrderItemCommand.Id).GreaterThan(0);
        }
    }
}
