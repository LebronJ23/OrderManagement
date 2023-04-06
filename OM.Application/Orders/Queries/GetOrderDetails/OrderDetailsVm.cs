using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Providers.Queries;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ProviderId { get; set; }
        public ProviderVm Provider { get; set; }
        public IEnumerable<OrderItemTableVm> OrderItems { get; set; } = Enumerable.Empty<OrderItemTableVm>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>();
                //.ForMember(orderVm => orderVm.Id, opt => opt.MapFrom(order => order.Id))
                //.ForMember(orderVm => orderVm.Number, opt => opt.MapFrom(order => order.Number))
                //.ForMember(orderVm => orderVm.Date, opt => opt.MapFrom(order => order.Date))
                //.ForMember(orderVm => orderVm.ProviderId, opt => opt.MapFrom(order => order.ProviderId))
                //.ForMember(orderVm => orderVm.Provider, opt => opt.MapFrom(order => order.Provider))
                //.ForMember(orderVm => orderVm.OrderItems, opt => opt.MapFrom(order => order.OrderItems));
        }
    }
}




//public class EntityA
//{
//    public string Name { get; set; }
//}

//public class ViewModelEntityA : IMapWith<EntityA>
//{
//    public string Name { get; set; }

//    public void Map(Profile profile)
//    {
//        profile.CreateMap<EntityA, ViewModelEntityA>()
//                .ForMember(eaVm => eaVm.Name, opt => opt.MapFrom(ea => ea.Name));
//    }
//}

//public class EntityB
//{
//    public string Name { get; set; }
//    public IEnumerable<EntityA> EntityAs { get; set; }
//}

//public class ViewModelEntityB : IMapWith<EntityB>
//{
//    public string Name { get; set; }
//    public IEnumerable<EntityA> EntityAs { get; set; }

//    public void Map(Profile profile)
//    {
//        profile.CreateMap<EntityB, ViewModelEntityB>()
//                .ForMember(ebVm => ebVm.Name, opt => opt.MapFrom(eb => eb.Name))
//                .ForMember(ebVm => ebVm.EntityAs, opt => opt.MapFrom(eb => eb.EntityAs));
//    }
//}


//public class EntityC
//{
//    public string Name { get; set; }
//    public EntityA EntityA { get; set; }
//}

//public class ViewModelEntityC : IMapWith<EntityC>
//{
//    public string Name { get; set; }
//    public ViewModelEntityA EntityA { get; set; }

//    public void Map(Profile profile)
//    {
//        profile.CreateMap<EntityC, ViewModelEntityC>()
//                .ForMember(ebVm => ebVm.Name, opt => opt.MapFrom(eb => eb.Name))
//                .ForMember(ebVm => ebVm.EntityA, opt => opt.MapFrom(eb => eb.EntityA));
//    }
//}

//public class EntityD
//{
//    public string Name { get; set; }
//    public IQueryable<EntityA> EntitiesA { get; set; }
//}

//public class ViewModelEntityD : IMapWith<EntityD>
//{
//    public string Name { get; set; }
//    public IQueryable<ViewModelEntityA> EntitiesA { get; set; }

//    public void Map(Profile profile)
//    {
//        profile.CreateMap<EntityD, ViewModelEntityD>()
//                .ForMember(ebVm => ebVm.Name, opt => opt.MapFrom(eb => eb.Name))
//                .ForMember(ebVm => ebVm.EntitiesA, opt => opt.MapFrom(eb => eb.EntitiesA));
//    }
//}