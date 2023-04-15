using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.CarrierConfiguration.GetCarrierConfigurationById
{
    public class GetCarrierConfigurationByIdQueryHandler : IRequestHandler<GetCarrierConfigurationByIdQueryRequest, GetCarrierConfigurationByIdQueryResponse>
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public GetCarrierConfigurationByIdQueryHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<GetCarrierConfigurationByIdQueryResponse> Handle(GetCarrierConfigurationByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var carrierConfiguration = await _carrierConfigurationService.GetCarrierConfigurationById(request.Id);
            if (carrierConfiguration == null)
            {
                return new GetCarrierConfigurationByIdQueryResponse { Success = false, Message = "Taşıyıcı yapılandırması bulunamadı." };
            }

            return new GetCarrierConfigurationByIdQueryResponse { Success = true, Message = "Taşıyıcı yapılandırması başarıyla alındı.", CarrierConfiguration = carrierConfiguration };
        }

    }
}