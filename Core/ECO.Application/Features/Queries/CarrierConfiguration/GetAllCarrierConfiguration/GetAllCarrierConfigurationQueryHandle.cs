using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationsQueryHandler : IRequestHandler<GetAllCarrierConfigurationQueryRequest, GetAllCarrierConfigurationQueryResponse>
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public GetAllCarrierConfigurationsQueryHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<GetAllCarrierConfigurationQueryResponse> Handle(GetAllCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _carrierConfigurationService.GetAllCarrierConfiguration();
            return new GetAllCarrierConfigurationQueryResponse
            {
                Success = result.Success,
                Message = result.Message,
                CarrierConfigurations = result.Data
            };
        }
    }
}
