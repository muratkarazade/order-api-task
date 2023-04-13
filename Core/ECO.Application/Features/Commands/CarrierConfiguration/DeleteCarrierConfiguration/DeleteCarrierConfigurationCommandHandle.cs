using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.DeleteCarrierConfiguration
{
    public class DeleteCarrierConfigurationCommandHandler : IRequestHandler<DeleteCarrierConfigurationCommandRequest, DeleteCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public DeleteCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<DeleteCarrierConfigurationCommandResponse> Handle(DeleteCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _carrierConfigurationService.DeleteCarrierConfiguration(request.Id);
            return new DeleteCarrierConfigurationCommandResponse { Success = result.Success, Message = result.Message };
        }
    }
}
