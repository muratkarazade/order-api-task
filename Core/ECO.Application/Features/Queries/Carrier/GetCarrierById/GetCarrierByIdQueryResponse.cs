using ECO.Application.Dto.Carrier;
using ECO.Application.Features.Commands;
using ECO.Application.Utilities.Result.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Carrier.GetCarrierById
{
    public class GetCarrierByIdQueryResponse : IDataResult<GetCarrierDto>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public GetCarrierDto Data { get; set; }
    }
}
