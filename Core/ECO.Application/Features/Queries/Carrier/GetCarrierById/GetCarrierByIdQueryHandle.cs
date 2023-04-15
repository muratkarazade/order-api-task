using ECO.Application.Abstractions.Services;
using ECO.Application.Dto.Carrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Carrier.GetCarrierById
{
    public class GetCarrierByIdQueryHandler : IRequestHandler<GetCarrierByIdQueryRequest, GetCarrierByIdQueryResponse>
    {
        private readonly ICarrierService _carrierService;

        public GetCarrierByIdQueryHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<GetCarrierByIdQueryResponse> Handle(GetCarrierByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var carrier = await _carrierService.GetCarrierById(request.Id);

            if (carrier == null)
            {
                return new GetCarrierByIdQueryResponse { Success = false, Message = "Taşıyıcı bulunamadı." };
            }

            var carrierDto = new GetCarrierDto
            {
                Name = carrier.Name,
                IsActive = carrier.IsActive,
                PlusDesiCost = carrier.PlusDesiCost
            };

            return new GetCarrierByIdQueryResponse { Success = true, Message = "Taşıyıcı başarıyla alındı.", Data = carrierDto };
        }

    }
}