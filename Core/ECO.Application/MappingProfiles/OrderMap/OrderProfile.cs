using AutoMapper;
using ECO.Application.Dto.Order;
using ECO.Application.Features.Commands.Orders.CreateOrder;
using ECO.Application.Features.Commands.Orders.DeleteOrder;
using ECO.Application.Features.Commands.Orders.UpdateOrder;
using ECO.Application.Features.Queries.Orders.GetAllOrder;
using ECO.Application.Features.Queries.Orders.GetByIdOrder;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.MappingProfiles.OrderMap
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderCommandRequest, Order>().ReverseMap();
            CreateMap<IResult, CreateOrderCommandResponse>().ReverseMap();

            CreateMap<DeleteOrderCommandRequest, Order>().ReverseMap();
            CreateMap<IResult, DeleteOrderCommandResponse>().ReverseMap();

            CreateMap<UpdateOrderCommandRequest, Order>().ReverseMap();
            CreateMap<IResult, UpdateOrderCommandResponse>().ReverseMap();

            CreateMap<GetAllOrderQueryRequest, Order>().ReverseMap();
            CreateMap<IDataResult<List<Order>>, GetAllOrderQueryResponse>().ReverseMap();

            CreateMap<GetOrderByIdQueryRequest, Order>().ReverseMap();
            CreateMap<Order, GetOrderByIdQueryResponse>().ReverseMap();

            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();    
        }
    }
}
