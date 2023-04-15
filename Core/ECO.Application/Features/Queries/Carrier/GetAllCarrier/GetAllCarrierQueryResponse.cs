using ECO.Application.Dto.Carrier;
using ECO.Application.Features.Commands;
using ECO.Application.Utilities.Result.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryResponse : IDataResult<List<GetCarrierDto>>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<GetCarrierDto> Data { get; set; }
    }
}
