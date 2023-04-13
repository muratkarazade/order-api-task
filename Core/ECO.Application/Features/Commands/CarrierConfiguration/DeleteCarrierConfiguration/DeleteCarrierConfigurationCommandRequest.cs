using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.CarrierConfiguration.DeleteCarrierConfiguration
{
    public class DeleteCarrierConfigurationCommandRequest : IRequest<DeleteCarrierConfigurationCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCarrierConfigurationCommandRequest(int id)
        {
            Id = id;
        }
    }
}
