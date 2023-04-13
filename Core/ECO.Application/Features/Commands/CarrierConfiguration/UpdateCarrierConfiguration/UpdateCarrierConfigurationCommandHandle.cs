using AutoMapper;
using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;
        private readonly IMapper _mapper;

        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService, IMapper mapper)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _mapper = mapper;
        }

        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            ECO.Domain.Entities.CarrierConfiguration carrierConfiguration = _mapper.Map<ECO.Domain.Entities.CarrierConfiguration>(request.CarrierConfiguration);
            var result = await _carrierConfigurationService.UpdateCarrierConfiguration(carrierConfiguration);
            return new UpdateCarrierConfigurationCommandResponse { Success = result.Success, Message = result.Message };
        }
    }
}
