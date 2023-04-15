using ECO.Application.Dto.Order;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandResponse : CommandBaseResponse
    {
        public Order Order { get; set; }
        public IResult Result { get; set; }
    }
}
