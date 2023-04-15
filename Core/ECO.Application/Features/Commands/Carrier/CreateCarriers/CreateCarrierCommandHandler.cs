using AutoMapper;
using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Carrier.CreateCarriers
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public CreateCarrierCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            var carrier = _mapper.Map<ECO.Domain.Entities.Carrier>(request.Carrier);
            var result = await _carrierService.CreateCarrier(carrier);
            if (!result.Success)
            {
                return new CreateCarrierCommandResponse { Success = false, Message = result.Message };
            }

            return new CreateCarrierCommandResponse { Success = true, Message = result.Message, Data = carrier };
        }
    }
}
