using ECO.Application.Dto.Carrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.CreateCarriers
{
    public class CreateCarrierCommandRequest : IRequest<CreateCarrierCommandResponse>
    {
        public CreateCarrierDto Carrier { get; set; }

        public CreateCarrierCommandRequest(CreateCarrierDto carrier)
        {
            Carrier = carrier;
        }
    }
}
