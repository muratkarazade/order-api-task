using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Carrier.GetCarrierById
{
    public class GetCarrierByIdQueryRequest : IRequest<GetCarrierByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
