using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Orders.GetByIdOrder
{
    public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetOrderByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
