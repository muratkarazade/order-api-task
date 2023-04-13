using ECO.Application.Dto.CarrierConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandRequest : IRequest<CreateCarrierConfigurationCommandResponse>
    {
        public CreateCarrierConfigurationDto CarrierConfiguration { get; set; }

        public CreateCarrierConfigurationCommandRequest(CreateCarrierConfigurationDto carrierConfiguration)
        {
            CarrierConfiguration = carrierConfiguration;
        }
    }
}
