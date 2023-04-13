using AutoMapper;
using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;
        private readonly IMapper _mapper;

        public CreateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService, IMapper mapper)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _mapper = mapper;
        }

        public async Task<CreateCarrierConfigurationCommandResponse> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CarrierConfiguration carrierConfiguration = _mapper.Map<Domain.Entities.CarrierConfiguration>(request.CarrierConfiguration);
            var result = await _carrierConfigurationService.CreateCarrierConfiguration(carrierConfiguration);
            if (!result.Success)
            {
                return new CreateCarrierConfigurationCommandResponse { Success = false, Message = result.Message };
            }

            return new CreateCarrierConfigurationCommandResponse { Success = true, Message = result.Message, Data = result };
        }
    }
}
