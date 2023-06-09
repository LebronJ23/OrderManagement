﻿using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Commands.Create;
using OM.Application.Orders.Commands.Delete;
using OM.Application.Orders.Commands.Update;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Providers.Queries;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>, IMapWith<CreateOrderCommand>, IMapWith<UpdateOrderCommand>, IMapWith<DeleteOrderCommand>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Truncate(TimeSpan.FromMinutes(1));
        public int ProviderId { get; set; }
        public ProviderVm Provider { get; set; }
        public IEnumerable<OrderItemTableVm> OrderItems { get; set; } = Enumerable.Empty<OrderItemTableVm>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>();
            profile.CreateMap<OrderDetailsVm, CreateOrderCommand>()
                .ForMember(orderVm => orderVm.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(orderVm => orderVm.CreationDate, opt => opt.MapFrom(order => order.Date))
                .ForMember(orderVm => orderVm.ProviderId, opt => opt.MapFrom(order => order.ProviderId));
            profile.CreateMap<OrderDetailsVm, UpdateOrderCommand>()
                .ForMember(orderVm => orderVm.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(orderVm => orderVm.CreationDate, opt => opt.MapFrom(order => order.Date))
                .ForMember(orderVm => orderVm.ProviderId, opt => opt.MapFrom(order => order.ProviderId));
            profile.CreateMap<OrderDetailsVm, DeleteOrderCommand>()
                .ForMember(orderVm => orderVm.Id, opt => opt.MapFrom(order => order.Id));

            profile.CreateMap<CreateOrderCommand, OrderDetailsVm>();
        }
    }
}
