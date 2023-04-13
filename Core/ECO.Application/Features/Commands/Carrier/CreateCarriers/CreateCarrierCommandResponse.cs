using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.CreateCarriers
{
    public class CreateCarrierCommandResponse : CommandBaseResponse
    {
        public ECO.Domain.Entities.Carrier Carrier { get; set; }
        public IResult Data { get; set; }
    }
}
