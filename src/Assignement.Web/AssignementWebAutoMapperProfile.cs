using Assignement.Customers;
using Assignement.Orders;
using AutoMapper;

namespace Assignement.Web;

public class AssignementWebAutoMapperProfile : Profile
{
    public AssignementWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CustomerReadDto, CustomerUpdateDto>();
        CreateMap<OrderReadDto, OrderUpdateDto>();
    }
}
