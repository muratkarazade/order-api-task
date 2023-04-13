using AutoMapper;
using ECO.Application.Dto.Carrier;
using ECO.Application.Features.Commands.Carrier.CreateCarriers;
using ECO.Application.Features.Commands.Carrier.DeleteCarrier;
using ECO.Application.Features.Commands.Carrier.UpdateCarrier;
using ECO.Application.Features.Queries.Carrier.GetAllCarrier;
using ECO.Application.Features.Queries.Carrier.GetCarrierById;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.MappingProfiles.CarrierMap
{
    internal class CarrierProfile : Profile
    {
        public CarrierProfile()
        {
            CreateMap<CreateCarrierCommandRequest, Carrier>().ReverseMap();
            CreateMap<IResult, CreateCarrierCommandResponse>().ReverseMap();

            CreateMap<DeleteCarrierCommandRequest, Carrier>().ReverseMap();
            CreateMap<IResult, DeleteCarrierCommandResponse>().ReverseMap();

            CreateMap<UpdateCarrierCommandRequest, Carrier>().ReverseMap();
            CreateMap<IResult, UpdateCarrierCommandResponse>().ReverseMap();

            CreateMap<GetAllCarrierQueryRequest, Carrier>().ReverseMap();
            CreateMap<IDataResult<List<Carrier>>, GetAllCarrierQueryResponse>().ReverseMap();

            CreateMap<GetCarrierByIdQueryRequest, Carrier>().ReverseMap();
            CreateMap<Carrier, GetCarrierByIdQueryResponse>().ReverseMap();

            CreateMap<CreateCarrierDto, Carrier>().ReverseMap();
            CreateMap<UpdateCarrierDto, Carrier>().ReverseMap();
        }
    }
}
