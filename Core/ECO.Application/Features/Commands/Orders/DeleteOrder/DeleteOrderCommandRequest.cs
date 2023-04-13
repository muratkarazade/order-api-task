using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Orders.DeleteOrder
{
    public class DeleteOrderCommandRequest : IRequest<CommandBaseResponse>
    {
        public int Id { get; set; }

        public DeleteOrderCommandRequest(int id)
        {
            Id = id;
        }
    }
}
