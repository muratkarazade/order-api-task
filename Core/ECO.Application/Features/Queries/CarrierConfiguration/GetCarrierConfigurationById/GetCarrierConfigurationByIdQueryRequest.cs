using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.CarrierConfiguration.GetCarrierConfigurationById
{
    public class GetCarrierConfigurationByIdQueryRequest : IRequest<GetCarrierConfigurationByIdQueryResponse>
    {
        public int Id { get; }

        public GetCarrierConfigurationByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
