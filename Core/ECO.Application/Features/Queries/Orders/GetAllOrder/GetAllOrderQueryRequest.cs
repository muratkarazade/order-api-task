using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Orders.GetAllOrder
{
    public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryResponse>
    {

    }
}