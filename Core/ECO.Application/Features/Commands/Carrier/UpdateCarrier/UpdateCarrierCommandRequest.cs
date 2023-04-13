using ECO.Application.Dto.Carrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandRequest : IRequest<CommandBaseResponse>
    {
        public UpdateCarrierDto Carrier { get; set; }

        public UpdateCarrierCommandRequest(UpdateCarrierDto carrier)
        {
            Carrier = carrier;
        }
    }
}
