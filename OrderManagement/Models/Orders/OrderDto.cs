using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.Orders.Commands.Create;
using OM.Application.Orders.Commands.Delete;
using OM.Application.Orders.Commands.Update;
using System;

namespace OrderManagement.Models.Orders
{
    public class OrderDto : IMapWith<CreateOrderCommand>, IMapWith<UpdateOrderCommand>, IMapWith<DeleteOrderCommand>
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderCommand, OrderDto>();
            profile.CreateMap<UpdateOrderCommand, OrderDto>();
            profile.CreateMap<DeleteOrderCommand, OrderDto>();
        }
    }
}
