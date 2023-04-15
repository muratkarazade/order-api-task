using ECO.Application.Abstractions.Services;
using ECO.Application.Dto.Carrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryHandler : IRequestHandler<GetAllCarrierQueryRequest, GetAllCarrierQueryResponse>
    {
        private readonly ICarrierService _carrierService;

        public GetAllCarrierQueryHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<GetAllCarrierQueryResponse> Handle(GetAllCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            var carriersResult = await _carrierService.GetAllCarrier();
            var carrierDtos = carriersResult.Data
                .Select(c => new GetCarrierDto
                {
                    Name = c.Name,
                    IsActive = c.IsActive,
                    PlusDesiCost = c.PlusDesiCost
                }).ToList();

            return new GetAllCarrierQueryResponse { Success = carriersResult.Success, Message = carriersResult.Message, Data = carrierDtos };
        }

    }
}
