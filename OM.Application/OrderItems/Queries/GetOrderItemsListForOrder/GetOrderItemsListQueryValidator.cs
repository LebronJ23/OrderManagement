using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Queries.GetOrderItemsListForOrder
{
    public class GetOrderItemsListQueryValidator : AbstractValidator<GetOrderItemsListQuery>
    {
        public GetOrderItemsListQueryValidator() 
        {
            RuleFor(orderitemsListQuery => orderitemsListQuery.OrderId).GreaterThan(0);
        }
    }
}
