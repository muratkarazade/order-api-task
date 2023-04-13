using AutoMapper;
using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, CommandBaseResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public UpdateCarrierCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }

        public async Task<CommandBaseResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            var carrier = _mapper.Map<Domain.Entities.Carrier>(request.Carrier);
            var result = await _carrierService.UpdateCarrier(carrier);
            return new CommandBaseResponse { Success = result.Success, Message = result.Message };
        }
    }
}
