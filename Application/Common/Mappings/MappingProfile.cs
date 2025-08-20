using N_To_N_With_AutoMapper.DTOs;
using N_To_N_With_AutoMapper.Entities;
using AutoMapper;

namespace N_To_N_With_AutoMapper.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, AccountDTO>()
            .ForMember(dest => dest.Addresses,
                       opt => opt.MapFrom(src => src.AccountAddresses.Select(aa => aa.Address)));

        CreateMap<Address, AddressDTO>();
    }
}