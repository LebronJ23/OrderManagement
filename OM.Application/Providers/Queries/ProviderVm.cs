using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Domain;

namespace OM.Application.Providers.Queries
{
    public class ProviderVm : IMapWith<Provider>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Provider, ProviderVm>()
                .ForMember(provider => provider.Id, opt => opt.MapFrom(providerVm => providerVm.Id))
                .ForMember(provider => provider.Name, opt => opt.MapFrom(providerVm => providerVm.Name));
        }
    }
}
