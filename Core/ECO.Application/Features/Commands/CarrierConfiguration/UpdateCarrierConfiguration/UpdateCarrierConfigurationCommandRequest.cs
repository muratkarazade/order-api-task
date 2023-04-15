using ECO.Application.Dto.CarrierConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandRequest : IRequest<UpdateCarrierConfigurationCommandResponse>
    {
        public UpdateCarrierConfigurationDto CarrierConfiguration { get; set; }

        public UpdateCarrierConfigurationCommandRequest(int id,UpdateCarrierConfigurationDto carrierConfiguration)
        {
            CarrierConfiguration = carrierConfiguration;
        }
    }
}
