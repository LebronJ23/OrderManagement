using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.Orders.Commands.Create;
using System;

namespace OrderManagement.Models.Orders
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public int ProviderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(orderCommand => orderCommand.Number, opt => opt.MapFrom(orderDto => orderDto.Number))
                .ForMember(orderCommand => orderCommand.CreationDate, opt => opt.MapFrom(orderDto => orderDto.CreationDate))
                .ForMember(orderCommand => orderCommand.ProviderId, opt => opt.MapFrom(orderDto => orderDto.ProviderId));
        }
    }
}
