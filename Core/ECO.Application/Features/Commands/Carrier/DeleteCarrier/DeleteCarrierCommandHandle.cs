using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.DeleteCarrier
{
    public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommandRequest, DeleteCarrierCommandResponse>
    {
        private readonly ICarrierService _carrierService;

        public DeleteCarrierCommandHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<DeleteCarrierCommandResponse> Handle(DeleteCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _carrierService.DeleteCarrier(request.Id);
            return new DeleteCarrierCommandResponse { Success = result.Success, Message = result.Message };
        }
    }
}
