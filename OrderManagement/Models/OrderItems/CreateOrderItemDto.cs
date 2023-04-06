using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.OrderItems.Commands.Create;
using OM.Application.Orders.Commands.Create;

namespace OrderManagement.Models.OrderItems
{
    public class CreateOrderItemDto : IMapWith<CreateOrderItemCommand>
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int OrderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderItemDto, CreateOrderItemCommand>()
               .ForMember(oICommand => oICommand.Name, opt => opt.MapFrom(orderIDto => orderIDto.Name))
               .ForMember(oICommand => oICommand.Quantity, opt => opt.MapFrom(orderIDto => orderIDto.Quantity))
               .ForMember(oICommand => oICommand.Unit, opt => opt.MapFrom(orderIDto => orderIDto.Unit))
               .ForMember(oICommand => oICommand.OrderId, opt => opt.MapFrom(orderIDto => orderIDto.OrderId));

        }


    }
}
