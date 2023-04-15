using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.DeleteCarrier
{
    public class DeleteCarrierCommandRequest : IRequest<DeleteCarrierCommandResponse>
    {
        public int Id { get; set; }
        public DeleteCarrierCommandRequest()
        {
            
        }
        public DeleteCarrierCommandRequest(int id)
        {
            Id = id;
        }
    }
}
