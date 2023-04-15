using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Domain.Entities.CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
