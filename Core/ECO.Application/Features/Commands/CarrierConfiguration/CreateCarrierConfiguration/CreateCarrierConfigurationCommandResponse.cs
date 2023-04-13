using ECO.Application.Utilities.Result.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandResponse : CommandBaseResponse
    {
        public Domain.Entities.CarrierConfiguration CarrierConfiguration { get; set; }
        public IResult Data { get; set; }
    }
}
