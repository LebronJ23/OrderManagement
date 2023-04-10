using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.OrderItems.Commands.Create;
using OM.Application.OrderItems.Commands.Delete;
using OM.Application.OrderItems.Commands.Update;
using OM.Application.Orders.Commands.Update;
using OM.Application.Orders.Queries.GetOrdersList;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OM.Application.OrderItems.Queries.GetOrderItemsListForOrder
{
    public class OrderItemTableVm : //IValidatableObject,
        IMapWith<OrderItem>, 
        IMapWith<CreateOrderItemCommand>, 
        IMapWith<UpdateOrderItemCommand>,
        IMapWith<DeleteOrderItemCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int OrderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemTableVm>()
                .ForMember(orderIVm => orderIVm.Id, opt => opt.MapFrom(orderItem => orderItem.Id))
                .ForMember(orderIVm => orderIVm.Name, opt => opt.MapFrom(orderItem => orderItem.Name))
                .ForMember(orderIVm => orderIVm.Quantity, opt => opt.MapFrom(orderItem => orderItem.Quantity))
                .ForMember(orderIVm => orderIVm.Unit, opt => opt.MapFrom(orderItem => orderItem.Unit))
                .ForMember(orderIVm => orderIVm.OrderId, opt => opt.MapFrom(orderItem => orderItem.OrderId));

            profile.CreateMap<OrderItemTableVm, CreateOrderItemCommand>();
            profile.CreateMap<OrderItemTableVm, UpdateOrderItemCommand>();
            profile.CreateMap<OrderItemTableVm, DeleteOrderItemCommand>();
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
            
        //}
    }
}
