using Assignement.Customers;
using Assignement.Orders;
using AutoMapper;

namespace Assignement;

public class AssignementApplicationAutoMapperProfile : Profile
{
    public AssignementApplicationAutoMapperProfile()
    {
        //Customer Mapper
        CreateMap<Customer, CustomerReadDto>();
        //Order Mapper
        CreateMap<Order, OrderReadDto>();
        CreateMap<OrderWithNavigationProperties, OrderWithNavigationPropertiesDto>();
    }
}
